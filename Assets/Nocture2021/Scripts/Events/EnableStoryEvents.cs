using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


/**
 * Helper Script to Start the experience from the hand menu
 */
public class EnableStoryEvents : MonoBehaviour
{
    public ConditionalEventComponent startCondition;

    public void EnableEventsTriggers()
    {
        //Enable the Dog Nav
        var dog = GameObject.FindGameObjectWithTag("IsAgent");
        if (dog.GetComponent<PhotonView>().IsMine)
        {          
            dog.GetComponent<NavMeshAgent>().enabled = true;

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
}
