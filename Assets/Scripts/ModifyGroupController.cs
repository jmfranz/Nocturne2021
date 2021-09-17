/*
 * @Author: Abbey Singh
 * This will provide the funcitonality for the modify a group page.
 */

using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ModifyGroupController : MonoBehaviour
{
    // Gameobjects to use
    public GameObject GroupItem;
    public GameObject StoryElementItem;
    public GameObject ContentGroups;
    public GameObject ContentStoryElements;
    public TMP_InputField GroupName;

    // List of Instantiated GameObjects
    List<GameObject> groupItems = new List<GameObject>();
    List<GameObject> storyElementItems = new List<GameObject>();
    List<Group> groups = new List<Group> ();

    List<StoryElement> storyElementsInGroup = new List<StoryElement>();
    List<StoryElement> storyElementsNotInGroup = new List<StoryElement>();
    readonly int yJump = -50;
    Color unselectedColor = Color.white;
    Color selectedColor = Color.grey;
    string currentGroupName;

    // Save reference to current Stories
    Stories initialStoriesReference = new Stories();

    // Called when Modify Groups Screen is turned active
    void OnEnable()
    {
        StandaloneSaveLoad.Instance.Save();
        initialStoriesReference = StandaloneSaveLoad.Instance.Load();

        PopulateGroups();

        // First group is the one selected
        SetSelectedGroup(1); 
    }

    // Will populate the left scroll view with all the current groups
    void PopulateGroups()
    {
        groupItems = new List<GameObject>();

        Stories stories = StandaloneSaveLoad.Instance.Load();
        groups = stories.CurrentStory.GetGroups();

        if(groups.Count == 0)
        {
            GroupName.interactable = false;
        }
        else
        {
            GroupName.interactable = true;
        }

        GroupItem.SetActive(true);

        // Go through all of the instantiated group items and delete all but the first one
        for(int i = 0; i < GroupItem.transform.parent.childCount; i++)
        {
            GameObject child = GroupItem.transform.parent.GetChild(i).gameObject;
            if (child.name != "Group")
            {
                Destroy(child);
            }
        }

        // Go through all groups for the story
        for (int i = 0; i < groups.Count; i++)
        {
            // Set name for prefab
            GameObject name = GroupItem.transform.GetChild(0).gameObject;
            name.GetComponent<TextMeshProUGUI>().text = groups[i].GroupName;

            // Get position of prefab
            Vector3 pos = GroupItem.GetComponent<RectTransform>().localPosition;

            // Instantiate a new GameObject
            GameObject newGroup = Instantiate(GroupItem, new Vector3(0, pos.y + i * yJump - 10, pos.z), GroupItem.transform.rotation);
            newGroup.transform.SetParent(GroupItem.transform.parent.transform, false);

            groupItems.Add(newGroup);
        }

        // Update the height of the container to hold enough rows of stories
        int dynamicHeight = Math.Abs(yJump * (groups.Count)) + 2 * 10;

        RectTransform rT = ContentGroups.GetComponent<RectTransform>();
        rT.sizeDelta = new Vector2(rT.sizeDelta.x, dynamicHeight);

        GroupItem.SetActive(false);
    }

    // SelectedIndex will range from 1 to n (number of groups) and represents which group is currently selected.
    void SetSelectedGroup(int selectedIndex)
    {
        for (int i = 0; i < groupItems.Count; i++)
        {
            groupItems[i].GetComponent<Image>().color = unselectedColor;
        }

        if(groupItems.Count != 0)
        {
            groupItems[selectedIndex - 1].GetComponent<Image>().color = selectedColor;
            string groupName = groupItems[selectedIndex - 1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;
            GroupName.text = groupName;
            currentGroupName = groupName;
            ShowStoryElements(groupName);
        }
        else
        {
            StoryElementItem.SetActive(false);
        }
    }

    // Populates scrollview on the right with story elements
    void ShowStoryElements(string group)
    {
        storyElementItems = new List<GameObject>();
        storyElementsInGroup = new List<StoryElement>();
        storyElementsNotInGroup = new List<StoryElement>();

        Stories stories = StandaloneSaveLoad.Instance.Load();
        StoryData currentStory = stories.CurrentStory;
        List<StoryElement> storyElements = new List<StoryElement>();

        foreach (var story in stories.GetStories())
        {
            if(story.Author == currentStory.Author && story.Title == currentStory.Title)
            {
                storyElements = story.GetStoryElements();
            }
        }

        // Find which story elements are in this group and which are not
        foreach (StoryElement storyElement in storyElements)
        {
            if (storyElement.GroupNames.Contains(group))
            {
                storyElementsInGroup.Add(storyElement);
            }
            else
            {
                storyElementsNotInGroup.Add(storyElement);
            }
        }

        PopulateStoryElements();
    }

    // Show the story elements
    void PopulateStoryElements()
    {
        // Go through all of the instantiated story elements and delete all but the first one
        for (int i = 0; i < StoryElementItem.transform.parent.childCount; i++)
        {
            GameObject child = StoryElementItem.transform.parent.GetChild(i).gameObject;
            if (child.name != "StoryElement")
            {
                Destroy(child);
            }
        }

        StoryElementItem.transform.GetChild(2).GetComponent<Toggle>().isOn = true;
        StoryElementItem.SetActive(true);
        for(int i = 0; i < storyElementsInGroup.Count; i++)
        {
            // Set name for prefab
            GameObject name = StoryElementItem.transform.GetChild(1).gameObject;
            name.GetComponent<TextMeshProUGUI>().text = storyElementsInGroup[i].Name;

            // Get position of prefab
            Vector3 pos = StoryElementItem.GetComponent<RectTransform>().localPosition;

            // Instantiate a new GameObject
            GameObject newStoryElement = Instantiate(StoryElementItem, new Vector3(0, pos.y + i * yJump - 10, pos.z), StoryElementItem.transform.rotation);
            newStoryElement.transform.SetParent(StoryElementItem.transform.parent.transform, false);

            storyElementItems.Add(newStoryElement);
        }

        StoryElementItem.transform.GetChild(2).GetComponent<Toggle>().isOn = false;

        for (int i = 0; i < storyElementsNotInGroup.Count; i++)
        {
            // Set name for prefab
            GameObject name = StoryElementItem.transform.GetChild(1).gameObject;
            name.GetComponent<TextMeshProUGUI>().text = storyElementsNotInGroup[i].Name;

            // Get position of prefab
            Vector3 pos = StoryElementItem.GetComponent<RectTransform>().localPosition;

            // Instantiate a new GameObject
            GameObject newStoryElement = Instantiate(StoryElementItem, new Vector3(0, pos.y + (i + storyElementsInGroup.Count) * yJump - 10, pos.z), 
                StoryElementItem.transform.rotation);
            newStoryElement.transform.SetParent(StoryElementItem.transform.parent.transform, false);

            storyElementItems.Add(newStoryElement);
        }

        // Update the height of the container to hold enough rows of stories
        int dynamicHeight = Math.Abs(yJump * (storyElementsInGroup.Count + storyElementsNotInGroup.Count)) + 2 * 10;

        RectTransform rT = ContentGroups.GetComponent<RectTransform>();
        rT.sizeDelta = new Vector2(rT.sizeDelta.x, dynamicHeight);

        StoryElementItem.SetActive(false);
    }

    // When the toggle for the story element is turned on this will add the story element to the group
    // When the toggle for the story element is turned off this will remove the story element from the group
    // Automatically saves data to stories.json
    public void AddStoryElementToGroup(GameObject storyElementSelected)
    {
        if(storyElementSelected.name == "StoryElement")
        {
            return;
        }

        string groupName = GroupName.text;
        string storyElementName = storyElementSelected.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text;
        
        StoryElement storyElement = GameState.Instance.GetCurrentStoryData().FindStoryElement(storyElementName);

        Transform toggle = storyElementSelected.transform.GetChild(2);
        bool isOn = toggle.GetComponent<Toggle>().isOn;

        // Story element should be added to the current group
        if (isOn)
        {
            storyElementsInGroup.Add(storyElement);

            for(int i = 0; i < storyElementsNotInGroup.Count; i++)
            {
                if (storyElementsNotInGroup[i].Name == storyElementName)
                {
                    storyElementsNotInGroup.Remove(storyElementsNotInGroup[i]);
                }
            }

            storyElement.AddGroup(groupName);
        }
        else
        {
            storyElementsNotInGroup.Add(storyElement);

            for (int i = 0; i < storyElementsInGroup.Count; i++)
            {
                if (storyElementsInGroup[i].Name == storyElementName)
                {
                    storyElementsInGroup.Remove(storyElementsInGroup[i]);
                }
            }

            storyElement.RemoveGroup(groupName);
        }

        PopulateStoryElements();

        StandaloneSaveLoad.Instance.Save();
    }

    // Selecting a new group
    public void NewGroupSelected(GameObject groupSelected)
    {
        // Find which group is selected
        string name = groupSelected.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;
        SetSelectedGroup(FindIndexOfGroupSelected(name));
    }

    // Gets the index ( 1 - n ) of the story element in the list of groups from it's name
    int FindIndexOfGroupSelected(string groupName)
    {
        for (int i = 0; i < groupItems.Count; i++)
        {
            string currentGroupsName = groupItems[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;

            if (currentGroupsName == groupName)
            {
                return (i + 1);
            }
        }

        return -1;
    }

    // This will be used to update the name of a group (when done editing)
    public void UpdateGroupName()
    {

        if(StandaloneSaveLoad.Instance.Load().CurrentStory.GetGroups().Count == 0)
        {
            return;
        }

        string updatedGroupName = GroupName.text;
        StoryData currentStory = GameState.Instance.GetCurrentStoryData();

        if (currentStory.AddGroup(updatedGroupName))
        {
            currentStory.RemoveGroups(new List<string>{currentGroupName});
            StandaloneSaveLoad.Instance.Save();

            // Add the group to story elements
            currentStory = GameState.Instance.GetCurrentStoryData();
            List<StoryElement> storyElements = new List<StoryElement>();

            foreach(var storyElement in storyElementsInGroup)
            {
                storyElements.Add(currentStory.FindStoryElement(storyElement.Name));
            }
            
            currentStory.SetGroup(storyElements, updatedGroupName);
            StandaloneSaveLoad.Instance.Save();
        }

        PopulateGroups();
        SetSelectedGroup(FindIndexOfGroupSelected(updatedGroupName));
    }

    public void Cancel()
    {
        string title = Stories.Instance.CurrentStory.Title;
        string author = Stories.Instance.CurrentStory.Author;

        Stories.Instance.StoriesList = new List<StoryData>();

        foreach(var story in initialStoriesReference.GetStories())
        {
            Stories.Instance.AddStory(story);
        }

        GameState.Instance.SetCurrentStoryData(title, author);

        StandaloneSaveLoad.Instance.Save();
    }
}
