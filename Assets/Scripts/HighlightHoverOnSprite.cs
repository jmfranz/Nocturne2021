/*
 * @Author: Abbey Singh
 * Place this on a sprite to highlight and enlarge it when hovering over it. This will also show text describing the page it is refering to.
 */

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HighlightHoverOnSprite : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        this.GetComponent<Image>().color = Color.white;
        this.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        this.GetComponent<Image>().color = Color.black;
        this.GetComponent<RectTransform>().localScale = new Vector3(1.25f, 1.25f, 1.25f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.GetComponent<Image>().color = Color.white;
        this.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
    }
}
