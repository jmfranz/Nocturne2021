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
    public ConversationPlayer ShadowDialogue, MaxScreams;

    public FadeShadow FadeShadow;

    bool DocWalksToPlayer = false;

    public GameObject EndingMessage;

    // Start is called before the first frame update
    void Start()
    {
        NoTrustDialogueConvo = DontTrustDogComments.ConversationPlayer;
        DontTrustDogComments.OnEventEnd += ShowTrailDogRoomToPlanetarium;
        JohnReadsMural.OnEventEnd += ShowCraterRoom;
        GoToMainRoom.OnEventEnd += FinishedOtherRoom;
        StartCoroutine(WaitForShadowDialogue());
        StartCoroutine(WaitForMaxToFollowPlayer());
        StartCoroutine(ShowEndingMessage());
    }

    IEnumerator WaitForShadowDialogue()
    {
        yield return new WaitUntil(()=> ShadowDialogue._remainingLines.Count == 1);
        UnShowCraterRoom();
    }

    IEnumerator WaitForMaxToFollowPlayer()
    {
        yield return new WaitUntil(() => MaxScreams._hasCompletedConversation);
        Max.GetComponent<NPCtoFollowPlayer>().FollowPlayer = true;
    }

    IEnumerator ShowEndingMessage()
    {
        yield return new WaitUntil(() => DoctorJohnConvo._hasCompletedConversation);
        EndingMessage.SetActive(true);
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
        Shadow.transform.GetChild(0).localPosition = Vector3.zero;
        Shadow.transform.GetChild(0).localRotation = Quaternion.Euler(0, 90, 0);
        Shadow.SetActive(true);
        Shadow.transform.localPosition = new Vector3(Shadow.transform.localPosition.x, 0, Shadow.transform.localPosition.z);
    }

    void FinishedOtherRoom()
    {
        ShowTrailCraterToMainRoom();
        UnShowCraterRoom();

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
}
