using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using PhotonNetwork = Photon.Pun.PhotonNetwork;

public class PhotonConnectionManager : MonoBehaviourPunCallbacks
{
    public GameObject PlayerPrefab;
    public Transform parentAnchor;
    public string RoomName = "Nocturne";

    private string gameVersion = "0";

    public GameObject ActiveUserHat1, PassiveUserHat2;


    //This will probably be 3 -> master + 2 HL
    private byte maxPlayers = 4;

    private void Awake()
    {
        //Ensures the scenes are loaded automatically over the network when the master switches scenes
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    private void Start()
    {
        //Lets connect to the server but not join a room
        if (PhotonNetwork.IsConnected) return;
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.GameVersion = gameVersion;


    }

    public void JoinNocturneRoom()
    {
        if (!PhotonNetwork.IsConnected)
        {
            throw new Exception("Client is not connected to the Photon Network!");
        }

        var roomOptions = new RoomOptions();
        roomOptions.IsVisible = true;
        roomOptions.MaxPlayers = maxPlayers;
        PhotonNetwork.JoinOrCreateRoom(RoomName, roomOptions, TypedLobby.Default);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        //If we are the first ones to join, becomes the master (ideally it should be the desktop app during nocturne)
        Debug.Log("Nocturne room was not running. Look at me, I am the master now");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connecting to room");
        JoinNocturneRoom();
    }

    public override void OnJoinedRoom()
    {
        var playerPrefab = PhotonNetwork.Instantiate(PlayerPrefab.name, Vector3.zero, Quaternion.identity, 0);
        playerPrefab.transform.parent = parentAnchor;

        GameObject playerHat;
        if (playerPrefab.GetPhotonView().IsMine)
        {
            playerHat = PhotonNetwork.Instantiate("Detective Hat", ActiveUserHat1.transform.localPosition, ActiveUserHat1.transform.localRotation, 0);
        }
        else
        {
            playerHat = PhotonNetwork.Instantiate("Cap", PassiveUserHat2.transform.localPosition, PassiveUserHat2.transform.localRotation, 0);
        }

        playerHat.transform.parent = playerPrefab.transform;
    }
}
