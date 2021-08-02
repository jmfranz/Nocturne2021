using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Microsoft.Azure.SpatialAnchors;
using Microsoft.Azure.SpatialAnchors.Unity;


#if WINDOWS_UWP
using Windows.Storage;
#endif


public class AnchorScriptManager : MonoBehaviour
{

    public string currentAzureAnchorID = "";
    public string removeAnchor = "Inactive";

    private SpatialAnchorManager spatialAnchorManager;
    private CloudSpatialAnchor currentCloudAnchor;
    private AnchorLocateCriteria anchorLocateCriteria;
    private CloudSpatialAnchorWatcher currentWatcher;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
