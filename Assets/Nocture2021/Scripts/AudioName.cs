using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioName : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var source = GetComponent<AudioSource>();

        var audioClip = Resources.Load<AudioClip>("Conversations/ConversationLines/dog7");
        source.clip = audioClip;
        source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
