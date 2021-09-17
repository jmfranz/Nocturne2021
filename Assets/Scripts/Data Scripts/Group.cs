/*
 * Author: Abbey Singh
 * This holds information about a group
 */

using System.Collections.Generic;

[System.Serializable]
public class Group
{
    public string GroupName;

    public bool AllElementsInSameRoom;

    public List<string> Attributes;

    public Group(string groupName)
    {
        Attributes = new List<string>();
        GroupName = groupName;

        AllElementsInSameRoom = false;
    }

    public void SetSpaceSyntaxValues(string visualComplexityOption, string opennessOption, string visualIntegrationOption)
    {
        Attributes.Add(opennessOption);
        Attributes.Add(visualComplexityOption);
        Attributes.Add(visualIntegrationOption);
    }

    public void AddAttribute(string attributeName)
    {
        //Add to the groups list of attributes
        Attributes.Add(attributeName);

        List<StoryElement> storyElements = GameState.Instance.GetCurrentStoryData().StoryElements;

        foreach(var storyElement in storyElements)
        {
            foreach(var group in storyElement.GroupNames)
            {
                // The story element belongs to this group so we need to add the new attribute
                if(group == this.GroupName)
                {
                    storyElement.AddPriorityAttribute(attributeName);
                    break;
                }
            }
        }
    }

    public void RemoveAttribute(string attributeName)
    {
        if (Attributes.Contains(attributeName))
        {
            Attributes.Remove(attributeName);
        }

        List<StoryElement> storyElements = GameState.Instance.GetCurrentStoryData().StoryElements;

        foreach (var storyElement in storyElements)
        {
            foreach (var group in storyElement.GroupNames)
            {
                // The story element belongs to this group so we need to add the new attribute
                if (group == this.GroupName)
                {
                    //Only remove the attribute from priority attribute list if the attribute does not exist in any other group or story element
                    if (UniqueAttribute(attributeName, group))
                    {
                        storyElement.RemovePriorityAttribute(attributeName);
                    }
                    break;
                }
            }
        }
    }

    bool UniqueAttribute(string attributeName, string groupName)
    {
        List<StoryElement> storyElements = GameState.Instance.GetCurrentStoryData().StoryElements;

        // Look through all story elements
        foreach (var storyElement in storyElements)
        {
            foreach(var attribute in storyElement.Attributes)
            {
                if(attribute == attributeName)
                {
                    return false;
                }
            }
        }

        //Look through all groups
        List<Group> groups = GameState.Instance.GetCurrentStoryData().GetGroups();
        foreach(var group in groups)
        {
            if(group.GroupName == groupName)
            {
                continue;
            }
            foreach(var attribute in group.Attributes)
            {
                if(attribute == attributeName)
                {
                    return false;
                }
            }
        }

        //If nothing was found to be false, it is a unique attribute
        return true;
    }
}
