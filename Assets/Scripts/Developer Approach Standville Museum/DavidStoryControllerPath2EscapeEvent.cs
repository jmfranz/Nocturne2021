using Microsoft.MixedReality.Toolkit.Input;
using PathCreation.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DavidStoryControllerPath2EscapeEvent : MonoBehaviour
{
    public GameObject Player, DogRoomTrigger, Shadow, Max, ShadowChild, MaxInOrb, LastRoomObjects;

    public DialogueEventComponent DialogueBeforeShowingTrailToDogRoom;
    public ConditionalEventComponent NoEventCondition;
    public ConditionalEventComponent YesEventCondition;
    public ConditionalEventComponent EnteredMainRoomForYesEnding;

    public ConversationPlayer DogRoomConvo1;
    public SpeechInputHandler SpeechInputHandler;
    public DialogueEventComponent DogRoomConvo1_DialogueComponent;
    public DogMovementController DogMovementController;
    public DialogueEventComponent DogDialogueRoom1;
    public DialogueEventComponent DialogueLastRoom;
    public TimerEventComponent TimeToWaitBeforeShowingMaxInOrb;

    [SerializeField] Transform ShadowLastRoomLocation;

    public PathFollower MapToDogRoomPathFollower;

    public PathFollower LastToMainRoomPathFollower;
    public EnterLocationTrigger DogEnterLocationTrigger;
    public EnterLocationTrigger MainRoomTrigger;
    public AudioSource DogAudioSource;

    public ConversationPlayer ScaryMusic;

    public FadeShadow FadeShadow;
    bool triggeredEnding = false;


    bool testingYesTrustEnding = false; // FOR TESTING ONLY

    public GameObject EndingMessage;
    public DialogueEventComponent MainRoomConvoEnd;

    private void Start()
    {
        LastRoomObjects.SetActive(false);
        Max.SetActive(false);

        if (testingYesTrustEnding)
        {
            DogDialogueRoom1.OnEventEnd += EnableDogMovementController;
        }

        DogRoomConvo1_DialogueComponent.OnEventEnd += EnableSpeechInputHandler;
    }

    void Awake()
    {
        DialogueBeforeShowingTrailToDogRoom.OnEventEnd += ShowTrailToDogRoom;
        DialogueLastRoom.OnEventEnd += GoToMainRoom;
        TimeToWaitBeforeShowingMaxInOrb.OnEventEnd += ShowMaxInTinyOrb;
        EnteredMainRoomForYesEnding.OnEventEnd += PlayerEntersMainRoom;

        MainRoomConvoEnd.OnEventEnd += ShowEndingMessage;
    }

    void ShowEndingMessage()
    {
        EndingMessage.SetActive(true);
    }

    bool shadowDisappears = false;
    bool maxFollows = false;
    bool trustDog = false;
    bool reachedDogRoom = false;

    private void FixedUpdate()
    {
        if(DialogueLastRoom.ConversationPlayer._remainingLines.Count == 1 && !shadowDisappears)
        {
            shadowDisappears = true;
            ShadowDisappears();
            LastRoomObjects.SetActive(false);
        }
        
        if(DialogueLastRoom.ConversationPlayer._remainingLines.Count == 3 && !maxFollows)
        {
            maxFollows = true;
            Max.GetComponent<NPCtoFollowPlayer>().FollowPlayer = true;
        }

        if (DogRoomConvo1._hasCompletedConversation && testingYesTrustEnding && yesTrustDog && !trustDog)
        {
            trustDog = true;
            EnableDogMovementController();
        }

        if (DogEnterLocationTrigger.ReachedDestination && !reachedDogRoom)
        {
            reachedDogRoom = true;
            MapToDogRoomPathFollower.playPath = false;
            DogAudioSource.clip = null;
            DogAudioSource.Stop();
        }
    }

    void EnableSpeechInputHandler()
    {
        SpeechInputHandler.enabled = true;
    }

    void ShowTrailToDogRoom()
    {
        MapToDogRoomPathFollower.playPath = true;
        DogRoomTrigger.GetComponent<BoxCollider>().isTrigger = true;
    }

    void GoToMainRoom()
    {
        MainRoomTrigger.GetComponentInParent<BoxCollider>().enabled = true;
        LastToMainRoomPathFollower.playPath = true;

        EnableDogMovementController();

        ScaryMusic.enabled = true;
    }

    void PlayerEntersMainRoom()
    {
        Max.SetActive(false);
        ScaryMusic.enabled = false;
        ScaryMusic.GetComponent<AudioSource>().clip = null;
        LastToMainRoomPathFollower.playPath = false;
    }

    private void Update()
    {

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
        if (!DogRoomConvo1._hasCompletedConversation || triggeredEnding)
        {
            return;
        }
        triggeredEnding = true;
        NoEventCondition.CompleteConditionalEvent();
        SpeechInputHandler.enabled = false;
    }

    bool yesTrustDog = false;
    public void TrustDogAction()
    {
        if (!DogRoomConvo1._hasCompletedConversation || triggeredEnding)
        {
            return;
        }
        triggeredEnding = true;
        yesTrustDog = true;

        if (testingYesTrustEnding)
        {
            YesEventCondition.Status = StoryEventComponent.StoryEventStatus.Running;
            YesEventCondition.CompleteConditionalEvent();

            DogRoomConvo1.enabled = true;
        }

        YesEventCondition.CompleteConditionalEvent();

        DogDialogueRoom1.OnEventEnd += EnableDogMovementController;

        ShowLastRoom();
        Max.SetActive(true);
        SpeechInputHandler.enabled = false;
    }

    void ShowLastRoom()
    {
        Shadow.transform.position = ShadowLastRoomLocation.position;
        Shadow.transform.localRotation = Quaternion.Euler(0, 90, 0);
        ShadowChild.transform.localPosition = new Vector3(0, 0, 0);
        ShadowChild.transform.localRotation = new Quaternion(0, 0, 0, 0);
        Shadow.transform.GetChild(0).gameObject.SetActive(true);
        LastRoomObjects.SetActive(true);
    }

    void EnableDogMovementController()
    {
        DogMovementController.enabled = true;
    }

    void ShadowDisappears()
    {
        Shadow.transform.GetChild(0).GetChild(2).gameObject.SetActive(false);
        FadeShadow.enabled = true;
    }

    void ShowMaxInTinyOrb()
    {
        MaxInOrb.SetActive(true);
        MaxInOrb.transform.LookAt(Player.transform.position);
    }
}