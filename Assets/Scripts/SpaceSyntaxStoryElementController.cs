/*
 * Author: Abbey Singh
 * This script will control the screen for specifying space syntax values for a new attribute
 */

using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class SpaceSyntaxStoryElementController : MonoBehaviour
{
    //Name of story element that you are setting space syntax values for
    public TMP_InputField StoryElementName;
    public TextMeshProUGUI WarningText;

    public GameObject Openness;
    public GameObject VisualComplexity;
    public GameObject VisualIntegration;

    // Selected color
    Color selectedNormalandSelectedColor  = new Color(191 / 255f, 158 / 255f, 1);
    Color selectedHighlightColor = new Color(159 / 255f, 109 / 255f, 1);

    //Unselected color
    Color unselectedNormalColor = Color.white;
    Color unselectedHighlightandSelectedColor = new Color(245 / 255f, 245 / 255f, 245 / 255f);

    public AddAttributeController AddAttributeController;
    public ControlStandalone ControlStandalone;

    //Called when creating a new attribute
    public void InitializeNewAttribute()
    {
        StoryElementName.text = "";

        SetSpaceSyntaxValue("None", Openness);
        SetSpaceSyntaxValue("None", VisualComplexity);
        SetSpaceSyntaxValue("None", VisualIntegration);
    }

    // Used to set (using color) a particular value (lowest, low, moderate, high, highest, or none) for a particular option (visual complexity, openness, or visual integration)
    public void SetSpaceSyntaxValue(string spaceSyntaxValue, GameObject spaceSyntaxObject)
    {
        //Child will have the name of one of the values
        foreach(Transform child in spaceSyntaxObject.transform)
        {
            if(child.name == spaceSyntaxValue)
            {
                SetSelectedColor(child);
            }
            else if(child.name != "Name")
            {
                SetUnselectedColor(child);
            }
        }
    }

    void SetSelectedColor(Transform objectToSet)
    {
        //Set it's colorblock to selected color
        Button b = objectToSet.GetComponent<Button>();
        ColorBlock cb = b.colors;
        cb.normalColor = selectedNormalandSelectedColor;
        cb.highlightedColor = selectedHighlightColor;
        cb.selectedColor = selectedNormalandSelectedColor;
        b.colors = cb;

        objectToSet.GetComponent<Image>().color = selectedNormalandSelectedColor;
    }

    void SetUnselectedColor(Transform objectToSet)
    {
        //Set it's colorblock to unselected color
        Button b = objectToSet.GetComponent<Button>();
        ColorBlock cb = b.colors;
        cb.normalColor = unselectedNormalColor;
        cb.highlightedColor = unselectedHighlightandSelectedColor;
        cb.selectedColor = unselectedHighlightandSelectedColor;
        b.colors = cb;

        objectToSet.GetComponent<Image>().color = unselectedNormalColor;
    }

    public void ButtonSelected(GameObject selectedObject)
    {
        SetSpaceSyntaxValue(selectedObject.name, selectedObject.transform.parent.gameObject);
    }

    //Saves the current space syntax values and options. 
    public void OnSave()
    {
        //Get name 
        string attributeName = StoryElementName.text;

        //Get options
        List<string> options = new List<string>();
        string opennessOption = GetSelectedOption(Openness);
        string visualComplexityOption = GetSelectedOption(VisualComplexity);
        string visualIntegrationOption = GetSelectedOption(VisualIntegration);
        options.Add(opennessOption);
        options.Add(visualComplexityOption);
        options.Add(visualIntegrationOption);

        //Add new attribute
        if (UniqueAttributeName(attributeName))
        {
            WarningText.gameObject.SetActive(false);

            AttributeSS newAttribute = new AttributeSS(attributeName, options);
            Stories.Instance.AddNewAttribute(newAttribute);

            StandaloneSaveLoad.Instance.Save();
            AddAttributeController.PopulateAttributes(GameState.Instance.GetSelectedObject());

            ControlStandalone.GoToScreen("AddAttributes");
        }
        else
        {
            WarningText.gameObject.SetActive(true);
        }

    }

    string GetSelectedOption(GameObject selectedGameObject)
    {
        //Child will have the name of one of the values
        foreach (Transform child in selectedGameObject.transform)
        {
            //selected child
            if (child.name != "Name" && child.GetComponent<Image>().color == selectedNormalandSelectedColor)
            {
                return child.name;
            }
        }

        return "";
    }

    public void OnCancel()
    {
        AddAttributeController.PopulateAttributes(GameState.Instance.GetSelectedObject());
        ControlStandalone.GoToScreen("AddAttributes");
    }

    bool UniqueAttributeName(string name)
    {
        if(name == "")
        {
            return false;
        }

        foreach(var attribute in Stories.Instance.GetAttributes())
        {
            if(name == attribute.AttributeName)
            {
                return false;
            }
        }

        return true;
    }

}