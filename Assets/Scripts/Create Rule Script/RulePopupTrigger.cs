using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class RulePopupTrigger : MonoBehaviour
{ 
    public GameObject proximityrule;
    public GameObject orientationrule;
    public TMPro.TMP_Dropdown triggerDropdown;
    public TMPro.TMP_Text andOr;
    public Button saveButton;

    void Start()
    {
        proximityrule.SetActive(false);
        orientationrule.SetActive(false);
        andOr.enabled = false;
        saveButton.interactable = false;
    }
    
    public void TriggerDropdown(int triggerIndex)
    {
        switch (triggerIndex)
        {
            case 0:
                proximityrule.SetActive(false);
                orientationrule.SetActive(false);
                andOr.text = "";
                saveButton.interactable = false;
                break;
            case 1:
                proximityrule.SetActive(true);
                orientationrule.SetActive(false);
                andOr.text = "";
                saveButton.interactable = true;
                break;
            case 2:
                proximityrule.SetActive(false);
                orientationrule.SetActive(true);
                andOr.text = "";
                saveButton.interactable = true;
                break;
            case 3:
                proximityrule.SetActive(true);
                orientationrule.SetActive(true);
                andOr.text = "AND";
                andOr.enabled = true;
                saveButton.interactable = true;
                break;
            case 4:
                proximityrule.SetActive(true);
                orientationrule.SetActive(true);
                andOr.text = "OR";
                andOr.enabled = true;
                saveButton.interactable = true;
                break;
        }
    }
}
