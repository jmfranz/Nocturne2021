using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Used when dialogue should occur in chronological order
public class DialogueEventComponent : StoryEventComponent
{
    // Conversation Player requirements:
    //  1. Should not be looping
    //  2. Make proximityy rule have max distance as 1000 (always triggers)
    //  3. Disable component
    public ConversationPlayer ConversationPlayer;
    bool _doEventAction = false;

    public void Init(ConversationPlayer convoPlayer)
    {
        ConversationPlayer = convoPlayer;
    }


    public override void DoEventAction()
    {
        ConversationPlayer.enabled = true;
        _doEventAction = true;
        //yield return new WaitUntil(() => ConversationPlayer.enabled && ConversationPlayer.IsConversationFinished && !ConversationPlayer.isLoopConversation);
    }

    public void FixedUpdate()
    {
        if(_doEventAction && ConversationPlayer.enabled && ConversationPlayer.IsConversationFinished && !ConversationPlayer.isLoopConversation)
        {
            _doEventAction = false;
            DoneEventAction = true;
        }
    }


    public override void DoEventStoppedAction()
    {
        ConversationPlayer.enabled = false;
    }

    public override void StopEventAction()
    {
        _doEventAction = false;
    }
}
