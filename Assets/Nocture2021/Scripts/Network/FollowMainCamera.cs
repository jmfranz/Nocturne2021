using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit;
using Photon.Pun;
using UnityEngine;

public class FollowMainCamera : MonoBehaviour
{
    private Transform partentAnchor;

    public void Start()
    {
        partentAnchor = GameObject.Find("ParentAnchor").transform;

    }

    public void Update()
    {
        if (GetComponent<PhotonView>().IsMine)
        {
            transform.position = Camera.main.transform.position;
        }
    }

}
