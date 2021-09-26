using Microsoft.MixedReality.Toolkit.Input;
using PathCreation.Examples;
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
    public SpeechInputHandler SpeechInputHandler;
    public DialogueEventComponent DogRoomConvo1_DialogueComponent;
    public DogMovementController DogMovementController;
    public DialogueEventComponent DogDialogueRoom1;
    public DialogueEventComponent DialogueBeforeLastRoom;
    public DialogueEventComponent DialogueLastRoom;
    public TimerEventComponent TimeToWaitBeforeShowingMaxInOrb;

    [SerializeField] Transform ShadowLastRoomLocation;

    public PathFollower MapToDogRoomPathFollower;
    public EnterLocationTrigger DogEnterLocationTrigger;
    public EnterLocationTrigger MainRoomTrigger;
    public AudioSource DogAudioSource;

    public ConversationPlayer ScaryMusic;

    public FadeShadow FadeShadow;
    bool triggeredEnding = false;

    bool testingYesTrustEnding = false; // FOR TESTING ONLY

    private void Start()
    {
        LastRoomObjects.SetActive(false);
        Max.SetActive(false);

        if (testingYesTrustEnding)
        {
            DogDialogueRoom1.OnEventEnd += EnableDogMovementController;
        }

        DogRoomConvo1_DialogueComponent.OnEventEnd += EnableSpeechInputHandler;

        //MapToDogRoomPathFollower.pathCreator.InitializeEditorData(false);
    }

    void Awake()
    {
        DialogueBeforeShowingTrailToDogRoom.OnEventEnd += ShowTrailToDogRoom;
        DialogueLastRoom.OnEventEnd += GoToMainRoom;
        TimeToWaitBeforeShowingMaxInOrb.OnEventEnd += ShowMaxInTinyOrb;
        EnteredMainRoomForYesEnding.OnEventEnd += PlayerEntersMainRoom;

        StartCoroutine(WaitForShadowDialogue());
        StartCoroutine(WaitForMaxToFollowPlayer());
    }

    IEnumerator WaitForShadowDialogue()
    {
        yield return new WaitUntil(() => DialogueLastRoom.ConversationPlayer._remainingLines.Count == 1);
        ShadowDisappears();
        LastRoomObjects.SetActive(false);
    }

    IEnumerator WaitForMaxToFollowPlayer()
    {
        yield return new WaitUntil(() => DialogueLastRoom.ConversationPlayer._remainingLines.Count == 3);
        Max.GetComponent<NPCtoFollowPlayer>().FollowPlayer = true;
    }

    void EnableSpeechInputHandler()
    {
        SpeechInputHandler.enabled = true;
    }

    void ShowTrailToDogRoom()
    {
        //Vector3 pos = Player.transform.position;
        //MapToDogRoomPathFollower.pathCreator.bezierPath.MovePoint(0, Camera.main.transform.position);
        MapToDogRoomPathFollower.playPath = true;
        DogRoomTrigger.GetComponent<BoxCollider>().isTrigger = true;
        //LastRoomObjects.SetActive(true);
        //Max.SetActive(true);
        StartCoroutine(TriggersDogLocation());
    }

    IEnumerator TriggersDogLocation()
    {
        yield return new WaitUntil(() => DogEnterLocationTrigger.ReachedDestination);
        MapToDogRoomPathFollower.playPath = false;
        DogAudioSource.Stop();
    }

    void GoToMainRoom()
    {
        MainRoomTrigger.GetComponentInParent<BoxCollider>().enabled = true;

        EnableDogMovementController();

        //Max.GetComponent<NPCtoFollowPlayer>().FollowPlayer = true;

        ScaryMusic.enabled = true;

        //ShadowDisappears();
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
        if (!DogRoomConvo1._hasCompletedConversation || triggeredEnding)
        {
            return;
        }
        triggeredEnding = true;
        NoEventCondition.CompleteConditionalEvent();
        SpeechInputHandler.enabled = false;
    }

    public void TrustDogAction()
    {
        if (!DogRoomConvo1._hasCompletedConversation || triggeredEnding)
        {
            return;
        }
        triggeredEnding = true;

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
        Max.SetActive(true);
        SpeechInputHandler.enabled = false;
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
        Shadow.transform.GetChild(0).GetChild(2).gameObject.SetActive(false);
        FadeShadow.enabled = true;
    }

    void ShowMaxInTinyOrb()
    {
        MaxInOrb.SetActive(true);
        MaxInOrb.transform.position = Player.transform.position + (Player.transform.forward * 2f);
        MaxInOrb.transform.LookAt(Player.transform.position);
    }
}
