using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using SharpOSC;

public class VirtualProxemicTracker : MonoBehaviour
{
    /*****************************************************
     * IF SENDING OSC MESSAGES
     ******************************************************
     */

    //UDPSender _sender;

    //void Start()
    //{
    //    _sender = new UDPSender("127.0.0.1", 5103);
    //    StartCoroutine(SendTrackingPose());
    //}


    //IEnumerator SendTrackingPose()
    //{
    //    while (true)
    //    {
    //        var message = new OscMessage(
    //        "/trackers/",
    //        DateTime.Now.ToString(),
    //        name,
    //        transform.position.x,
    //        transform.position.y,
    //        transform.position.z,
    //        transform.eulerAngles.y,
    //        transform.eulerAngles.x,
    //        transform.eulerAngles.z);

    //        _sender.Send(message);

    //        yield return null;
    //    }
    //}

    //private void OnDestroy()
    //{
    //    _sender.Close();
    //}

    /********************************************************
     * IF SENDING MESSAGES DIRECTLY
     ******************************************************** 
     */

    void Start()
    {
        StartCoroutine(SendTrackingPose());
    }

    IEnumerator SendTrackingPose()
    {
        while (true)
        {
            List<double> entities = new List<double>() { transform.position.x, transform.position.y, transform.position.z, transform.eulerAngles.y, transform.eulerAngles.x, transform.eulerAngles.z };

            ProxemicUIFramework.EntityContainer.Instance.EntityChecker(DateTime.Now.ToString(), new Dictionary<string, List<double>>
            {
                { name, new List<double>() { transform.position.x, transform.position.y, transform.position.z, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.z }
            } });

            yield return null;
        }
    }
}
