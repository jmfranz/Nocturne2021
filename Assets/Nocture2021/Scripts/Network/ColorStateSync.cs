using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshPro))]
public class ColorStateSync : MonoBehaviour, IPunObservable
{
    private TextMeshPro _text;

    private void Start()
    {
        _text = GetComponent<TextMeshPro>();
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            Color32 color = _text.color;

            stream.SendNext(color.r);
            stream.SendNext(color.g);
            stream.SendNext(color.b);
            stream.SendNext(color.a);
        }
        else // Reading
        {
            byte r = (byte)stream.ReceiveNext();
            byte g = (byte)stream.ReceiveNext();
            byte b = (byte)stream.ReceiveNext();
            byte a = (byte)stream.ReceiveNext();

            _text.color = new Color32(r, g, b, a);
        }
    }
}
