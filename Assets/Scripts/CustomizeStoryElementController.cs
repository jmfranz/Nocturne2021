/*
 * Author: Abbey Singh
 * This script will control the customize story elements screen.
 */

using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CustomizeStoryElementController : MonoBehaviour
{
    public TMP_InputField Name;
    public ViewStoryElementsController ViewStoryElementsController;
    public ControlStandalone ControlStandalone;
    public GameObject WarningText;

    public void Initialize()
    {
        StoryElement currentStoryElement = GameState.Instance.GetCurrentStoryElement();
        if (currentStoryElement != null)
        {
            Name.GetComponent<TMP_InputField>().text = currentStoryElement.Name;
        }

        WarningText.SetActive(false);
    }

    public void OnSave()
    {
        string nameInputted = Name.GetComponent<TMP_InputField>().text;

        if(nameInputted != "" && GameState.Instance.GetCurrentStoryData().IsUniqueStoryElementName(nameInputted))
        {
            if (GameState.Instance.GetModeForStoryElement() && nameInputted != "")
            {
                GameState.Instance.AddStoryElement(nameInputted);
            }
            else if (!GameState.Instance.GetModeForStoryElement() && nameInputted != "")
            {
                StoryData currentStoryData = GameState.Instance.GetCurrentStoryData();
                currentStoryData.ChangeNameOfStoryElement(GameState.Instance.GetCurrentStoryElement().Name, nameInputted);
            }

            StandaloneSaveLoad.Instance.Save();
            StandaloneSaveLoad.Instance.Load();

            WarningText.SetActive(false);

            //ViewStoryElementsController.PopulateViewStoryElements();
            ControlStandalone.GoToScreen("ViewStoryElementsScreen");
        }
        else
        {
            WarningText.SetActive(true);
        }
    }

    public void OnCancel()
    {
        GameState.Instance.NewStoryElement();
    }

    public void ClearInputs()
    {
        Name.GetComponent<TMP_InputField>().text = "";
    }

    //In the edit story/mapping pair mode this will show the previously inputted text
    public void SetInputs()
    {
        StoryElement currentStoryElement = GameState.Instance.GetCurrentStoryElement();

        if (currentStoryElement != null)
        {
            Name.GetComponent<TMP_InputField>().text = currentStoryElement.Name;
        }
    }
}
