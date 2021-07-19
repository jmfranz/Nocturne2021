using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class MaterialColourNetworkSync : MonoBehaviour, IPunObservable
{
    private Material _material;
    // Start is called before the first frame update
    void Start()
    {
        _material = gameObject.GetComponent<MeshRenderer>().material;
        if (_material == null)
        {
            //If the object has no material we don't sync it ;)
            Destroy(this);
        }

        
    }
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        //Syncs the material over the network. Maybe it should be just the color? We'll see
        if (stream.IsWriting)
        {
            stream.SendNext(_material.color.r);
            stream.SendNext(_material.color.g);
            stream.SendNext(_material.color.b);
            stream.SendNext(_material.color.a);

        }
        else
        {
            var r = (float) stream.ReceiveNext();
            var g = (float) stream.ReceiveNext();
            var b = (float) stream.ReceiveNext();
            var a = (float) stream.ReceiveNext();
            _material.color = new Color(r, g, b, a);
        }
    }
}
