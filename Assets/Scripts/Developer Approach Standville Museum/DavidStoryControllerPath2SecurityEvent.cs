using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DavidStoryControllerPath2SecurityEvent : MonoBehaviour
{
    public DialogueEventComponent ScaryMusic;
    public TimerEventComponent ChaseTime;
    public ShadowChaseController ShadowChaseController;

    // Start is called before the first frame update
    void Start()
    {
        ScaryMusic.OnEventEnd += BeginShadowChase;
        ChaseTime.OnEventEnd += StopShadowChase;
    }

    void BeginShadowChase()
    {
        ShadowChaseController.enabled = true;
    }

    void StopShadowChase()
    {
        ShadowChaseController.enabled = false;
    }
}
