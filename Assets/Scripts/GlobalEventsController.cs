using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GlobalEventsController : MonoBehaviour
{
    public ScrollViewController ScrollViewController;
    public ControlStandalone ControlStandalone;

    public TMP_Dropdown AddEventDropdown;

    // This will occur when the screen ViewSecondaryStoryElements becomes active
    private void OnEnable()
    {
        UpdateGlobalEventsUI();
    }

    void UpdateGlobalEventsUI()
    {
        AddEventDropdown.value = 0;

        List<StoryEvent> globalEvents = GameState.Instance.GetCurrentStoryData().GetEvents();

        ScrollViewController.PopulateScrollViewItems(globalEvents.Count);

        List<GameObject> scrollviewGameObjects = ScrollViewController.GetScrollViewGameObjects();

        for (int i = 0; i < scrollviewGameObjects.Count; i++)
        {
            TextMeshProUGUI name = scrollviewGameObjects[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI preconditions = scrollviewGameObjects[i].transform.GetChild(2).GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI type = scrollviewGameObjects[i].transform.GetChild(3).GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI action = scrollviewGameObjects[i].transform.GetChild(4).GetComponent<TextMeshProUGUI>();

            StoryEvent globalEvent = globalEvents[i];

            name.text = globalEvent.Name;

            string preconditionText = "";
            for(int j = 0; j < globalEvent.Preconditions_Actions.Count; j++) // goes through all preconditions
            {
                preconditionText += globalEvent.Preconditions_Events[j].ToString() + "." + StoryEventComponent.ParseStoryEventAction(globalEvent.Preconditions_Actions[j]);

                if(j != globalEvent.Preconditions_Actions.Count - 1)
                {
                    preconditionText += ", ";
                }
            }
            
            if(preconditionText == "") //there are no preconditions
            {
                preconditionText = "Story Start";
            }

            preconditions.text = preconditionText; 
            type.text = globalEvents[i].EventType.ToString();
            action.text = globalEvents[i].Description;
        }
    }

    public void Delete(GameObject objectToDelete)
    {
        string name = objectToDelete.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text;
        StoryData currentStoryData = GameState.Instance.GetCurrentStoryData();
        currentStoryData.DeleteEvent(name);

        StandaloneSaveLoad.Instance.Save();
        StandaloneSaveLoad.Instance.Load();

        UpdateGlobalEventsUI();
    }

    public void AddAnEvent()
    {
        if(AddEventDropdown.value != 0)
        {
            if (AddEventDropdown.options[AddEventDropdown.value].text.Contains("Traversal"))
            {
                ControlStandalone.GoToScreen("TraversalEvent");
            }
            else if (AddEventDropdown.options[AddEventDropdown.value].text.Contains("Timer"))
            {
                ControlStandalone.GoToScreen("TimerEvent");
            }
        }
    }
}
