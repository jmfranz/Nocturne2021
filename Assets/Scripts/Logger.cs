using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Logger : MonoBehaviour
{
    public static Dictionary<string, List<string>> Buffer;
    public float WriteWaitTime = 1;
    public int MaxAudioTime = 3;

    private static Dictionary<string, string> _headers;
    private static string _userId = "0";
    private float _elapsedTime = 0;
    private bool _logFileSetUp = false;
    private AudioClip _audioClip;

    public static void SetUserID(string newID)
    {
        _userId = newID;
    }

    public static string GetUserID()
    {
        return _userId ?? "noID";
    }

    public static void AddHeaderRequest(string filename, params string[] columnNames)
    {
        _headers ??= new Dictionary<string, string>();

        var line = "UserID,";

        for (int i = 0; i < columnNames.Length; i++)
        {
            line += columnNames[i];
            if (i < columnNames.Length - 1)
                line += ",";
        }

        _headers.Add(filename, line);
        Debug.Log(_headers[filename]);
    }

    public static void WriteRequest(string filename, params object[] content)
    {
        Buffer ??= new Dictionary<string, List<string>>();

        if (!Buffer.ContainsKey(filename))
        {
            Buffer.Add(filename, new List<string>());
        }

        var line = _userId + ",";

        for (int i = 0; i < content.Length; i++)
        {
            line += content[i].ToString();
            if (i < content.Length - 1)
                line += ",";
        }

        Buffer[filename].Add(line);
    }

    // Update is called once per frame
    void Update()
    {
        if (_elapsedTime >= WriteWaitTime)
        {
            _elapsedTime = 0;

            var BufferKeys = Buffer.Keys;

            foreach (var k in BufferKeys)
            {
                string idk = _userId.ToString() + "-" + k;

                string path = Path.Combine(Application.persistentDataPath, idk);


                if (!File.Exists(path))
                {
                    StreamWriter swh = File.CreateText(path);

                    if (_headers.ContainsKey(k))
                    {
                        swh.WriteLine(_headers[k]);
                    }

                    swh.Close();
                }

                StreamWriter sw = new StreamWriter(path, true);

                foreach (var s in Buffer[k])
                {
                    sw.WriteLine(s);
                }

                sw.Close();

                Buffer[k].Clear();
            }
        }

        _elapsedTime += Time.deltaTime;

    }

}
