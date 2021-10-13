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

    public bool reset;


    // Start is called before the first frame update
    void Start()
    {
        currentConversation = GetComponent<ConversationNode>();
        counter = 0;
        reset = true;
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (reset)
        {
            reset = false;
            if (stream.IsWriting)
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
                    thisAvatar.GetComponent<AvatarController>().ActiveNode?.RemoveAvatar(currentConversation.gameObject);
                    currentConversation.AddAvatar(thisAvatar);
                    thisAvatar.GetComponent<AvatarController>().ActiveNode = currentConversation;
                }

            }
            StartCoroutine(Wait());
        }
    }

    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(15);
        reset = true;
    }
}
