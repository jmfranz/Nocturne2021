/*
 * Author: Abbey Singh
 * This script should be attached to the dropdown menu. It controls when the second slider becomes active.
 */

using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ControlTwoHandleSlider : MonoBehaviour
{
    public Slider Slider1;
    public Slider Slider2;

    bool slider2Active;

    public SpaceSyntaxStoryElementController SpaceSyntaxStoryElementController;

    // Start is called before the first frame update
    void Start()
    {
        Slider2.GetComponent<Slider>().gameObject.SetActive(false);
        slider2Active = false;
    }


    public void UpdateSlider()
    {
        //"In range of" is selected
        if(this.GetComponent<TMP_Dropdown>().value == 3)
        {
            slider2Active = true;

            Slider2.GetComponent<Slider>().gameObject.SetActive(true);

            Slider1.value = 0;
            Slider2.value = 1;
        }
        else
        {
            Slider2.GetComponent<Slider>().gameObject.SetActive(false);

            if (slider2Active)
            {
                slider2Active = false;
                Slider1.value = 0.5f;
            }
        }
    }
}
