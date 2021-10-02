using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strikes : MonoBehaviour
{
    public int currentStrikes = 0;
    public int maxStrikes = 3;

    public TMPro.TMP_Text strikeBar;

    // Start is called before the first frame update
    void Start()
    {
        currentStrikes = 0;
        SetStrikes();
    }

    // Update is called once per frame
    void Update()
    {

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
        //Player gets kicked out sequence starts
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
