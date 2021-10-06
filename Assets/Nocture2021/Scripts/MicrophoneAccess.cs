using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

#if WINDOWS_UWP
using Windows.Storage;
#endif


//For now, this is just so we can hear us back
[RequireComponent(typeof(AudioSource))]
public class MicrophoneAccess : MonoBehaviour
{
    private AudioClip mic;

    private const int RecordTimeInMinutes = 15;
    private const int TempSaveTimeInSeconds = 20;
    private float _timeSinceStart = 0;

    public void Start()
    {
        var audioSource = GetComponent<AudioSource>();
        mic = Microphone.Start(Microphone.devices[0], true, 60*RecordTimeInMinutes, 44100);
        audioSource.clip = mic;
        audioSource.loop = true;
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
