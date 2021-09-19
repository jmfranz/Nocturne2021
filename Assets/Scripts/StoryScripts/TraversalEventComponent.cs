using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraversalEventComponent : StoryEventComponent
{
    public AvatarController AvatarController;
    public AvatarController.MovementTypes MovementType;
    public ConversationNode Destination; //TODO: Support different transforms as well

    public void Init(AvatarController controller, AvatarController.MovementTypes moveType, ConversationNode dest)
    {
        AvatarController = controller;
        MovementType = moveType;
        Destination = dest;
    }

    public override IEnumerator DoEventAction()
    {
        AvatarController.GoToConversationNode(Destination, MovementType);
        yield return new WaitUntil(() => AvatarController.MovementState == AvatarController.MovementStates.Stopped);
    }

    public bool EventCompleted()
    {
        if (AvatarController.transform.position == Destination.transform.position)
        {
            return true;
        }
        else
        {
            return false;
           
        }
    }
}
