/*
 * Author: Abbey Singh
 * This script will read from a JSON file when the last write time for the file has changed.
 */

using UnityEngine;
using System.IO;

//This script is executed in Edit mode (so it does not have to be run)
[ExecuteInEditMode]
public class EditorSaveLoadUI : MonoBehaviour
{
    string directoryPath;
    string filePath;

    //Save the time MappingData.json was last modified
    long lastChangedDateTime;

    //singleton
    private static EditorSaveLoadUI _instance;
    public static EditorSaveLoadUI Instance
    {
        get
        {
            if (_instance == null)
            {
                var singletonObject = GameObject.Find("GameManager");
                _instance = singletonObject.AddComponent<EditorSaveLoadUI>();
            }
            return _instance;
        }
    }

    private void Awake()
    {
        #if UNITY_STANDALONE_OSX
            directoryPath = "/Library/SpaceSyntaxData/";
        #endif

        #if UNITY_STANDALONE_WIN
            directoryPath = "/SpaceSyntaxData/";
        #endif

        #if UNITY_STANDALONE_LINUX
            directoryPath = "~/SpaceSyntaxData/";
        #endif

        //for editor
        #if UNITY_EDITOR_OSX
                directoryPath = "/Library/SpaceSyntaxData/";
        #endif
        #if UNITY_EDITOR_WIN
                directoryPath = "/SpaceSyntaxData/";
        #endif
        #if UNITY_EDITOR_LINUX
                directoryPath = "~/SpaceSyntaxData/";
        #endif

        filePath = directoryPath + "Stories.json";

        //Make sure directory exists
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        //Make sure file exists
        if (!File.Exists(filePath))
        {
            File.Create(filePath).Dispose();
        }

        lastChangedDateTime = File.GetLastWriteTime(filePath).Ticks;

    }

    void Update()
    {
        //Check if MappingData.json has been written to since it was last read from
        if (lastChangedDateTime != File.GetLastWriteTime(filePath).Ticks && Application.isEditor)
        {
            lastChangedDateTime = File.GetLastWriteTime(filePath).Ticks;

            //Create rules json for each story
            StoryToRulesInterface.Instance.PopulateRules();
        }
    }

    //Read data from json
    public Stories Load()
    {
        //Holds data from Stories.json
        string jsonData;

        //Read the database file if it exists
        if (File.Exists(filePath))
        {
            jsonData = File.ReadAllText(filePath);
            return JsonUtility.FromJson<Stories>(jsonData);
        }
        else
        {
            Debug.LogErrorFormat("File is missing: '{0}' ", filePath);
            return null;
        }
    }
}
