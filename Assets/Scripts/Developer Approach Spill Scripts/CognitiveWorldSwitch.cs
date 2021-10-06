using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class CognitiveWorldSwitch : MonoBehaviour
{
    public GameObject Floor;

    public GameObject CognitiveAvatars;
    public GameObject CognitiveCatherine;

    public GameObject MushroomRing;
    public GameObject Fokthipur;
    public GameObject Catherine;
    public GameObject Lapin;
    public GameObject Ferghus;
    public GameObject Bultilda;
    public GameObject NPC1;
    public GameObject NPC2;
    public GameObject NPC3;
    public GameObject Player;

    public ConversationPlayer CognitiveConvo;
    public ConversationPlayer GetCaughtConvo;
    public ConversationNode TellFok;
    public ConversationNode TellNPC;
    public ConversationNode CognitiveConvoNode;

    public FokthipurRoomController fokthipurRoomController;
    public NPC_Movements nPC_Movements;
   
    public bool inCognitive;
    public bool getCaught;
    public bool finishingText;
    bool avatarsVisible;
    public TMPro.TMP_Text keywordInstruction;

    public SpriteRenderer NorthReal;
    public SpriteRenderer NorthCognitive;
    public SpriteRenderer SouthReal;
    public SpriteRenderer SouthCognitive;
    public SpriteRenderer EastReal;
    public SpriteRenderer EastCognitive;
    List<SpriteRenderer> CognitiveImages = new List<SpriteRenderer>();
    List<SpriteRenderer> RealImages = new List<SpriteRenderer>();

    public Strikes Strikes;

    private Cognitive_Catherine_Reaction cognitive_Catherine_Reaction;

    List<GameObject> NormalAvatars;

    // Story Start Script
    public ConditionalEventComponent storyStart;

    // Start is called before the first frame update
    void Start()
    { 
        inCognitive = false;
        getCaught = false;
        finishingText = false;
        avatarsVisible = false;

        NormalAvatars = new List<GameObject>();
        NormalAvatars.Add(Catherine);
        NormalAvatars.Add(Lapin);
        NormalAvatars.Add(Ferghus);
        NormalAvatars.Add(Bultilda);
        NormalAvatars.Add(Fokthipur);
        NormalAvatars.Add(NPC1);
        NormalAvatars.Add(NPC2);
        NormalAvatars.Add(NPC3);

        CognitiveImages.Add(NorthCognitive);
        CognitiveImages.Add(SouthCognitive);
        CognitiveImages.Add(EastCognitive);

        RealImages.Add(SouthReal);
        RealImages.Add(NorthReal);
        RealImages.Add(EastReal);

        foreach (var image in RealImages)
        {
            image.enabled = true;
        }
        foreach (var image in CognitiveImages)
        {
            image.enabled = false;
        }


    }


    // Update is called once per frame
    void Update()
    {
        if (storyStart.Complete && !avatarsVisible)
        {
            GameObject.Find("Event Data Synchronization").GetComponent<EventDataSync>().SetEventData("StoryStart", true);
            Catherine.SetActive(true);
            Fokthipur.SetActive(true);
            Ferghus.SetActive(true);
            Lapin.SetActive(true);
            Bultilda.SetActive(true);
            NPC1.SetActive(true);
            NPC2.SetActive(true);
            NPC3.SetActive(true);
            avatarsVisible = true;
        }
        
        if (CognitiveCatherine.GetComponent<AvatarController>()._agent != null && !inCognitive)
        {
            CognitiveAvatars.SetActive(false);
            CognitiveConvo.gameObject.SetActive(false);
            CognitiveCatherine.SetActive(false);
        }

        if (isClose(Player, MushroomRing, 1) && !inCognitive && !CognitiveConvo._hasCompletedConversation)
        {
            GoToCognitive();
        }

        if (isClose(Player, MushroomRing, 1) && inCognitive && CognitiveConvo._hasCompletedConversation)
        {
            LeaveCognitive();
            StartCoroutine(nPC_Movements.AfterCognitive());
        }

        if (!getCaught && GetCaughtConvo._remainingLines.Count == 0 && !GetCaughtConvo._hasCompletedConversation)
        {
            GetCaught();
        }

        if (inCognitive && !CognitiveConvo._hasCompletedConversation)
        {
            nPC_Movements.AvatarToConversation(CognitiveCatherine.GetComponent<AvatarController>(), CognitiveConvoNode);
        }

        if (CognitiveConvo.isActiveAndEnabled)
        {
            keywordInstruction.gameObject.SetActive(true);
        } 
    }

    public void GoToCognitive()
    {
        GameObject.Find("Event Data Synchronization").GetComponent<EventDataSync>().SetEventData("IntoCognitive", true);
        ToggleWindows();
        nPC_Movements.StopNPCMovements();
        CognitiveCatherine.SetActive(true);
        CognitiveAvatars.SetActive(true);
        CognitiveConvo.gameObject.SetActive(true);
        foreach (GameObject actor in NormalAvatars)
        {
            actor.SetActive(false);
        }
        Floor.GetComponent<MeshRenderer>().material.color = new Color(87f/255f, 65f/255f, 99f/255f);
        inCognitive = true;
    }

    public void LeaveCognitive()
    {
            inCognitive = false;
            ToggleWindows();
            GameObject.Find("Event Data Synchronization").GetComponent<EventDataSync>().SetEventData("LearnedSecret", true);
            foreach (GameObject actor in NormalAvatars)
            {
                actor.SetActive(true);
            }
            CognitiveAvatars.SetActive(false);
            CognitiveConvo.gameObject.SetActive(false);
            TellFok.gameObject.SetActive(true);
            TellNPC.gameObject.SetActive(true);
            Floor.GetComponent<MeshRenderer>().material.color = Color.white;

            StartCoroutine(nPC_Movements.AfterCognitive());
    }

    public bool isClose(GameObject player, GameObject otherObject, float distance)
    {
        Vector3 playerPosition = player.transform.position;
        Vector3 objectPosition = otherObject.transform.position;

        float x_Value = Math.Abs(playerPosition.x - objectPosition.x);
        float z_Value = Math.Abs(playerPosition.z - objectPosition.z);

        if (x_Value <= distance && z_Value <= distance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void GetCaught()
    {
        Strikes.GetStrike(1);
        getCaught = true;
    }

    public void ToggleWindows()
    {
        if (NorthReal.enabled)
        {
            foreach (var image in RealImages)
            {
                image.enabled = false;
            }
            foreach (var image in CognitiveImages)
            {
                image.enabled = true;
            }
        } else
        {
            foreach (var image in RealImages)
            {
                image.enabled = true;
            }
            foreach (var image in CognitiveImages)
            {
                image.enabled = false;
            }
        }
    }
}
