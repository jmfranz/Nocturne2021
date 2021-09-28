using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class LoadNewScene : MonoBehaviour
{

    public void LoadNewSceneOnNetwork(int sceneIndex)
    {
        PhotonNetwork.LoadLevel(sceneIndex);
    }
}
