using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This will be replacing SharingModuleScript which will share and get the Azure Anchor
//ShareAzureAnchor() needs PhotonUser class and needs a work around so that the user gets the anchor id shared without building the class out
//TBD

public class SpatialAnchorTagRegistry : MonoBehaviour
{
    public AnchorScriptManager anchorScriptManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //public void ShareAzureAnchor()
    //{
    //    NetworkInstance.Instance.azureAnchorId = anchorScriptManager.currentAzureAnchorID;
    //    Debug.Log("NetworkInstance.Instance.azureAnchorId: " + NetworkInstance.Instance.azureAnchorId);
    //
    //     var pvLocalUser = NetworkInstance.Instance.localUser.gameObject;
    //    var pu = pvLocalUser.gameObject.GetComponent<PhotonUser>();
    //    pu.ShareAzureAnchorId();
    //}

    public void GetAzureAnchor()
    {
        Debug.Log("NetworkInstance.Instance.azureAnchorId: " + NetworkInstance.Instance.azureAnchorId);

        anchorScriptManager.FindSpatialAnchor(NetworkInstance.Instance.azureAnchorId);
    }
}
