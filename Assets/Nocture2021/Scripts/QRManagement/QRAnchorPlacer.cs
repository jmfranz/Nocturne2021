using System.Collections;
using System.Collections.Generic;
using System.Timers;
using ExitGames.Client.Photon;
using Newtonsoft.Json.Bson;
using Photon.Pun;
using Photon.Realtime;
using QRTracking;
using UnityEngine;

public class QRAnchorPlacer : MonoBehaviour
{

    private const int WhatIsAnchorEvent = 01;
    private const int AnchorTagReply = 02;
    private const int AnchorTagTimeoutInSeconds = 10; //change to 10 in deploy
    
    private bool _hasReceivedAnchorReply = false;
    private float _timeSinceStart = 0;

    public QRCodesManager QrCodeManagerGameObject;
    public GameObject InstructionsPrefab;

    // Start is called before the first frame update
    void Start()
    {
        //Raise what is the Anchor tag event
        if (PhotonNetwork.IsConnectedAndReady)
        {
            PhotonNetwork.RaiseEvent(WhatIsAnchorEvent, null, RaiseEventOptions.Default, SendOptions.SendReliable);
        }

        //TODO: DELETE THIS. IS HERE FOR REFERENCE.
        //Start reply timer BUT unity doesn't not support MT... we have to implement our own
        //_anchorTimeoutTimer = new Timer(AnchorTagTimeoutInSeconds * 1000);
        //_anchorTimeoutTimer.Elapsed += NoAnchorTagReplyEvent;
        //_anchorTimeoutTimer.AutoReset = false;
        //_anchorTimeoutTimer.Start();
       
        
    }

    public void FixedUpdate()
    {
        //If we already have a TAG from the network, there is nothing to do here.
        //REFACTORING Option: Move this into an event based (non-MT) code to free the fixed update
        if (_hasReceivedAnchorReply)
        {
            return;
        }
        //Let our "timer" run up waiting for a response
        if (_timeSinceStart < AnchorTagTimeoutInSeconds)
        {
            _timeSinceStart += Time.deltaTime;
            return;
        }
        //Check if we have already added the TapToSetAnchor or not.
        if (gameObject.GetComponent<TapToSetAnchor>() == null)
        {
            NoAnchorTagReplyEvent();
           
        }
           
    }

    private void NoAnchorTagReplyEvent()
    {
        if (QrCodeManagerGameObject == null)
        {
            throw new System.NotImplementedException();
        }
        Debug.Log("Starting QR Tracking");
        //QrCodeManagerGameObject.StartQRTracking();

        //Instantiate the local prefab with instructions to find the QR code
        Instantiate(InstructionsPrefab);
        //Add the anchor placer on click script (hell I need better comments)
        //TODO: Handle placing anchor once target is found and deleting the InstructionsPrefab
        gameObject.AddComponent<TapToSetAnchor>();
        
    }

    public void OnEvent(EventData photonEvent)
    {
        //capture here the code event and stop timer OR start tracking
        if (photonEvent.Code == AnchorTagReply)
        {
            _hasReceivedAnchorReply = true;
            //Set the tag and trigger the anchor recall from the Anchor Store on Azure
            //TODO: comment above
        }
        
    }

    private void OnEnable()
    {
        PhotonNetwork.AddCallbackTarget(this);
    }

    private void OnDisable()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
    }
}
