/*
 * Author: Abbey Singh
 * This will hold information related to the current state of the game
 */

using UnityEngine;
using System.IO;

public class GameState : MonoBehaviour
{
    static StoryData _currentStoryData = new StoryData();
    static StoryElement _currentStoryElement = new StoryElement();
    static GameObject _selectedGameObject; //holds currently selected story element or group from space syntax screen
 
    //True if this is the first time creating the story/mapping pair 
    //False if this is in editMode
    public bool CreateMode;

    //Creating new story element (true)
    //Editing existing story element (false)
    public bool IsNewStoryElement;

    //Singleton
    private static GameState _instance;
    public static GameState Instance
    {
        get
        {
            if (_instance == null)
            {
                var singletonObject = GameObject.Find("Game Handler");
                _instance = singletonObject.AddComponent<GameState>();
            }
            return _instance;
        }
    }

    public GameState()
    {
        CreateMode = true;
        IsNewStoryElement = true;
    }

    public void SetSelectedObject(GameObject selected)
    {
        _selectedGameObject = selected;
    }

    public GameObject GetSelectedObject()
    {
        return _selectedGameObject;
    }

    //Mode is either in create story or edit story mode
    public void SetMode(bool value)
    {
        CreateMode = value;
    }
    public bool GetMode()
    {
        return CreateMode;
    }

    public void SetModeForStoryElement(bool value)
    {
        IsNewStoryElement = value;
    }

    public bool GetModeForStoryElement()
    {
        return IsNewStoryElement;
    }

    public void NewStoryData()
    {
        _currentStoryData = new StoryData();
    }

    public StoryData GetCurrentStoryData()
    {
        return _currentStoryData;
    }

    public void SetCurrentStoryData(string title, string author)
    {
        _currentStoryData = Stories.Instance.FindUniqueStory(title, author);
    }

    //Called when creating a new story
    public void AddBasicData(string title, string author, string genre)
    {
        _currentStoryData.Title = title;
        _currentStoryData.Author = author;
        _currentStoryData.Genre = genre;

        Stories.Instance.AddStory(_currentStoryData);
    }

    //Called when creating a new story element
    public void AddStoryElement(string name)
    {
        _currentStoryElement.Name = name;
        _currentStoryElement.SetColor();
        _currentStoryData.AddStoryElement(_currentStoryElement);  
    }

    public void SetCurrentStoryElement(StoryElement storyElement)
    {
        IsNewStoryElement = false;
        _currentStoryElement = storyElement;
    }

    public void NewStoryElement()
    {
        IsNewStoryElement = true;
        _currentStoryElement = new StoryElement();
    }

    //The reference is the filepath
    public void SaveReference(string reference)
    {
        _currentStoryElement.Reference = reference;
        _currentStoryElement.Name = Path.GetFileName(reference);
    }

    public StoryElement GetCurrentStoryElement()
    {
        return _currentStoryElement;
    }
}
