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

        var thisObject = GameObject.FindGameObjectWithTag("IsAgent");

        //Enable the Dog Nav
        if (thisObject.GetComponent<PhotonView>().IsMine)
        {    
            if (startCondition != null)
            {
                startCondition.Complete = true;
                this.gameObject.SetActive(false); // So you can't restart the story multiple times in the same session
            }
            else
            {
                throw new Exception("I cannot start the events without a reference it the conditional component");
            }
        }      
    }
}
