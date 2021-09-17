/*
 * @Author Abbey Singh
 * This script will create a new scene, when a json file has been added
 * This script will update an existing scene, when a json file has been modified
 */

using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System;
using UnityEditor.SceneManagement;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

[ExecuteInEditMode]
[Serializable]
public class CreateScene : MonoBehaviour
{
    string directoryPath;

    // Holds the names of files that have scenes created for them
    [SerializeField]
    public static Dictionary<string, long> CreatedScenesDateTime = new Dictionary<string, long>();

    [SerializeField]
    public List<string> CreatedSceneName = new List<string>();

    List<string> objectNamesNotToBeDeleted = new List<string> {"Game Handler", "Directional Light", "Exclude Regions",
                                                            "EventSystem", "OVRPlayerController", "Test"};

    // singleton
    private static CreateScene _instance;
    public static CreateScene Instance
    {
        get
        {
            if (_instance == null)
            {
                var singletonObject = GameObject.Find("Game Handler");
                _instance = singletonObject.AddComponent<CreateScene>();
            }
            return _instance;
        }
    }

    void Awake()
    {
       // for standalone
        #if UNITY_STANDALONE_OSX
            directoryPath = "/Library/SpaceSyntaxData/Scenes/";
        #endif

        #if UNITY_STANDALONE_WIN
            directoryPath = "/SpaceSyntaxData/Scenes/";
        #endif

        #if UNITY_STANDALONE_LINUX
            directoryPath = "~/SpaceSyntaxData/Scenes/";
        #endif

        // for editor
        #if UNITY_EDITOR_OSX
                directoryPath = "/Library/SpaceSyntaxData/Scenes/";
        #endif
        #if UNITY_EDITOR_WIN
                directoryPath = "/SpaceSyntaxData/Scenes/";
        #endif
        #if UNITY_EDITOR_LINUX
                directoryPath = "~/SpaceSyntaxData/Scenes/";
        #endif

        // Make sure directory exists
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Application.isEditor && !Application.isPlaying)
        {
            var files = new DirectoryInfo(directoryPath).GetFiles();

            foreach(var file in files)
            {
                string fileName = file.ToString().Substring(file.ToString().LastIndexOf('\\') + 1);
                fileName = fileName.Substring(0, fileName.Length - Path.GetExtension(fileName).Length);

                //Read the instructions
                if ("SceneInstructions" == fileName)
                {
                    StreamReader reader = new StreamReader(file.ToString());
                    string data = reader.ReadToEnd();
                    reader.Close();

                    File.Delete(file.ToString());

                    string command = data.Substring(0, data.IndexOf(" "));
                    string name = data.Substring(data.IndexOf(" ") + 1);

                    //Removes "/r/n"
                    name = name.Substring(0, name.LastIndexOf('.'));

                    string scenePath = "Assets/Scenes/SavedScenes/" + name + ".unity";

                    string filePath = Path.GetPathRoot(Application.dataPath)+"SpaceSyntaxData\\Scenes\\" + name + ".json";

                    if (command == "CREATE")
                    {
                        EditorSceneManager.SaveScene(EditorSceneManager.GetActiveScene(), scenePath, false);
                        EditorSceneManager.OpenScene(scenePath, OpenSceneMode.Single);
                        ClearScene();
                        CreatedSceneName.Add(name);
                        PopulateScene(filePath.ToString(), name);
                    }
                    else if (command == "UPDATE")
                    {
                        EditorSceneManager.OpenScene(scenePath, OpenSceneMode.Single);
                        ClearScene();
                        PopulateScene(filePath.ToString(), name);
                    }

                    break;
                }

            }

            //Check if any files should be deleted
            var jsonFiles = new DirectoryInfo(directoryPath).GetFiles();

            string[] sceneNames = Directory.GetFiles(Application.dataPath + "/" + "/Scenes/SavedScenes/");

            bool jsonFileExists;
            for(int i = 0; i < sceneNames.Length; i++)
            {

                if (sceneNames[i].Contains(".meta"))
                {
                    continue;
                }

                //Get the file name out of the path
                string sceneName = sceneNames[i].Substring(sceneNames[i].LastIndexOf('/') + 1);
                sceneName = sceneName.Substring(0, sceneName.Length - Path.GetExtension(sceneName).Length);


                jsonFileExists = false;
                foreach (var jsonFile in jsonFiles)
                {
                    //get json file name from path
                    string jsonName = jsonFile.ToString().Substring(jsonFile.ToString().LastIndexOf('\\') + 1);
                    jsonName = jsonName.Substring(0, jsonName.Length - Path.GetExtension(jsonName).Length);

                    if (sceneName == jsonName)
                    {
                        jsonFileExists = true;
                    }
                }

                //Delete the scene since the json file has been removed
                if (!jsonFileExists)
                {
                    File.Delete(Application.dataPath + "/" + "/Scenes/SavedScenes/" + sceneName + ".unity");
                }
            }
        }
    }


    void ClearScene()
    {
        GameObject [] gameObjectsToDestroy = FindObjectsOfType<GameObject>();
        for (int i = 0; i < gameObjectsToDestroy.Length; i++)
        {
            var gameObject = gameObjectsToDestroy[i];

            // cases where we don't want the gameobject to be deleted
            if(gameObject == null || gameObject.transform.parent != null || objectNamesNotToBeDeleted.Contains(gameObject.name))
            {
                continue;
            }

            DestroyImmediate(gameObject);
        }
    }

    void PopulateScene(string filePath, string jsonFileName)
    {
        // Holds data from Stories.json
        string jsonData;
        SceneData sceneData;

        // Read the database file if it exists
        if (File.Exists(filePath))
        {
            jsonData = File.ReadAllText(filePath);
            sceneData = JsonUtility.FromJson<SceneData>(jsonData);
        }
        else
        {
            Debug.LogErrorFormat("File is missing: '{0}' ", filePath);
            return;
        }

        // Create the VR player controller TODO: Change when expanding to more deployment targets
        Instantiate(Resources.Load("VRPlayer/VRPlayerController") as GameObject);

        // Create the map
        string mapName = jsonFileName.Substring(jsonFileName.LastIndexOf("-") + 1);
        mapName = ChangeUnderscoreToSpace(mapName);

        // Generate the path of the avatar to be generated.
        string mapPath = "Maps/" + mapName;

        // Implement a try catch to ensure that an invalid map path does not break the rest of the script.
        try
        {
            // Load the map from the resources folder
            GameObject obj = Instantiate(Resources.Load(mapPath) as GameObject);
        }
        catch (Exception ex)
        {
            // Catch the error and log a message to the user
            Debug.Log("Map Path is Invalid");
        }

        for (int i = 0; i < sceneData.ObjectName.Count; i++)
        {
            GameObject obj = null;

            // Instantiating based off spawnObject.cs "setGameObject" method
            if (sceneData.ObjectReference[i].Contains("Avatar") )
            {
                // Generate the path of the avatar to be generated.
                string avatarPath = sceneData.ObjectReference[i] + "/Export/" + sceneData.ObjectReference[i].Split('/')[1];

                // Implement a try catch to ensure that an invalid avatar path does not break the rest of the script.
                try
                {
                    // Load the avatar as specified in the Json File
                    obj = AvatarInstaller.InstantiateAvatar(avatarPath);
                }
                catch (Exception ex)
                {
                    // Catch the error and log a message to the user
                    Debug.Log("Avatar Path is Invalid");
                    obj = null;
                }   
            }
            else if (sceneData.ObjectReference[i].Contains("Music"))
            {
                obj = new GameObject();
                obj.tag = "Game Object";

                // Add generic game object script to the game object
                obj.AddComponent<genericGameObject>();
                obj.AddComponent<VirtualProxemicTracker>();

                // Attach an audio clip to the Avatar Game Object.
                AudioSource audioSource = obj.AddComponent<AudioSource>() as AudioSource;

                // Spawn the audioClip defined by the path in the config file
                AudioClip audioClip = Resources.Load<AudioClip>(sceneData.ObjectReference[i]);

                // Attach the clip to the audio source.
                audioSource.clip = audioClip;

                // NOTE: THIS IS WHY THE AUDIO PLAYS AS SOON AS THE SCENE STARTS.  SET THIS TO FALSE WHEN USING THE PROXIMITY TRIGGERS.
                audioSource.playOnAwake = true;

                // Make this audio source a fully 3D sound object by default.
                audioSource.spatialBlend = 1.0f;
            }
            else if(sceneData.ObjectReference[i].Contains("NewObjects"))
            {
                // Implement a try catch to ensure that an invalid avatar path does not break the rest of the script.
                try
                {
                    // Load the avatar as specified in the Json File
                    obj = Instantiate(Resources.Load(sceneData.ObjectReference[i]) as GameObject);
                }
                catch (Exception ex)
                {
                    // Catch the error and log a message to the user
                    Debug.Log("Object Path is Invalid");
                    obj = null;
                }
            }
            else if (sceneData.ObjectReference[i].Contains("ConversationNodeData"))
            {
                // Implement a try catch to ensure that an invalid avatar path does not break the rest of the script.
                try
                {
                    // Load the avatar as specified in the Json File
                    obj = new GameObject();
                }
                catch (Exception ex)
                {
                    // Catch the error and log a message to the user
                    Debug.Log("Object Path is Invalid");
                    obj = null;
                }
            }

            // It is an avatar or music
            if (obj != null)
            {
                obj.name = sceneData.ObjectName[i];
                TransformStoryElement transformStoryElement = sceneData.ObjectTransforms[i];

                // set position of object
                obj.transform.localPosition = new Vector3(transformStoryElement.Position[0], 
                    transformStoryElement.Position[1], transformStoryElement.Position[2]);
            }
        }

        ConversationInstaller.LoadStoryJsonData();
        EventInstaller.LoadStoryJsonData();

        //Add ProxemicUI Host
        GameObject.Find("Game Handler").AddComponent<StoryProxemicUIHost>();
    }

    string ChangeUnderscoreToSpace(string word)
    {
        return word.Replace("_", " ");
    }
}
