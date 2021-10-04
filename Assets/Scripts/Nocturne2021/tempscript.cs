using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class tempscript : MonoBehaviour
{

    public AvatarController Bultilda;
    public ConversationNode place;


    // Start is called before the first frame update
    void Start()
    {
        Bultilda.GoToConversationNode(place, AvatarController.MovementTypes.Walk);
        Debug.Log("Newline");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
