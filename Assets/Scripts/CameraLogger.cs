using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraLogger : MonoBehaviour
{
    public float RecordFrequency = 1;
    public string filename = "camera.csv";

    private float elapsedTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        Logger.AddHeaderRequest(filename, "Date", "Hour", "Minute", "Second", "Milisecond", "PosX", "PosY", "PosZ", "RotX", "RotY", "RotZ", "RotW", "Scene", "IsMaster");
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.fixedTime;

        if (elapsedTime >= RecordFrequency)
        {
            elapsedTime = 0;

            DateTime now = DateTime.Now;
            string date = now.ToString("yyyy-MM-dd");

            Vector3 pos = transform.position;
            Quaternion rot = transform.rotation;
            string sceneName = SceneManager.GetActiveScene().name;

            string IsMaster;

            try
            {
                IsMaster = PhotonNetwork.IsMasterClient.ToString();
            }
            catch
            {
                IsMaster = "ERROR";
            }

            Logger.WriteRequest(filename, date, now.Hour, now.Minute, now.Second, now.Millisecond,
                pos.x, pos.y, pos.z,
                rot.x, rot.y, rot.z, rot.w,
                sceneName,
                IsMaster);
        }
    }
}
