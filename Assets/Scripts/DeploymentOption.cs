using Microsoft.MixedReality.Toolkit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeploymentOption : MonoBehaviour
{
    public enum DeploymentTypes { VR, AR };
    public DeploymentTypes DeploymentType = DeploymentTypes.AR;

    //public Transform VRPlayer;
    public Transform ARPlayer;

    //Singleton
    private static DeploymentOption _instance;
    public static DeploymentOption Instance
    {
        get
        {
            if (_instance == null)
            {
                var singletonObject = GameObject.Find("Game Handler");
                _instance = singletonObject.AddComponent<DeploymentOption>();
            }
            return _instance;
        }
    }

    private void Awake()
    {
        //VRPlayer = GameObject.Find("VRPlayerController(Clone)").transform;
        ARPlayer = GameObject.FindGameObjectWithTag("MainCamera").transform; // Main camera is the part that moves
    }

    //private void Start()
    //{
    //    if (DeploymentType == DeploymentTypes.AR)
    //    {
    //        CoreServices.SpatialAwarenessSystem.Disable();
    //    }
    //}

    // If finds name, replaces with other controller.
    public void CheckEntity(List<Transform> entities, string name)
    {
        for (int i = 0; i < entities.Count; i++)
        {
            if (entities[i].name == name)
            {
                if (name.Contains("VRPlayerController(Clone)"))
                {
                    entities[i] = ARPlayer;
                }
                break;
            }
        }
    }
}
