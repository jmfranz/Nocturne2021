using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarLipController : MonoBehaviour
{

    public AudioSource audioSource;
    public float updateStep = 0.1f;
    public int sampleDataLength = 1024;

    public Transform upperLip, lowerJaw;
    public Vector3 upperLipLimit, lowerJawLimit;

    private Vector3 upperLipRest, lowerJawRest;


    private float currentUpdateTime = 0f;

    private float clipLoudness;
    private float[] clipSampleData;

    const float scale = 1.75f;


    // Use this for initialization
    void Awake()
    {

        if (!audioSource)
        {
            Debug.LogError(GetType() + ".Awake: there was no audioSource set.");
        }
        clipSampleData = new float[sampleDataLength];

        upperLipRest = upperLip.localPosition;
        lowerJawRest = lowerJaw.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        float loudness = FindClipLoudness() * scale;

        lowerJaw.transform.localPosition = Vector3.Lerp(lowerJawRest, lowerJawLimit, loudness);
        upperLip.transform.localPosition = Vector3.Lerp(upperLipRest, upperLipLimit, loudness);
    }

    float FindClipLoudness()
    {
        currentUpdateTime += Time.deltaTime;
        if (currentUpdateTime >= updateStep)
        {
            currentUpdateTime = 0f;

            if(audioSource.clip == null) 
            {
                return 0;
            }

            audioSource.clip.GetData(clipSampleData, audioSource.timeSamples); //I read 1024 samples, which is about 80 ms on a 44khz stereo clip, beginning at the current sample position of the clip.
            clipLoudness = 0f;
            foreach (var sample in clipSampleData)
            {
                clipLoudness += Mathf.Abs(sample);
            }
            clipLoudness /= sampleDataLength; //clipLoudness is what you are looking for
        }

        return clipLoudness;
    }

}