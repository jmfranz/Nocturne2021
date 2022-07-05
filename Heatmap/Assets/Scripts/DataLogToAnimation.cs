using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using System;

public class DataLogToAnimation : MonoBehaviour
{
    public Animation playerAnimcation;
    // Start is called before the first frame update
    void Start()
    {
        var filePath = @"C:\Users\Franz\Desktop\Nocturne 2021\HL Logs\cameraLogs\4a-camera.csv";

        var fileLines = File.ReadAllLines(filePath);

        AnimationClip clip = new AnimationClip();
        var cameraPosition = new List<AnimationCurve>()
        {
            new AnimationCurve(),
            new AnimationCurve(),
            new AnimationCurve()
        };
        var cameraRotation = new List<AnimationCurve>()
        {
            new AnimationCurve(),
            new AnimationCurve(),
            new AnimationCurve(),
            new AnimationCurve()
        };

        DateTime startTime = new DateTime();
        
        //Skip the header
        //UserID,Date,Hour,Minute,Second,Milisecond,PosX,PosY,PosZ,RotX,RotY,RotZ,RotW,Scene,IsMaster
        
        for (int i = 1; i < fileLines.Length; i++)
        {
            var line = fileLines[i].Split(',');
            var date = line[1].Split('-');
            var timeStamp = new DateTime(int.Parse(date[0]), int.Parse(date[1]), int.Parse(date[2]),
                    int.Parse(line[2]), int.Parse(line[3]), int.Parse(line[4]), int.Parse(line[5]));

            if (i == 1)
            {
                startTime = timeStamp;
            }
            
            var position = new Vector3(float.Parse(line[6]), float.Parse(line[7]), float.Parse(line[8]));
            var rotation = new Quaternion(float.Parse(line[9]), float.Parse(line[10]), float.Parse(line[11]), float.Parse(line[12]));

            cameraPosition[0].AddKey((float)(timeStamp - startTime).TotalMilliseconds, position.x);
            cameraPosition[1].AddKey((float)(timeStamp - startTime).TotalMilliseconds, position.y);
            cameraPosition[2].AddKey((float)(timeStamp - startTime).TotalMilliseconds, position.z);

            cameraRotation[0].AddKey((float)(timeStamp - startTime).TotalMilliseconds, rotation.x);
            cameraRotation[1].AddKey((float)(timeStamp - startTime).TotalMilliseconds, rotation.y);
            cameraRotation[2].AddKey((float)(timeStamp - startTime).TotalMilliseconds, rotation.z);
            cameraRotation[3].AddKey((float)(timeStamp - startTime).TotalMilliseconds, rotation.w);
        }
        clip.legacy = true;
        clip.SetCurve("", typeof(Transform), "localPosition.x", cameraPosition[0]);
        clip.SetCurve("", typeof(Transform), "localPosition.y", cameraPosition[1]);
        clip.SetCurve("", typeof(Transform), "localPosition.z", cameraPosition[2]);

        clip.SetCurve("", typeof(Transform), "rotation.x", cameraRotation[0]);
        clip.SetCurve("", typeof(Transform), "rotation.y", cameraRotation[0]);
        clip.SetCurve("", typeof(Transform), "rotation.z", cameraRotation[0]);
        clip.SetCurve("", typeof(Transform), "rotation.w", cameraRotation[0]);


        playerAnimcation.AddClip(clip, clip.name) ;
        

    }

}
