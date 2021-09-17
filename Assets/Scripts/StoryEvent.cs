using System.Collections.Generic;

[System.Serializable]
public class StoryEvent 
{
    public string Name; //unique identifier

    //Temporarily limit precondtions to existing events and story event actions
    public List<string> Preconditions_Events = new List<string>();
    public List<StoryEventComponent.StoryEventActions> Preconditions_Actions = new List<StoryEventComponent.StoryEventActions>();

    public enum EventTypes { Traversal, Timer };
    public EventTypes EventType;
    public string Description;
}
