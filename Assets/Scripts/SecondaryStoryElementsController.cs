using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SecondaryStoryElementsController : MonoBehaviour
{

    public ScrollViewController ScrollViewController;

    // This will occur when the screen ViewSecondaryStoryElements becomes active
    private void OnEnable()
    {
        UpdateSecondaryStoryElementsUI();
    }

    void UpdateSecondaryStoryElementsUI()
    {
        List<ConversationNodeData> conversationNodes = GameState.Instance.GetCurrentStoryData().GetConversationNodeDatas();

        ScrollViewController.PopulateScrollViewItems(conversationNodes.Count);

        List<GameObject> scrollviewGameObjects = ScrollViewController.GetScrollViewGameObjects();

        for (int i = 0; i < scrollviewGameObjects.Count; i++)
        {
            TextMeshProUGUI name = scrollviewGameObjects[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI type = scrollviewGameObjects[i].transform.GetChild(2).GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI initialActors = scrollviewGameObjects[i].transform.GetChild(3).GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI allActors = scrollviewGameObjects[i].transform.GetChild(4).GetComponent<TextMeshProUGUI>();

            name.text = conversationNodes[i].Title;
            type.text = conversationNodes[i].FormationType.ToString();
            initialActors.text = DataFormatHandler.Instance.ConvertStringArrayToCSVString(
                conversationNodes[i].InitialPlacedAvatars.ToArray());
            allActors.text = DataFormatHandler.Instance.ConvertStringArrayToCSVString(
                conversationNodes[i].IncludedAvatars.ToArray());

        }
    }

    public void Delete(GameObject objectToDelete)
    {
        string title = objectToDelete.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text;
        StoryData currentStoryData = GameState.Instance.GetCurrentStoryData();
        currentStoryData.DeleteConversationNodeData(title);

        // Create null references for events with the conversation associated with it
        List<TraversalEvent> traversalEvents = currentStoryData.GetTraversalEvents();

        for (int i = 0; i < traversalEvents.Count; i++)
        {
            TraversalEvent traversalEvent = traversalEvents[i];

            if (traversalEvent.Location == title)
            {
                traversalEvent.Location = null;
                traversalEvent.Description = "";
            }
        }

        StandaloneSaveLoad.Instance.Save();
        StandaloneSaveLoad.Instance.Load();

        UpdateSecondaryStoryElementsUI();
    }
}
