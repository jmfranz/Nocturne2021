/*  
 * Author: Abbey Singh
 * This holds data about the story/mapping pair  
 */ 
 
 using System.Collections.Generic;

[System.Serializable] 
public class StoryData { 

    public string Title; 
    public string Author; 
    public string Genre; 
    public List<StoryElement> StoryElements = new List<StoryElement>();
    public List<ConversationNodeData> ConversationNodeDatas = new List<ConversationNodeData>();
    public List<string> Maps = new List<string> { "Mona Campbell", "Goldberg" };
    public List<Group> Groups = new List<Group>();
    public List<StoryEvent> Events = new List<StoryEvent>();
    public List<TimerEvent> TimerEvents = new List<TimerEvent>();
    public List<TraversalEvent> TraversalEvents = new List<TraversalEvent>();
    public string MapSelected = "Mona Campbell";

    public RoomController RoomController = new RoomController();

    public RoomController GetRoomController() { return RoomController; }
    public void SetRoomController(RoomController roomController) { RoomController = roomController; }

    public List<TraversalEvent> GetTraversalEvents()
    {
        return TraversalEvents;
    }

    public List<StoryEvent> GetEvents()
    {
        return Events;
    }

    public void AddStoryEvent(StoryEvent storyEvent)
    {
        Events.Add(storyEvent);

        switch(storyEvent.EventType)
        {
            case StoryEvent.EventTypes.Timer:
                TimerEvents.Add(storyEvent as TimerEvent);
                break;
            case StoryEvent.EventTypes.Traversal:
                TraversalEvents.Add(storyEvent as TraversalEvent);
                break;
        }
    }

    public void DeleteEvent(string name)
    {
        int size = Events.Count;
        StoryEvent eventToRemove = new StoryEvent();

        for (int j = 0; j < size; j++)
        {
            StoryEvent storyEvent = Events[j];
            if (storyEvent.Name == name)
            {
                eventToRemove = storyEvent;
            }
            else
            {
                // remove this event from other object's preconditions
                for (int i = 0; i < storyEvent.Preconditions_Events.Count; i++)
                {
                    if(storyEvent.Preconditions_Events[i] == name)
                    {
                        storyEvent.Preconditions_Events.RemoveAt(i);
                        storyEvent.Preconditions_Actions.RemoveAt(i);
                        break;
                    }
                }
            }
        }

        Events.Remove(eventToRemove);

        switch (eventToRemove.EventType)
        {
            case StoryEvent.EventTypes.Timer:
                TimerEvents.Remove(eventToRemove as TimerEvent);
                break;
            case StoryEvent.EventTypes.Traversal:
                TraversalEvents.Remove(eventToRemove as TraversalEvent);
                break;
        }
    }

    public List<ConversationNodeData> GetConversationNodeDatas()
    {
        return ConversationNodeDatas;
    }

    public void AddConversationNodeData(ConversationNodeData conversationNodeData)
    {
        ConversationNodeDatas.Add(conversationNodeData);
    }


    public void DeleteConversationNodeData(string name)
    {
        foreach(ConversationNodeData conversationNodeData in ConversationNodeDatas)
        {
            if(conversationNodeData.Title == name)
            {
                // Initial Placed avatars should have "ShouldPlace" true
                List<string> names = conversationNodeData.InitialPlacedAvatars;
                foreach(string storyElementName in names)
                {
                    if(storyElementName != "")
                    {
                        StoryElement storyElement = FindStoryElement(storyElementName);
                        storyElement.ShouldPlace = true;
                    }
                }

                ConversationNodeDatas.Remove(conversationNodeData);
                break;
            }
        }
    }

    public ConversationNodeData FindConversationNodeData(string name)
    {
        foreach (var conversationNodeData in ConversationNodeDatas)
        {
            if (name == conversationNodeData.Title)
            {
                return conversationNodeData;
            }
        }

        return null;
    }

    public bool IsUniqueEventName(string name)
    {
        foreach (var storyEvent in Events)
        {
            if (name == storyEvent.Name)
            {
                return false;
            }
        }

        return true;
    }

    public List<StoryElement> GetStoryElements()
    {
        return StoryElements;
    }

    public void AddStoryElement(StoryElement storyElement)
    {
        StoryElements.Add(storyElement);
    }

    public void RemoveStoryElement(string name)
    {
        StoryElements.Remove(FindStoryElement(name));
    }

    //Returns a storyelement with the unique name
    public StoryElement FindStoryElement(string name)
    {
        foreach(var storyElement in StoryElements)
        {
            if(name == storyElement.Name)
            {
                return storyElement;
            }
        }

        return null;
    }

    //Add storyelements to group
    public void SetGroup(List<StoryElement> groupList, string groupName)
    {
        if (IsUniqueName(groupName))
        {
            foreach (StoryElement member in groupList)
            {
                member.AddGroup(groupName);
            }
        }
        else
        {
            UnityEngine.Debug.LogFormat("Group Name '{0}' is not unique.", groupName);
        }
    }

    //Returns a list of all story elements that are a part of that group
    public List<StoryElement> GetStoryElementsFromGroup(string groupName)
    {
        List<StoryElement> groupList = new List<StoryElement>();

        foreach(var storyElement in StoryElements)
        {
            foreach(var group in storyElement.GetGroups())
            {
                if (group == groupName)
                {
                    groupList.Add(storyElement);
                    break;
                }
            }
        }

        return groupList;
    }


    public void ChangeNameOfStoryElement(string oldName, string newName)
    {
        if (IsUniqueName(newName))
        {
            FindStoryElement(oldName).Name = newName;
        }
        else
        {
            UnityEngine.Debug.LogFormat("Name '{0}' is not unique.", newName);
        }
    }

    //Checks if story element has a unique name
    public bool IsUniqueName(string name)
    {
        foreach(var storyElement in StoryElements)
        {
            if(name == storyElement.Name)
            {
                return false;
            }
        }

        return true;
    }

    public List<Group> GetGroups()
    {
        return Groups;
    }

    //Returns true if the group was successfully added
    public bool AddGroup(string groupName)
    {
        if (IsUniqueGroup(groupName) && groupName != "")
        {
            Group newGroup = new Group(groupName);
            Groups.Add(newGroup);
            return true;
        }
        else
        {
            UnityEngine.Debug.LogFormat("There already exists group with name '{0}'", groupName);
            return false;
        }
    }

    //Assumes that name and group names are not the same
    public bool IsUniqueGroup(string name)
    {
        foreach (var group in Groups)
        {
            if (name == group.GroupName || name == group.GroupName)
            {
                return false;
            }
        }

        return true;
    }

    public bool IsUniqueStoryElementName(string name)
    {
        foreach(var storyElement in StoryElements)
        {
            if(storyElement.Name == name)
            {
                return false;
            }
        }

        return true;
    }

    public void RemoveGroups(List<string> groupsToRemove)
    {
        foreach(string group in groupsToRemove)
        {
            //Remove group from any storyelement in that group
            for (int i = 0; i < StoryElements.Count; i++)
            {
                for(int j = 0; j < StoryElements[i].GetGroups().Count; j++)
                {
                    if(StoryElements[i].GetGroups()[j] == group)
                    {
                        StoryElements[i].RemoveGroup(group);
                    }
                }
            }

            Groups.Remove(FindGroup(group));
        }
    }

    public Group FindGroup(string groupName)
    {
        foreach(var group in Groups)
        {
            if(groupName == group.GroupName)
            {
                return group;
            }
        }

        return null;
    }
}

