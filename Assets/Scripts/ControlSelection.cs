/*
 * Author: Abbey Singh
 * This script will control checkmark selection
 */

using UnityEngine;

public class ControlSelection : MonoBehaviour
{
    bool selected = false;

    void Start()
    {
        selected = false;
    }

    void Select(GameObject storyElementGameObject)
    {
        GameObject checkObject = storyElementGameObject.transform.GetChild(1).GetChild(2).gameObject;
        checkObject.SetActive(true);
    }

    void UnSelect(GameObject storyElementGameObject)
    {
        GameObject checkObject = storyElementGameObject.transform.GetChild(1).GetChild(2).gameObject;
        checkObject.SetActive(false);
    }

    public void ChangeSelectionValue(GameObject storyElementGameObject)
    {
        if (!selected)
        {
            Select(storyElementGameObject);
            selected = true;
        }
        else
        {
            UnSelect(storyElementGameObject);
            selected = false;
        }
    }
}
