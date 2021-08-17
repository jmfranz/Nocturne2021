using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class RaycastAudioVolume : MonoBehaviour
{
    
    private void LateUpdate()
    {
        var audioSource = GetComponent<AudioSource>();
        var ray = new Ray(transform.position, Camera.main.transform.position - transform.position);

        Debug.DrawRay(transform.position, Camera.main.transform.position - transform.position, Color.green);

        if (audioSource.isPlaying)
        {
            
            if (Physics.Raycast(ray, Vector3.Distance(transform.position,Camera.main.transform.position), 1 << 6))
            {
                GetComponent<AudioSource>().mute = true;
            }
            else
            {
                GetComponent<AudioSource>().mute = false;
            }
        }
    }
}
