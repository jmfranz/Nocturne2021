using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;

public class TextMeshProStateSync : MonoBehaviour, IPunObservable
{
    private TextMeshPro _text;

    void Start()
    {
        _text = GetComponent<TextMeshPro>();
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(_text.text);
        }
        else // Reading
        {
            _text.text  = (string)stream.ReceiveNext();
        }
    }
}
