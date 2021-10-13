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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(currentConversation.transform.childCount);
            for (int i = 0; i < currentConversation.transform.childCount; i++)
            {
                stream.SendNext(currentConversation.transform.GetChild(i).name);
                //Debug.Log(currentConversation.transform.GetChild(i).name);
                Debug.Log("NAME" + currentConversation.transform.GetChild(i).name);
                counter++;
            }

        }
        else
        {

            int count = (int)stream.ReceiveNext();

         
            for (int i = 0; i < count; i++)
            {
                string newName = (string)stream.ReceiveNext();
                GameObject thisAvatar = GameObject.Find(newName);
                currentConversation.AddAvatar(thisAvatar);
            }

        }
    }
}
