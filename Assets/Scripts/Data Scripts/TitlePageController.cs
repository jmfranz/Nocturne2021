/*
 * Author: Abbey Singh
 * This script will control the functionality for the title screen.
 */

using UnityEngine;

public class TitlePageController : MonoBehaviour
{
    public ViewStoriesController ViewStoriesController;
    public GameObject StaticCanvas;
    public GameObject ViewStoriesText;

    void Start()
    {
        StaticCanvas.SetActive(false);
    }

    public void SetStaticCanvasActive()
    {
        StaticCanvas.SetActive(true);
        ViewStoriesText.transform.GetChild(0).gameObject.SetActive(false);
    }
}
