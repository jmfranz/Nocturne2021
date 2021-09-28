using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class ActiveComponentSync : MonoBehaviour, IPunObservable
{

    public Behaviour SyncedComponent;


    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(SyncedComponent.enabled);
        }
        else
        {
            SyncedComponent.enabled = (bool) stream.ReceiveNext();
        }
    }
}
