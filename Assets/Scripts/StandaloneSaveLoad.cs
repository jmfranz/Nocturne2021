/*
 * Author: Abbey Singh
 * This script will write to a json file when MainMenu is clicked.  
 */

using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class StandaloneSaveLoad : MonoBehaviour {
    string directoryPath;
    string filePath;

    //Save the time the json file was last modified
    long lastChangedDateTime;

    //singleton
    private static StandaloneSaveLoad _instance;
    public static StandaloneSaveLoad Instance {
        get {
            if (_instance == null) {
                var singletonObject = GameObject.Find ("Game Handler");
                _instance = singletonObject.AddComponent<StandaloneSaveLoad> ();
            }
            return _instance;
        }
    }

    void Awake () {
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

        //for Standalone
        #if UNITY_STANDALONE_OSX
                directoryPath = "/Library/SpaceSyntaxData/";
        #endif
        #if UNITY_STANDALONE_WIN
                directoryPath = "/SpaceSyntaxData/";
        #endif
        #if UNITY_STANDALONE_LINUX
                directoryPath = "~/SpaceSyntaxData/";
        #endif

   
        filePath = directoryPath + "Stories.json";

        //Make sure directory exists
        if (!Directory.Exists (directoryPath)) {
            Directory.CreateDirectory (directoryPath);
        }

        //Make sure file exists
        if (!File.Exists (filePath)) {
            File.Create (filePath).Dispose ();
        }

        RestoreData();
        lastChangedDateTime = File.GetLastWriteTime(filePath).Ticks;
    }

    void Update () {
        //Check if Stories.json has been written to since it was last read from
        if (lastChangedDateTime != File.GetLastWriteTime (filePath).Ticks) {
            lastChangedDateTime = File.GetLastWriteTime (filePath).Ticks;
            Load ();
            StoryToRulesInterface.Instance.PopulateRules();
        }
    }

    //Write data to Stories.json
    public void Save () {
        Stories.Instance.CurrentStory = GameState.Instance.GetCurrentStoryData();
        string json = JsonUtility.ToJson (Stories.Instance);

        //Write the text to the database file
        //Make sure last write time is set to current time
        File.WriteAllText (filePath, json);

        // This line breaks a Linux RunTime of the application.  
        File.SetLastWriteTime (filePath, DateTime.Now);
    }

    //Read data from json
    public Stories Load () {
        //Holds data from Stories.json
        string jsonData;

        //Read the database file if it exists
        if (File.Exists (filePath)) {
            jsonData = File.ReadAllText (filePath);
            return JsonUtility.FromJson<Stories> (jsonData);
        } else {
            Debug.LogErrorFormat ("File is missing: '{0}' ", filePath);
            return null;
        }
    }

    //Let Stories instance hold same info as json file
    void RestoreData () {
        Stories existingStories = Load ();

        if (existingStories != null) {
            List<StoryData> storiesList = existingStories.GetStories ();
            foreach (var story in storiesList) {
                Stories.Instance.AddStory (story);
            }

            foreach(var attribute in existingStories.Attributes)
            {
                if(Stories.Instance.FindAttribute(attribute.AttributeName) == null)
                {
                    Stories.Instance.AddNewAttribute(attribute);
                }
            }

            foreach(var color in existingStories.Colors)
            {
                Stories.Instance.AddColor(color);
            }

            Stories.Instance.CurrentStory = existingStories.CurrentStory;
            Stories.Instance.CurrentStory.RoomController = existingStories.CurrentStory.RoomController;
        }
    }
}
