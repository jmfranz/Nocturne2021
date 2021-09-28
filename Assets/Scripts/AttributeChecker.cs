/*
 * @Author: Abbey Singh
 * This script will check if this gameObject has all n gameObjects as active, then it will disable a button
 */

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttributeChecker : MonoBehaviour
{
    public List<GameObject> ObjectsToCheck;
    public Button MyButton;

    bool allActive;

    //Update is called once per frame
    void Update()
    {
        allActive = true;

        //If all gameObjects are active, then disable button
        foreach (var checkObject in ObjectsToCheck)
        {
            if (!checkObject.activeSelf)
            {
                allActive = false;
            }
        }

        //Disable button
        if (allActive)
        {
            MyButton.interactable = false;
        }
        else
        {
            MyButton.interactable = true;
        }
    }
}
