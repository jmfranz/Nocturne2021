using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class ChildActiveSync : MonoBehaviour, IPunObservable
{
    // Start is called before the first frame update

    public List<GameObject> syncObjects = new List<GameObject>();


    void Start() { 

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        Debug.Log("Test");

        if (stream.IsWriting)
        {
            foreach(GameObject syncObject in syncObjects)
            {
                stream.SendNext(syncObject.activeInHierarchy);
            }
        }
        else
        {
            foreach (GameObject syncObject in syncObjects)
            {
                gameObject.SetActive(
                    (bool)stream.ReceiveNext());
            }
        }
    }


}
