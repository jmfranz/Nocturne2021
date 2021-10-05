using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerEventComponent : StoryEventComponent
{
    public float WaitTime;
    bool _doEventAction = false;
    float _timeSinceStart = 0f;
    public bool FinishedEvent = false;

    public void Init(float time)
    {
        WaitTime = time;
    }

    public override void DoEventAction()
    {
        _doEventAction = true;
    }

    public void FixedUpdate()
    {
        if (_doEventAction)
        {
            if(_timeSinceStart < WaitTime)
            {
                _timeSinceStart += Time.deltaTime;
            }
            else
            {
                _doEventAction = false;
                DoneEventAction = true;
            }
        }
    }

    public override void StopEventAction()
    {
        _doEventAction = false;
    }
}
