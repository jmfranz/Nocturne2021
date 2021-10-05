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

    bool _sendingTrackingPose = false;
    List<double> entityTransform = new List<double>();
    Dictionary<string, List<double>> entities = new Dictionary<string, List<double>>();
    float _timeThreshold = 0.33f;
    float _timeSinceLastUpdate = 0f;

    private void Awake()
    {
        entities.Add(name, entityTransform);
;
        entityTransform.Add(transform.position.x);
        entityTransform.Add(transform.position.y);
        entityTransform.Add(transform.position.z);
        entityTransform.Add(transform.eulerAngles.y);
        entityTransform.Add(transform.eulerAngles.x);
        entityTransform.Add(transform.eulerAngles.z);
        ProxemicUIFramework.EntityContainer.Instance.EntityChecker(DateTime.Now.ToString(), entities);
        //_timeSinceLastUpdate = _timeThreshold;
    }


    private void FixedUpdate()
    {
        _timeSinceLastUpdate += Time.fixedDeltaTime;
        if(_timeSinceLastUpdate < _timeThreshold)
        {
            return;
        }

        _timeSinceLastUpdate = 0;

        entityTransform.Clear();
        entityTransform.Add(transform.position.x);
        entityTransform.Add(transform.position.y);
        entityTransform.Add(transform.position.z);
        entityTransform.Add(transform.eulerAngles.y);
        entityTransform.Add(transform.eulerAngles.x);
        entityTransform.Add(transform.eulerAngles.z);
              

        ProxemicUIFramework.EntityContainer.Instance.EntityChecker(DateTime.Now.ToString(), entities);
    }

    //IEnumerator SendTrackingPose()
    //{
    //    while (true)
    //    {
    //        List<double> entities = new List<double>() { transform.position.x, transform.position.y, transform.position.z, transform.eulerAngles.y, transform.eulerAngles.x, transform.eulerAngles.z };

    //        ProxemicUIFramework.EntityContainer.Instance.EntityChecker(DateTime.Now.ToString(), new Dictionary<string, List<double>>
    //        {
    //            { name, new List<double>() { transform.position.x, transform.position.y, transform.position.z, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.z }
    //        } });

    //        yield return null;
    //    }
    //}
}
