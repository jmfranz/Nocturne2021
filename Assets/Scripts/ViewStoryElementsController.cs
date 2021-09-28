/*
 * Author: Abbey Singh
 * This script will control the view story elements screen.
 */

using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class ViewStoryElementsController : MonoBehaviour
{
    //Prefab for view stories page
    public GameObject StoryElementGameObject;
    public Transform StoryElementTransform; //copy of original position

    public GameObject NoStoryElementsText;
    public GameObject Content;

    public List<GameObject> StoryElements = new List<GameObject>();

    public GameObject ScrollBarVertical;

    public PrioritizeAttributes PrioritizeAttributes; 

    //Show all stories that have been previously created
    public void PopulateViewStoryElements()
    {

        //Reset Scroll Bar
        ScrollBarVertical.GetComponent<Scrollbar>().value = 1;

        //List of all stories from json file
        StandaloneSaveLoad.Instance.Save();

        StoryData tempStoryData = StandaloneSaveLoad.Instance.Load().CurrentStory;//null;

        if (tempStoryData != null)
        {
            //Each story should have a y value that differs by yJump
            int yJump = -60;

            List<StoryElement> tempStoryElementList = tempStoryData.GetStoryElements();

            StoryElementGameObject.SetActive(true);

            if(tempStoryElementList.Count == 0)
            {
                NoStoryElementsText.SetActive(true);
            }
            else
            {
                NoStoryElementsText.SetActive(false);
            }

            //Go through all story elements
            for (int i = 0; i < tempStoryElementList.Count; i++)
            {
                //Set name for prefab
                GameObject name = StoryElementGameObject.transform.GetChild(1).gameObject;
                name.GetComponent<TextMeshProUGUI>().text = tempStoryElementList[i].Name;

                //Set group for prefab
                GameObject groups = StoryElementGameObject.transform.GetChild(2).gameObject;

                for (int j = 0; j < tempStoryElementList[i].GetGroups().Count; j++)
                {
                    if(j < 4)
                    {
                        GameObject tag1 = groups.transform.GetChild(j).gameObject;
                        tag1.SetActive(true);
                        tag1.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = tempStoryElementList[i].GetGroups()[j];
                    }
                    else
                    {
                        groups.transform.GetChild(4).gameObject.SetActive(true);
                    }
                }

                //Get position of prefab
                Vector3 pos = StoryElementTransform.GetComponent<RectTransform>().localPosition;

                //Instantiate a new GameObject
                GameObject newStoryPair = Instantiate(StoryElementGameObject, new Vector3(0, pos.y + i * yJump - 20, pos.z), StoryElementTransform.rotation);
                newStoryPair.transform.SetParent(StoryElementGameObject.transform.parent.transform, false);

                StoryElements.Add(newStoryPair);

                for (int j = 0; j < tempStoryElementList[i].GetGroups().Count; j++)
                {
                    if (j < 5)
                    {
                        GameObject temp = groups.transform.GetChild(j).gameObject;
                        temp.SetActive(false);
                    }
                }
            }

            //Update the height of the container content to hold enough rows of story elements
            int dynamicHeight = Math.Abs(yJump * (tempStoryElementList.Count + 1)) - 30;

            RectTransform rT = Content.GetComponent<RectTransform>();
            rT.sizeDelta = new Vector2(rT.sizeDelta.x, dynamicHeight);
        }

        //Make original prefab invisible
        StoryElementGameObject.SetActive(false);
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

    //Delete the GameObject corresponding to the story from the scene and delete the story from the json file
    public void DeleteStoryElement(GameObject storyElement)
    {
        StoryData currentStoryData = GameState.Instance.GetCurrentStoryData();
        string name = storyElement.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text;
        Stories.Instance.RemoveColor(currentStoryData.FindStoryElement(name).Color);
        currentStoryData.RemoveStoryElement(name);

        Destroy(storyElement);

        //Delete it from the initial and all avatar list for conversation nodes
        List<ConversationNodeData> conversationNodeDatas = currentStoryData.GetConversationNodeDatas();

        for(int i = 0; i < conversationNodeDatas.Count; i++)
        {
            ConversationNodeData currentConversationNodeData = conversationNodeDatas[i];

            if (currentConversationNodeData.InitialPlacedAvatars.Contains(name))
            {
                currentConversationNodeData.InitialPlacedAvatars.Remove(name);
            }

            if (currentConversationNodeData.IncludedAvatars.Contains(name))
            {
                currentConversationNodeData.IncludedAvatars.Remove(name);
            }

            // Delete it from the conversation lines
            if (currentConversationNodeData.PlayerFocusedDialogue != null)
            {
                List<VoiceLineData> voiceLines = currentConversationNodeData.PlayerFocusedDialogue.VoiceLines;

                for (int j = 0; j < voiceLines.Count; j++)
                {
                    VoiceLineData voiceLineData = voiceLines[j];
                    if (voiceLineData.VoiceOrigin == name)
                    {
                        if (currentConversationNodeData.IncludedAvatars.Count != 0)
                        {
                            voiceLineData.VoiceOrigin = currentConversationNodeData.IncludedAvatars[0];
                        }
                        else
                        {
                            voiceLines.Remove(voiceLineData);
                        }
                    }
                }
            }

            if (currentConversationNodeData.ConversationFocusedDialogue != null)
            {
                List<VoiceLineData> voiceLines = currentConversationNodeData.ConversationFocusedDialogue.VoiceLines;

                // Delete it from the conversation lines
                if (currentConversationNodeData.ConversationFocusedDialogue != null)
                {
                    List<VoiceLineData> voiceLinesPlayer = currentConversationNodeData.ConversationFocusedDialogue.VoiceLines;

                    for (int j = 0; j < voiceLinesPlayer.Count; j++)
                    {
                        VoiceLineData voiceLineData = voiceLinesPlayer[j];
                        if (voiceLineData.VoiceOrigin == name)
                        {
                            if (currentConversationNodeData.IncludedAvatars.Count != 0)
                            {
                                voiceLineData.VoiceOrigin = currentConversationNodeData.IncludedAvatars[0];
                            }
                            else
                            {
                                voiceLines.Remove(voiceLineData);
                            }
                        }
                    }
                }
            }
        }

        // Create null references for events with story element associated with it
        List<TraversalEvent> traversalEvents = currentStoryData.GetTraversalEvents();

        for(int i = 0; i < traversalEvents.Count; i++)
        {
            TraversalEvent traversalEvent = traversalEvents[i];
            
            if(traversalEvent.AvatarToMove == name)
            {
                traversalEvent.AvatarToMove = null;
                traversalEvent.Description = "";

                //if the location is attached to a conversation node, make it null also
                foreach(ConversationNodeData conversationNodeData in currentStoryData.ConversationNodeDatas)
                {
                    if (traversalEvent.Location == conversationNodeData.Title)
                    {
                        traversalEvent.Location = null;
                    }
                }
            }
        }

        StandaloneSaveLoad.Instance.Save();

        ClearStoryElements();
        PopulateViewStoryElements();
    }

    public void EditStoryElement(GameObject storyElement)
    {
        GameState.Instance.SetModeForStoryElement(false); //edit mode

        string name = storyElement.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text;
        StoryElement currentStoryElement = GameState.Instance.GetCurrentStoryData().FindStoryElement(name);
        GameState.Instance.SetCurrentStoryElement(currentStoryElement);

        PrioritizeAttributes.PopulatePriorities();
    }
}
