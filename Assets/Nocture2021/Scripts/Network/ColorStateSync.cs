using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;

public class ColorStateSync : MonoBehaviour, IPunObservable
{
    public bool UsingTextMeshPro = true;
    public bool UsingShader = false;

    public TextMeshPro Text;
    public Material Material;

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            Color32 color = Color.clear;

            if (UsingTextMeshPro)
            {
                color = Text.color;
            }
            if (UsingShader)
            {
                color = Material.color;
            }

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

            Text.color = new Color32(r, g, b, a);
        }
    }
}
