/*
 * Author: Abbey Singh
 * This script will control the screen for creating a new group.
 */

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class AddGroupController : MonoBehaviour
{
    //Prefab for view stories page
    public GameObject StoryElementGameObject;
    public Transform StoryElementTransform; //copy of original position

    public TMP_InputField GroupName;
    public Toggle Toggle;

    public GameObject WarningText;

    public ViewStoryElementsController ViewStoryElementsController;
    public SpaceSyntaxStoryElementController SpaceSyntaxStoryElementController;
    public ControlStandalone ControlStandalone;

    public List<GameObject> StoryElements = new List<GameObject>();
    public GameObject Content;

    public GameObject ScrollBarVertical;

    GameObject storyElementsParent;

    void Start()
    {
        WarningText.SetActive(false);
    }

    public void PopulateStoryElements()
    {
        //Reset Scroll Bar
        ScrollBarVertical.GetComponent<Scrollbar>().value = 1;

        //List of all stories from json file
        Stories tempStoryHolder = StandaloneSaveLoad.Instance.Load();

        StoryData tempStoryData = null;

        foreach (var storyData in tempStoryHolder.GetStories())
        {
            if (storyData.Title == GameState.Instance.GetCurrentStoryData().Title &&
                storyData.Author == GameState.Instance.GetCurrentStoryData().Author)
            {
                tempStoryData = storyData;
                break;
            }
        }

        if (tempStoryData != null)
        {
            //Each story should have a y value that differs by yJump
            int yJump = -45;

            List<StoryElement> tempStoryElementList = tempStoryData.GetStoryElements();

            StoryElementGameObject.SetActive(true);

            //Go through all story elements
            for (int i = 0; i < tempStoryElementList.Count; i++)
            {
                //Set name for prefab
                GameObject name = StoryElementGameObject.transform.GetChild(1).GetChild(1).gameObject;
                name.GetComponent<Text>().text = tempStoryElementList[i].Name;

                //Get position of prefab
                Vector3 pos = StoryElementTransform.GetComponent<RectTransform>().localPosition;

                //Instantiate a new GameObject
                //Subtract 100 due to offset
                GameObject newStoryPair = Instantiate(StoryElementGameObject, new Vector3(0, pos.y + i * yJump - 10, pos.z), StoryElementTransform.rotation);
                newStoryPair.transform.SetParent(StoryElementGameObject.transform.parent.transform, false);

                StoryElements.Add(newStoryPair);
            }

            StoryElementGameObject.SetActive(false);

            //Update the height of the container (this) to hold enough rows of audio buttons
            int dynamicHeight = Math.Abs(yJump * tempStoryElementList.Count);

            RectTransform rT = Content.GetComponent<RectTransform>();
            rT.sizeDelta = new Vector2(rT.sizeDelta.x, dynamicHeight);
        }
    }

    //Delete GameObjects from the scene
    public void ClearStoryElements()
    {
        for (int i = 0; i < StoryElements.Count; i++)
        {
            Destroy(StoryElements[i]);
        }

        //Make list empty
        StoryElements.Clear();

    }

    void Clear()
    {
        ClearStoryElements();
        ClearText();
    }

    public void OnSave()
    {
        string nameInputted = GroupName.GetComponent<TMP_InputField>().text;
        StoryData currentStoryData = GameState.Instance.GetCurrentStoryData();

        if (currentStoryData.AddGroup(nameInputted))
        {
            //check which story elements have been selected and set their group name to 'nameInputted'
            List<StoryElement> storyElementsInGroup = new List<StoryElement>();

            storyElementsParent = StoryElementGameObject.transform.parent.gameObject;

            //Goes through all children of storyElementsParent
            //Finds which children were selected
            foreach(Transform child in storyElementsParent.transform)
            {
                if(child.gameObject.activeSelf)
                {
                    // Story element should be part of the group
                    GameObject Toggle = child.GetChild(1).gameObject;
                    if (Toggle.GetComponent<Toggle>().isOn)
                    {
                        storyElementsInGroup.Add(currentStoryData.FindStoryElement(
                            Toggle.transform.GetChild(1).GetComponent<Text>().text));
                    }
                }
                
            }

            currentStoryData.SetGroup(storyElementsInGroup, nameInputted);
            StandaloneSaveLoad.Instance.Save();
            StandaloneSaveLoad.Instance.Load();
            Clear();

            WarningText.SetActive(false);
            ControlStandalone.GoToScreen("ViewStoryElementsScreen");

        }
        else
        {
            WarningText.SetActive(true);
        }
    }

    public void OnCancel()
    {
        Clear();
        ViewStoryElementsController.PopulateViewStoryElements();
    }

    void ClearText()
    {
        GroupName.GetComponent<TMP_InputField>().text = "";
    }
}
