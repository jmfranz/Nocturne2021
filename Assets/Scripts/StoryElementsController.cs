/*
 * Author: Abbey Singh
 * This script will control the menu in the story elements section.
 */

using UnityEngine;

public class StoryElementsController : MonoBehaviour
{
    public GameObject StoryMenu;
    public GameObject OutButton;

    bool menuIn;

    void Start()
    {
        SetMenuIn();
    }

    public void ControlDropDown()
    {
        if (menuIn)
        {
            SetMenuOut();
        }
        else
        {
            SetMenuIn();
        }
    }

    public void SetMenuIn()
    {
        StoryMenu.SetActive(false);
        OutButton.SetActive(true);
        menuIn = true;
    }

    public void SetMenuOut()
    {
        StoryMenu.SetActive(true);
        OutButton.SetActive(false);
        menuIn = false;
    }
}
