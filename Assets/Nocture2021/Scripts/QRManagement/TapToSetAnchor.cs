using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using QRTracking;
using UnityEngine;

public class TapToSetAnchor : MonoBehaviour, IMixedRealityPointerHandler
{
    public GameObject ParentAnchor;
    public void Start()
    {
        CoreServices.InputSystem?.RegisterHandler<IMixedRealityPointerHandler>(this);
    }

    public void OnEnable()
    {
        CoreServices.InputSystem?.RegisterHandler<IMixedRealityPointerHandler>(this);
    }

    public void OnDisable()
    {
        CoreServices.InputSystem?.UnregisterHandler<IMixedRealityPointerHandler>(this);
    }
    
    public void OnPointerDown(MixedRealityPointerEventData eventData)
    {
        //Do Nothing
    }

    public void OnPointerDragged(MixedRealityPointerEventData eventData)
    {
        //Do Nothing
    }

    public void OnPointerUp(MixedRealityPointerEventData eventData)
    {
        //Do Nothing
    }

    /// <summary>
    /// Position's the anchor object on the QR code. This will not create an anchor to allow for rotation fine tuning
    /// The hand menu contains a create anchor option.
    ///
    /// We don't care (at least for now) what is the QR code as we assume there will be only one in sight.
    /// </summary>
    /// <param name="eventData">Event data from the pointer interaction. Not used in this method</param>
    public void OnPointerClicked(MixedRealityPointerEventData eventData)
    {
        if (ParentAnchor == null)
        {
            throw  new InvalidOperationException("We need the parent anchor to work with azure");
        }

        var QRCode = GameObject.FindGameObjectWithTag("QRTag");
        if (QRCode == null)
        {
            return;
        }

        ParentAnchor.transform.position = QRCode.transform.position;
        //Ignore the X and Z rotations to keep the building level :)

#if !UNITY_EDITOR
        ParentAnchor.transform.rotation = Quaternion.Euler(0, QRCode.transform.rotation.eulerAngles.y-270, 0);
#endif

        //Remove the text on the screen
        //TODO: move text creation to this script so we don't have to search for it... ugh...
        var text = GameObject.Find("No TAG Text(Clone)");
        if (text != null)
        {
            Destroy(text);
        }

        //Destroy the QR Code
        Destroy(QRCode);

        //Disable the "scanner"
        var qrManager = GameObject.Find("QRCodesManager").GetComponent<QRCodesManager>();
        qrManager.StopQRTracking();

#if !UNITY_EDITOR
        var anchorModule = ParentAnchor.GetComponent<AnchorModuleScript>();
        anchorModule.OnCreateAnchorSucceeded += AnchorCreatedOnAzure;
        anchorModule.CreateAzureAnchor(ParentAnchor);
#else
        Destroy(this);
#endif



    }

    private void AnchorCreatedOnAzure()
    {
        var anchorModule = ParentAnchor.GetComponent<AnchorModuleScript>();
        //I really don't like searching objects by name....
        //Maybe move the anchor store to the same GO and use require component instead
        var anchorStore = GameObject.Find("AnchorStore").GetComponent<SharedAnchorStore>();
        if (anchorStore != null)
        {
            Debug.Log("Storing new anchor ID into the local anchor store");
            anchorStore.StoreNewTag(anchorModule.currentAzureAnchorID);
        }

        anchorModule.SaveAzureAnchorIdToDisk();
        anchorModule.OnCreateAnchorSucceeded -= AnchorCreatedOnAzure;
        //Get rid of this script (we already placed the anchor)
        Destroy(this);
    }
}
