using System;
using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using UnityEngine;

using Photon;
using Photon.Pun;
using Photon.Realtime;

/// <summary>
/// We use a separate script to hold the azure anchor ID (instead of the MRTK script) so we can save the ID on the editor
/// </summary>
public class SharedAnchorStore : MonoBehaviourPun, IOnEventCallback
{
    public GameObject ParentAnchor;

    public static byte ClearAnchorEvent = 3;
    public static byte UpdateToNewAnchorEvent = 4;


    [SerializeField]
    private string _currentAzureTag = string.Empty;

    public void OnEvent(EventData photonEvent)
    {
        //Debug.Log("event on the store, code: " + photonEvent.Code);
        if(photonEvent.Code == QRAnchorPlacer.WhatIsAnchorEvent)
        {
            Debug.Log("Replying to anchor challenge with " + _currentAzureTag);
            //We can only receive events if we are connected. I don't think (oops?) that we need to check
            PhotonNetwork.RaiseEvent(QRAnchorPlacer.AnchorTagReply, _currentAzureTag, RaiseEventOptions.Default,
                SendOptions.SendReliable);
        }
        else if (photonEvent.Code == ClearAnchorEvent)
        {
            _currentAzureTag = string.Empty;
#if !UNITY_EDITOR
        var anchorModule = ParentAnchor.GetComponent<AnchorModuleScript>();
//        anchorModule.RemoveLocalAnchor(ParentAnchor);
        anchorModule.DeleteAzureAnchor();
#endif
        }
        else if (photonEvent.Code == UpdateToNewAnchorEvent)
        {
            var tag = (string)photonEvent.CustomData;
            if (string.IsNullOrEmpty(tag))
            {
                //throw new Exception("Oh no! anyway...");
                throw new Exception("Received an invalid tag from the network, cannot query Azure");
            }
            StoreNewTag(tag);
#if !UNITY_EDITOR
            var anchorModule = ParentAnchor.GetComponent<AnchorModuleScript>();
            anchorModule.RemoveLocalAnchor(ParentAnchor);
            anchorModule.FindAzureAnchor(_currentAzureTag);
#endif
        }
    }

    public void ClearAzureTag()
    {
        var options = RaiseEventOptions.Default;
        options.Receivers = ReceiverGroup.All;
        PhotonNetwork.RaiseEvent(ClearAnchorEvent, null, options , SendOptions.SendReliable);
    }
    
    public void UpdateAzureTag()
    {
#if !UNITY_EDITOR
        var anchorModule = ParentAnchor.GetComponent<AnchorModuleScript>();
        anchorModule.OnCreateAnchorSucceeded += AnchorCreatedOnAzure;
        anchorModule.CreateAzureAnchor(ParentAnchor);
#endif
    }

    private void AnchorCreatedOnAzure()
    {
        var anchorModule = ParentAnchor.GetComponent<AnchorModuleScript>();
        StoreNewTag(anchorModule.currentAzureAnchorID);
        anchorModule.OnCreateAnchorSucceeded -= AnchorCreatedOnAzure;

        PhotonNetwork.RaiseEvent(UpdateToNewAnchorEvent, _currentAzureTag, RaiseEventOptions.Default, SendOptions.SendReliable);
        
    }

    public void StoreNewTag(string tagId)
    {
        _currentAzureTag = tagId;
    }

    private void OnEnable()
    {
        PhotonNetwork.AddCallbackTarget(this);
    }

    private void OnDisable()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
    }


}