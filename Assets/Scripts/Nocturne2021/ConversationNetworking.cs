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
            if (currentConversation.transform.childCount > 0)
            {
                for (int i = 0; i < currentConversation.transform.childCount; i++)
                {
                    stream.SendNext(currentConversation.transform.GetChild(i).name);
                    counter++;
                }

            }
            else
            {
                stream.SendNext("No Children");
            }
        }
        else
        {
            List<string> allNames = new List<string>();

            while (counter >= 0 )
            {
                allNames.Add((string)stream.ReceiveNext());
                counter--;
            }

            foreach (var name in allNames)
            {
                GameObject thisAvatar = GameObject.Find(name);
                currentConversation.AddAvatar(thisAvatar);
            }

        }
    }
}
