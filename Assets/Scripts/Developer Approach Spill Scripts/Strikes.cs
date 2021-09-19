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
        SetStrikes();
    }

    public void GetStrike(int numStrikes)
    {
        currentStrikes += numStrikes;
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
            case 4:
                strikeBar.text = "X X X";
                strikeBar.color = new Color(222, 13, 13, 1);
                KickOutPlayer();
                break;
        }
    }
}
