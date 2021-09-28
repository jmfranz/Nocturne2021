/*
 * Author: Abbey Singh
 * This script will make the rules into the format Jake's config file is in
 */

using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RulesFormat
{
    public string[] GameObjects = new string[15];

    Dictionary<string, int> spaceSyntaxPriorities = new Dictionary<string, int>();

    string opennessValue = "";
    string visualComplexityValue = "";
    string visualIntegrationValue = "";
    string roomName = "";

    public void SetRules(StoryElement storyElement, StoryData story)
    {
        StandaloneSaveLoad.Instance.Load();
        // First add story element's attribute to list of attributes
        List<string> attributes = storyElement.Attributes;
        List<string> storyelementGroupsName = storyElement.GroupNames;

        // Add group attributes to list of attributes
        foreach(var storyelementGroupName in storyelementGroupsName)
        {
            //find group from story data
            foreach(var group in story.Groups)
            {
                //add its attributes to list of attributes
                if(group.GroupName == storyelementGroupName)
                {
                    foreach(var groupAttribute in group.Attributes)
                    {
                        attributes.Add(groupAttribute);
                    }
                }
            }
        }

        // Sets appropritate space syntax values for the attributes
        PrioritizeAttributes(storyElement.Attributes);

        GameObjects[0] = FormatReference(storyElement.Reference);
        GameObjects[1] = storyElement.Name;
        GameObjects[2] = storyElement.GroupID.ToString();
        GameObjects[3] = storyElement.Cardinality.ToString();
        GameObjects[4] = opennessValue;
        GameObjects[5] = storyElement.OpennessPriority.ToString();
        GameObjects[6] = visualComplexityValue; 
        GameObjects[7] = storyElement.VisualComplexityPriority.ToString();
        GameObjects[8] = visualIntegrationValue; 
        GameObjects[9] = storyElement.ConnectivityPriority.ToString();
        GameObjects[10] = storyElement.Precision.ToString();
        GameObjects[11] = storyElement.Distance.ToString();
        GameObjects[12] = storyElement.DistancePriority.ToString(); //assume distance priority is always 4
        GameObjects[13] = storyElement.DistanceID.ToString();
        GameObjects[14] = roomName;
    }

    public void SetRules(ConversationNodeData conversationNodeData, StoryData story)
    {
        // First add story element's attribute to list of attributes
        List<string> attributes = conversationNodeData.Attributes;

        // Sets appropritate space syntax values for the attributes
        PrioritizeAttributes(conversationNodeData.Attributes);

        GameObjects[0] = FormatReference(conversationNodeData.Reference);
        GameObjects[1] = conversationNodeData.Title;
        GameObjects[2] = "";
        GameObjects[3] = conversationNodeData.Cardinality.ToString();
        GameObjects[4] = opennessValue;
        GameObjects[5] = conversationNodeData.OpennessPriority.ToString();
        GameObjects[6] = visualComplexityValue;
        GameObjects[7] = conversationNodeData.VisualComplexityPriority.ToString();
        GameObjects[8] = visualIntegrationValue;
        GameObjects[9] = conversationNodeData.ConnectivityPriority.ToString();
        GameObjects[10] = conversationNodeData.Precision.ToString();
        GameObjects[11] = conversationNodeData.Distance.ToString();
        GameObjects[12] = conversationNodeData.DistancePriority.ToString(); //assume distance priority is always 4
        GameObjects[13] = conversationNodeData.DistanceID.ToString();
        GameObjects[14] = roomName;
    }

    void PrioritizeAttributes(List<string> attributes)
    {
        if(attributes.Count == 0)
        {
            opennessValue = FindSpaceSyntaxValue("None").ToString();
            visualComplexityValue = FindSpaceSyntaxValue("None").ToString();
            visualIntegrationValue = FindSpaceSyntaxValue("None").ToString();
        }
        // Assuming that the story element's attributes are ordered by priority
        else
        {
            // Go through all the story element's attributes
            for(int i = 0; i < attributes.Count; i++)
            {
                // All values have been set
                if(opennessValue != "" && visualComplexityValue != "" && visualIntegrationValue != "")
                {
                    break;
                }
                // All values have not been set
                else
                {
                    AttributeSS currentAttribute = Stories.Instance.FindAttribute(attributes[i]);

                    List<string> options = currentAttribute.SpaceSyntaxOptions; //holds none, lowest, low, etc. for each openness, visual complexity, and visual integration

                    if(options == null || (options.Count == 0 && currentAttribute.AttributeName != "Random")) // it is a room
                    {
                        roomName = currentAttribute.AttributeName;
                    }
                    else
                    {
                        for (int j = 0; j < options.Count; j++)
                        {
                            if (options[j] != "None")
                            {
                                string val = FindSpaceSyntaxValue(options[j]).ToString();

                                if (j == 0 && opennessValue == "")
                                {
                                    opennessValue = val;
                                }
                                else if (j == 1 && visualComplexityValue == "")
                                {
                                    visualComplexityValue = val;
                                }
                                else if (j == 2 && visualIntegrationValue == "")
                                {
                                    visualIntegrationValue = val;
                                }
                            }
                        }
                    }
                }
            }

            // Make sure all values have been set
            if (opennessValue == "")
            {
                opennessValue = FindSpaceSyntaxValue("None").ToString();
            }
            if (visualComplexityValue == "")
            {
                visualComplexityValue = FindSpaceSyntaxValue("None").ToString();
            }
            if (visualIntegrationValue == "")
            {
                visualIntegrationValue = FindSpaceSyntaxValue("None").ToString();
            }
        }
    }

    //Gets a space syntax value in the range specified (between 0 and 100)
    int FindSpaceSyntaxValue(string option)
    {
        //assumes range is 0 - 100
        if(option == "None")
        {
            return Random.Range(0, 100);
        }
        //assumes range is 0 - 20
        else if(option == "Lowest")
        {
            return Random.Range(0, 20);
        }
        //assumes range 20 - 40
        else if(option == "Low")
        {
            return Random.Range(20, 40);
        }
        //assumes range 40 - 60
        else if (option == "Moderate")
        {
            return Random.Range(40, 60);
        }
        //assumes range 60 - 80
        else if (option == "High")
        {
            return Random.Range(60, 80);
        }        
        //assumes range 80 - 100
        else if (option == "Highest")
        {
            return Random.Range(80, 100);
        }
        return -1;
    }

    //Remove reference until it gets to resources folder
    //Remove extension
    string FormatReference(string reference)
    {
        string formatted = reference;

        if (reference.Contains("Resources/"))
        {
            int last = formatted.LastIndexOf("Resources/") + 10; //length of the word 'Resources/' is 10
            formatted = formatted.Substring(last, formatted.Length - last);
        }

        return formatted;
    }   
}
