using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class MT_Controller : MonoBehaviour
{
    public TMPro.TMP_Text MainText;
    public ConversationPlayer IntroConvo;
    public ConversationPlayer Abduction;

    public bool TutorialStarted;
    public bool TutorialCompleted;
    public bool RescueStarted;
    public bool InvestigationStart;

    public GameObject Player;
    public GameObject Shadow;
    public GameObject EndPainting;
    public Vector3 TutorialEnd;
    public Vector3 ClueStart;
    public GameObject RescueToInvestigation;
    public GameObject ClueSequence;
    public GameObject TeddyBear;
    public GameObject BusinessCard;
    public GameObject Pencil;

    public IntroConversation IntroConversation;
    public GuideTrailController PathController;
    public ShadowPathController ShadowPathController;
    public StandvilleMuseumEventsController standvilleMuseumEventsController;

    // Start is called before the first frame update
    void Start()
    {
        MainText.text = "";
        TutorialStarted = false;
        TutorialCompleted = false;
        RescueStarted = false;
        InvestigationStart = false;

        TeddyBear.SetActive(false);
        BusinessCard.SetActive(false);
        Pencil.SetActive(false);

        TutorialEnd = GetNearPosition(Player, EndPainting);
    }

    // Update is called once per frame
    void Update()
    {
        //Plays tutorial at the beginning of the story before the initial conversation
        if (!TutorialStarted && !IntroConvo.enabled)
        {
            StartCoroutine(RunTutorial());
        }

        //Checks that the tutorial is complete and that the initial conversation has completed. 
        //Directs player back to story if wandering off
        if (IntroConvo.IsConversationFinished && IntroConversation.fullConvoAdded && !Abduction.IsConversationFinished && !TutorialCompleted)
        {
            StartCoroutine(TutorialComplete());
        }

        //Checks that Max has been abducted before announcing it to John
        if (Abduction.IsConversationFinished && !InvestigationStart)
        {
            StartCoroutine(RescueMaxSequence());
        }

        //Checks that player had gone towards the bathroom and suggests to go and check for clues
        if (standvilleMuseumEventsController.isClose(Player.transform.position, RescueToInvestigation.transform.position, 2) &&!InvestigationStart)
        {
            StartCoroutine(StartInvestigation());
        }

        //Starts the Clues sequence
        if (InvestigationStart && standvilleMuseumEventsController.isClose(Player.transform.position, ClueSequence.transform.position, 2))
        {
            StartCoroutine(SeeClues());
        }

        //Checks proximity to clues
        if (standvilleMuseumEventsController.isClose(Player.transform.position, TeddyBear.transform.position, 1))
        {
            StartCoroutine(CheckTeddy());
        }
        else if (standvilleMuseumEventsController.isClose(Player.transform.position, Pencil.transform.position, 1))
        {
            StartCoroutine(CheckPencil());
        }
        else if (standvilleMuseumEventsController.isClose(Player.transform.position, BusinessCard.transform.position, 1))
        {
            StartCoroutine(CheckBusinessCard());
        }
    }

    IEnumerator RunTutorial()
    {
        TutorialStarted = true;
        MainText.text = "You are a detective that is enjoying his holidays with his son." +
            " After planning this trip for a long time, you and your son have traveled to Halifax" +
            " and have been visiting different touristic places of the city. Right now, you are in the" +
            " most popular museum in the city and you are taking the time to appreciate each" +
            " part of the museum in detail.The good thing is that the museum is almost empty" +
            " since many people in the city have preferred to travel to other countries this year.";
        yield return new WaitForSeconds(20);
        MainText.text = "Can you see the golden trail? It is that line in front of you. Well, that’s " +
                "part of the Detective’s mind. This detective's feeling will guide you to a zone where " +
                "his detective skills and knowledge believe its the closest part to find your son. However, " +
                "this won’t tell you about the location of your son.That’s up to you to find out.";
        PathController.IntroPathObject.SetActive(true);
        yield return new WaitForSeconds(20);
        MainText.text = "Let's try it. Go to your son.  Follow the trail now";
        yield return new WaitForSeconds(10);
        MainText.text = "";
    }

    IEnumerator TutorialComplete()
    {
        TutorialCompleted = true;
        MainText.text = "Great! While Max is in the bathroom, try following the path and looking at some of the paintings along the way.";
        PathController.IntroPathObject.SetActive(false);
        PathController.TutorialPath.SetActive(true);
        yield return new WaitForSeconds(20);
        MainText.text = "";
    }
    
    IEnumerator RescueMaxSequence()
    {
        RescueStarted = true;
        ShadowPathController.StalkingToAbduction();
        TutorialCompleted = true;
        MainText.text = "Rescue Max!";
        yield return new WaitForSeconds(10);
    }

    IEnumerator OffStoryLine()
    {
        MainText.text = "You are wandering away from the storyline, please return to follow the story.";
        yield return new WaitForSeconds(30);
    }

    IEnumerator StartInvestigation()
    {
        PathController.TutorialPath.SetActive(false);
        PathController.BacktoClues.SetActive(true);
        InvestigationStart = true;
        ShadowPathController.CompleteAbduction();
        TeddyBear.SetActive(true);
        BusinessCard.SetActive(true);
        Pencil.SetActive(true);
        MainText.text = "I can't see them! Where did they go? I can figure this out. I'll try heading back to the scene and look for clues.";
        yield return new WaitForSeconds(30);
    }

    IEnumerator SeeClues()
    {
        PathController.TutorialPath.SetActive(false);
        MainText.text = "I see the clues!  A business card, a backpack and a piece of cloth.  I should choose one to check out.";
        yield return new WaitForSeconds(30);
    }

    IEnumerator CheckTeddy()
    {
        PathController.BacktoClues.SetActive(false);
        PathController.TeddyPath.SetActive(true);
        PathController.BusinessCardPath.SetActive(false);
        MainText.text = "Max's teddy bear.  How did this get here?  It was in the Flora and Fauna room.  Maybe I should go there and check if there's any more clues.";
        yield return new WaitForSeconds(30);
        MainText.text = "";
    }

    IEnumerator CheckBusinessCard()
    {
        PathController.BacktoClues.SetActive(false);
        PathController.TeddyPath.SetActive(false);
        PathController.BusinessCardPath.SetActive(true);
        MainText.text = "This business card has a number on it.  This should be a room number.  I think it was the number to the sculptures room.";
        yield return new WaitForSeconds(30);
        MainText.text = "";
    }

    IEnumerator CheckPencil()
    {
        MainText.text = "A pencil..... I don't know what this could mean yet.";
        yield return new WaitForSeconds(30);
        MainText.text = "";
    }

    Vector3 GetNearPosition(GameObject movingObject, GameObject target)
    {
        Vector3 TargetPosition = target.transform.position;
        Vector3 newPosition = target.transform.forward + TargetPosition;

        return new Vector3(newPosition.x, movingObject.transform.position.y, newPosition.z);
    }
}
