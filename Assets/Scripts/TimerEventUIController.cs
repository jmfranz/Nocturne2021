using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerEventUIController : MonoBehaviour
{
    public ScrollViewController ScrollViewController;
    public GameObject PreconditionItemGameObject;

    public Button AddPreConditionButton;

    int numberOfPreconditionLineData;

    List<string> preconditionevent = new List<string>();
    List<string> preconditionAction = new List<string>();

    public TMP_InputField NameInputField;
    public TMP_InputField TimeInputField;

    public GameObject WarningMessage;

    public ControlStandalone ControlStandalone;

    private void OnEnable()
    {
        SetFields();
        SetLineDefaultInfo();

        //assume no edit function FOR NOW
        numberOfPreconditionLineData = 0;
        ScrollViewController.PopulateScrollViewItems(numberOfPreconditionLineData);

        //Reset values
        preconditionevent = new List<string>();
        preconditionAction = new List<string>();

        Transform NoScrollViewItemGameObject = PreconditionItemGameObject.transform.parent.GetChild(1);
        
        // No Story events already means this event has to begin at game start
        if (Stories.Instance.CurrentStory.Events.Count == 0)
        {
            NoScrollViewItemGameObject.GetChild(0).GetComponent<TextMeshProUGUI>().text = "This event will begin at story start";
            AddPreConditionButton.interactable = false;
        }
        else
        {
            NoScrollViewItemGameObject.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Click on the + to get started";
            AddPreConditionButton.interactable = true;
        }
    }

    //sets the event and action options for the preconditions
    void SetLineDefaultInfo()
    {
        Transform eventDropdown = PreconditionItemGameObject.transform.GetChild(1);
        Transform actionDropdown = PreconditionItemGameObject.transform.GetChild(2);

        // Get a list of story event names
        List<string> eventNames = new List<string>();
        List<StoryEvent> storyEvents = Stories.Instance.CurrentStory.Events;
        for(int i = 0; i < storyEvents.Count; i++)
        {
            eventNames.Add(storyEvents[i].Name);
        }

        eventDropdown.GetComponent<TMP_Dropdown>().ClearOptions();
        eventDropdown.GetComponent<TMP_Dropdown>().AddOptions(eventNames);

        actionDropdown.GetComponent<TMP_Dropdown>().ClearOptions();
        actionDropdown.GetComponent<TMP_Dropdown>().AddOptions(new List<string>(new string[] { "Started", "Completed"}));
    }

    void SetFields()
    {
        NameInputField.text = "";
        TimeInputField.text = "";       
    }

    public void SaveEvent()
    {
        string name = NameInputField.text;
        string time = TimeInputField.text;

        // Check if all fields are filled out, movement speed has a default of walk
        if (name == "" || !GameState.Instance.GetCurrentStoryData().IsUniqueEventName(name) ||
            time == "")
        {
            WarningMessage.SetActive(true);
            return;
        }

        WarningMessage.SetActive(false);

        TimerEvent timerEvent = new TimerEvent(name, float.Parse(time));

        // Save preconditions
        for (int i = 0; i < preconditionevent.Count; i++)
        {
            timerEvent.Preconditions_Events.Add(preconditionevent[i]);
            timerEvent.Preconditions_Actions.Add(StoryEventComponent.ParseStoryStringAsEventAction(preconditionAction[i]));
        }

        GameState.Instance.GetCurrentStoryData().AddStoryEvent(timerEvent);

        StandaloneSaveLoad.Instance.Save();
        StandaloneSaveLoad.Instance.Load();

        ControlStandalone.GoToScreen("GlobalEvents");
    }

    public void UpdatePreconditionData()
    {
        List<GameObject> scrollviewGameObjects = ScrollViewController.GetScrollViewGameObjects();

        for (int i = 0; i < scrollviewGameObjects.Count; i++)
        {
            TMP_Dropdown eventDropdown = scrollviewGameObjects[i].transform.GetChild(1).GetComponent<TMP_Dropdown>();
            TMP_Dropdown actionDropdown = scrollviewGameObjects[i].transform.GetChild(2).GetComponent<TMP_Dropdown>();
            TextMeshProUGUI indexText = scrollviewGameObjects[i].transform.GetChild(3).GetComponent<TextMeshProUGUI>();

            SetDropdown(eventDropdown, preconditionevent[i]);
            SetDropdown(actionDropdown, preconditionAction[i]);
            indexText.text = i.ToString();
        }
    }

    void SetDropdown(TMP_Dropdown dropdown, string option)
    {
        for (int i = 0; i < dropdown.options.Count; i++)
        {
            if (dropdown.options[i].text == option)
            {
                dropdown.value = i;
                break;
            }
        }
    }

    public void SavePreconditionLineData(GameObject PreconditionItem)
    {
        TMP_Dropdown eventDropdown = PreconditionItem.transform.GetChild(1).GetComponent<TMP_Dropdown>();
        TMP_Dropdown actionDropdown = PreconditionItem.transform.GetChild(2).GetComponent<TMP_Dropdown>();
        int index = int.Parse(PreconditionItem.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text);
        string eventSelected = eventDropdown.options[eventDropdown.value].text;
        string actionSelected = actionDropdown.options[actionDropdown.value].text;

        preconditionevent[index] = eventSelected;
        preconditionAction[index] = actionSelected;
        UpdatePreconditionData();
    }

    public void AddPreconditionData()
    {
        numberOfPreconditionLineData++;

        if(Stories.Instance.CurrentStory.Events.Count != 0)
        {
            preconditionevent.Add(Stories.Instance.CurrentStory.Events[0].Name);
        }
        
        preconditionAction.Add("Started");

        ScrollViewController.PopulateScrollViewItems(numberOfPreconditionLineData);
        UpdatePreconditionData();

        Transform NoScrollViewItemGameObject = PreconditionItemGameObject.transform.parent.GetChild(1);
        // No Story events already means this event has to begin at game start
        if (preconditionAction.Count == numberOfPreconditionLineData)
        {
            AddPreConditionButton.interactable = false;
        }
        else
        {
            AddPreConditionButton.interactable = true;
        }
    }
}
