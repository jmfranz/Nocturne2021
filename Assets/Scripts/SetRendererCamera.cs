/*
 * @Author: Abbey Singh
 * This script will be used in the rules placement screen to control the display of maps.
 * To add more maps there are instructions below on creating a new map and camera prefab. 
 * Once you have created a new map and camera prefab, select the GameObject in the hierarchy called "ChooseMap" dropdown menu.
 * In the inspector window, increase the size of "Map Prefabs" and "Camera Prefabs" by one and drag your prefabs into their respective folders. 
 */


using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetRendererCamera : MonoBehaviour
{
    /*
     * Creating a new map prefab can be done by:
     * 1. Make sure the Map name is the exact same as the name that you gave to the graph file.
     * 
     */
    public List<GameObject> MapPrefabs;

    /*
     * Creating a new camera prefab can be done by:
     * 1. In the Assets folder > Maps > CameraPrefabs
     * 2. Drag one of the CameraPrefabs into the hierarchy, duplicate, and rename it.
     * 3. Ensuring only the mapPrefab you are concerned with is active in the scene, adjust the camera size until your map is in full view.
     * 4. You may also need to adjust the object's position to center it better.
     * 5. Save the camera component by creating a prefab variant (drag the Camera GameObject from the hierarchy) in the folder "CameraPrefabs".
     */ 
    public List<GameObject> CameraPrefabs;

    //Holds index of the current map
    int currentIndex;

    //Current map as shown by json file
    string mapName = "";

    //We want the ability to reload placement rules
    public UserInput UserInput;

    public GameObject MapImage;

    //Initialize which map is selected based on the current story and map.
    void Start()
    {
        StandaloneSaveLoad.Instance.Load();
    }

    //Occurs every frame
    void Update()
    {
        //Current story could have changed
        if(mapName != GameState.Instance.GetCurrentStoryData().MapSelected)
        {
            mapName = GameState.Instance.GetCurrentStoryData().MapSelected;

            //set value of map in dropdown
            List<TMP_Dropdown.OptionData> options = this.GetComponent<TMP_Dropdown>().options;
            for(int i = 0; i < options.Count; i++)
            {
                if(options[i].text == mapName)
                {
                    this.GetComponent<TMP_Dropdown>().value = i;
                }
            }
        } 
    }

    void SetMapWithName(string name)
    {
        for (int i = 0; i < MapPrefabs.Count; i++)
        {
            if (MapPrefabs[i].name == name)
            {
                RemoveCurrentMap();
                AddNewMap(i);
                break;
            }
        }
    }

    //Called when the dropdown option has changed value
    public void ChangeMap()
    {
        string name = this.GetComponent<TMP_Dropdown>().options[this.GetComponent<TMP_Dropdown>().value].text;
        mapName = name;
        GameState.Instance.GetCurrentStoryData().MapSelected = mapName;
        StandaloneSaveLoad.Instance.Save();
        SetMapWithName(name);
    }


    //Removes the current map prefab and it's corresponding camera
    void RemoveCurrentMap()
    {
        Destroy(GameObject.Find(MapPrefabs[currentIndex].name));
        Destroy(GameObject.Find(CameraPrefabs[currentIndex].name));
    }

    //Adds a new map prefab and it's corresponding camera given by the specified index
    void AddNewMap(int index)
    {
        Instantiate(MapPrefabs[index]);
        Instantiate(CameraPrefabs[index]);

        //Our current index now points to the new map
        currentIndex = index;

        //Apply new rules to new map
        UserInput.SetInputs();
    }
}
