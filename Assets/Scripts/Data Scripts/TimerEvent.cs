[System.Serializable]
public class TimerEvent : StoryEvent
{
    public float Time;

    public TimerEvent(string name, float time)
    {
        Name = name;
        Time = time;
        EventType = StoryEvent.EventTypes.Timer;
        //Preconditions.Add("Game Start"); //TODO: Edit to work with others
        CreateDescription();
    }

    public void CreateDescription()
    {
        Description = "Wait " + Time + " seconds";
    }
}
