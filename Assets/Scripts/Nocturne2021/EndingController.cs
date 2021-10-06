using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingController : MonoBehaviour
{
    public ConversationPlayer TellFok;
    public ConversationPlayer TellCatherine;

    public GameObject End;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (TellFok._remainingLines.Count == 0 || TellCatherine._remainingLines.Count == 0)
        {
            TheEnd();
        }
    }

    public void TheEnd()
    {
        End.SetActive(true);
    }
}