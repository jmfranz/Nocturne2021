using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayAudioWhenEnter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var audioSource = GetComponent <AudioSource>();
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }

    }
}
