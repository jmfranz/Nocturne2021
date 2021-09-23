using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Photon.Pun;
using UnityEngine;

[RequireComponent(typeof(StringBuilder))]
public class EventDataSync : MonoBehaviour, IPunObservable
{
    private StringBuilder _eventName;
    private StringBuilder _eventActive; // 1 means active, 0 means inactive


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


    void Awake()
    {
        _eventName = new StringBuilder();
        _eventActive = new StringBuilder();
    }


    public void SetEventData(string eventName, bool eventActive)
    {
        if(_eventName.Length == 0) // First string added
        {
            _eventName.AppendFormat("{0}", eventName);
            _eventActive.AppendFormat("{0}", eventActive);
        }
        else // Subsequent string added
        {
            _eventName.AppendFormat(", {0}", eventName);
            _eventActive.AppendFormat(", {0}", eventActive);
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            if(_eventName.Length != 0)
            {
                stream.SendNext(_eventName.ToString());
                stream.SendNext(_eventActive.ToString());
                Debug.LogFormat("Sent '{0}' with status '{1}'", _eventName, _eventActive);

                //Reset data
                _eventName.Length = 0;
                _eventActive.Length = 0;
            }
            else
            {
                stream.SendNext("No Events");
                stream.SendNext("No Status");
            }
        }
        else // Reading
        {
            string eventName = (string)stream.ReceiveNext();
            string eventActive = (string)stream.ReceiveNext();

            if(eventName != "No Events") // There was an event change
            {
                Debug.LogFormat("Received '{0}' with status '{1}'", eventName, eventActive);
            }
        }
    }
}
