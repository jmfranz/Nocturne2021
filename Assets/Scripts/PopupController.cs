using TMPro;
using UnityEngine;


public class PopupController : MonoBehaviour
{
    public TextMeshProUGUI Title;   

    public void ShowPopup(string title)
    {
        SetTitleText(title);
        gameObject.SetActive(true);
    }

    void SetTitleText(string text)
    {
        Title.text = text;
    }

    public string GetTitleText()
    {
        return Title.text;
    }

    public void ClosePopup()
    {
        gameObject.SetActive(false);
    }
}
