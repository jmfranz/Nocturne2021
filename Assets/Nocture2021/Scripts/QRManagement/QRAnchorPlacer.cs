using System.Collections;
using System.Collections.Generic;
using System.Timers;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using QRTracking;
using UnityEngine;

public class QRAnchorPlacer : MonoBehaviour
{

    private const int WhatIsAnchorEvent = 01;
    private const int AnchorTagReply = 01;
    private const int AnchorTagTimeoutInSeconds = 1; //change to 30 in deploy

    private Timer _anchorTimeoutTimer;

    public QRCodesManager QrCodeManagerGameObject;

    // Start is called before the first frame update
    void Start()
    {
        //Raise what is the Anchor tag event
        PhotonNetwork.RaiseEvent(WhatIsAnchorEvent, null, RaiseEventOptions.Default, SendOptions.SendReliable);
        //Start 30s reply timer
        _anchorTimeoutTimer = new Timer(AnchorTagTimeoutInSeconds * 1000);
        _anchorTimeoutTimer.Elapsed += NoAnchorTagReplyEvent;
        _anchorTimeoutTimer.AutoReset = false;
        _anchorTimeoutTimer.Start();
        
    }

    private void NoAnchorTagReplyEvent(object sender, ElapsedEventArgs e)
    {
        if (QrCodeManagerGameObject == null)
        {
            throw new System.NotImplementedException();
        }
        Debug.Log("Starting QR Tracking");
        QrCodeManagerGameObject.StartQRTracking();

        //Add the anchor placer on click script (hell I need better comments)
        gameObject.AddComponent<TapToSetAnchor>();
        //TODO: Handle placing anchor once target is found
    }

    public void OnEvent(EventData photonEvent)
    {
        //capture here the code event and stop timer OR start tracking
        if (photonEvent.Code == AnchorTagReply)
        {
            _anchorTimeoutTimer.Stop();
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
