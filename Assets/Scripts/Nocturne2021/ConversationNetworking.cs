using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Unity.Profiling;
using UnityEngine;

[RequireComponent(typeof(ConversationNode))]
public class ConversationNetworking : MonoBehaviour, IPunObservable
{
    
    public ConversationNode currentConversation;

    public int counter;


    // Start is called before the first frame update
    void Start()
    {
        currentConversation = GetComponent<ConversationNode>();
        counter = 0;
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(currentConversation.transform.childCount);
            for (int i = 0; i < currentConversation.transform.childCount; i++)
            {
                stream.SendNext(currentConversation.transform.GetChild(i).name);
                Debug.Log("NAME" + currentConversation.transform.GetChild(i).name);
            }

        }
        else
        {
            Debug.Log("Before int");
            int count = (int)stream.ReceiveNext();
            Debug.Log("after int");

            for (int i = 0; i < count; i++)
            {
                Debug.Log("before string");
                string newName = (string)stream.ReceiveNext();
                Debug.Log("after string");
                Debug.Log(newName);
                GameObject thisAvatar = GameObject.Find(newName);
                currentConversation.AddAvatar(thisAvatar);
                thisAvatar.GetComponent<AvatarController>().ActiveNode = currentConversation;
            }

        }
    }
}
