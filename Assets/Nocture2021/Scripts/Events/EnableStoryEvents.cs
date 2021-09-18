using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * Helper Script to Start the experience from the hand menu
 */
public class EnableStoryEvents : MonoBehaviour
{
    public ConditionalEventComponent startCondition;

    public void EnableEventsTriggers()
    {
        if (startCondition != null)
        {
            startCondition.Complete = true;
        }
        else
        {
            throw new Exception("I cannot start the events without a reference ti the conditional component");
        }
    }
}
