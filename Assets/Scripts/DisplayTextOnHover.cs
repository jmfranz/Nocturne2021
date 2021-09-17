/*
 * @Author: Abbey Singh
 * This will be used to display a screens name in the dot navigation
 */

using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class DisplayTextOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public DotNavigationController DotNavigationController;

    GameObject ScreenName;

    void Start()
    {
        ScreenName = DotNavigationController.GetScreenNameText();
        ScreenName.SetActive(false);
    }


    public void SetScreenNameInactive()
    {
        ScreenName.SetActive(false);
    }

    public void DisplayScreenNameText(GameObject dot)
    {
        // Show name of this dot
        string screenName = DotNavigationController.FindScreenName(dot);
        screenName = ParseScreenName(screenName);
        ScreenName.SetActive(true);
        ScreenName.GetComponent<TextMeshProUGUI>().text = screenName;

        Vector3 pos = dot.transform.localPosition;
        ScreenName.transform.localPosition = new Vector3(pos.x, pos.y + 30, pos.z);
    }

    string ParseScreenName(string name)
    {
        // Remove "screen" if contained in name
        if (name.Contains("Screen"))
        {
            name = name.Replace("Screen", "");
        }

        // Split up 'CamelCase' into 'Camel Case' (adding spaces between words).
        // Expression obtained from: https://stackoverflow.com/questions/5796383/insert-spaces-between-words-on-a-camel-cased-token
        name = Regex.Replace(name, "(\\B[A-Z])", " $1");
        return name;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        DisplayScreenNameText(this.transform.parent.gameObject);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        SetScreenNameInactive();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        SetScreenNameInactive();
    }
}
