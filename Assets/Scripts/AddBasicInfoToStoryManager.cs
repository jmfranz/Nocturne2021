/*
 * Author: Abbey Singh
 * This script will control the add basic info to story page
 */

using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class AddBasicInfoToStoryManager : MonoBehaviour
{
    public TMP_InputField Title;
    public TMP_InputField Author;

    public GameObject GameManager;
    public GameObject WarningText;

    public ControlStandalone ControlStandalone;

    public Transform GenreDropDownMenu;
    //Get the selected index
    int menuIndex;

    //Get all options available within this dropdown menu
    List<TMP_Dropdown.OptionData> menuOptions;

    //Get the string value of the selected index
    string value;

    void Start()
    {
        WarningText.SetActive(false);
    }

    public bool AddBasicInfo()
    {
        //Text to add to MappingData.json
        string titleInputted = Title.GetComponent<TMP_InputField>().text;
        string authorInputted = Author.GetComponent<TMP_InputField>().text;

        //Set map data's genre to option selected in dropdown
        menuIndex = GenreDropDownMenu.GetComponent<TMP_Dropdown>().value;
        value = GenreDropDownMenu.GetComponent<TMP_Dropdown>().options[menuIndex].text;
        string genreInputted = value;

        bool invalidInputs = false;

        //change previous author/title/genre in the story
        if (!GameState.Instance.GetMode() && titleInputted != "" && authorInputted != "")
        {
            Stories.Instance.ChangeTitleAuthorGenre(
                GameState.Instance.GetCurrentStoryData().Title,
                titleInputted,
                GameState.Instance.GetCurrentStoryData().Author,
                authorInputted,
                genreInputted);
        }
        //Only create new story if the author/title pair is unique or game is in edit mode
        else if (GameState.Instance.GetMode() && Stories.Instance.IsUniqueStory(titleInputted, authorInputted) && titleInputted != "" && authorInputted != "")
        {
            GameState.Instance.AddBasicData(titleInputted, authorInputted, genreInputted);
            GameState.Instance.SetMode(false);
            StandaloneSaveLoad.Instance.Save();
            StandaloneSaveLoad.Instance.Load();
            RoomController roomController = Stories.Instance.GetStories()[Stories.Instance.GetStories().Count -1].RoomController;
            roomController.ReadCSVRoomData();
            Stories.Instance.GetStories()[Stories.Instance.GetStories().Count - 1].SetRoomController(roomController);
            StandaloneSaveLoad.Instance.Save();     
        }
        else
        {
            invalidInputs = true;
            WarningText.SetActive(true);
            return !invalidInputs;
        }

        if (!invalidInputs)
        {
            WarningText.SetActive(false);
            GameState.Instance.SetCurrentStoryData(titleInputted, authorInputted);
            StandaloneSaveLoad.Instance.Save();

            ClearInputs();

        }

        return !invalidInputs;
    }


    //In the edit story/mapping pair mode this will show the previously inputted text
    public void SetInputs()
    {
        StoryData currentStoryData = GameState.Instance.GetCurrentStoryData();

        if (currentStoryData != null)
        {
            Title.GetComponent<TMP_InputField>().text = currentStoryData.Title;
            Author.GetComponent<TMP_InputField>().text = currentStoryData.Author;

            //Set map genre to inputted genre
            menuOptions = GenreDropDownMenu.GetComponent<TMP_Dropdown>().options;
            int i;
            for (i = 0; i < menuOptions.Count; i++)
            {
                if(String.Compare(menuOptions[i].text, currentStoryData.Genre) == 0)
                {
                    break;
                }
            }

            GenreDropDownMenu.GetComponent<TMP_Dropdown>().value = i;
        }
    }

    public void ClearInputs()
    {
        Title.GetComponent<TMP_InputField>().text = "";
        Author.GetComponent<TMP_InputField>().text = "";
        GenreDropDownMenu.GetComponent<TMP_Dropdown>().value = 0;
        WarningText.SetActive(false);
    }
}
