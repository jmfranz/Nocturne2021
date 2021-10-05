using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraversalEventComponent : StoryEventComponent
{
    public AvatarController AvatarController;
    public AvatarController.MovementTypes MovementType;
    public ConversationNode Destination; //TODO: Support different transforms as well
    bool _doEventAction = false;

    public void Init(AvatarController controller, AvatarController.MovementTypes moveType, ConversationNode dest)
    {
        AvatarController = controller;
        MovementType = moveType;
        Destination = dest;
    }

    public override void DoEventAction()
    {
        _doEventAction = true;

        AvatarController.GoToConversationNode(Destination, MovementType);
    }
    public void FixedUpdate()
    {
        if (_doEventAction && AvatarController.MovementState == AvatarController.MovementStates.Stopped)
        {
            _doEventAction = false;
            DoneEventAction = true;
        }
    }
    public override void StopEventAction()
    {
        _doEventAction = false;
    }
}
