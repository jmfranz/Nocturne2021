using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Fade : MonoBehaviour
{
    //[Header("Have one of the following true")] 
    [SerializeField] bool fadeTextIn = true;

    [SerializeField] float duration = 5; // duration in seconds
    private float t = 0; // lerp control variable

    void Update ()
    {
        if (fadeTextIn && t < 1)
        {
            Color32 color  = Color32.Lerp(Color.clear, Color.red, t);
            GetComponent<TextMeshPro>().color = color;

            t += Time.deltaTime / duration;
        }
    }
}
