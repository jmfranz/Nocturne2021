using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class StoryEventComponent : MonoBehaviour
{
    public string name = "";
    public enum StoryEventStatus { Waiting, Running, Stopped }
    public enum StoryEventActions { Start, End }

    public event Action OnEventStart;
    public event Action OnEventEnd;
    public StoryEventStatus Status = StoryEventComponent.StoryEventStatus.Waiting;
    public List<Condition> _preConditions = new List<Condition>(); //Possibly extend to have a bool if precondition needs to be ACTIVELY true or only true ONCE - for interuption
    public List<Condition> _postConditions = new List<Condition>();

    // STATIC OBJECTS
    public static string logFilename = "story.csv"; // Keeping track of when the story is logged.
    public static bool logFileSetUp = false;        // Check if the log file has been set up or not.

    public virtual IEnumerator DoEventAction() { Debug.LogError("This function needs to be overridden"); return null; }
    public virtual void DoEventStoppedAction() { return; } // This function is optionally used by certain events (animation)

    //Must get called before Start to work properly
    public void SetupPreconditions(List<StoryEventComponent> eventComponents, List<StoryEventActions> eventActions)
    {
        if (eventComponents.Count != eventActions.Count)
        {
            Debug.LogErrorFormat("Cannot set up preconditions as two provided lists need to be the same size. " +
                "Size found instead is '{0}' and '{1}'", eventComponents.Count, eventActions.Count);
        }

        for (int i = 0; i < eventComponents.Count; i++)
        {
            StoryEventComponent eventComponent = eventComponents[i];
            StoryEventActions eventAction = eventActions[i];

            _preConditions.Add(new Condition(eventComponent, eventAction));
        }
    }

    public static string ParseStoryEventAction(StoryEventActions action)
    {
        switch (action)
        {
            case StoryEventActions.Start:
                return "Started";
            case StoryEventActions.End:
                return "Completed";
            default:
                Debug.LogErrorFormat("Story Event action can not be found. '{0}'", action);
                return "ERROR";
        }
    }

    public static StoryEventActions ParseStoryStringAsEventAction(string actionName)
    {
        switch (actionName)
        {
            case "Started":
                return StoryEventActions.Start;
            case "Completed":
                return StoryEventActions.End;
            default:
                Debug.LogErrorFormat("Story Event action can not be found. '{0}'", actionName);
                return StoryEventActions.Start;
        }
    }

    void Start()
    {
        // Try to set up the log file.
        if (!logFileSetUp)
        {
            string path = Application.dataPath + "/Data/" + logFilename;

            if (!File.Exists(path))
            {
                StreamWriter swt = File.CreateText(path);
                swt.WriteLine("Date,Hour,Minute,Second,Milisecond,EventName,Event,Scene,IsMaster");
                swt.Close();
            }

            logFileSetUp = true;
        }

        //No preconditions means run at game start
        if (_preConditions.Count == 0)
        {
            co = StartCoroutine(TriggerEvent());
        }

        //Otherwise, subscribe to each storyevent for its preconditions
        foreach (var storyEventPair in _preConditions)
        {
            switch (storyEventPair.Action)
            {
                case StoryEventActions.Start:
                    storyEventPair.Component.OnEventStart += OnPreconditionChange;
                    break;
                case StoryEventActions.End:
                    storyEventPair.Component.OnEventEnd += OnPreconditionChange;
                    break;
                default:
                    Debug.LogErrorFormat("[PRECONDITION] StoryEventAction '{0}' not found", storyEventPair.Action);
                    break;
            }
        }

        //Otherwise, subscribe to each storyevent for its post conditions
        foreach (var storyEventPair in _postConditions)
        {
            switch (storyEventPair.Action)
            {
                case StoryEventActions.Start:
                    storyEventPair.Component.OnEventStart += OnPostconditionChange;
                    break;
                case StoryEventActions.End:
                    storyEventPair.Component.OnEventEnd += OnPostconditionChange;
                    break;
                default:
                    Debug.LogErrorFormat("[POSTCONDITION] StoryEventAction '{0}' not found", storyEventPair.Action);
                    break;
            }
        }

    }


    Coroutine co;

    void OnPostconditionChange()
    {
        if (Status != StoryEventStatus.Running)
        {
            return;
        }

        //Check for each postcondition - if each passes then start event
        bool hasPostConditionPassed = true; //until proven false


        foreach (var storyEventPair in _postConditions)
        {
            switch (storyEventPair.Action)
            {
                case StoryEventActions.Start:
                    if (storyEventPair.Component.Status == StoryEventStatus.Waiting)
                    {
                        hasPostConditionPassed = false;
                    }
                    break;
                case StoryEventActions.End:
                    if (storyEventPair.Component.Status == StoryEventStatus.Waiting || storyEventPair.Component.Status == StoryEventStatus.Running)
                    {
                        hasPostConditionPassed = false;
                    }
                    break;
            }

            //Break out early if not passed
            if (!hasPostConditionPassed)
            {
                break;
            }
        }

        if (hasPostConditionPassed)
        {
            InterruptEvent();
        }
    }

    public void InterruptEvent()
    {
        EventFinished();
        StopCoroutine(co);
    }


    void OnPreconditionChange()
    {
        //Currently ignore precondition changes when this event is running (and currently stopped, though better to unsubscribe when stopped
        if (Status == StoryEventStatus.Running || Status == StoryEventStatus.Stopped)
        {
            return;
        }

        //Check for each precondition - if each passes then start event
        bool hasPreConditionPassed = true; //until proven false

        foreach (var storyEventPair in _preConditions)
        {
            switch (storyEventPair.Action)
            {
                case StoryEventActions.Start:
                    if (storyEventPair.Component.Status == StoryEventStatus.Waiting)
                    {
                        hasPreConditionPassed = false;
                    }
                    break;
                case StoryEventActions.End:
                    if (storyEventPair.Component.Status == StoryEventStatus.Waiting || storyEventPair.Component.Status == StoryEventStatus.Running)
                    {
                        hasPreConditionPassed = false;
                    }
                    break;
            }

            //Break out early if not passed
            if (!hasPreConditionPassed)
            {
                break;
            }
        }

        if (hasPreConditionPassed)
        {
            co = StartCoroutine(TriggerEvent());
        }
    }


    IEnumerator TriggerEvent()
    {
        Status = StoryEventStatus.Running;
        OnEventStart?.Invoke();

        // Tells across network this event starts
        if(name != "") GameObject.Find("Event Data Synchronization").GetComponent<EventDataSync>().SetEventData(name, true);

        // Log the events.
        string path = Application.dataPath + "/Data/" + logFilename;
        StreamWriter sw = new StreamWriter(path, true);

        DateTime now = DateTime.Now;
        string date = now.ToString("yyyy-MM-dd");

        string log = string.Format("{0},{1},{2},{3},{4},{5},Start,{6},{7}", 
            date, now.Hour, now.Minute, now.Second, now.Millisecond, 
            name,
            SceneManager.GetActiveScene().name, PhotonNetwork.IsMasterClient);
        sw.WriteLine(log);

        //Wait for action to finish
        yield return StartCoroutine(DoEventAction());

        EventFinished();

        // Tells across network this event finishes
        if(name != "") GameObject.Find("Event Data Synchronization").GetComponent<EventDataSync>().SetEventData(name, false);

        // Log the event and close the stream.
        now = DateTime.Now;
        date = now.ToString("yyyy-MM-dd");
        log = string.Format("{0},{1},{2},{3},{4},{5},End,{6},{7}", 
            date, now.Hour, now.Minute, now.Second, now.Millisecond, 
            name,
            SceneManager.GetActiveScene().name, PhotonNetwork.IsMasterClient);
        sw.WriteLine(log);
        sw.Close();
    }


    void EventFinished()
    {
        Status = StoryEventStatus.Stopped;
        DoEventStoppedAction();
        OnEventEnd?.Invoke();

        //Unsubscribe to all preconditions
        foreach (var storyEventPair in _preConditions)
        {
            switch (storyEventPair.Action)
            {
                case StoryEventActions.Start:
                    storyEventPair.Component.OnEventStart -= OnPreconditionChange;
                    break;
                case StoryEventActions.End:
                    storyEventPair.Component.OnEventEnd -= OnPreconditionChange;
                    break;
            }
        }

        //Unsubscribe to all postconditions
        foreach (var storyEventPair in _postConditions)
        {
            switch (storyEventPair.Action)
            {
                case StoryEventActions.Start:
                    storyEventPair.Component.OnEventStart -= OnPostconditionChange;
                    break;
                case StoryEventActions.End:
                    storyEventPair.Component.OnEventEnd -= OnPostconditionChange;
                    break;
            }
        }
    }

    [Serializable]
    public class Condition
    {
        public StoryEventComponent Component;
        public StoryEventActions Action;

        public Condition(StoryEventComponent comp, StoryEventActions action)
        {
            Component = comp;
            Action = action;
        }
    }
}


