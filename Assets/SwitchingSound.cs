using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchingSound : MonoBehaviour
{
    private AudioSource switchingSoundSource;
    public AudioClip cognitiveWorldSound;
    public AudioClip realWorldSound;
    public AudioClip doorSound;


    void Awake()
    {

    }

    void Start()
    {
        switchingSoundSource = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            PlayRealWorldSound();
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            CognitiveRealWorldSound();
        }
    }

    public void PlayRealWorldSound()
    {
        switchingSoundSource.PlayOneShot(realWorldSound);
    }

    public void CognitiveRealWorldSound()
    {
        switchingSoundSource.PlayOneShot(cognitiveWorldSound);
    }
    public void PlayDoorSound()
    {
        switchingSoundSource.PlayOneShot(doorSound);
    }

}
