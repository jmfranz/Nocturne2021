using PathCreation.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontTrustDogHandler : MonoBehaviour
{
    public DialogueEventComponent DontTrustDogComments;
    ConversationPlayer NoTrustDialogueConvo;
    public GameObject DogBreakingVaseVideo;

    // Dog Room To Planetarium PATH
    public PathFollower DogRoomToPlantariumPathFollower;
    public EnterLocationTrigger PlanetariumEnterLocationTrigger;

    public ConditionalEventComponent EnteredPlanetarium;

    public GameObject CraterRoomObjects, Max;
    public GameObject Shadow;
    public Transform ShadowPositionInCraterRoom;

    public DialogueEventComponent JohnReadsMural;
    public DialogueEventComponent GoToMainRoom;

    // Crater Room to Main Room PATH
    public PathFollower CraterRoomToMainRoomPathFollower;
    public EnterLocationTrigger MainRoomEnterLocationTrigger;

    public ConditionalEventComponent EnteredMainRoom;

    public GameObject MainRoomObjects;
    public ConversationPlayer ScaryMusic, PoliceConvo1, PoliceConvo2;
    public Transform Doctor, Player;
    public ConversationPlayer DoctorJohnConvo;

    bool DocWalksToPlayer = false;

    // Start is called before the first frame update
    void Start()
    {
        NoTrustDialogueConvo = DontTrustDogComments.ConversationPlayer;
        //StartCoroutine(ShowDogBreakingVaseVideo());

        DontTrustDogComments.OnEventEnd += ShowTrailDogRoomToPlanetarium;
        JohnReadsMural.OnEventEnd += ShowCraterRoom;

        GoToMainRoom.OnEventEnd += FinishedOtherRoom;
    }

    IEnumerator ShowDogBreakingVaseVideo()
    {
        yield return new WaitUntil(() => NoTrustDialogueConvo._remainingLines.Count == 8);

        //Play 5 second Video (if timing needs to be changed, change the "wait before" part of the dialogue "Don't trust dog ending convo")
        DogBreakingVaseVideo.SetActive(true);
        //TODO: play the video

        yield return new WaitForSeconds(5);
        DogBreakingVaseVideo.SetActive(false);
    }

    void ShowTrailDogRoomToPlanetarium()
    {
        DogRoomToPlantariumPathFollower.playPath = true;
        PlanetariumEnterLocationTrigger.GetComponentInParent<BoxCollider>().enabled = true;
        StartCoroutine(TriggersPlanetariumLocation());
    }

    IEnumerator TriggersPlanetariumLocation()
    {
        yield return new WaitUntil(() => PlanetariumEnterLocationTrigger.ReachedDestination);
        DogRoomToPlantariumPathFollower.playPath = false;
        EnteredPlanetarium.CompleteConditionalEvent();
    }

    void ShowCraterRoom()
    {
        Max.SetActive(true);
        CraterRoomObjects.SetActive(true);
        Shadow.transform.GetChild(0).gameObject.SetActive(true);
        Shadow.SetActive(false); // Disable shadow while setting its position
        Shadow.transform.SetPositionAndRotation(new Vector3(ShadowPositionInCraterRoom.position.x, 0, ShadowPositionInCraterRoom.position.z),
                                        Quaternion.Euler(0, 90, 0));
        Shadow.SetActive(true);
    }

    void FinishedOtherRoom()
    {
        ShowTrailCraterToMainRoom();
        UnShowCraterRoom();
        Max.GetComponent<NPCtoFollowPlayer>().FollowPlayer = true;

        ScaryMusic.enabled = true;
        PoliceConvo1.enabled = true;
        PoliceConvo2.enabled = true;
    }

    void UnShowCraterRoom()
    {
        CraterRoomObjects.SetActive(false);
        Shadow.transform.GetChild(0).gameObject.SetActive(false);
    }

    void ShowTrailCraterToMainRoom()
    {
        CraterRoomToMainRoomPathFollower.playPath = true;
        MainRoomEnterLocationTrigger.GetComponentInParent<BoxCollider>().enabled = true;
        StartCoroutine(TriggersMainRoomLocation());
        MainRoomObjects.SetActive(true);
    }

    IEnumerator TriggersMainRoomLocation()
    {
        yield return new WaitUntil(() => MainRoomEnterLocationTrigger.ReachedDestination);
        CraterRoomToMainRoomPathFollower.playPath = false;
        EnteredMainRoom.CompleteConditionalEvent();

        ScaryMusic.enabled = false;
        ScaryMusic.GetComponent<AudioSource>().clip = null;

        DocWalksToPlayer = true;
    }

    private void Update()
    {
        if (DocWalksToPlayer)
        {
            float distance = Vector3.Distance(Doctor.position, Player.position);

            if (distance < 2f) // Doctor is in front of player and starts talking
            {
                DoctorJohnConvo.enabled = true;
                DocWalksToPlayer = false;
            }
            else // Doctor moves to Player
            {
                Doctor.GetComponent<AvatarController>().SetDestination(Player.position);
            }
        }   
    }
}
