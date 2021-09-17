/*
 * @Author: Abbey Singh
 * This script will control the placement rules screen.
 */

using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlacementRulesController : MonoBehaviour
{
    public GameObject NoStoryItems;

    public GameObject ScrollviewItem;
    int i;

    List<GameObject> TempScrollViewItems;
    public GameObject ScrollBarVertical;

    public GameObject UnsavedChangesText; // appears if the user has added attributes, but not reapplied the rules

    float initialHeight;


    void Awake()
    {
        TempScrollViewItems = null;
        initialHeight = GetComponent<RectTransform>().rect.height;
    }

    void Update()
    {
        if (AddAttributeController.UnSavedChanges)
        {
            UnsavedChangesText.SetActive(true);
        }
        else
        {
            UnsavedChangesText.SetActive(false);
        }
    }

    //Show all story elements and groups in the scroll view
    public void PopulateStoryElementsGroups()
    {
        //Reset Scroll Bar
        ScrollBarVertical.GetComponent<Scrollbar>().value = 1;

        TempScrollViewItems = new List<GameObject>();

        //List of all stories from json file
        Stories tempStoryHolder = StandaloneSaveLoad.Instance.Load();

        StoryData tempStoryData = null;

        //find current story data
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
            int yJump = -60; //offset between each list item
            int yStartOffset = -10; //initial offset for first item

            List<StoryElement> tempStoryElementList = tempStoryData.GetStoryElements();

            ScrollviewItem.SetActive(true);

            if(tempStoryElementList.Count == 0 && tempStoryData.Groups.Count == 0 && tempStoryData.ConversationNodeDatas.Count == 0)
            {
                NoStoryItems.SetActive(true);
            }
            else
            {
                NoStoryItems.SetActive(false);
            }

            List<string> avatarsNotToBePlaced = new List<string>();

            //Go through all of the secondary story elements
            for (int a = 0; a < tempStoryData.ConversationNodeDatas.Count; a++)
            {
                ConversationNodeData conversationNodeData = tempStoryData.ConversationNodeDatas[a];

                //Set name for prefab
                GameObject name = ScrollviewItem.transform.GetChild(0).gameObject;
                name.GetComponent<TextMeshProUGUI>().text = conversationNodeData.Title;

                //Specify attributes
                for (int j = 0; j < conversationNodeData.Attributes.Count; j++)
                {
                    GameObject attribute = ScrollviewItem.transform.GetChild(j + 2).gameObject;
                    attribute.SetActive(true);
                    attribute.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = conversationNodeData.Attributes[j];
                }

                foreach(string avatar in conversationNodeData.InitialPlacedAvatars)
                {
                    avatarsNotToBePlaced.Add(avatar);
                }

                //Specify icon color
                ScrollviewItem.transform.GetChild(1).gameObject.SetActive(true); //set color icon to true
                ScrollviewItem.transform.GetChild(6).gameObject.SetActive(false); //set group icon to false
                ScrollviewItem.transform.GetChild(1).gameObject.GetComponent<Image>().color = conversationNodeData.Color;

                //Get position of prefab
                Vector3 pos = ScrollviewItem.GetComponent<RectTransform>().localPosition;

                //Instantiate a new GameObject
                GameObject newScrollviewItem = Instantiate(ScrollviewItem, new Vector3(0, pos.y + a * yJump + yStartOffset, pos.z), ScrollviewItem.transform.rotation);
                newScrollviewItem.transform.SetParent(ScrollviewItem.transform.parent.transform, false);
                TempScrollViewItems.Add(newScrollviewItem);

                //Set attribute objects to inactive
                for (int j = 0; j < 3; j++)
                {
                    GameObject attribute = ScrollviewItem.transform.GetChild(j + 2).gameObject;
                    attribute.SetActive(false);
                }
            }

            int storyElementsAddedToScrollview = 0;

            //Go through all story elements
            for (i = 0; i < tempStoryElementList.Count; i++)
            {
                //Set name for prefab
                GameObject name = ScrollviewItem.transform.GetChild(0).gameObject;
                name.GetComponent<TextMeshProUGUI>().text = tempStoryElementList[i].Name;

                // do not place an avatar if it is in the inital avatars for a conversation
                bool doNotPlaceAvatar = false;
                foreach(string avatarName in avatarsNotToBePlaced)
                {
                    if (avatarName == tempStoryElementList[i].Name)
                    {
                        doNotPlaceAvatar = true;
                        break;
                    }
                }

                if (doNotPlaceAvatar)
                {
                    continue;
                }


                //Specify attributes
                for (int j = 0; j < tempStoryElementList[i].Attributes.Count; j++)
                {
                    GameObject attribute = ScrollviewItem.transform.GetChild(j + 2).gameObject;
                    attribute.SetActive(true);
                    attribute.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = tempStoryElementList[i].Attributes[j];
                }

                //Specify icon color
                ScrollviewItem.transform.GetChild(1).gameObject.SetActive(true); //set color icon to true
                ScrollviewItem.transform.GetChild(6).gameObject.SetActive(false); //set group icon to false
                ScrollviewItem.transform.GetChild(1).gameObject.GetComponent<Image>().color = tempStoryElementList[i].Color;

                //Instantiate a new GameObject
                Vector3 pos = ScrollviewItem.GetComponent<RectTransform>().localPosition;

                GameObject newScrollviewItem = Instantiate(ScrollviewItem, new Vector3(0, pos.y + (storyElementsAddedToScrollview + tempStoryData.ConversationNodeDatas.Count) * yJump + 
                                        yStartOffset, pos.z), ScrollviewItem.transform.rotation);
                newScrollviewItem.transform.SetParent(ScrollviewItem.transform.parent.transform, false);
                TempScrollViewItems.Add(newScrollviewItem);
                storyElementsAddedToScrollview++;

                //Set attribute objects to inactive
                for (int j = 0; j < 3; j++)
                {
                    GameObject attribute = ScrollviewItem.transform.GetChild(j + 2).gameObject;
                    attribute.SetActive(false);
                }
            }

            //go through all groups
            for(int k = 0; k < tempStoryData.Groups.Count; k++)
            {
                //Set name for prefab
                GameObject name = ScrollviewItem.transform.GetChild(0).gameObject;
                name.GetComponent<TextMeshProUGUI>().text = tempStoryData.Groups[k].GroupName;

                ScrollviewItem.transform.GetChild(1).gameObject.SetActive(false);

                //Specify attributes
                for (int j = 0; j < tempStoryData.Groups[k].Attributes.Count; j++)
                {
                    GameObject attribute = ScrollviewItem.transform.GetChild(j + 2).gameObject;
                    attribute.SetActive(true);
                    attribute.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = tempStoryData.Groups[k].Attributes[j];
                }

                //Specify icon color
                ScrollviewItem.transform.GetChild(1).gameObject.SetActive(false); //set color icon to false
                ScrollviewItem.transform.GetChild(6).gameObject.SetActive(true); //set group icon to true

                //Get position of prefab
                Vector3 pos = ScrollviewItem.GetComponent<RectTransform>().localPosition;

                //Instantiate a new GameObject
                GameObject newScrollviewItem = Instantiate(ScrollviewItem, new Vector3(0, pos.y + (k + storyElementsAddedToScrollview + tempStoryData.ConversationNodeDatas.Count) * yJump + yStartOffset, pos.z), ScrollviewItem.transform.rotation);
                newScrollviewItem.transform.SetParent(ScrollviewItem.transform.parent.transform, false);
                TempScrollViewItems.Add(newScrollviewItem);

                //Set attribute objects to inactive
                for (int j = 0; j < 3; j++)
                {
                    GameObject attribute = ScrollviewItem.transform.GetChild(j + 2).gameObject;
                    attribute.SetActive(false);
                }
            }           

            //Update the height of the container (this) to hold enough rows of storyelement/groups 
            int dynamicHeight = Math.Abs((yJump) * (tempStoryData.Groups.Count + storyElementsAddedToScrollview + tempStoryData.ConversationNodeDatas.Count)
                                        + 2 * yStartOffset);

            RectTransform rT = GetComponent<RectTransform>();
            rT.sizeDelta = new Vector2(rT.sizeDelta.x, dynamicHeight - initialHeight);
        }

        //Make original prefab invisible
        ScrollviewItem.SetActive(false);
    }

    public void ClearStoryElementItems()
    {
        if(TempScrollViewItems != null)
        {
            foreach (var item in TempScrollViewItems)
            {
                Destroy(item);
            }
        }
    }

    public void DeleteStoryElementAttribute(GameObject ObjectToDelete)
    {
        //Find reference to current story element
        StoryData tempStoryData = GameState.Instance.GetCurrentStoryData();

        StoryElement currentStoryElement = null;

        string objectToDeleteFrom = ObjectToDelete.transform.parent.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;
        string attributeName = ObjectToDelete.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;

        foreach (var storyElement in tempStoryData.GetStoryElements())
        {
            if (storyElement.Name == objectToDeleteFrom)
            {
                currentStoryElement = storyElement;
                GameState.Instance.SetCurrentStoryElement(currentStoryElement);
                currentStoryElement.RemoveAttribute(attributeName);
                break;
            }
        }

        if(currentStoryElement == null)
        {
            bool inGroup = false;
            foreach(var group in tempStoryData.GetGroups())
            {
                if(group.GroupName == objectToDeleteFrom)
                {
                    group.RemoveAttribute(attributeName);
                    inGroup = true;
                    break;
                }
            }

            if (!inGroup)
            {
                foreach(var conversationNode in tempStoryData.GetConversationNodeDatas())
                {
                    if(conversationNode.Title == objectToDeleteFrom)
                    {
                        conversationNode.RemoveAttribute(attributeName);
                    }
                }
            }
        }

        AddAttributeController.UnSavedChanges = true;

        ObjectToDelete.SetActive(false);
        StandaloneSaveLoad.Instance.Save();
    }
}
