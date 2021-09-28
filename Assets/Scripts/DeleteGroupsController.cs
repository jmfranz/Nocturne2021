/*
 * Author: Abbey Singh
 * This script will control the delete group screen.
 */

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DeleteGroupsController : MonoBehaviour
{
    //Prefab for view stories page
    public GameObject StoryElementGameObject;
    public Transform StoryElementTransform; //copy of original position

    public List<GameObject> Groups = new List<GameObject>();
    public GameObject Content;

    public ViewStoryElementsController ViewStoryElementsController;
    public ControlStandalone ControlStandalone;

    public GameObject ScrollBarVertical;

    public void PopulateAllgroups()
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

            List<string> groups = new List<string>();

            foreach (var group in tempStoryData.GetGroups())
            {
                groups.Add(group.GroupName);
            }

            StoryElementGameObject.SetActive(true);

            //Go through all story elements
            for (int i = 0; i < groups.Count; i++)
            {
                //Set name for prefab
                GameObject name = StoryElementGameObject.transform.GetChild(1).GetChild(1).gameObject;
                name.GetComponent<Text>().text = groups[i];

                //Get position of prefab
                Vector3 pos = StoryElementTransform.GetComponent<RectTransform>().localPosition;

                //Instantiate a new GameObject
                //Subtract 100 due to offset
                GameObject newStoryPair = Instantiate(StoryElementGameObject, new Vector3(0, pos.y + i * yJump - 10, pos.z), StoryElementTransform.rotation);
                newStoryPair.transform.SetParent(StoryElementGameObject.transform.parent.transform, false);

                Groups.Add(newStoryPair);
            }

            StoryElementGameObject.SetActive(false);

            //Update the height of the container (this) to hold enough rows of audio buttons
            int dynamicHeight = Math.Abs(yJump * groups.Count);

            RectTransform rT = Content.GetComponent<RectTransform>();
            rT.sizeDelta = new Vector2(rT.sizeDelta.x, dynamicHeight);
        }
    }

    public void ClearStoryElements()
    {
        for (int i = 0; i < Groups.Count; i++)
        {
            Destroy(Groups[i]);
        }

        //Make list empty
        Groups.Clear();
    }

    public void OnSave()
    {
        StoryData currentStoryData = GameState.Instance.GetCurrentStoryData();

        //check which story elements have been selected 
        List<string> groupsToRemove = new List<string>();

        GameObject storyElementsParent = StoryElementGameObject.transform.parent.gameObject;

        //Goes through all children of storyElementsParent
        //Finds which children were selected
        foreach (Transform child in storyElementsParent.transform)
        {
            if (child.gameObject.activeSelf)
            {
                // Story element should be part of the group
                GameObject Toggle = child.GetChild(1).gameObject;
                if (Toggle.GetComponent<Toggle>().isOn)
                {
                    groupsToRemove.Add(Toggle.transform.GetChild(1).GetComponent<Text>().text);
                }
            }
        }

        currentStoryData.RemoveGroups(groupsToRemove);

        StandaloneSaveLoad.Instance.Save();
        ClearStoryElements();

        ViewStoryElementsController.PopulateViewStoryElements();
        ControlStandalone.GoToScreen("ViewStoryElementsScreen");
    }

    public void OnCancel()
    {
        ClearStoryElements();
        ViewStoryElementsController.PopulateViewStoryElements();
    }
}
