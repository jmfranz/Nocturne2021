using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoTrustEnding : MonoBehaviour
{
    public DialogueEventComponent NoTrustConvo;

    // Start is called before the first frame update
    void Start()
    {
        NoTrustConvo.OnEventEnd += TrailToPlanetarium;
    }

    void TrailToPlanetarium()
    {
        // Continue here
    }
}
