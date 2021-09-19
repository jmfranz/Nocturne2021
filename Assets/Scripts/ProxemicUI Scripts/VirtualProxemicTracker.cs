using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using SharpOSC;

public class VirtualProxemicTracker : MonoBehaviour
{
    UDPSender _sender;


    void Start()
    {
        _sender = new UDPSender("127.0.0.1", 5103);
        StartCoroutine(SendTrackingPose());
    }


    IEnumerator SendTrackingPose()
    {
        while (true)
        {
            var message = new OscMessage(
            "/trackers/",
            DateTime.Now.ToString(),
            name,
            transform.position.x,
            transform.position.y,
            transform.position.z,
            transform.eulerAngles.y,
            transform.eulerAngles.x,
            transform.eulerAngles.z);

            _sender.Send(message);

            yield return null;
        }
    }

    private void OnDestroy()
    {
        _sender.Close();
    }
}
