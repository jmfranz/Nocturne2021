using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class ChildActiveSync : MonoBehaviour, IPunObservable
{
    // Start is called before the first frame update
<<<<<<< Updated upstream
    public List<GameObject> syncObjects = new List<GameObject>();
=======
    public List<GameObject> SyncGameObjects;
>>>>>>> Stashed changes

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
<<<<<<< Updated upstream
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
=======
            foreach (var go in SyncGameObjects)
            {
                stream.SendNext(go.activeInHierarchy);
            }
            
        }
        else
        {
            foreach (var go in SyncGameObjects)
            {
                go.SetActive(
                    (bool)stream.ReceiveNext());
            }

>>>>>>> Stashed changes
        }
    }


}
