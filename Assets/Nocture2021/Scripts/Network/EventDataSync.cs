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
    private static EventDataSync _instance;

    void Awake()
    {
        var singletonObject = GameObject.Find("Event Data Synchronization");
        _instance = singletonObject.AddComponent<EventDataSync>();
    }

    public void SetEventData(string eventName, bool eventActive)
    {
        if (!PhotonNetwork.IsConnectedAndReady)
        {
            return;
        }

        Debug.LogFormat("Sent '{0}' with status '{1}'", eventName, eventActive);

        object[] content = { eventName, eventActive };
        RaiseEventOptions raiseEventOptions = RaiseEventOptions.Default;
        raiseEventOptions.Receivers = ReceiverGroup.All;
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
