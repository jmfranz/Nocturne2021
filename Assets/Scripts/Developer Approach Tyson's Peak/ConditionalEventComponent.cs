using System.Collections;
using UnityEngine;

// Used when you want to wait for a simple boolean to be true
// TODO: extend to include multiple paths
public class ConditionalEventComponent : StoryEventComponent
{
    // NOTE: Make sure to use another script to set the CompleteConditionalEvent() method

    public bool Complete;
    bool _doEventAction = false;

    public void Init()
    {
        Complete = false;
    }

    // Call from other class
    public void CompleteConditionalEvent()
    {
        Complete = true;
    }

    public override void DoEventAction()
    {
        _doEventAction = true;
    }

    public void FixedUpdate()
    {
        if (_doEventAction && Complete)
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
