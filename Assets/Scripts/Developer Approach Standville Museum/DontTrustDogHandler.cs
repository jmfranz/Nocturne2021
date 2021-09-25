using PathCreation.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DontTrustDogHandler : MonoBehaviour
{
    public DialogueEventComponent DontTrustDogComments;
    ConversationPlayer NoTrustDialogueConvo;

    // Dog Room To Planetarium PATH
    public PathFollower DogRoomToPlantariumPathFollower;
    public EnterLocationTrigger PlanetariumEnterLocationTrigger;

    public ConditionalEventComponent EnteredPlanetarium;

    public GameObject CraterRoomObjects, Max, Dog;
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

    public FadeShadow FadeShadow;

    bool DocWalksToPlayer = false;

    // Start is called before the first frame update
    void Start()
    {
        NoTrustDialogueConvo = DontTrustDogComments.ConversationPlayer;
        DontTrustDogComments.OnEventEnd += ShowTrailDogRoomToPlanetarium;
        JohnReadsMural.OnEventEnd += ShowCraterRoom;
        GoToMainRoom.OnEventEnd += FinishedOtherRoom;
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
        Dog.SetActive(false);
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
        Debug.Log("Shadow position " + Shadow.transform.localPosition);
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
        Shadow.transform.GetChild(0).GetChild(2).gameObject.SetActive(false);
        FadeShadow.enabled = true;
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
                Doctor.GetComponent<NavMeshAgent>().isStopped = true;

                DoctorJohnConvo.enabled = true;
                DocWalksToPlayer = false;
            }
            else // Doctor moves to Player
            {
                Doctor.GetComponent<NavMeshAgent>().SetDestination(Player.position);
            }
        }   
    }

    //IEnumerator WaitForDocToStop()
    //{
    //    AvatarController avatarController = Doctor.GetComponent<AvatarController>();
    //    yield return new WaitUntil(() => avatarController.MovementState == AvatarController.MovementStates.Stopped);

    //}
}
