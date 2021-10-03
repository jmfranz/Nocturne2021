using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Logger : MonoBehaviour
{
    public static Dictionary<string, List<string>> Buffer;
    private static Dictionary<string, string> Headers;

    public float WriteWaitTime = 1;
    private float elapsedTime = 0;

    public static void AddHeaderRequest(string filename, params string[] columnNames)
    {
        if (Headers == null)
            Headers = new Dictionary<string, string>();

        string line = "";

        for (int i = 0; i < columnNames.Length; i++)
        {
            line += columnNames[i];
            if (i < columnNames.Length - 1)
                line += ",";
        }

        Headers.Add(filename, line);
        Debug.Log(Headers[filename]);
    }

    public static void WriteRequest(string filename, params object[] content)
    {
        if (Buffer == null)
            Buffer = new Dictionary<string, List<string>>();

        if (!Buffer.ContainsKey(filename))
        {
            Buffer.Add(filename, new List<string>());
        }

        string line = "";

        for (int i = 0; i < content.Length; i++)
        {
            line += content[i].ToString();
            if (i < content.Length - 1)
                line += ",";
        }

        Buffer[filename].Add(line);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (elapsedTime >= WriteWaitTime)
        {
            elapsedTime = 0;

            var BufferKeys = Buffer.Keys;

            foreach (var k in BufferKeys)
            {
                string path = Path.Combine(Application.persistentDataPath, k);


                if (!File.Exists(path))
                {
                    StreamWriter swh = File.CreateText(path);

                    if (Headers.ContainsKey(k))
                    {
                        swh.WriteLine(Headers[k]);
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

        elapsedTime += Time.deltaTime;
    }
}