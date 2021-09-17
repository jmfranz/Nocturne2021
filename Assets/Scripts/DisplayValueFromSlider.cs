/*
 * @Author: Abbey Singh
 * Attach this script to a text UI object, take in the slider you would like to get the value from.
 * This will display the numeric value of the slider from 0 - 100.
 */

using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayValueFromSlider : MonoBehaviour
{
    public TMP_Dropdown Dropdown;

    //two sliders in case there are two slider handles (specifying a range)
    public Slider Slider1;
    public Slider Slider2; 

    void Start()
    {
        //slider starts at value 0.5
        //0.5 * 100 = 50
        this.GetComponent<TextMeshProUGUI>().text = "50";
    }

    void Update()
    {
        int slider1Text = Mathf.RoundToInt(Slider1.GetComponent<Slider>().value * 100);
        this.GetComponent<TextMeshProUGUI>().text = slider1Text.ToString();

        //"In range of" is selected
        //text should be in the form "20 - 50"
        if (Dropdown.GetComponent<TMP_Dropdown>().value == 3)
        {
            int slider2Text = Mathf.RoundToInt(Slider2.GetComponent<Slider>().value * 100);

            if(slider1Text <= slider2Text)
            {
                this.GetComponent<TextMeshProUGUI>().text = slider1Text + " - " + slider2Text;
            }
            else
            {
                this.GetComponent<TextMeshProUGUI>().text = slider2Text + " - " + slider1Text;
            }
        }
    }
}