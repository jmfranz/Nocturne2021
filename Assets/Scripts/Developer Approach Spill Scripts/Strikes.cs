using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strikes : MonoBehaviour
{
    public int currentStrikes = 0;
    public int maxStrikes = 3;

    public TMPro.TMP_Text strikeBar;

    public ConversationPlayer Catherine_Bultilda;
    public ConversationPlayer Catherine_Lapin;
    public ConversationPlayer Catherine_Ferghus;
    public ConversationPlayer Ferghus_Lapin;
    public ConversationPlayer Ferghus_Bultilda;
    public ConversationPlayer Lapin_Ferghus;

    bool CBStrike;
    bool CLStirke;
    bool CFStrike;
    bool FBStrike;
    bool LFStrike;
    bool FLStrike;
    public bool kickOut;

    public EndingController ending;

    public AudioClip Strike1;
    public AudioClip Strike2;
    public AudioClip Strike3;
    public AudioSource Source;

    public StoryEventComponent storyEventComponent;

    // Start is called before the first frame update
    void Start()
    {
        CBStrike = false;
        CLStirke = false;
        CFStrike = false;
        FBStrike = false;
        LFStrike = false;
        FLStrike = false;
        kickOut = false;

        currentStrikes = 0;
        SetStrikes();
    }

    // Update is called once per frame
    void Update()
    {
        if (Catherine_Bultilda._remainingLines.Count == 0 && !CBStrike)
        {
            GetStrike(1);
            CBStrike = true;
        }
        if (Catherine_Ferghus._remainingLines.Count == 0 && !CFStrike)
        {
            GetStrike(1);
            CFStrike = true;
        }
        if (Catherine_Lapin._remainingLines.Count == 0 && !CLStirke)
        {
            GetStrike(1);
            CLStirke = true;
        }
        if (Ferghus_Bultilda._remainingLines.Count == 0 && !FBStrike)
        {
            GetStrike(1);
            FBStrike = true;
        }
        if (Lapin_Ferghus._remainingLines.Count == 0 && !LFStrike)
        {
            GetStrike(1);
            LFStrike = true;
        }
        if (Ferghus_Lapin._remainingLines.Count == 0 && !FLStrike)
        {
            GetStrike(1);
            FLStrike = true;
        } 
    }

    public void GetStrike(int numStrikes)
    {
        currentStrikes += numStrikes;
        SetStrikes();

        switch (currentStrikes)
        {
            case 1:
                Source.PlayOneShot(Strike1);
                GameObject.Find("Event Data Synchronization").GetComponent<EventDataSync>().SetEventData("Strike1", true);
                storyEventComponent.WriteEventStartRequest("Strike1");
                break;
            case 2:
                Source.PlayOneShot(Strike2);
                GameObject.Find("Event Data Synchronization").GetComponent<EventDataSync>().SetEventData("Strike2", true);
                storyEventComponent.WriteEventStartRequest("Strike2");
                break;
            case 3:
                StartCoroutine(Strike3_Coroutine());
                break;
        }
    }

    public void RemoveStrike()
    {
        currentStrikes -= 1;
    }

    public void SetStrikes()
    {
        switch (currentStrikes)
        {
            case 0:
                strikeBar.text = "- - -";
                break;
            case 1:
                strikeBar.text = "X - -";
                break;
            case 2:
                strikeBar.text = "X X -";
                break;
            case 3:
                strikeBar.text = "X X X";
                strikeBar.color = new Color(222, 13, 13, 1);
                break;
        }
    }

    public int getCurrentStrikes()
    {
        return currentStrikes;
    }

    IEnumerator Strike3_Coroutine()
    {
        Source.PlayOneShot(Strike3);
        yield return new WaitForSeconds(3);
        GameObject.Find("Event Data Synchronization").GetComponent<EventDataSync>().SetEventData("Strike3", true);
        storyEventComponent.WriteEventStartRequest("Strike3");
        kickOut = true;
    }

}
