/*
 * @Author: Abbey Singh
 * This will hold all information required to save and populate a new scene 
 * Notice map is not needed here since it is part of the name of the json file
 */

using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SceneData
{
    public List<string> ObjectName = new List<string>();
    public List<string> ObjectReference = new List<string>();
    public List<TransformStoryElement> ObjectTransforms = new List<TransformStoryElement>();

    //Singleton
    private static SceneData _instance;
    public static SceneData Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new SceneData();
            }
            return _instance;
        }
    }

    public void UpdateSceneData()
    {
        StoryData currentStoryData = GameState.Instance.GetCurrentStoryData();

        //Go through all story elements and find their position in the scene
        //The name of the gameobjects is the story element name
        GameObject[] storyElements = GameObject.FindGameObjectsWithTag("Game Object");
        foreach(GameObject storyElement in storyElements)
        {
            TransformStoryElement objectTransform = new TransformStoryElement(storyElement.name, storyElement.transform);
            ObjectTransforms.Add(objectTransform);
            ObjectName.Add(storyElement.name);

            if(currentStoryData.FindStoryElement(storyElement.name) != null)
            {
                ObjectReference.Add(currentStoryData.FindStoryElement(storyElement.name).Reference);
            }
            else if(currentStoryData.FindConversationNodeData(storyElement.name) != null)
            {
                ObjectReference.Add(currentStoryData.FindConversationNodeData(storyElement.name).Reference);

            }
        }
    }

}
