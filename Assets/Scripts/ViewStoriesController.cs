/*
 * Author: Abbey Singh
 * This script will control the view stories page 
 */

using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using System;
using UnityEngine.UI;

public class ViewStoriesController : MonoBehaviour
{
    //Prefab for view stories page
    public GameObject StoryMappingPairGameObject;
    public Transform StoryMappingPairTransform; //copy of original position

    public List<GameObject> StoryMappingPairs = new List<GameObject>();

    //Get all options available within this dropdown menu
    List<TMP_Dropdown.OptionData> menuOptions;

    public GameObject Content;
    public GameObject NoStoriesCreated;

    public GameObject ScrollBarVertical;

    //Show all stories that have been previously created
    public void PopulateViewStories()
    {

        //Reset Scroll Bar
        ScrollBarVertical.GetComponent<Scrollbar>().value = 1;

        //List of all stories from json file
        Stories tempStoryHolder = StandaloneSaveLoad.Instance.Load();

        if (tempStoryHolder != null)
        {
            //Each story should have a y value that differs by yJump
            int yJump = -60;

            List<StoryData> tempStoryDataList = tempStoryHolder.GetStories();
            List<string> mapOptions = tempStoryHolder.GetMaps();

            StoryMappingPairGameObject.SetActive(true);

            if(tempStoryDataList.Count == 0)
            {
                NoStoriesCreated.SetActive(true);
            }
            else
            {
                NoStoriesCreated.SetActive(false);
            }

            //Go through all mapping/story pair
            for (int i = 0; i < tempStoryDataList.Count; i++)
            {
                //Set title for prefab
                GameObject title = StoryMappingPairGameObject.transform.GetChild(1).gameObject;
                title.GetComponent<TextMeshProUGUI>().text = tempStoryDataList[i].Title;

                //Set author for prefab
                GameObject author = StoryMappingPairGameObject.transform.GetChild(2).gameObject;
                author.GetComponent<TextMeshProUGUI>().text = tempStoryDataList[i].Author;

                //Get position of prefab
                Vector3 pos = StoryMappingPairTransform.GetComponent<RectTransform>().localPosition;

                //Instantiate a new GameObject
                GameObject newStoryPair = Instantiate(StoryMappingPairGameObject, new Vector3(0, pos.y + i * yJump + 5, pos.z), StoryMappingPairTransform.rotation);
                newStoryPair.transform.SetParent(StoryMappingPairGameObject.transform.parent.transform, false);

                StoryMappingPairs.Add(newStoryPair);
            }

            //Update the height of the container to hold enough rows of stories
            int dynamicHeight = Math.Abs(yJump * (tempStoryDataList.Count + 1)) - 30;

            RectTransform rT = Content.GetComponent<RectTransform>();
            rT.sizeDelta = new Vector2(rT.sizeDelta.x, dynamicHeight);
        }
        else
        {
            NoStoriesCreated.SetActive(true);
        }

        //Make original prefab invisible
        StoryMappingPairGameObject.SetActive(false);
    }

    //Delete GameObjects from the scene
    public void ClearStoryMappingPair()
    {
        for (int i = 0; i < StoryMappingPairs.Count; i++)
        {
            Destroy(StoryMappingPairs[i]);
        }

        //Make list empty
        StoryMappingPairs.Clear();
    }

    //Delete the GameObject corresponding to the story from the scene and delete the story from the json file
    //Check if any scenes created with the story should be deleted
    public void DeleteStory(GameObject storyMappingPair)
    {
        string title = storyMappingPair.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text;
        string author = storyMappingPair.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text;

        Stories.Instance.DeleteStory(title, author);

        Destroy(storyMappingPair);

        StandaloneSaveLoad.Instance.Save();

        //Find any scene files that correspond to this story/author pair
        var files = new DirectoryInfo("/SpaceSyntaxData/Scenes/").GetFiles();

        for(int i = 0; i < files.Length; i++)
        {
            string file = files[i].ToString();

            string fileName = file.ToString().Substring(file.ToString().LastIndexOf('\\') + 1);

            string fileTitle = fileName.Substring(0, fileName.IndexOf("-"));
            string fileAuthor = fileName.Substring(fileTitle.Length + 1, fileName.LastIndexOf("-") - fileTitle.Length - 1);

            if(fileTitle == title && fileAuthor == author)
            {
                File.Delete(files[i].ToString());
            }
        }

        ClearStoryMappingPair();
        PopulateViewStories();
    }

    public void EditStory(GameObject storyMappingPair)
    {
        GameState.Instance.SetMode(false);
        string title = storyMappingPair.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text;
        string author = storyMappingPair.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text;

        GameState.Instance.SetCurrentStoryData(title, author);
    }

    //public void MapSelected(GameObject storyMappingPair)
    //{
    //    Transform dropdownMenu = storyMappingPair.transform.GetChild(2);
    //    int menuIndex = dropdownMenu.GetComponent<TMP_Dropdown>().value;
    //    List<TMP_Dropdown.OptionData> menuOptions = dropdownMenu.GetComponent<TMP_Dropdown>().options;
    //    string value = menuOptions[menuIndex].text;

    //    string title = storyMappingPair.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;
    //    string author = storyMappingPair.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text;

    //    StoryData currentStoryData = Stories.Instance.FindUniqueStory(title, author);
    //    if (currentStoryData != null)
    //    {
    //        GameState.Instance.SetCurrentStoryData(currentStoryData.Title, currentStoryData.Author);
    //        currentStoryData.MapSelected = value;
    //        StandaloneSaveLoad.Instance.Save();
    //        GameState.Instance.NewStoryData();
    //    }
    //}
}
