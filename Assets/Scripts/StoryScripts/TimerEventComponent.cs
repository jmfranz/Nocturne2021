using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerEventComponent : StoryEventComponent
{
    public float WaitTime;

    public void Init(float time)
    {
        WaitTime = time;
    }

    public override IEnumerator DoEventAction()
    {
        yield return new WaitForSeconds(WaitTime);
    }
}
