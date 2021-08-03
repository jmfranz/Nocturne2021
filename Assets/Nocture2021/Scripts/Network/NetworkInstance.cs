using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class NetworkInstance : MonoBehaviour
{
    public static NetworkInstance Instance;

    public string azureAnchorId = "";
    public PhotonView localUser;

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            if (Instance != this)
            {
                Destroy(Instance.gameObject);
                Instance = this;
            }
        }

        DontDestroyOnLoad(gameObject);
    }
}
