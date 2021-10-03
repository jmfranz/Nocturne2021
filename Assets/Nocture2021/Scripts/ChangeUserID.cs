using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChangeUserID : MonoBehaviour
{
    public TextMeshPro UIText;
    public int currentUserID;

    private TouchScreenKeyboard keyboard;
    private string keyboardText = "";


    public void OpenSystemKeyboard()
    {
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default, false, false, false, false);
    }

    private void Update()
    {
        if (keyboard != null)
        {
            keyboardText = keyboard.text;
            if(int.TryParse(keyboardText, out currentUserID))
            {
                UIText.text = $"Current User ID {currentUserID}";
                Logger.SetUserID(currentUserID.ToString());   // Set the User ID for the Logger.
            }
        }
    }
}
