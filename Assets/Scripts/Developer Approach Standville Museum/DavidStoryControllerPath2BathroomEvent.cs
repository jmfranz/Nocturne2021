using PathCreation.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DavidStoryControllerPath2BathroomEvent : MonoBehaviour
{
    public TimerEventComponent TimeToWaitBeforeHighlightingSecurityCamera;
    public GameObject SecurityCameraHighlight;
    public GameObject BathroomJohnFoundCam1;
    public DialogueEventComponent BathroomBloodConvo;
    public ConditionalEventComponent StartGame;
    public Fade BloodTextFade;

    ConversationPlayer securityCameraConversationPlayer;
    bool highlightShowing = false;

    bool shownTrailToMap = false;

    public PathFollower MapToSecurityRoomPathFollower;
    public EnterLocationTrigger SecurityEnterLocationTrigger;

    void Awake()
    {
        securityCameraConversationPlayer = BathroomJohnFoundCam1.GetComponent<ConversationPlayer>();

        TimeToWaitBeforeHighlightingSecurityCamera.OnEventEnd += HelpPlayerFindCamera;
        BathroomBloodConvo.OnEventEnd += EnableSecurityCameraConvo;
        StartGame.OnEventEnd += EnableTextFade;
    }

    void Update()
    {
        if (highlightShowing && securityCameraConversationPlayer._hasCompletedConversation)
        {
            PlayerFoundCamera();
            ShowTrailToSecurityRoom();
        }
        else if (!shownTrailToMap && securityCameraConversationPlayer._hasCompletedConversation)
        {
            shownTrailToMap = true;
            ShowTrailToSecurityRoom();
        }
    }

    void EnableSecurityCameraConvo()
    {
        BathroomJohnFoundCam1.GetComponent<ObjectTalking>().enabled = true;
    }

    void ShowTrailToSecurityRoom()
    {
        MapToSecurityRoomPathFollower.playPath = true;
    }

    private void FixedUpdate()
    {
        if(SecurityEnterLocationTrigger.ReachedDestination && MapToSecurityRoomPathFollower.playPath)
        {
            MapToSecurityRoomPathFollower.playPath = false;
        }
    }

    void HelpPlayerFindCamera()
    {
        // Make sure the conversation is not already playing or has been played
        if (!(securityCameraConversationPlayer.enabled || securityCameraConversationPlayer._hasCompletedConversation))
        {
            HighlightSecurityCamera();
        }
        else
        {
            securityCameraConversationPlayer.transform.gameObject.SetActive(false);
        }
    }

    public void HighlightSecurityCamera()
    {
        highlightShowing = true;
        SecurityCameraHighlight.SetActive(true);
    }

    void PlayerFoundCamera()
    {
        UnHighlightSecurityCamera();
        securityCameraConversationPlayer.transform.gameObject.SetActive(false);
    }

    public void UnHighlightSecurityCamera()
    {
        highlightShowing = false;
        SecurityCameraHighlight.SetActive(false);
        SecurityEnterLocationTrigger.GetComponent<BoxCollider>().enabled = true;
    }

    void EnableTextFade()
    {
        BloodTextFade.enabled = true;
    }
}
