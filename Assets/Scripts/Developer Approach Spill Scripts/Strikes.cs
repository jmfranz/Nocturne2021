using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strikes : MonoBehaviour
{
    public int currentStrikes = 0;
    public int maxStrikes = 3;

    public TMPro.TMP_Text strikeBar;
    public TMPro.TMP_Text endStrikeBar;

    public ConversationPlayer Catherine_Bultilda;
    public ConversationPlayer Catherine_Lapin;
    public ConversationPlayer Catherine_Ferghus;
    public ConversationPlayer Ferghus_Bultilda;
    public ConversationPlayer Lapin_Ferghus;

    bool CBStrike;
    bool CLStirke;
    bool CFStrike;
    bool FBStrike;
    bool LFStrike;

    public EndingController ending;

    // Start is called before the first frame update
    void Start()
    {
        CBStrike = false;
        CLStirke = false;
        CFStrike = false;
        FBStrike = false;
        LFStrike = false;

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
    }

    public void GetStrike(int numStrikes)
    {
        currentStrikes += numStrikes;
        SetStrikes();

        switch (currentStrikes)
        {
            case 1:
                GameObject.Find("Event Data Synchronization").GetComponent<EventDataSync>().SetEventData("Strike1", true);
                break;
            case 2:
                GameObject.Find("Event Data Synchronization").GetComponent<EventDataSync>().SetEventData("Strike2", true);
                break;
            case 3:
                GameObject.Find("Event Data Synchronization").GetComponent<EventDataSync>().SetEventData("Strike3", true);
                KickOutPlayer();
                break;
        }
    }

    public void RemoveStrike()
    {
        currentStrikes -= 1;
    }

    public void KickOutPlayer()
    {
        endStrikeBar.enabled = true;
        strikeBar.enabled = false;
        ending.TheEnd();
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
                KickOutPlayer();
                break;
        }
    }

    public int getCurrentStrikes()
    {
        return currentStrikes;
    }
}
