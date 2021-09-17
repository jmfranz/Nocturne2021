/*
 * Author: Abbey Singh
 * Attach this script to a gameObject. 
 * This script will turn this gameobjects first child active when you are hovering over it and inactive when you leave the hover.
 */

using UnityEngine;
using UnityEngine.EventSystems;

public class AddUnderLine : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }
}
