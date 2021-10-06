using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveMicrophoneRecordingOnEnable : MonoBehaviour
{
    public MicrophoneAccess Microphone;
    
    // Start is called before the first frame update
    void Start()
    {
        var userID = Logger.GetUserID();
        Microphone.saveAudioFile(userID != null ? $"recording-{userID}" : $"recording");
    }

}
