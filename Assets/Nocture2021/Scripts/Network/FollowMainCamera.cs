using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class FollowMainCamera : MonoBehaviour
{
    void LateUpdate()
    {
        if (GetComponent<PhotonView>().IsMine)
        {
            transform.position = Camera.main.GetComponent<Transform>().position;
            transform.rotation = Camera.main.GetComponent<Transform>().rotation;
        }
    }
}
