using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMainCamera : MonoBehaviour
{
    void LateUpdate()
    {
        transform.position = Camera.main.GetComponent<Transform>().position;
        transform.rotation = Camera.main.GetComponent<Transform>().rotation;
    }
}
