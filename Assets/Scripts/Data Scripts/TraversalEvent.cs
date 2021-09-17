using UnityEngine;

[System.Serializable]
public class TraversalEvent : StoryEvent
{
    public string AvatarToMove;
    public string Location; //includes conversations, or anywhere
    public enum MovementSpeeds {Walk, WalkFast, Run};
    public MovementSpeeds MovementSpeed;

    public TraversalEvent(string name, string avatarToMove, string location, MovementSpeeds movementSpeed)
    {
        Name = name;
        AvatarToMove = avatarToMove;
        Location = location;
        MovementSpeed = movementSpeed;
        EventType = StoryEvent.EventTypes.Traversal;
        //Preconditions.Add("Game Start"); //TODO: Edit to work with changes
        CreateDescription();
    }

    public void CreateDescription()
    {
        Description = "Move Avatar " + AvatarToMove + " to " + Location;
    }

    public static MovementSpeeds GetMovementSpeed(string name)
    {
        switch (name)
        {
            case "Walk":
                return MovementSpeeds.Walk;
            case "Fast Walk":
                return MovementSpeeds.WalkFast;
            case "Run":
                return MovementSpeeds.Run;
            default:
                Debug.LogErrorFormat("ERROR: Movement Speeds input '{0}' is undefined", name);
                return MovementSpeeds.Walk;
        }

    }
}
