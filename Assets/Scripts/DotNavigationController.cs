/*
 * @Author: Abbey Singh
 * This script will control the dot navigation with automatic positioning of dots.
 * When an unselected dot is pressed this script will switch to that dot's screen.
 * Dot navigation should be placed in a separate canvas, this will need to be updated 
 * in ControlStandalone.cs to indicate when this canvas should be active.
 */
 
using UnityEngine;

public class DotNavigationController : MonoBehaviour
{
    //Order matters, drag the first screen in the navigation in the first position of the array
    public GameObject[] ListOfScreensInNavigation;

    public GameObject DotPrefab;
    public GameObject ScreenNameText;

    //Holds how many screens (dots) in the navigation there are
    int numDots;

    //if you change size of navigation width or size of dot width these will need to be changed
    readonly int dotNavigationWidth = 400;
    readonly int dotWidth = 50;

    public ControlStandalone ControlStandalone;

    //Start will position the objects 
    void Awake()
    {
        numDots = ListOfScreensInNavigation.Length;

        //Calculate spacing between dots
        int whiteSpaceLeftOver = dotNavigationWidth - dotWidth * numDots;
        float spacing = whiteSpaceLeftOver / (1 + numDots);

        DotPrefab.SetActive(true);

        //position from middle of dot
        float xStartPosition = -dotNavigationWidth / 2 + dotWidth / 2;

        for (int i = 0; i < numDots; i++)
        {
            //Position dots evenly horizontally
            float xPosition = xStartPosition + (i + 1) * spacing + dotWidth * i;

            GameObject dot = Instantiate(DotPrefab, this.transform, false);
            dot.name = i.ToString();
            dot.transform.localPosition = new Vector3(xPosition, 0, 0);
        }

        DotPrefab.SetActive(false);
        SetInitialDotsPosition(0);
    }

    public GameObject GetScreenNameText()
    {
        return ScreenNameText;
    }

    public void SetInitialDotsPosition(int position)
    {
        SetAllDotsToUnselectedBut(position);
    }

    //Called when the dot is pressed
    public void DotPressed(GameObject pressedDot)
    {
        SetAllDotsToUnselectedBut(int.Parse(pressedDot.name));
        ControlStandalone.GoToScreen(FindScreenName(pressedDot));
    }

    public string FindScreenName(GameObject pressedDot)
    {
        return ListOfScreensInNavigation[int.Parse(pressedDot.name)].name;
    }

    //0 is first dot, 1 is second dot, etc.
    public void SetAllDotsToUnselectedBut(int dotNumber)
    {
        for(int i = 0; i < numDots; i++)
        {
            SetAsUnselected(FindDot(i));
        }

        SetAsSelected(FindDot(dotNumber));
    }

    //Has first child as selected and second child as unselected
    void SetAsUnselected(GameObject dot)
    {
        if(dot != null)
        {
            dot.transform.GetChild(0).gameObject.SetActive(false);
            dot.transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    //Has first child as selected and second child as unselected
    void SetAsSelected(GameObject dot)
    {
        if(dot != null)
        {
            dot.transform.GetChild(0).gameObject.SetActive(true);
            dot.transform.GetChild(1).gameObject.SetActive(false);
        }
    }

    GameObject FindDot(int dotNumber)
    {
        foreach (Transform child in this.transform)
        {
            if (child.name != "ScreenName" && int.Parse(child.name) == dotNumber)
            {
                return child.gameObject;
            }
        }

        return null;
    }
}
