using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NPC_Movements : StoryEventComponent
{   
    string bultildaStatus;
    string ferghusStatus;
    string lapinStatus;
    string catherineStatus;

    bool loopFinished;
    bool canStartStory;

    //Avatars
    public AvatarController Fokthipur;
    public AvatarController Ferghus;
    public AvatarController Lapin;
    public AvatarController Catherine;
    public AvatarController Bultilda;
    public AvatarController NPC1_Avatar;
    public AvatarController NPC2_Avatar;
    public AvatarController NPC3_Avatar;

    //Fokthipur's conversations
    public ConversationNode Fokthipur_midgame;
    
    //Bultilda conversations
    public ConversationNode B_Lapin;
    
    //Lapin conversations
    public ConversationNode L_Catherine;
    public ConversationNode L_Fok;
    public ConversationNode L_Ferghus;
    
    //Catherine converstations
    public ConversationNode C_Lapin;
    public ConversationNode C_Bultilda;
    public ConversationNode C_Fok;
    public ConversationNode C_Ferghus;
    
    //Ferghus conversations
    public ConversationNode F_Bultilda;
    
    //NPC conversations
    public ConversationNode NPC1;
    public ConversationNode NPC2;
    public ConversationNode NPC3;

    //Final conversations
    public ConversationNode TellFokEnding;
    public ConversationNode TellCatherineEnding;

    // Story Start Script
    public ConditionalEventComponent storyStart;

    // Start is called before the first frame update
    void Start()
    {
        loopFinished = true;
        bultildaStatus = "";
        lapinStatus = "";
        catherineStatus = "";
        ferghusStatus = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (storyStart.Complete && loopFinished)
        {
            StartCoroutine(ConversationLoop());
        }
    }

    public void AvatarToConversation(AvatarController avatar, ConversationNode convo)
    {
        avatar.GoToConversationNode(convo, AvatarController.MovementTypes.Walk);
        
        if (avatar.Equals(Bultilda))
        {
            bultildaStatus = convo.name;
        }
        else if (avatar.Equals(Ferghus))
        {
            ferghusStatus = convo.name;
        }
        else if (avatar.Equals(Catherine))
        {
            catherineStatus = convo.name;
        }
        else if (avatar.Equals(Lapin))
        {
            lapinStatus = convo.name;
        }
    }

    public bool isClose(Vector3 player, Vector3 otherObject, float distance)
    {
    
        float x_Value = Math.Abs(player.x - otherObject.x);
        float z_Value = Math.Abs(player.z - otherObject.z);

        if (x_Value <= distance && z_Value <= distance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    public  IEnumerator FixedTimeCoroutineWaitingThing(int d)
    {
        YieldInstruction waitForFixedUpdate = new WaitForFixedUpdate();
        while (true)
        {

            for (float duration = d; duration > 0; duration -= Time.fixedDeltaTime)
            {
                yield return waitForFixedUpdate;
            }
        }
    }

    //Bultilda's Conversations

    IEnumerator BL()
    {
        AvatarToConversation(Bultilda, B_Lapin);
        FixedTimeCoroutineWaitingThing(5);
        //yield return new WaitForSeconds(5);
        AvatarToConversation(Lapin, B_Lapin);
        FixedTimeCoroutineWaitingThing(5);
        //yield return new WaitForSeconds(45);
        YieldInstruction waitForFixedUpdate = new WaitForFixedUpdate();
        yield return waitForFixedUpdate;
    }

    //Catherine's Conversations
    IEnumerator CF()
    {
        AvatarToConversation(Catherine, C_Ferghus);

        FixedTimeCoroutineWaitingThing(5);
        // yield return new WaitForSeconds(5);

        AvatarToConversation(Ferghus, C_Ferghus);
        //yield return new WaitForSeconds(65);
        FixedTimeCoroutineWaitingThing(65);

        YieldInstruction waitForFixedUpdate = new WaitForFixedUpdate();
        yield return waitForFixedUpdate;
    }

    IEnumerator CB()
    {
        AvatarToConversation(Catherine, C_Bultilda);
        FixedTimeCoroutineWaitingThing(5);
        //yield return new WaitForSeconds(5);
        AvatarToConversation(Bultilda, C_Bultilda);
        FixedTimeCoroutineWaitingThing(65);
        //yield return new WaitForSeconds(65);

        YieldInstruction waitForFixedUpdate = new WaitForFixedUpdate();
        yield return waitForFixedUpdate;
    }

    IEnumerator CL()
    {
        AvatarToConversation(Catherine, C_Lapin);
        FixedTimeCoroutineWaitingThing(5);
       // yield return new WaitForSeconds(5);
        AvatarToConversation(Lapin, C_Lapin);
        FixedTimeCoroutineWaitingThing(65);
        // yield return new WaitForSeconds(65);

        YieldInstruction waitForFixedUpdate = new WaitForFixedUpdate();
        yield return waitForFixedUpdate;
    }

    IEnumerator CK()
    {
        AvatarToConversation(Catherine, C_Fok);
        FixedTimeCoroutineWaitingThing(5);
        //yield return new WaitForSeconds(5);
        AvatarToConversation(Fokthipur, C_Fok);
        FixedTimeCoroutineWaitingThing(65);
        //yield return new WaitForSeconds(65);

        YieldInstruction waitForFixedUpdate = new WaitForFixedUpdate();
        yield return waitForFixedUpdate;
    }

    //Lapin's Conversations
    IEnumerator LF()
    {
        AvatarToConversation(Lapin, L_Ferghus);
        FixedTimeCoroutineWaitingThing(5);
        //yield return new WaitForSeconds(5);
        AvatarToConversation(Ferghus, L_Ferghus);
        FixedTimeCoroutineWaitingThing(55);
        //yield return new WaitForSeconds(55);

        YieldInstruction waitForFixedUpdate = new WaitForFixedUpdate();
        yield return waitForFixedUpdate;
    }

    IEnumerator LC()
    {
        AvatarToConversation(Lapin, L_Catherine);
        FixedTimeCoroutineWaitingThing(5);
        //yield return new WaitForSeconds(5);
        AvatarToConversation(Catherine, L_Catherine);
        FixedTimeCoroutineWaitingThing(55);
        //yield return new WaitForSeconds(55);

        YieldInstruction waitForFixedUpdate = new WaitForFixedUpdate();
        yield return waitForFixedUpdate;
    }

    IEnumerator LK()
    {
        AvatarToConversation(Lapin, L_Fok);
        FixedTimeCoroutineWaitingThing(5);
        //yield return new WaitForSeconds(5);
        AvatarToConversation(Fokthipur, L_Fok);
        FixedTimeCoroutineWaitingThing(55);
        //yield return new WaitForSeconds(55);

        YieldInstruction waitForFixedUpdate = new WaitForFixedUpdate();
        yield return waitForFixedUpdate;
    }

    //Ferghus' Conversations
    IEnumerator FB()
    {
        AvatarToConversation(Ferghus, F_Bultilda);
        FixedTimeCoroutineWaitingThing(5);
        //yield return new WaitForSeconds(5);
        AvatarToConversation(Bultilda, F_Bultilda);
        FixedTimeCoroutineWaitingThing(60);
        //yield return new WaitForSeconds(60);

        YieldInstruction waitForFixedUpdate = new WaitForFixedUpdate();
        yield return waitForFixedUpdate;
    }

    //Fok Midgame
    IEnumerator Fok_Player()
    {
        AvatarToConversation(Fokthipur, Fokthipur_midgame);
        FixedTimeCoroutineWaitingThing(85);
        //yield return new WaitForSeconds(85);

        YieldInstruction waitForFixedUpdate = new WaitForFixedUpdate();
        yield return waitForFixedUpdate;
    }


    public IEnumerator ConversationLoop()
    {
        Debug.Log("Conversation Loop Started");
        loopFinished = false;
        FixedTimeCoroutineWaitingThing(2);
        //yield return new WaitForSeconds(2);
        AvatarToConversation(Fokthipur, NPC1);
        AvatarToConversation(Bultilda, NPC1);
        AvatarToConversation(Ferghus, NPC2);
        AvatarToConversation(Catherine, NPC3);
        AvatarToConversation(Lapin, NPC3);
        AvatarToConversation(NPC1_Avatar, NPC1);
        AvatarToConversation(NPC2_Avatar, NPC2);
        AvatarToConversation(NPC3_Avatar, NPC3);

        //Everyone is now at initial conversations
        FixedTimeCoroutineWaitingThing(10);
        //yield return new WaitForSeconds(10);
        
        //Catherine & Ferghus
        StartCoroutine(CF());
        yield return new WaitUntil(() => isClose(Catherine.transform.position, C_Ferghus.transform.position, 2));
        AvatarToConversation(Fokthipur, NPC2);
        FixedTimeCoroutineWaitingThing(45);
        //yield return new WaitForSeconds(45);
        AvatarToConversation(Catherine, NPC2);
        AvatarToConversation(Ferghus, NPC1);
        FixedTimeCoroutineWaitingThing(15);
        //yield return new WaitForSeconds(15);
        
        //Catherine & Bultilda
        StartCoroutine(CB());
        yield return new WaitUntil(() => isClose(Catherine.transform.position, C_Bultilda.transform.position, 2));
        FixedTimeCoroutineWaitingThing(55);
        //yield return new WaitForSeconds(55);
       
        //Lapin & Ferghus
        StartCoroutine(LF());
        yield return new WaitUntil(() => isClose(Ferghus.transform.position, L_Ferghus.transform.position, 2));
        FixedTimeCoroutineWaitingThing(30);
        //yield return new WaitForSeconds(30);
        
        //Catherine & Lapin
        StartCoroutine(CL());
        AvatarToConversation(Fokthipur, NPC1);
        AvatarToConversation(Ferghus, NPC1);
        yield return new WaitUntil(() => isClose(Catherine.transform.position, C_Lapin.transform.position, 2));
        
        //Ferghus & Bultilda
        StartCoroutine(FB());
        FixedTimeCoroutineWaitingThing(45);
        //yield return new WaitForSeconds(45);
        AvatarToConversation(Catherine, NPC3);
        yield return new WaitUntil(() => isClose(Catherine.transform.position, NPC3.transform.position, 2));
        FixedTimeCoroutineWaitingThing(25);
        //yield return new WaitForSeconds(25);
       
        //Bultilda & Lapin
        StartCoroutine(BL());
       
        //Catherine & Fok
        StartCoroutine(CK());
        AvatarToConversation(Ferghus, NPC2);
        yield return new WaitUntil(() => isClose(Catherine.transform.position, C_Fok.transform.position, 2));
        AvatarToConversation(Fokthipur, Fokthipur_midgame);
        FixedTimeCoroutineWaitingThing(405);
        //yield return new WaitForSeconds(40);
        AvatarToConversation(Bultilda, NPC2);
        AvatarToConversation(Ferghus, NPC3);
        AvatarToConversation(Catherine, NPC3);
        AvatarToConversation(Lapin, NPC2);
        yield return new WaitUntil(() => isClose(Catherine.transform.position, NPC3.transform.position, 2));
        FixedTimeCoroutineWaitingThing(20);
        //yield return new WaitForSeconds(20);
        
        //Lapin & Catherine
        StartCoroutine(LC());
        
        yield return new WaitUntil(() => isClose(Catherine.transform.position, L_Catherine.transform.position, 2));
        FixedTimeCoroutineWaitingThing(20);
        //yield return new WaitForSeconds(20);
        Debug.Log("Loop Complete");
        loopFinished = true;

        YieldInstruction waitForFixedUpdate = new WaitForFixedUpdate();
        yield return waitForFixedUpdate;
    }

    public IEnumerator AfterCognitive()
    {
        FixedTimeCoroutineWaitingThing(2);
        //yield return new WaitForSeconds(2);
        AvatarToConversation(Fokthipur, TellFokEnding);
        AvatarToConversation(Catherine, TellCatherineEnding);
        AvatarToConversation(Bultilda, NPC1);
        AvatarToConversation(Lapin, NPC2);
        AvatarToConversation(Ferghus, NPC3);

        YieldInstruction waitForFixedUpdate = new WaitForFixedUpdate();
        yield return waitForFixedUpdate;

    }

    public void StopNPCMovements()
    {
        StopCoroutine(BL());
        StopCoroutine(CF());
        StopCoroutine(CB());
        StopCoroutine(CK());
        StopCoroutine(LF());
        StopCoroutine(LC());
        StopCoroutine(LK());
        StopCoroutine(FB());
        StopCoroutine(ConversationLoop());
    }
}
