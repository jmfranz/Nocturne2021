/*
 * @Author: Abbey Singh
 * This will be used to save the current state into a json file.
 */
 
using UnityEngine;
using System.IO;

public class SaveScene : MonoBehaviour
{
    string directoryPath, filePath;

    // Start is called before the first frame update
    void Start()
    {
        //for editor
        #if UNITY_EDITOR_OSX
            directoryPath = "/Library/SpaceSyntaxData/Scenes/";
        #endif
        #if UNITY_EDITOR_WIN
            directoryPath = "/SpaceSyntaxData/Scenes/";
        #endif
        #if UNITY_EDITOR_LINUX
           directoryPath = "~/SpaceSyntaxData/Scenes/";
        #endif

        //for Standalone
        #if UNITY_STANDALONE_OSX
            directoryPath = "/Library/SpaceSyntaxData/Scenes/";
        #endif
        #if UNITY_STANDALONE_WIN
            directoryPath = "/SpaceSyntaxData/Scenes/";
        #endif
        #if UNITY_STANDALONE_LINUX
            directoryPath = "~/SpaceSyntaxData/Scenes/";
        #endif

        //Make sure directory exists
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }
    }

    public void SaveSceneToJSON()
    {
        //name is in the format title-author-mapName.json
        filePath = directoryPath + GameState.Instance.GetCurrentStoryData().Title + "-" + GameState.Instance.GetCurrentStoryData().Author
                + "-" + SpaceReplacedWithUnderScore(GameState.Instance.GetCurrentStoryData().MapSelected) + ".json";

        //Update scene data
        SceneData.Instance.UpdateSceneData();

        //Make sure file exists
        string path = directoryPath + "SceneInstructions.txt";
        StreamWriter writer = new StreamWriter(path, true);

        if (!File.Exists(filePath))
        {
            //Instructions for creating scenes
            string message = "CREATE " + GameState.Instance.GetCurrentStoryData().Title + "-" + GameState.Instance.GetCurrentStoryData().Author
                + "-" + SpaceReplacedWithUnderScore(GameState.Instance.GetCurrentStoryData().MapSelected) + ".json";
            writer.WriteLine(message);
        }
        else
        {
            //Instructions for updating scenes
            string message = "UPDATE " + GameState.Instance.GetCurrentStoryData().Title + "-" + GameState.Instance.GetCurrentStoryData().Author
                + "-" + SpaceReplacedWithUnderScore(GameState.Instance.GetCurrentStoryData().MapSelected) + ".json";
            writer.WriteLine(message);
        }
        writer.Close();


        //Save scene data to json file
        string json = JsonUtility.ToJson(SceneData.Instance);

        //Write the text to the database file
        File.WriteAllText(filePath, json);

        //Quit running application in the editor
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    string SpaceReplacedWithUnderScore(string word)
    {
        return word.Replace(" ", "_");
    }
}
