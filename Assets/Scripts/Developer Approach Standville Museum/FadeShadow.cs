using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeShadow : MonoBehaviour
{
    //[Header("Have one of the following true")] 
    [SerializeField] bool fadeShadow = true;

    [SerializeField] float duration = 5; // duration in seconds
    private float t = 0; // lerp control variable

    Color color1 = Color.red, color2 = Color.red;

    public GameObject Shadow;

    private void Awake()
    {
        var materials = GetComponent<Renderer>().materials;
        color1 = materials[0].color;
        color2 = materials[1].color;
    }

    void Update()
    {
        if (fadeShadow && t < 1)
        {
            Color32 color1_lerp = Color32.Lerp(color1 , Color.clear, t);
            Color32 color2_lerp = Color32.Lerp(color2, Color.clear, t);

            var materials = GetComponent<Renderer>().materials;
            materials[0].color = color1_lerp;
            materials[1].color = color2_lerp;

            t += Time.deltaTime / duration;
        }
        else if(fadeShadow && t >= 1)
        {
            Shadow.SetActive(false);
        }
    }
}
