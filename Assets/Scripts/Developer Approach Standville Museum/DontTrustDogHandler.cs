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
    public EnterLocationTrigger MainRoomTrigger;                

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
    }

    bool unshowCraterRoom = false;
    bool maxScreams = false;
    bool docJohnConvo = false;
    bool planetarium = false;
    bool mainRoom = false;

    private void FixedUpdate()
    {
        if(ShadowDialogue._remainingLines.Count == 1 && !unshowCraterRoom)
        {
            unshowCraterRoom = true;
            UnShowCraterRoom();
        }

        if (MaxScreams._hasCompletedConversation && !maxScreams)
        {
            maxScreams = true;
            Max.GetComponent<NPCtoFollowPlayer>().FollowPlayer = true;
        }

        if (DoctorJohnConvo._hasCompletedConversation && !docJohnConvo)
        {
            docJohnConvo = true;
            EndingMessage.SetActive(true);
        }

        if (PlanetariumEnterLocationTrigger.ReachedDestination && !planetarium)
        {
            planetarium = true;
            DogRoomToPlantariumPathFollower.playPath = false;
            Dog.SetActive(false);
            EnteredPlanetarium.CompleteConditionalEvent();
        }

        if (MainRoomEnterLocationTrigger.ReachedDestination && CraterRoomToMainRoomPathFollower.playPath && !mainRoom)
        {
            mainRoom = true;
            CraterRoomToMainRoomPathFollower.playPath = false;
            EnteredMainRoom.CompleteConditionalEvent();

            ScaryMusic.enabled = false;
            ScaryMusic.GetComponent<AudioSource>().clip = null;

            DocWalksToPlayer = true;
        }
    }

    void ShowTrailDogRoomToPlanetarium()
    {
        DogRoomToPlantariumPathFollower.playPath = true;
        PlanetariumEnterLocationTrigger.GetComponentInParent<BoxCollider>().enabled = true;
    }

    void ShowCraterRoom()
    {
        Max.SetActive(true);
        CraterRoomObjects.SetActive(true);
        Shadow.transform.GetChild(0).gameObject.SetActive(true);
        Shadow.SetActive(false); // Disable shadow while setting its position
        Shadow.transform.SetPositionAndRotation(new Vector3(ShadowPositionInCraterRoom.position.x, 0, ShadowPositionInCraterRoom.position.z),
                                        Quaternion.Euler(0, 0, 0));
        Shadow.transform.GetChild(0).localPosition = Vector3.zero;
        Shadow.transform.GetChild(0).localRotation = Quaternion.Euler(0, 0, 0);
        Shadow.SetActive(true);
        Shadow.transform.localPosition = new Vector3(Shadow.transform.localPosition.x, 0, Shadow.transform.localPosition.z);
        Shadow.transform.localRotation = Quaternion.Euler(0, 0, 0);
    }

    void FinishedOtherRoom()
    {
        ShowTrailCraterToMainRoom();
        UnShowCraterRoom();

        ScaryMusic.enabled = true;
        PoliceConvo1.enabled = true;
        PoliceConvo2.enabled = true;

        MainRoomTrigger.enabled = true;
        MainRoomTrigger.ConditionalEventComponent = EnteredMainRoom;
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
        MainRoomObjects.SetActive(true);
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
