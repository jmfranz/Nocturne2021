using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EventInstaller : Editor
{
    static GameObject _eventHandlerObject;
    static Dictionary<string, StoryEventComponent> _storyEventComponents = new Dictionary<string, StoryEventComponent>();

    //Entry point to loading Event Story Data
    public static void LoadStoryJsonData()
    {
        _eventHandlerObject = new GameObject("EventHandler");

        List<TimerEvent> timerEventData = GameState.Instance.GetCurrentStoryData().TimerEvents;
        List<TraversalEvent> traversalEventData = GameState.Instance.GetCurrentStoryData().TraversalEvents;

        foreach (var data in timerEventData)
        {
            var newComponent = InstallTimerEvent(data);
            if(newComponent != null)
            {
                _storyEventComponents.Add(data.Name, newComponent);
            }
        }
        foreach (var data in traversalEventData)
        {
            var newComponent = InstallTraversalEvent(data);
            if(newComponent != null)
            {
                _storyEventComponents.Add(data.Name, newComponent);
            }
        }

        //As all components need to exist before preconditions need to be hooked up, do this step afterwards
        foreach (TimerEvent data in timerEventData)
        {
            SetupPreconditions(data);
        }
        foreach (TraversalEvent data in traversalEventData)
        {
            if(data.AvatarToMove != "")
            {
                SetupPreconditions(data);
            }
        }
    }

    static void SetupPreconditions(StoryEvent storyEvent)
    {
        StoryEventComponent storyEventComp = _storyEventComponents[storyEvent.Name];

        List<StoryEventComponent> preconditionsComponents = new List<StoryEventComponent>();
        foreach(string preEvent in storyEvent.Preconditions_Events)
        {
            preconditionsComponents.Add(_storyEventComponents[preEvent]);
        }

        storyEventComp.SetupPreconditions(preconditionsComponents, storyEvent.Preconditions_Actions);
    }

    static StoryEventComponent InstallTimerEvent(TimerEvent timerEvent)
    {
        var comp = _eventHandlerObject.AddComponent<TimerEventComponent>();

        //Initialize component
        comp.Init(timerEvent.Time);
        return comp;
    }

    static StoryEventComponent InstallTraversalEvent(TraversalEvent traversalEvent)
    {
        if(traversalEvent.AvatarToMove == "") // avatar was deleted after the traversal event was created
        {
            return null;
        }
        var comp = _eventHandlerObject.AddComponent<TraversalEventComponent>();

        //Get AvatarController
        AvatarController controller = GameObject.Find(traversalEvent.AvatarToMove).GetComponent<AvatarController>();

        //Get MovementType
        AvatarController.MovementTypes type;
        switch(traversalEvent.MovementSpeed)
        {
            case TraversalEvent.MovementSpeeds.Walk:
                type = AvatarController.MovementTypes.Walk;
                break;
            case TraversalEvent.MovementSpeeds.WalkFast:
                type = AvatarController.MovementTypes.FastWalk;
                break;
            case TraversalEvent.MovementSpeeds.Run:
                type = AvatarController.MovementTypes.Run;
                break;
            default:
                Debug.LogErrorFormat("MovementSpeed type not found in parsing '{0}'", traversalEvent.MovementSpeed);
                return null;
        }

        //Get ConversationNode
        ConversationNode node = GameObject.Find(traversalEvent.Location).GetComponent<ConversationNode>(); //TODO: Expand beyond conversation node destinations. Each object in project may want its own ID.

        //Initialize component
        comp.Init(controller, type, node);
        return comp;
    }
}
