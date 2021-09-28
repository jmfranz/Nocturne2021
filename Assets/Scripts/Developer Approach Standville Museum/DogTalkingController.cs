using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogTalkingController : MonoBehaviour
{

    AudioSource audioSource;
    bool playing = false;

    DogAnimController dogAnimController;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        dogAnimController = this.GetComponent<DogAnimController>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (audioSource.isPlaying && !playing)
        {
            dogAnimController.DogAnimState = DogAnimController.DogAnimStates.Talking;
            playing = true;
        }
        else if(!audioSource.isPlaying && playing)
        {
            dogAnimController.DogAnimState = DogAnimController.DogAnimStates.Idle;
            playing = false;
        }
    }
}
