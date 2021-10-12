using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChangeUserID : MonoBehaviour
{
    public TextMeshPro UIText;
    
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
            UIText.text = $"Current User ID {keyboardText}";
            Logger.SetUserID(keyboardText);   // Set the User ID for the Logger.
        }
    }
}
