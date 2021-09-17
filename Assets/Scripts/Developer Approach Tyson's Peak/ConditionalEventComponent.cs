using System.Collections;
using UnityEngine;

// Used when you want to wait for a simple boolean to be true
// TODO: extend to include multiple paths
public class ConditionalEventComponent : StoryEventComponent
{
    // NOTE: Make sure to use another script to set the CompleteConditionalEvent() method

    public bool Complete;

    public void Init()
    {
        Complete = false;
    }

    // Call from other class
    public void CompleteConditionalEvent()
    {
        Complete = true;
    }

    public override IEnumerator DoEventAction()
    {
        yield return new WaitUntil(() => Complete);
    }
}
