using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventDataSync : MonoBehaviourPun, IOnEventCallback
{
    private static byte _event = 10;
    public ContextAwareGuide AwareGuide;

    public void SetEventData(string eventName, bool eventActive)
    {
        if (!PhotonNetwork.IsConnectedAndReady)
        {
            return;
        }

        //Debug.LogFormat("Sent '{0}' with status '{1}'", eventName, eventActive);

        object[] content = { eventName, eventActive };
        RaiseEventOptions raiseEventOptions = RaiseEventOptions.Default;
        raiseEventOptions.Receivers = ReceiverGroup.Others;
        raiseEventOptions.CachingOption = EventCaching.DoNotCache;
        PhotonNetwork.RaiseEvent(_event, content, raiseEventOptions, SendOptions.SendReliable);
    }

    
    public void OnEvent(EventData photonEvent)
    {
        if(photonEvent.Code != _event)
        {
            return;
        }

        object[] eventData = (object[])photonEvent.CustomData;
        string eventName = (string)eventData[0];
        bool eventSatus = (bool)eventData[1];

        if(SceneManager.GetActiveScene().name.Contains("Guide"))
        {
            AwareGuide.OnEventDataChange(eventName, eventSatus);
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
