using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using Photon.Pun;
using Photon.Realtime;
using Microsoft.Azure.SpatialAnchors;
using Microsoft.Azure.SpatialAnchors.Unity;


#if WINDOWS_UWP
using Windows.Storage;
#endif


public class AnchorScriptManager : MonoBehaviour
{

    public string currentAzureAnchorID = "";
    public string removeAnchor = "Inactive";

    public SpatialAnchorManager spatialAnchorManager;
    private CloudSpatialAnchor currentCloudAnchor;
    private AnchorLocateCriteria anchorLocateCriteria;
    private CloudSpatialAnchorWatcher currentWatcher;

    public CloudSpatialAnchorSession cloudSASession;
    public PhotonConnectionManager photonConnectionManager;


    // Start is called before the first frame update
    void Start()
    {

        // Get a reference to the SpatialAnchorManager component (must be on the same gameobject)
        spatialAnchorManager = GetComponent<SpatialAnchorManager>();

        anchorLocateCriteria = new AnchorLocateCriteria();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
     * Create new SA session
     */
    public async void CreateSpatialAnchorSession()
    {
        if (spatialAnchorManager.Session == null)
        {
            await spatialAnchorManager.CreateSessionAsync();
        }

        StartSpatialAnchorSession();
    }
    
    /*
     * Start to process environment data
     */
    public async void StartSpatialAnchorSession()
    {
        // Starts the session if not already started
        await spatialAnchorManager.StartSessionAsync();

        Debug.Log("Azure session has successfully started");
    }

    public async void StopSpatialAnchorSession()
    {
        spatialAnchorManager.StopSession();

        // Resets the current session if there is one, and waits for any active queries to be stopped
        await spatialAnchorManager.ResetSessionAsync();

        Debug.Log("Azure session stopped successfully");
    }

    public async void CreateSpatialAnchor(GameObject theObject)
    {
        // Create a native anchor at the object
        gameObject.CreateNativeAnchor();

        // Create a new local cloud anchor
        CloudSpatialAnchor localCloudAnchor = new CloudSpatialAnchor();

        // Set the local cloud anchor's position to the native anchor's position
        localCloudAnchor.LocalAnchor = await theObject.FindNativeAnchor().GetPointer();

        // Check to see if we got the local XR anchor pointer
        if (localCloudAnchor.LocalAnchor == IntPtr.Zero)
        {
            Debug.Log("Didn't get the local anchor...");
            return;
        }
        else
        {
            Debug.Log("Local anchor created");
        }


        Debug.Log("Creating Azure anchor... please wait...");

        //save
        await spatialAnchorManager.CreateAnchorAsync(localCloudAnchor);

        // Store
        currentCloudAnchor = localCloudAnchor;
        localCloudAnchor = null;

        // Success?
        bool success = currentCloudAnchor != null;

        if (success)
        {
            // Update the current Azure anchor ID
            Debug.Log($"Current Azure anchor ID updated to '{currentCloudAnchor.Identifier}'");
            currentAzureAnchorID = currentCloudAnchor.Identifier;
        }
        else
        {
            Debug.Log($"Failed to save cloud anchor with ID '{currentAzureAnchorID}' to Azure");
        }
    }

    public  void FindSpatialAnchor(string id = "")
    {
        if (id != "")
        {
            currentAzureAnchorID = id;
        }

        // Set up list of anchor IDs to locate
        List<string> anchorsToFind = new List<string>();

        if (currentAzureAnchorID != "")
        {
            anchorsToFind.Add(currentAzureAnchorID);
        }
        else
        {
            Debug.Log("Current Azure anchor ID is empty");
            return;
        }

        anchorLocateCriteria.Identifiers = anchorsToFind.ToArray();
        Debug.Log($"Anchor locate criteria configured to look for Azure anchor with ID '{currentAzureAnchorID}'");

        // Start watching for Anchors
        if ((spatialAnchorManager != null) && (spatialAnchorManager.Session != null))
        {
            currentWatcher = spatialAnchorManager.Session.CreateWatcher(anchorLocateCriteria);
            Debug.Log("Watcher created");
            Debug.Log("Looking for Azure anchor... please wait...");
        }
        else
        {
            Debug.Log("Attempt to create watcher failed, no session exists");
            currentWatcher = null;
        }
    }

    public string Get_ASA_SessionID()
    {
        var cloudID = cloudSASession.SessionId;
        return cloudID;
    }

    public async void DeleteSpacialAnchor()
    {
        // Delete the Azure anchor with the ID specified off the server and locally
        await spatialAnchorManager.DeleteAnchorAsync(currentCloudAnchor);
        currentCloudAnchor = null;

        Debug.Log("Azure anchor deleted successfully");
    }

}
