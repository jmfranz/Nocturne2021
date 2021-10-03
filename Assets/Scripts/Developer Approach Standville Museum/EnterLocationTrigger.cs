using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterLocationTrigger : MonoBehaviour
{
    public ConditionalEventComponent ConditionalEventComponent;

    public bool ReachedDestination = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "VRPlayerController(Clone)" || other.name == "Main Camera")
        {
            TriggerEvent();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "VRPlayerController(Clone)" || other.name == "Main Camera")
        {
            TriggerEvent();
        }
    }

    void TriggerEvent()
    {
        if (ConditionalEventComponent.Status == StoryEventComponent.StoryEventStatus.Running)
        {
            ConditionalEventComponent.CompleteConditionalEvent();
            this.GetComponent<BoxCollider>().enabled = false;
            ReachedDestination = true;
        }
    }
}
