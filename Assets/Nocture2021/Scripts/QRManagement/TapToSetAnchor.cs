using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using UnityEngine;

public class TapToSetAnchor : MonoBehaviour, IMixedRealityPointerHandler
{

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
    /// Once the user clicks the reference object, which will anchor the play space, gets instantiated
    /// on the location of the QR code.
    ///
    /// We don't care (at least for now) what is the QR code as we assume there will be only one in sight.
    /// </summary>
    /// <param name="eventData">Event data from the pointer interaction. Not used in this method</param>
    public void OnPointerClicked(MixedRealityPointerEventData eventData)
    {
        var QRCode = GameObject.Find("QRCode");
        if (QRCode == null)
        {
            return;
        }

        //TODO: for now we are instantiating a cube. It should be an empty game object to work as the ASA
        var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);

        //TODO: call the ASA tag registry script @Shannon

        //Remove the text on the screen
        var text = GameObject.Find("No TAG Text(Clone)");
        if (text != null)
        {
            Destroy(text);
        }

        //Get rid of this script (we already placed the anchor)
        Destroy(this);

    }
}
