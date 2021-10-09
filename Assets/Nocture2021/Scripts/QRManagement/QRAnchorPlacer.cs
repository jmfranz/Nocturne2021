using System;
using System.Collections.Generic;
using System.IO;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using QRTracking;
using UnityEngine;

public class QRAnchorPlacer : MonoBehaviourPun, IOnEventCallback, IMatchmakingCallbacks
{

    public static byte WhatIsAnchorEvent = 01;
    public static byte AnchorTagReply = 02;

#if UNITY_EDITOR
    //We don't need to wait forever in the editor do we?
    private  float AnchorTagTimeoutInSeconds = 1;
#else
    private  float AnchorTagTimeoutInSeconds = 5;
#endif

    private bool _hasReceivedAnchorReply = false;
    private bool _tapToSetInstantiatedOnce = false;
    private float _timeSinceStart = 0;

    private bool networkReady = false;

    public QRCodesManager QrCodeManagerGameObject;
    public GameObject InstructionsPrefab;
    public GameObject ParentAnchor;


    public  void OnJoinedRoom()
    {
        bool loadedAnchorFromFile = false;
#if !UNITY_EDITOR
        //Connect to the azure cloud
        var anchorModuleScript = ParentAnchor.GetComponent<AnchorModuleScript>();
        if (anchorModuleScript == null)
        {
            throw new System.NotSupportedException("could not find the anchor module script"); 
        }
        anchorModuleScript.StartAzureSession();

        try
        {
            anchorModuleScript.GetAzureAnchorIdFromDisk();
            anchorModuleScript.FindAzureAnchor();
            loadedAnchorFromFile = true;
            var anchorStore = GameObject.Find("AnchorStore").GetComponent<SharedAnchorStore>();
            anchorStore.StoreNewTag(tag);
            _hasReceivedAnchorReply = true;
        }
        catch (FileNotFoundException e)
        {
            Debug.Log("No anchor fond on disk. Moving on to network");
        }
#endif

        

        if (PhotonNetwork.IsConnectedAndReady && !loadedAnchorFromFile)
        {
            PhotonNetwork.RaiseEvent(WhatIsAnchorEvent, null, RaiseEventOptions.Default, SendOptions.SendReliable);
        }
        Debug.Log("Joined Room starting Anchor Placer");
        networkReady = true;

    }



    public void FixedUpdate()
    {
        //Postpone the timer until we are connected to the room
        if (!networkReady)
        {
            AnchorTagTimeoutInSeconds += Time.fixedDeltaTime;
            return;
        }

        //If we already have a TAG from the network, there is nothing to do here.
        if (_hasReceivedAnchorReply || _tapToSetInstantiatedOnce)
        {
            return;
        }
        //Let our "timer" run up waiting for a response
        //REFACTORING Option: Move this into an event based (non-MT) code to free the fixed update
        //OR event better: create a timer script, destroy it once it elapses ;)
        if (_timeSinceStart < AnchorTagTimeoutInSeconds)
        {
            _timeSinceStart += Time.deltaTime;
            return;
        }

        NoAnchorTagReplyEvent();

           
    }

    private void NoAnchorTagReplyEvent()
    {

        if (QrCodeManagerGameObject == null)
        {
            throw new System.NotSupportedException();
        }
        Debug.Log("Starting QR Tracking");
        QrCodeManagerGameObject.StartQRTracking();

        //Instantiate the local prefab with instructions to find the QR code
        Instantiate(InstructionsPrefab);

        var tapScript = gameObject.AddComponent<TapToSetAnchor>();
        tapScript.ParentAnchor = ParentAnchor;
        _tapToSetInstantiatedOnce = true;

    }

    public void OnEvent(EventData photonEvent)
    {
        //capture here the code event and stop timer OR start tracking
        if (photonEvent.Code == AnchorTagReply)
        {
            _hasReceivedAnchorReply = true;

            var tag = (string)photonEvent.CustomData;
            if (string.IsNullOrEmpty(tag))
            {
                //throw new Exception("Oh no! anyway...");
                return;//  throw new Exception("Received an invalid tag from the network, cannot query Azure");
            }
            var anchorStore = GameObject.Find("AnchorStore").GetComponent<SharedAnchorStore>();
            if (anchorStore != null)
            {
                Debug.Log("Storing new anchor ID into the local anchor store: ");

                anchorStore.StoreNewTag(tag);
            }

#if !UNITY_EDITOR
            var anchorModuleScript = ParentAnchor.GetComponent<AnchorModuleScript>();
            if (anchorModuleScript == null)
            {
                throw new System.NotSupportedException("could not find the anchor module script");
            }
            anchorModuleScript.FindAzureAnchor(tag);
#endif


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

    //OK the list below is CRAP. We only care that we joined the room (method above).
    //3 options
    //use the on joined room on the connection manager to start this script
    //inherit puncalbacks (not sure if it will play nicely with the event interface)
    //leave as it is (G0d...)

    public void OnFriendListUpdate(List<FriendInfo> friendList)
    {

    }

    public void OnCreatedRoom()
    {

    }

    public void OnCreateRoomFailed(short returnCode, string message)
    {

    }



    public void OnJoinRoomFailed(short returnCode, string message)
    {
        
    }

    public void OnJoinRandomFailed(short returnCode, string message)
    {
        
    }

    public void OnLeftRoom()
    {
        
    }
}
