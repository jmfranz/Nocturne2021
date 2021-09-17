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


    public void Init(ConversationPlayer convoPlayer)
    {
        ConversationPlayer = convoPlayer;
    }


    public override IEnumerator DoEventAction()
    {
        ConversationPlayer.enabled = true;
        yield return new WaitUntil(() => ConversationPlayer.enabled && ConversationPlayer.IsConversationFinished);
    }


    public override void DoEventStoppedAction()
    {
        ConversationPlayer.enabled = false;
    }
}
