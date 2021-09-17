using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class ChildActiveSync : MonoBehaviour, IPunObservable
{
    // Start is called before the first frame update


    void Start() { 

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(transform.GetChild(0).gameObject.activeInHierarchy);
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(
                (bool)stream.ReceiveNext());
        }
    }
}
