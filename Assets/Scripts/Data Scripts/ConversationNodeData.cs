using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ConversationNodeData
{
    public ConversationNodeData(string name, ConversationPlacementTypes placementType, ConversationFormationTypes formationType, List<string> initalPlacedAvatars = null, List<string> includedAvatars = null, string outOfRangeClip = "", 
                                ConversationDialogueData playerFocusedDialogue = null, ConversationDialogueData avatarFocusedDialogue = null)
    {
        Title = name;
        InitialPlacedAvatars = initalPlacedAvatars; 
        IncludedAvatars = includedAvatars; 
        PlacementType = placementType;
        FormationType = formationType;
        if (outOfRangeClip != "") { OutOfRangeClip = outOfRangeClip; }
        PlayerFocusedDialogue = playerFocusedDialogue; 
        ConversationFocusedDialogue = avatarFocusedDialogue;
        Color = Stories.Instance.GenerateUniqueColor();
        Reference = "ConversationNodeData/" + Title;

        this.Attributes = new List<string>();
        this.AttributesInPriority = new List<string>();

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

    public void AddAttribute(string attributeName)
    {
        Attributes.Add(attributeName);
        AddPriorityAttribute(attributeName);
    }

    public void AddPriorityAttribute(string name)
    {
        if (!AttributesInPriority.Contains(name))
        {
            AttributesInPriority.Add(name);
        }
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

    bool UniqueAttribute(string attributeName)
    {
        List<StoryElement> storyElements = GameState.Instance.GetCurrentStoryData().StoryElements;
        StoryElement storyElement = null; ;

        // Look through this story element's attributes
        for (int i = 0; i < storyElements.Count; i++)
        {
            storyElement = storyElements[i];
            if (storyElement.Name == Title)
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

        // If nothing was found to be false, it is a unique attribute
        return true;
    }

    public enum ConversationPlacementTypes
    {
        Intimate,
        Personal,
        Social,
    }

    public enum ConversationFormationTypes
    {
        Circle,
        SemiCircle,
        Line,
    }

    public static ConversationPlacementTypes GetPlacementType(string conversationType)
    {
        switch (conversationType)
        {
            case "Intimate":
                return ConversationPlacementTypes.Intimate;
            case "Personal":
                return ConversationPlacementTypes.Personal;
            case "Social":
                return ConversationPlacementTypes.Social;
            default:
                Debug.LogErrorFormat("ERROR: Conversation Type '{0}' is not defined", conversationType);
                return ConversationPlacementTypes.Personal;
        }
    }

    public string Title; //Used as an ID
    public List<string> InitialPlacedAvatars;
    public List<string> IncludedAvatars; //is this necessary for Peter?
    public ConversationPlacementTypes PlacementType;
    public ConversationFormationTypes FormationType;
    public string OutOfRangeClip;
    public Color Color;
    public string Reference;

    //for placement
    public Vector3 Position;
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
    public Room Room = null;

    //For Proximity (RelativeDistanceRule) min/max
    public RulesContainer.RuleContainer ListofRules;

    //the story elements own attributes
    public List<string> Attributes;
    public List<string> AttributesInPriority;

    public ConversationDialogueData PlayerFocusedDialogue;
    public ConversationDialogueData ConversationFocusedDialogue;
}
