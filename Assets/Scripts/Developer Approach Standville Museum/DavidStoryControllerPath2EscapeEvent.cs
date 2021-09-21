﻿using PathCreation.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DavidStoryControllerPath2EscapeEvent : MonoBehaviour
{
    public GameObject Player, DogRoomTrigger, Shadow, Max, ShadowChild, MaxInOrb, LastRoomObjects;   

    public DialogueEventComponent DialogueBeforeShowingTrailToDogRoom;
    public DialogueEventComponent DialogueBeforeShowingTrailToDog;
    public ConditionalEventComponent NoEventCondition;
    public ConditionalEventComponent YesEventCondition;
    public ConditionalEventComponent EnteredMainRoomForYesEnding;

    public ConversationPlayer DogRoomConvo1;
    public DogMovementController DogMovementController;
    public DialogueEventComponent DogDialogueRoom1;
    public DialogueEventComponent DialogueBeforeLastRoom;
    public DialogueEventComponent DialogueLastRoom;
    public TimerEventComponent TimeToWaitBeforeShowingMaxInOrb;

    [SerializeField] Transform ShadowLastRoomLocation;

    public PathFollower MapToDogRoomPathFollower;
    public EnterLocationTrigger DogEnterLocationTrigger;
    public EnterLocationTrigger MainRoomTrigger;

    public ConversationPlayer ScaryMusic;

    bool testingYesTrustEnding = false; // FOR TESTING ONLY

    private void Start()
    {
        LastRoomObjects.SetActive(false);
        Max.SetActive(false);

        if (testingYesTrustEnding)
        {
            DogDialogueRoom1.OnEventEnd += EnableDogMovementController;
        }
    }

    void Awake()
    {
        DialogueBeforeShowingTrailToDogRoom.OnEventEnd += ShowTrailToDogRoom;
        DialogueLastRoom.OnEventEnd += GoToMainRoom;
        TimeToWaitBeforeShowingMaxInOrb.OnEventEnd += ShowMaxInTinyOrb;
        EnteredMainRoomForYesEnding.OnEventEnd += PlayerEntersMainRoom;
    }

    void ShowTrailToDogRoom()
    {
        Vector3 pos = Player.transform.position;
        MapToDogRoomPathFollower.pathCreator.bezierPath.AddSegmentToStart(new Vector3(pos.x, 1.2f, pos.z));
        MapToDogRoomPathFollower.playPath = true;
        DogRoomTrigger.GetComponent<BoxCollider>().isTrigger = true;
        //LastRoomObjects.SetActive(true);
        Max.SetActive(true);
        StartCoroutine(TriggersDogLocation());
    }

    IEnumerator TriggersDogLocation()
    {
        yield return new WaitUntil(() => DogEnterLocationTrigger.ReachedDestination);
        MapToDogRoomPathFollower.playPath = false;
    }

    void GoToMainRoom()
    {
        MainRoomTrigger.GetComponentInParent<BoxCollider>().enabled = true;

        EnableDogMovementController();

        Max.GetComponent<NPCtoFollowPlayer>().FollowPlayer = true;
        ScaryMusic.enabled = true;
    }

    void PlayerEntersMainRoom()
    {
        Max.SetActive(false);
        ScaryMusic.enabled = false;
        ScaryMusic.GetComponent<AudioSource>().clip = null;
    }

    private void Update()
    {
        //#if  UNITY_EDITOR
        //    if (Input.GetKeyDown("y"))
        //    {
        //        TrustDogAction();
        //    }

        //    if (Input.GetKeyDown("n"))
        //    {
        //        DontTrustDogAction();
        //    }
        //#endif

        #if UNITY_ANDROID
            if (OVRInput.Get(OVRInput.Button.One))
            {
                TrustDogAction();
            }

            if (OVRInput.Get(OVRInput.Button.Two))
            {
                DontTrustDogAction();
            }
        #endif
    }

    public void DontTrustDogAction()
    {
        Debug.Log("No, I don't trust the dog");
        NoEventCondition.CompleteConditionalEvent();
    }

    public void TrustDogAction()
    {
        Debug.Log("Of course, I trust the dog");
        if (testingYesTrustEnding)
        {
            YesEventCondition.Status = StoryEventComponent.StoryEventStatus.Running;
            YesEventCondition.CompleteConditionalEvent();

            DogRoomConvo1.enabled = true;
            StartCoroutine(WaitForDialogueFinished());
        }

        YesEventCondition.CompleteConditionalEvent();

        DogDialogueRoom1.OnEventEnd += EnableDogMovementController;

        ShowLastRoom();
    }

    IEnumerator WaitForDialogueFinished()
    {
        yield return new WaitUntil(() => DogRoomConvo1._hasCompletedConversation);
        EnableDogMovementController();
    }

    void ShowLastRoom()
    {
        Shadow.transform.position = ShadowLastRoomLocation.position;
        ShadowChild.transform.localPosition = new Vector3(0, 0, 0);
        ShadowChild.transform.localRotation = new Quaternion(0,0,0,0);
        Shadow.transform.GetChild(0).gameObject.SetActive(true);
        LastRoomObjects.SetActive(true);
    }

    void EnableDogMovementController()
    {
        DogMovementController.enabled = true;
    }

    void ShadowDisappears()
    {
        ShadowChild.gameObject.SetActive(false);
    }

    void ShowMaxInTinyOrb()
    {
        MaxInOrb.SetActive(true);
        MaxInOrb.transform.position = Player.transform.position + (Player.transform.forward * 2f);
        MaxInOrb.transform.LookAt(Player.transform.position);
    }
}
