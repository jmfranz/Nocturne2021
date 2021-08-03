using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using QRTracking;
using UnityEngine;

public class QRAnchorPlacer : MonoBehaviour, IOnEventCallback
{

    private const int WhatIsAnchorEvent = 01;
    private const int AnchorTagReply = 02;

#if UNITY_EDITOR
    //We don't need to wait forever in the editor do we?
    private const int AnchorTagTimeoutInSeconds = 1;
#else
    private const int AnchorTagTimeoutInSeconds = 5;
#endif

    private bool _hasReceivedAnchorReply = false;
    private bool _tapToSetInstantiatedOnce = false;
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
       
    }

    public void FixedUpdate()
    {
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
            throw new System.NotImplementedException();
        }
        Debug.Log("Starting QR Tracking");
        QrCodeManagerGameObject.StartQRTracking();

        //Instantiate the local prefab with instructions to find the QR code
        Instantiate(InstructionsPrefab);
        //Add the anchor placer on click script (hell I need better comments)
        //TODO: Handle placing anchor once target is found
        gameObject.AddComponent<TapToSetAnchor>();
        _tapToSetInstantiatedOnce = true;

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
