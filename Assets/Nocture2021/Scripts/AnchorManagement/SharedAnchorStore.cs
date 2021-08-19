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
    [SerializeField]
    private string _currentAzureTag = string.Empty;

    public void OnEvent(EventData photonEvent)
    {
        Debug.Log("event on the store, code: " + photonEvent.Code);
        if(photonEvent.Code == QRAnchorPlacer.WhatIsAnchorEvent)
        {
            Debug.Log("Replying to anchor challenge with " + _currentAzureTag);
            //We can only receive events if we are connected. I don't think (oops?) that we need to check
            PhotonNetwork.RaiseEvent(QRAnchorPlacer.AnchorTagReply, _currentAzureTag, RaiseEventOptions.Default,
                SendOptions.SendReliable);
        }
    }

    public void ClearAzureTag()
    {
        _currentAzureTag = string.Empty;
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