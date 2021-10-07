using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;


#if WINDOWS_UWP
using Windows.Storage;
using Windows.ApplicationModel.Core;
#endif


//For now, this is just so we can hear us back
[RequireComponent(typeof(AudioSource))]
public class MicrophoneAccess : MonoBehaviour
{
    private AudioClip mic;

    public int RecordTimeInMinutes = 15;
    private float _timeSinceStart = 0;

    public void Start()
    {
        var audioSource = GetComponent<AudioSource>();
        mic = Microphone.Start(Microphone.devices[0], true, 60*RecordTimeInMinutes, 44100);
        audioSource.clip = mic;
        audioSource.loop = false;
        audioSource.Play();
    }

#if UNITY_EDITOR
    public void OnGUI()
    {
        if (GUILayout.Button("Save me"))
        {
            saveAudioFile("rec");
        }
    }
#endif



    /// <summary>
    /// Save the recording when the app pauses/closes
    /// Note that this only works on the Hololens
    ///
    /// We should switch to the OpenXR XR_SESSION_STATE_STOPPING in the future and not rely on Unity's MonoBehaviour
    /// </summary>
    /// <param name="paused">true if paused</param>
    public void OnApplicationPause(bool paused)
    {
        if (!paused) return;

        var id = Logger.GetUserID() ?? DateTime.UtcNow.ToString();
        saveAudioFile($"Recording-{id}");
    }



    public void saveAudioFile(string fileName)
    {
        
        var audioSource = GetComponent<AudioSource>();
        audioSource.Stop();
        
        var sav = new SavWav();
        
        sav.Save(fileName, mic);

        var saveCube = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        saveCube.transform.position = Camera.main.transform.position;
        saveCube.transform.Translate(0,0,1.5f);

    }
}
