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

    public void OnPointerClicked(MixedRealityPointerEventData eventData)
    {
        var QRCode = GameObject.Find("QRCode");
        if (QRCode == null)
        {
            return;
        }

        var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = QRCode.transform.position;
    }
}
