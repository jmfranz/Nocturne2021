/*
 * Author: Abbey Singh
 * This holds information about a story element.
 */ 
 
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StoryElement {

    public string Name;
    public string Reference;
    public List<string> GroupNames;
    public Vector3 Position; 
    public int Order;
    public Color Color;
    public bool ShouldPlace = true;

    //Needed for Jake's work - set to defaults
    public int GroupID; // no groups are being created now so everyone belongs to group 1
    public int Cardinality; // Only one of this story element will show up by default
    public int OpennessPriority;
    public int VisualComplexityPriority;
    public int ConnectivityPriority;
    public int Precision;
    public int Distance;
    public int DistancePriority;
    public int DistanceID;
    public Room Room;

    //the story elements own attributes
    public List<string> Attributes;
    public List<string> AttributesInPriority;

    public StoryElement()
    {
        this.GroupNames = new List<string>();
        this.Attributes = new List<string>();
        this.AttributesInPriority = new List<string>();

        //default values
        this.GroupID = 1;
        this.Cardinality = 1;
        this.OpennessPriority = 1;
        this.VisualComplexityPriority = 2;
        this.ConnectivityPriority = 3;
        this.Precision = 15;
        this.Distance = 5;
        this.DistancePriority = 4;
        this.DistanceID = 0;
        Room = null;
    }

    public List<string> GetAttributesInPrioriry()
    {
        return AttributesInPriority;
    }

    public void AddPriorityAttribute(string name)
    {
        if (!AttributesInPriority.Contains(name))
        {
            AttributesInPriority.Add(name);
        }
    }

    public void SetPriorityAttributes(List<string> updatedAttributeList)
    {
        AttributesInPriority = updatedAttributeList;
    }

    public void RemovePriorityAttribute(string name)
    {
        AttributesInPriority.Remove(name);
    }

    public void SetColor()
    {
        this.Color = Stories.Instance.GenerateUniqueColor();
    }

    public void AddGroup(string groupName) 
    { 
        GroupNames.Add(groupName); 

        //Add the groups attributes
        foreach(var attribute in GameState.Instance.GetCurrentStoryData().FindGroup(groupName).Attributes)
        {
            AddPriorityAttribute(attribute);
        }
    }   

    public List<string> GetGroups()
    {
        return GroupNames;
    }

    public void RemoveGroup(string groupName)
    {
        foreach(var group in GroupNames)
        {
            if(group == groupName)
            {
                GroupNames.Remove(group);

                //Remove all attributes that belong to that group
                List<string> groupAttributes = GameState.Instance.GetCurrentStoryData().FindGroup(groupName).Attributes;

                // Go through this story element's attributes
                foreach (var attribute in groupAttributes)
                {
                    if (AttributesInPriority.Contains(attribute))
                    {
                        if (UniqueAttribute(attribute))
                        {
                            AttributesInPriority.Remove(attribute);
                        }
                    }
                }
                break;
            }
        }
    }

    bool UniqueAttribute(string attributeName)
    {
        List<StoryElement> storyElements = GameState.Instance.GetCurrentStoryData().StoryElements;
        StoryElement storyElement = null; ;

        // Look through this story element's attributes
        for (int i = 0; i < storyElements.Count; i++)
        {
            storyElement = storyElements[i];
            if (storyElement.Name == Name)
            {
                foreach (var attribute in storyElement.Attributes)
                {
                    if (attribute == attributeName)
                    {
                        return false;
                    }
                }
                break;
            }

        }

        // Look through all groups this story element belongs to
        foreach (string groupName in storyElement.GroupNames)
        {
            // Find group
            Group group = GameState.Instance.GetCurrentStoryData().FindGroup(groupName);
            foreach (var attribute in group.Attributes)
            {
                if (attribute == attributeName)
                {
                    return false;
                }
            }
        }

        // If nothing was found to be false, it is a unique attribute
        return true;
    }

    public void AddAttribute(string attributeName)
    {
        Attributes.Add(attributeName);
        AddPriorityAttribute(attributeName);
    }

    public void RemoveAttribute(string attributeName)
    {
        if (Attributes.Contains(attributeName))
        {
            Attributes.Remove(attributeName);

            if (UniqueAttribute(attributeName))
            {
                AttributesInPriority.Remove(attributeName);
            }
        }
    }
}

