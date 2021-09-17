/*
 * @author: Abbey Singh
 * This script will control the screen for adding attributes.
 */

using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class AddAttributeController : MonoBehaviour
{
    public GameObject AttributePrefab;
    public ControlStandalone ControlStandalone;
    public SpaceSyntaxStoryElementController SpaceSyntaxStoryElementController;
    public GameObject Name;

    List<GameObject> scrollItemObjects;
    public Transform ParentTransform; //holds a reference to "Content"
    public GameObject ScrollBarVertical;

    public static bool UnSavedChanges = false;

    public void PopulateAttributes(GameObject selectedGameObject)
    {
        Stories Stories = StandaloneSaveLoad.Instance.Load();

        List <AttributeSS> attributes = Stories.GetAttributes();
        scrollItemObjects = new List<GameObject>();

        string name = selectedGameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;
        Name.GetComponent<TextMeshProUGUI>().text = name;
        GameState.Instance.SetSelectedObject(selectedGameObject);
        AttributePrefab.SetActive(true);

        //Find reference to current story element
        StoryData tempStoryData = GameState.Instance.GetCurrentStoryData();

        StoryElement currentStoryElement = null;
        bool roomAlreadySelected = false;

        foreach (var storyElement in tempStoryData.GetStoryElements())
        {
            if (storyElement.Name == Name.GetComponent<TextMeshProUGUI>().text)
            {
                currentStoryElement = storyElement;
                //Do not show attributes that the current story element already has
                foreach (var attribute in storyElement.Attributes)
                {
                    for (int i = 0; i < attributes.Count; i++)
                    {
                        // do not show rooms if a room attribute is already selected
                        foreach (Room room in Stories.Instance.CurrentStory.RoomController._rooms)
                        {
                            if (room.Name == attributes[i].AttributeName)
                            {
                                roomAlreadySelected = true;
                            }
                        }

                        if (attributes[i].AttributeName == attribute)
                        {
                            attributes.Remove(attributes[i]);
                        }
                    }
                }

                if (roomAlreadySelected)
                {
                    int attributesCount = attributes.Count;
                    for (int i = 0; i < attributesCount; i++)
                    {
                        foreach (Room room in Stories.Instance.CurrentStory.RoomController._rooms)
                        {
                            if (room.Name == attributes[i].AttributeName)
                            {
                                attributes.Remove(attributes[i]);
                                i--;
                                attributesCount = attributes.Count;
                            }
                        }
                    }
                }

                break;
            }
        }

        //Find group
        if(currentStoryElement == null)
        {
            foreach(var group in tempStoryData.GetGroups())
            {
                if(group.GroupName == Name.GetComponent<TextMeshProUGUI>().text)
                {
                    //Do not show attributes that the current story element already has
                    foreach (var attribute in group.Attributes)
                    {
                        for (int i = 0; i < attributes.Count; i++)
                        {
                            if (attributes[i].AttributeName == attribute)
                            {
                                attributes.Remove(attributes[i]);
                            }
                        }
                    }

                    break;
                }
            }
        }



        Vector3 pos = AttributePrefab.GetComponent<RectTransform>().localPosition;

        //Add first attribute (create a new attribute)
        AttributePrefab.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Create a new Attribute";

        //Set color to make it stand out
        Button b = AttributePrefab.GetComponent<Button>();
        ColorBlock cb = b.colors;
        cb.normalColor = Color.black;
        cb.highlightedColor = new Color(202/255f, 142/255f, 198/255f);
        b.colors = cb;

        int yJump = -35;
        int yStartPos = -5;

        GameObject newScrollviewItem = Instantiate(AttributePrefab, new Vector3(0, pos.y + yStartPos, pos.z), AttributePrefab.transform.rotation);
        newScrollviewItem.transform.SetParent(ParentTransform, false);
        scrollItemObjects.Add(newScrollviewItem);

        //Change back to white
        b = AttributePrefab.GetComponent<Button>();
        cb = b.colors;
        cb.normalColor = new Color(1, 1, 1);
        cb.highlightedColor = new Color(245/255f, 245/255f, 245/255f);
        b.colors = cb;


        for (int i = 0; i < attributes.Count; i++)
        {
            AttributePrefab.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = attributes[i].AttributeName;
            GameObject newScrollviewItem1 = Instantiate(AttributePrefab, new Vector3(0, pos.y + (i + 1) * yJump + yStartPos, pos.z), AttributePrefab.transform.rotation);
            newScrollviewItem1.transform.SetParent(ParentTransform, false);
            scrollItemObjects.Add(newScrollviewItem1);
        }


        //Update the height of the container (this) to hold enough rows of storyelement/groups 
        GameObject content = ParentTransform.gameObject;
        int dynamicHeight = Math.Abs((yJump) * (attributes.Count + 1) + yStartPos);

        RectTransform rT = content.GetComponent<RectTransform>();
        rT.sizeDelta = new Vector2(rT.sizeDelta.x, dynamicHeight);

        AttributePrefab.SetActive(false);
    }


    public void AttributeSelectedEvent(GameObject selectedGameObject)
    {
        RemoveScrollviewGameObjects();

        //Create a new attribute
        if (selectedGameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "Create a new Attribute")
        {
            SpaceSyntaxStoryElementController.InitializeNewAttribute();
            ControlStandalone.GoToScreen("SpaceSyntaxStoryElementScreen");
        }
        //Add an attribute
        else
        {
            //Find reference to current story element
            StoryData tempStoryData = GameState.Instance.GetCurrentStoryData();

            StoryElement currentStoryElement = null;

            foreach(var storyElement in tempStoryData.GetStoryElements())
            {
                if(storyElement.Name == Name.GetComponent<TextMeshProUGUI>().text)
                {
                    currentStoryElement = storyElement;
                    break;
                }
            }

            ConversationNodeData conversationNodeData = null;

            foreach(var conversationNode in tempStoryData.GetConversationNodeDatas())
            {
                if(conversationNode.Title == Name.GetComponent<TextMeshProUGUI>().text)
                {
                    conversationNodeData = conversationNode;
                }
            }

            Room roomData = null;

            if (currentStoryElement != null)
            {
                GameState.Instance.SetCurrentStoryElement(currentStoryElement);
                currentStoryElement.AddAttribute(selectedGameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text);
                StandaloneSaveLoad.Instance.Save();
            }
            else if(conversationNodeData != null)
            {
                conversationNodeData.AddAttribute(selectedGameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text);
                StandaloneSaveLoad.Instance.Save();
            }
            //otherwise a group was selected
            else
            {
                foreach(var group in tempStoryData.GetGroups())
                {
                    if(group.GroupName == Name.GetComponent<TextMeshProUGUI>().text)
                    {
                        group.AddAttribute(selectedGameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text);
                        StandaloneSaveLoad.Instance.Save();
                        break;
                    }
                }
            }

            UnSavedChanges = true;

            ControlStandalone.GoToScreen("PlacementRules");
        }
    }

    public void RemoveScrollviewGameObjects()
    {
        for(int i = 0; i < scrollItemObjects.Count; i++)
        {
            Destroy(scrollItemObjects[i]);
        }
    }
}
