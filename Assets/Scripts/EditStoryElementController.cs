/*
 * Author: Abbey Singh
 * This script will control edit story element screen.
 */

using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class EditStoryElementController : MonoBehaviour
{
    // Reference to UI gameobjects, transforms, inputs
    public GameObject StoryElementsGroupGameObject;
    public Transform StoryElementsGroupTransform; //copy of original position
    public GameObject GroupGameObject;
    public Transform GroupTransform; //copy of original position
    public TMP_InputField Name;
    public TMP_InputField Filter;

    // Reference to other scripts
    public ViewStoryElementsController ViewStoryElementsController;
    public ControlStandalone ControlStandalone;
    public PrioritizeAttributes PrioritizeAttributes;

    // Local list of groups
    List<GameObject> currentGroups = new List<GameObject>();
    List<GameObject> groups = new List<GameObject>();
    List<string> groupList;

    string _nameFilter;
    StoryElement currentStoryElement;

    // Called when the value of filter changes
    public void SetFilter()
    {
        _nameFilter = Filter.GetComponent<TMP_InputField>().text;
        ClearAllGroups();
        PopulateAllGroups();
    }

    public void SetUpEditStoryPage()
    {
        currentStoryElement = GameState.Instance.GetCurrentStoryElement();

        //create new lists
        groupList = new List<string>();
        groupList = currentStoryElement.GetGroups();

        //set name to current story elements name
        Name.GetComponent<TMP_InputField>().text = GameState.Instance.GetCurrentStoryElement().Name;

        //Show current story elements groups
        PopulateStoryElements(groupList);

        //show all groups
        PopulateAllGroups();
        _nameFilter = "";
    }

    //This shows current groups for the given story element
    public void PopulateStoryElements(List<string> groups)
    {
        ClearCurrentGroups();

        //Set prefab to false
        StoryElementsGroupGameObject.SetActive(true);

        for (int i = 0; i < groups.Count; i++)
        {
            //Set name for prefab
            GameObject name = StoryElementsGroupGameObject.transform.GetChild(0).gameObject;
            name.GetComponent<TextMeshProUGUI>().text = groups[i];

            //Get position of prefab
            Vector3 pos = StoryElementsGroupTransform.GetComponent<RectTransform>().localPosition;

            int yJump = -30;
            int xJump;

            if(i%2 == 0)
            {
                xJump = 0;
            }
            else
            {
                xJump = 100;
            }

            //Instantiate a new GameObject
            GameObject newStoryPair = Instantiate(StoryElementsGroupGameObject, new Vector3(pos.x + xJump, -10 + Mathf.Floor(i/2) * yJump, pos.z), StoryElementsGroupTransform.rotation);
            newStoryPair.transform.SetParent(StoryElementsGroupGameObject.transform.parent.transform, false);

            currentGroups.Add(newStoryPair);
        }

        //Set prefab to false
        StoryElementsGroupGameObject.SetActive(false);
    }

   public void PopulateAllGroups()
   {
        ClearAllGroups();

        StoryData currentStoryData = GameState.Instance.GetCurrentStoryData();
        GroupGameObject.SetActive(true);

        List<string> storyDataGroups = new List<string>();

        foreach(var group in currentStoryData.GetGroups())
        {
            storyDataGroups.Add(group.GroupName);
        }

        int index = 0;

        for (int i = 0; i < storyDataGroups.Count; i++)
        {
            bool isFilteredOut = false;

            //Name Filter
            if (_nameFilter != "" && _nameFilter != null)
            {
                isFilteredOut = storyDataGroups[i].IndexOf(_nameFilter, StringComparison.OrdinalIgnoreCase) < 0; //ignores case when checking if filter is contained by name
            }

            if (isFilteredOut)
            {
                continue;
            }

            //Set name for prefab
            GameObject name = GroupGameObject.transform.GetChild(0).gameObject;
            name.GetComponent<TextMeshProUGUI>().text = storyDataGroups[i];

            //Get position of prefab
            Vector3 pos = StoryElementsGroupTransform.GetComponent<RectTransform>().localPosition;

            //Each story should have a y value that differs by 30
            int yJump = -30;

            //Instantiate a new GameObject
            GameObject newStoryPair = Instantiate(GroupGameObject, new Vector3(pos.x + 74, -15 + yJump * index, pos.z), GroupTransform.rotation);
            newStoryPair.transform.SetParent(GroupGameObject.transform.parent.transform, false);

            
            groups.Add(newStoryPair);

            index++;
        }

        GroupGameObject.SetActive(false);
    }

    public void ClearAllGroups()
    {
        foreach(var group in groups)
        {
            Destroy(group);
        }

        groups.Clear();
    }

    //Delete GameObjects from the scene
    public void ClearCurrentGroups()
    {
        for (int i = 0; i < currentGroups.Count; i++)
        {
            Destroy(currentGroups[i]);
        }

        //Make list empty
        currentGroups.Clear();
    }

    public void OnSave()
    {
        string nameInputted = Name.GetComponent<TMP_InputField>().text;
        GameState.Instance.GetCurrentStoryData().ChangeNameOfStoryElement(
                                                GameState.Instance.GetCurrentStoryElement().Name, nameInputted);
        
        StandaloneSaveLoad.Instance.Save();
        ClearEditStoryPage();

        ViewStoryElementsController.PopulateViewStoryElements();
        ControlStandalone.GoToScreen("ViewStoryElementsScreen");
    }

    public void OnCancel()
    {
        ClearEditStoryPage();
        ViewStoryElementsController.PopulateViewStoryElements();
    }

    void ClearText()
    {
        Name.GetComponent<TMP_InputField>().text = "";
        Filter.GetComponent<TMP_InputField>().text = "";
    }

    void ClearEditStoryPage()
    {
        ClearCurrentGroups();
        ClearAllGroups();
        ClearText();
    }

    public void AddGroup(GameObject group) 
    {
        string groupName = group.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;

        //Add new group
        if (!groupList.Contains(groupName))
        {
            //groupList.Add(groupName);
            currentStoryElement.AddGroup(groupName);

            ClearCurrentGroups();
            PopulateStoryElements(groupList);

            PrioritizeAttributes.PopulateAttributesInPriority();
        }
    }

    //delete UI tag and remove group
    public void OnDelete(GameObject tag)
    {
        string name = tag.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text;

        if (groupList.Contains(name))
        {
            currentStoryElement.RemoveGroup(name);
            groupList.Remove(name);
            PrioritizeAttributes.PopulateAttributesInPriority();
            PopulateStoryElements(groupList);
        }

        Destroy(tag);
    }
}
