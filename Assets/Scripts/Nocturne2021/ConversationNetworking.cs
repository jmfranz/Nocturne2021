using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Unity.Profiling;
using UnityEngine;

[RequireComponent(typeof(ConversationNode))]
public class ConversationNetworking : MonoBehaviour//, IPunObservable
{
    
    public ConversationNode currentConversation;

    public int counter;

    bool tenFrames;
    int frameCounter;

    public NPC_Movements nPC_Movements;


    // Start is called before the first frame update
    void Start()
    {
        currentConversation = GetComponent<ConversationNode>();
        counter = 0;
        tenFrames = false;
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if ( stream.IsWriting)
        {
            stream.SendNext(currentConversation.transform.childCount);
            for (int i = 0; i < currentConversation.transform.childCount; i++)
            {
                stream.SendNext(currentConversation.transform.GetChild(i).name);
            }
        }
        else
        {
            int count = (int)stream.ReceiveNext();

            for (int i = 0; i < count; i++)
            {
                string newName = (string)stream.ReceiveNext();
                Debug.Log(newName);
                GameObject thisAvatar = GameObject.Find(newName);
                if (newName != null)
                {
                    thisAvatar.GetComponent<AvatarController>().GoToConversationNode(currentConversation, AvatarController.MovementTypes.Walk);
                }
                else
                {
                    thisAvatar.GetComponent<AvatarController>().ActiveNode?.RemoveAvatar(currentConversation.gameObject);
                    currentConversation.AddAvatar(thisAvatar);
                    thisAvatar.GetComponent<AvatarController>().ActiveNode = currentConversation;
                }
            }
        }
    }
}
