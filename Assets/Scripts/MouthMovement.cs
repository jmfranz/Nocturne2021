/*
    MouthMovement: A simple script for performing a basic mouth movement animation based on an audio clip.
    @Author: Matt P.

    clipLoudness snippet adapted from: https://answers.unity.com/questions/1167177/how-do-i-get-the-current-volume-level-amplitude-of.html
*/
using UnityEngine;

public class MouthMovement : MonoBehaviour {

    /* --- Public Vars --- */
    public Transform MJaw;
    public int CyclesPerMouthMovement = 20;
    public float UpdateStep = 0.1f;

    public float RotationPerCycle = 0.5f;
    public float LoudnessThreshold = 0.01f;

    /* --- Private Vars --- */
    private AudioSource audioSource;

    private int currentCycle = 0;
    private int direction = 1;

    private int sampleDataLength = 1024;

    private float currentUpdateTime = 0f;

    private float clipLoudness;
    private float[] clipSampleData;

    void Start () {
        audioSource = gameObject.GetComponent<AudioSource> ();
        Debug.Log ("Test start: " + audioSource);

        if (!audioSource) {
            Debug.LogError (GetType () + ".Awake: there was no audioSource set.");
        }
        clipSampleData = new float[sampleDataLength];
    }

    void Update () {

        currentUpdateTime += Time.deltaTime;

        // Extracts the 'Clip Loudness'
        if (currentUpdateTime >= UpdateStep) {
            currentUpdateTime = 0f;
            audioSource.clip.GetData (clipSampleData, audioSource.timeSamples);
            clipLoudness = 0f;
            foreach (var sample in clipSampleData) {
                clipLoudness += Mathf.Abs (sample);
            }
            clipLoudness /= sampleDataLength; //clipLoudness is what you are looking for
        }

        /*
            // This value is the 'loudness' of the audio clip playing.  It must exceed the user defined threshold to activate mouth movement.
            Debug.Log ("Clip Loudness: " + clipLoudness);
        */

        if (clipLoudness > LoudnessThreshold) {
            // Perform the rotation.
            MJaw.Rotate (0.0f, 0.0f, RotationPerCycle * direction, Space.Self);

            currentCycle++;

            // If the maximum amount of cycles is reached, reverse the direction of rotation. 
            if (currentCycle % CyclesPerMouthMovement == 0) {
                direction *= -1;
            }
        }
    }

}