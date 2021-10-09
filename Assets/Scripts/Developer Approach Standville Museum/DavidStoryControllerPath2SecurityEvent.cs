using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DavidStoryControllerPath2SecurityEvent : MonoBehaviour
{
    public DialogueEventComponent ScaryMusic;
    public TimerEventComponent ChaseTime;
    public ShadowChaseController ShadowChaseController;
    public DialogueEventComponent DMLine; // What the hell is that, evade the shadow
    public List<MeshRenderer> Monitors;

    // Start is called before the first frame update
    void Start()
    {
        ScaryMusic.OnEventEnd += BeginShadowChase;
        ChaseTime.OnEventEnd += StopShadowChase;
        DMLine.OnEventEnd += DisableMonitors;
    }

    void BeginShadowChase()
    {
        ShadowChaseController.enabled = true;
    }

    void StopShadowChase()
    {
        ShadowChaseController.enabled = false;
        foreach (var monitor in Monitors)
        {
            monitor.enabled = true;
        }
    }

    void DisableMonitors()
    {
        foreach(var monitor in Monitors)
        {
            monitor.enabled = false;
        }
    }
}
