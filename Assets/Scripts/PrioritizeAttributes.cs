/*
 * @Author: Abbey Singh
 * This script is used in the edit story element screen.
 * This will allow the user to prioritize attributes.
 */

using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PrioritizeAttributes : MonoBehaviour
{
    // GameObjects for populating scroll view
    public GameObject Attribute;
    public GameObject NoAttribute;

    // Holds the list of attributes in the current prioritization
    List<string> prioritizedAttributes;

    // Reference to current story element and story
    StoryElement storyElement;
    StoryData story;

    // Called when the object is enabled
    public void PopulatePriorities()
    {
        prioritizedAttributes = new List<string>();

        // Find current story element and story 
        storyElement = GameState.Instance.GetCurrentStoryElement();
        story = GameState.Instance.GetCurrentStoryData();

        PopulateAttributesInPriority();
    }

    void ClearAttributeGameObjects()
    {
        Transform parent = Attribute.transform.parent.transform;
        int children = parent.childCount;
        for (int i = 0; i < children; ++i)
        {
            GameObject child = parent.GetChild(i).gameObject;
            if (child.name != "NoAttribute" && child.name != "Attribute")
            {
                Destroy(child);
            }
        }
    }

    public void PopulateAttributesInPriority()
    {
        prioritizedAttributes = storyElement.GetAttributesInPrioriry();
        ClearAttributeGameObjects();

        if (prioritizedAttributes.Count == 0)
        {
            Attribute.SetActive(false);
            NoAttribute.SetActive(true);
        }
        else
        {
            Attribute.SetActive(true);
            NoAttribute.SetActive(false);

            int yJump = -40;
            for (int i = 0; i < prioritizedAttributes.Count; i++)
            {
                //Set name for prefab
                GameObject name = Attribute.transform.GetChild(1).gameObject;
                name.GetComponent<TextMeshProUGUI>().text = prioritizedAttributes[i];

                //Set number in input field
                GameObject inputField = Attribute.transform.GetChild(2).gameObject;
                inputField.GetComponent<TMP_InputField>().text = (i+1).ToString();

                //Get position of prefab
                Vector3 pos = Attribute.GetComponent<RectTransform>().localPosition;

                //Instantiate a new GameObject
                GameObject newStoryPair = Instantiate(Attribute, new Vector3(0, pos.y + i * yJump - 5, pos.z), Attribute.GetComponent<Transform>().rotation);
                newStoryPair.transform.SetParent(Attribute.transform.parent.transform, false);
            }

            //Update the height of the container to hold enough rows of stories
            int dynamicHeight = Math.Abs(yJump * (prioritizedAttributes.Count + 1));

            RectTransform rT = Attribute.transform.parent.GetComponent<RectTransform>();
            rT.sizeDelta = new Vector2(rT.sizeDelta.x, dynamicHeight);

            Attribute.SetActive(false);
        }
    }

    //Called when the input for an attribute has ended
    public void InputChanged(TMP_InputField inputField)
    {
        prioritizedAttributes = storyElement.GetAttributesInPrioriry();

        int number = int.Parse(inputField.text);

        //Make sure number is valid
        if(number < 1)
        {
            number = 1;
        }
        else if (number > prioritizedAttributes.Count)
        {
            number = prioritizedAttributes.Count;
        }

        //update prioritized attributes
        string attributeName = inputField.transform.parent.GetChild(1).GetComponent<TextMeshProUGUI>().text;
        prioritizedAttributes.Remove(attributeName);
        prioritizedAttributes.Insert(number - 1, attributeName);

        storyElement.SetPriorityAttributes(prioritizedAttributes);
        PopulateAttributesInPriority();
    }
}
