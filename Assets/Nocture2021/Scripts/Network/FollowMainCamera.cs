using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit;
using Photon.Pun;
using UnityEngine;

public class FollowMainCamera : MonoBehaviour, IPunObservable
{
    public Transform partentAnchor;

    public void Start()
    {
        partentAnchor = GameObject.Find("ParentAnchor").transform;
    }



    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(Camera.main.transform.InverseTransformPoint(partentAnchor.position));
        }
        else
        {
            var trans = (Vector3) stream.ReceiveNext();
            //have not tested the - (minus)
            transform.position = trans - partentAnchor.position;
        }
    }
}
