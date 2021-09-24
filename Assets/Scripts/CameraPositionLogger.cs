using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

/// <summary>
/// A Unity class for recording camera and the player's position logger.
/// </summary>
public class CameraPositionLogger : MonoBehaviour
{
    public string filename; // The name of the file.
    public Camera camera;   // The camera that will be tracked.
    public GameObject parentAnchor; // The anchroing object for the camera.

    bool logPathPrinted = false;

    //public StreamWriter sw;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        string path = Application.dataPath + "/Data/" + filename;

        if (!File.Exists(path))
        {
            StreamWriter swt = File.CreateText(path);
            swt.WriteLine("Date,Hour,Minute,Second,Milisecond,PosX,PosY,PosZ,RotX,RotY,RotZ,RotW");
            swt.Close();
        }

        if (!logPathPrinted)
        {
            Debug.Log(string.Format("Writing CameraPositionLog data to: {0}", path));
            logPathPrinted = true;
        }

        StreamWriter sw = new StreamWriter(path, true);
        DateTime now = DateTime.Now;
        string date = now.ToString("yyyy-MM-dd");

        Vector3 pos = camera.transform.InverseTransformPoint(parentAnchor.transform.position);
        Quaternion rot = camera.transform.rotation;



        string cam_info = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}", date, now.Hour, now.Minute, now.Second, now.Millisecond, pos.x, pos.y, pos.z, rot.x, rot.y, rot.z, rot.w);
        sw.WriteLine(cam_info);
        sw.Close();
    }
}
