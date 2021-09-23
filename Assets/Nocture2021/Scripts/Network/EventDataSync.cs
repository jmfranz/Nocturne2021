using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;


public class EventDataSync : MonoBehaviour, IOnEventCallback
{
    private static byte _event = 10;
    
    //Singleton
    private static EventDataSync _instance;
    public static EventDataSync Instance
    {
        get
        {
            if (_instance == null)
            {
                var singletonObject = GameObject.Find("Event Data Synchronization");
                _instance = singletonObject.AddComponent<EventDataSync>();
            }
            return _instance;
        }
    }


    public void SetEventData(string eventName, bool eventActive)
    {
        Debug.LogFormat("Sent '{0}' with status '{1}'", eventName, eventActive);

        object[] content = { eventName, eventActive };
        RaiseEventOptions raiseEventOptions = RaiseEventOptions.Default;
        raiseEventOptions.Receivers = ReceiverGroup.Others;
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

        Debug.LogFormat("Received '{0}' with status '{1}'", eventName, eventSatus);
    }
}
