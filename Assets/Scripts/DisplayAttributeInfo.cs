/*
 * @Author: Abbey Singh
 * This will show a text bubble with information on the attribute
 */
 
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using System.Collections.Generic;

public class DisplayAttributeInfo : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public GameObject PopUp;

    public void OnPointerClick(PointerEventData eventData)
    {
        //Perform same function as exit
        PopUp.SetActive(false);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Remove text bubble
        PopUp.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        string name = this.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;

        if(name != "Create a new Attribute")
        {
            //Show text bubble
            PopUp.SetActive(true);

            //find current attribute from list
            int i;
            for (i = 0; i < Stories.Instance.Attributes.Count; i++)
            {
                if(Stories.Instance.Attributes[i].AttributeName == name)
                {
                    break;
                }
            }

            AttributeSS attribute = Stories.Instance.Attributes[i];

            //create text for UI
            string UItext = name + ":\n\n";
            List<string> spaceSyntaxAttributes = new List <string> {"Openness", "Visual Complexity", "Visual Integration"};

            if(attribute.SpaceSyntaxOptions != null)
            {
                for (i = 0; i < attribute.SpaceSyntaxOptions.Count; i++)
                {
                    if (attribute.SpaceSyntaxOptions[i] != "None")
                    {
                        UItext += spaceSyntaxAttributes[i] + ":" + attribute.SpaceSyntaxOptions[i] + "\n";
                    }
                }
            }

            PopUp.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = UItext;

        }
    }
}
