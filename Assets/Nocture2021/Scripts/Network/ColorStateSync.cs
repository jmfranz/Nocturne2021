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
    public SkinnedMeshRenderer ShadowSkinnedMeshRenderer;

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            Color32 color = Color.clear;

            if (UsingTextMeshPro)
            {
                color = Text.color;

                stream.SendNext(color.r);
                stream.SendNext(color.g);
                stream.SendNext(color.b);
                stream.SendNext(color.a);
            }
            if (UsingShader)
            {
                color = ShadowSkinnedMeshRenderer.materials[0].color;

                stream.SendNext(color.r);
                stream.SendNext(color.g);
                stream.SendNext(color.b);
                stream.SendNext(color.a);

                color = ShadowSkinnedMeshRenderer.materials[1].color;

                stream.SendNext(color.r);
                stream.SendNext(color.g);
                stream.SendNext(color.b);
                stream.SendNext(color.a);
            }
        }
        else // Reading
        {
            byte r = (byte)stream.ReceiveNext();
            byte g = (byte)stream.ReceiveNext();
            byte b = (byte)stream.ReceiveNext();
            byte a = (byte)stream.ReceiveNext();


            if (UsingTextMeshPro)
            {
                Text.color = new Color32(r, g, b, a);
            }
            if (UsingShader)
            {
                ShadowSkinnedMeshRenderer.materials[0].color = new Color32(r, g, b, a);

                r = (byte)stream.ReceiveNext();
                g = (byte)stream.ReceiveNext();
                b = (byte)stream.ReceiveNext();
                a = (byte)stream.ReceiveNext();

                ShadowSkinnedMeshRenderer.materials[1].color = new Color32(r, g, b, a);


            }
        }
    }
}
