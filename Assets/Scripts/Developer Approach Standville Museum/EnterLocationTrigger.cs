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
            ConditionalEventComponent.CompleteConditionalEvent();
            this.GetComponent<BoxCollider>().enabled = false;
            ReachedDestination = true;
        }
    }
}
