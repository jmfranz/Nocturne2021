using System.Collections.Generic;
using UnityEngine;

/* Author: Jake Moore
 * The purpose of this class is to allow the user to apply mapping, and switch maps in the editor panel. 
 * It uses [ExecuteInEditMode] to allow for running of functions without playing the game.
 * The rest of the code controls the boolean check boxes resetting, and the resetting/generation of game objects
 * when a new mapping is applied.
 */

[ExecuteInEditMode]
public class UserInput : MonoBehaviour {
    public bool positionObjects = false;
    private Texture2D compositeMap;
    public string fileName;
    public List<GameObject> Prefabs;
    public bool applyMap = false;
    public GameObject GameHandler;

    /*To add a new map, first create a new entry in the enum, such as:
     * public enum mapSelectorEnum { monaCampbell, goldberg, NewMap };
     */
    public enum mapSelectorEnum { monaCampbell, goldberg };
    public mapSelectorEnum mapSelector;

    public ContourMap ContourMap;
    public StoryToRulesInterface StoryToRulesInterface;

    public linearSort LinearSort;

    //Call this to set inputs
    public void SetInputs()
    {
        AddAttributeController.UnSavedChanges = false;

        LinearSort.ClearPointsAlreadyUsed();

        StoryToRulesInterface.PopulateRules();
        StandaloneSaveLoad.Instance.Save();

        Stories stories = EditorSaveLoadDemo.Instance.Load();
        string mapSelected = stories.CurrentStory.MapSelected;

        fileName = "Rules/" + stories.CurrentStory.Title + "-" + stories.CurrentStory.Author + ".json";

        if(mapSelected == "Mona Campbell")
        {
            ContourMap.SetCompositeMap(Prefabs[0]);
            switchMap(Prefabs[0]);
        }
        else
        {
            ContourMap.SetCompositeMap(Prefabs[1]);
            switchMap(Prefabs[1]);
        }

        removeGameObjectsInScene("Sphere");
        removeGameObjectsInScene("Game Object");
        removeGameObjectsInScene("Exclude Regions");
        createGameHandler();
    }

    private void createGameHandler () {
        //set the file name, start the loadjson script to game handler
        GameHandler.GetComponent<loadJson> ().setFilePath (fileName);
        GameHandler.GetComponent<loadJson> ().loadJsonFile ();
    }

    //removes all game objects in the scene based on its tag
    private void removeGameObjectsInScene (string tag) {
        GameObject[] objList = GameObject.FindGameObjectsWithTag (tag);
        for (int i = 0; i < objList.Length; i++) {
            Destroy(objList[i]);
        }
    }

    //Removes the current map in the scene, and instantiates the selected map.
    private void switchMap (GameObject prefab) {
        GameObject[] mapList = GameObject.FindGameObjectsWithTag ("Map");
        for (int i = 0; i < mapList.Length; i++) {
            DestroyImmediate (mapList[i]);
        }

        Instantiate (prefab, new Vector3 (0, 0, 0), new Quaternion (0, 180, 0, 0));
    }
}