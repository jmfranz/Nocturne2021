using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    public enum States
    {
        Beginning,
        TalkingToDad,
        SearchingForKid,
        Finished,
    }

    public static States CurrentState = States.Beginning;
}
