/*
 * Author: Abbey Singh
 * This script will control the screen for uploading a story element.
 */

using UnityEngine;
using UnityEngine.UI;

public class ControlMappingScreen : MonoBehaviour
{
    public InputField Name;

    //Called when save button is clicked
    //TODO: Later this should also check if a map is inputted, if it is not inputted do not save the name.
    public void OnSave()
    {
        string mapNameInputted = Name.GetComponent<InputField>().text;
        //Make sure title inputted is not empty and it is unique
        if (mapNameInputted != "" && Stories.Instance.IsUniqueMapName(mapNameInputted))
        {
            Debug.LogFormat("Name: '{0}'", mapNameInputted);

            //Add to stories
            Stories.Instance.AddMap(mapNameInputted);

            //Save to json
            StandaloneSaveLoad.Instance.Save();
        }

        ClearInputs();
    }

    //Called when cancel button is clicked
    public void OnCancel()
    {
        ClearInputs();
    }

    void ClearInputs()
    {
        //Clear input field
        Name.GetComponent<InputField>().text = "";
    }
}
