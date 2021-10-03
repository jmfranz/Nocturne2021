using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using PhotonNetwork = Photon.Pun.PhotonNetwork;

public class PhotonConnectionManager : MonoBehaviourPunCallbacks
{
    public GameObject PlayerPrefab;
    public Transform parentAnchor;
    public string RoomName = "Nocturne";
    public List<MeshRenderer> Walls;

    private string gameVersion = "0";

    //public GameObject ActiveUserHat1, PassiveUserHat2;
    public GameObject InGameObjects, AwareGuideObjects;

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

        if (PhotonNetwork.IsMasterClient && !SceneManager.GetActiveScene().name.Contains("Guide"))
        {
            playerPrefab.transform.GetChild(1).gameObject.SetActive(true);
        }
        else if(!PhotonNetwork.IsMasterClient && !SceneManager.GetActiveScene().name.Contains("Guide"))
        {
            playerPrefab.transform.GetChild(0).gameObject.SetActive(true);
            GameObject.Find("Enable Story Events").SetActive(false); // We don't want the passivie viewer to be able to say voice commands
        }       

        if (SceneManager.GetActiveScene().name.Contains("Guide"))
        {
            Debug.Log("Setting up for aware guide :)");
            

            if (!PhotonNetwork.IsMasterClient)
            {
                foreach(var meshRenderer in Walls)
                {
                    meshRenderer.enabled = false;
                }

                InGameObjects.SetActive(false);
                AwareGuideObjects.SetActive(true);
                GameObject.Find("Enable Story Events").SetActive(false); // We don't want the passivie viewer to be able to say voice commands
                GameObject.Find("Audio").GetComponent<ContextAwareGuide>().enabled = true;
            }
        }
        
    }
}
