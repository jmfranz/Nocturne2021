using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

/*
 * Based off script from https://answers.unity.com/questions/836642/new-ui-46-how-to-show-ellipsis-for-text-overflow.html 
 */

public class ShowOverflowTextEllipsis : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    TextMeshProUGUI text;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        UseEllipsis();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (text.isTextTruncated)
        {
            ShowFullText();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!text.isTextTruncated)
        {
            UseEllipsis();
        }
    }

    void ShowFullText()
    {
        text.enableWordWrapping = true;
        text.overflowMode = TextOverflowModes.Overflow;
    }

    void UseEllipsis()
    {
        text.enableWordWrapping = false;
        text.overflowMode = TextOverflowModes.Ellipsis;
    }
}
