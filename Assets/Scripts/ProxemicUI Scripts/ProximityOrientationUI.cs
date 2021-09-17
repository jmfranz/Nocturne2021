using ProxemicUIFramework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * The class deals with the creation of proximity and orientation rules based on user input through StoryCreatAR UI
 * @author: Shannon Frederick
 * @lastUpdated: March 6, 2021
 */
public class ProximityOrientationUI : MonoBehaviour
{
    DataReceiver _dataReceiver;
    public CreateConversationNodeUIController CreateConversationNodeUIController;
    public ConversationDialogueUIController ConversationDialogueUIController;

    //Pulls dropdown objects
    public TMPro.TMP_Dropdown proximityMin;
    public TMPro.TMP_Dropdown proximityMax;
    public TMPro.TMP_Dropdown orientationDropdown;
    public TMPro.TMP_Dropdown triggerConfiguration;
    public TMPro.TMP_Dropdown locationDropdown;
    public Button saveButton;
    public Button addRuleButton;

    //Modifiable Text
    public TMPro.TMP_Text ruleSummary;
    public TMPro.TMP_Text triggerDescription;
    public TMPro.TMP_Text errorMessage;

    //Input variables to be set
    public int proximityMinInput;
    public int proximityMaxInput;
    public int orientationInput;
    public int triggerChosen;
    public int proximityOrNot;
    public ConversationNodeData ConversationNodeData;

    //Player and Entities
    [SerializeField] GameObject _player;

    //List of rules and entities player is interacting with
    List<int> proximityContainer;
    List<int> combinationContainer;
    List<string> ruleSummaryString;

    //Start is called before the first frame update
    void Start()
    {
        //Receive position data from Unity
        _dataReceiver = new DataReceiver(5103, "127.0.0.1");

        //Disable Save Button and enable add rule button as default
        saveButton.interactable = false;
        addRuleButton.interactable = true;

        proximityOrNot = 0;
        proximityContainer = new List<int>();
        combinationContainer = new List<int>();
        ruleSummaryString = new List<string>();

        proximityMinInput = -1;
        proximityMaxInput = -1;
    }

    //Get and save min value
    public void GetProximityMin(int proxMin)
    {
        proximityMinInput = proxMin - 1;
        errorChecking(this.proximityMinInput, this.proximityMaxInput);
    }

    //Get and save max value
    public void GetProximityMax(int proxMax)
    {
        proximityMaxInput = proxMax;
        errorChecking(this.proximityMinInput, proxMax);
    }

    //Get proximity location (in the range or outside range)
    public void GetProximityLocation(int proxLocation)
    {
        proximityOrNot = proxLocation;
    }

    //Get and save orientation value
    public void GetOrientationValue(int orientation)
    {
        orientationInput = orientation;
    }


    //Get and save desired trigger
    public void GetTrigger(int trigger)
    {
        errorMessage.enabled = false;
        switch (trigger)
        {
            case 1:
                triggerDescription.SetText("Proximity trigger activates when the actor comes within a set distance of the subject.  Please select the min and max distance below.  Please select \'Outside\' in the dropdown to reverse the trigger ");                
                
                // check if proximity distances are filled in
                if(!errorChecking(proximityMinInput, proximityMaxInput) && proximityMinInput != -1 && proximityMaxInput != -1)
                {
                    saveButton.interactable = true;
                }
                else
                {
                    saveButton.interactable = false;
                }
                break;
            case 2:
                triggerDescription.SetText("Is Facing trigger activates when the actor is either facing or not facing within 45 degrees of the subject depending on orientation choice.  The subject is not necessarily facing the actor");
                saveButton.interactable = true;
                break;
            case 3:
                triggerDescription.SetText("Facing each other trigger activates when the player and the subject are either facing or not facing within 45 degrees of eachother depending on orientation choice.");
                saveButton.interactable = true;
                break;
            case 4:
                triggerDescription.SetText("Proximity AND Orientation trigger activates when the actor comes within a set distance of the subject AND the actor is either facing or not facing within 45 degrees depending on orientation choice.");
                saveButton.interactable = false;
                break;
            case 5:
                triggerDescription.SetText("Either Proximity OR Orientation trigger activates when the actor comes within a set distance of the subject OR the actor is either facing or not facing within 45 degrees depending on orientation chioce but not both.");
                saveButton.interactable = true;
                break;
        }

        triggerChosen = trigger;
    }

    bool errorChecking(int oldMin, int max)
    {
        int min = oldMin;
        if (min > max)
        {
            // Cannot save rule and error message appears
            saveButton.interactable = false;
            errorMessage.SetText("Min value cannot be greater than max value.  Please enter valid values.");
            errorMessage.enabled = true;
            return true;
        }
        else if (min == max)
        {
            saveButton.interactable = false;
            errorMessage.SetText("Min and max values cannot be equal");
            errorMessage.enabled = true;
            return true;
        }
        else if (min == -1 || max == 0)
        {
            errorMessage.SetText("Min and max values must be set");
            errorMessage.enabled = true;
            saveButton.interactable = false;
            return true;
        }
        else
        {
            errorMessage.enabled = false;
            saveButton.interactable = true;
            return false;
        }
    }

    /*
     * Saves the rule upon closing the popup
     * @param: triggerOption - the value of the selected dropdown indicated type of trigger
     */
    public void SaveRule()
    {
        string finalString = "";

        foreach (string rule in this.ruleSummaryString)
        {
            finalString += rule + ", ";
        }
        
        ruleSummary.SetText(finalString + ".");

        Debug.Log("Rule has been saved.");

        int ruleCount = ConversationDialogueUIController.GetRuleCount();
        if (ruleCount >= 2)
        {
            addRuleButton.interactable = false;
        } else
        {
            addRuleButton.interactable = true;
        }
    }

    /*
     * Takes in selected trigger, addes rule information into containers
     * Sets UI text and checks for input errors
     */
    public void SetRules()
    {
        int triggerOption = this.triggerChosen;
        bool withinOrNot;

        switch (triggerOption)
        {
            case 0:                                                             // No trigger selected
                //Disables save button and error message
                saveButton.interactable = false;
                errorMessage.enabled = false;
                break;
            case 1:                                                             // Within a Distance selected
                //Set proximity rule
                withinOrNot = true;                                                             
                if (this.proximityOrNot == 1)
                {
                    //If player is OUTSIDE range specified
                    ruleSummaryString.Add("Proximity outside of: " + this.proximityMinInput + " and " + this.proximityMaxInput);
                    withinOrNot = false;
                }
                else
                {
                    //Adding rule to list and Rule Enguine
                    ruleSummaryString.Add("Proximity within: " + this.proximityMinInput + " and " + this.proximityMaxInput);
                }
                //CreateConversationNodeUIController.SetDistanceRule(proximityContainer);
                ConversationDialogueUIController.SetDistanceRule(this.proximityMinInput, this.proximityMaxInput, withinOrNot);
                saveButton.interactable = true;
                break;
            case 2:                                                             // is Facing selected
                int facingVariable = 0;
                switch (this.orientationInput)
                {
                    case 0:
                        ruleSummaryString.Add("Player facing subject");
                        facingVariable = 1;
                        break;
                    case 1:
                        ruleSummaryString.Add("Player not facing subject");
                        facingVariable = 2;
                        break;
                }
                //CreateConversationNodeUIController.SetIsFacingRule(facingVariable);
                ConversationDialogueUIController.SetIsFacingRule(facingVariable);
                saveButton.interactable = true;
                break;
                ///////*********REMOVED FOR INTERFACE APPROACH WITH AUTHORS*********/////// 
                /*case 3:                                                            // Proximity AND Orientation selected
                    //Create "AND" rule so that if BOTH are true, conversation occurs
                    ruleSummaryString.Add("Proximity AND Orientation set");

                    //Setting rules
                    combinationContainer.Add(this.proximityMinInput);
                    combinationContainer.Add(this.proximityMaxInput);
                    combinationContainer.Add(1);            //withinRange
                    combinationContainer.Add(1);            //isFacing
                    combinationContainer.Add(1);            //RuleType
                    CreateConversationNodeUIController.SetCombinationRule(combinationContainer);
                    saveButton.interactable = true;
                    break;
                case 4:                                                             // Either Proximity OR Orientation selected
                    //Create "XOR" rule so that if either one is true, conversation occurs
                    ruleSummaryString.Add("Trigger Proximity OR Orientation set");

                    //Setting rules
                    //Set combination variables
                    combinationContainer.Add(this.proximityMinInput);
                    combinationContainer.Add(this.proximityMaxInput);
                    combinationContainer.Add(1);            //withinRange
                    combinationContainer.Add(1);            //isFacing
                    combinationContainer.Add(2);            //RuleType
                    CreateConversationNodeUIController.SetCombinationRule(combinationContainer);
                    saveButton.interactable = true;
                    break;

                    case 5:                                                             // are Facing Each Other selected
                    switch (this.orientationInput)
                    {
                        case 0:
                            ruleSummaryString.Add("Orientation facing each other");
                            orientationContainer.facing = true;
                            break;
                        case 1:
                            ruleSummaryString.Add("Orientation not facing each other");
                            orientationContainer.facing = false;
                            break;
                    }
                    CreateConversationNodeUIController.SetOrientationRule(orientationContainer);
                    saveButton.interactable = true;
                    break;
                    */
        }
    }

    /*
     * Resets rules so that the next time rules are added to a different conversation they are not duplicated or incorrect
     * This also resets the dropdown variable choices
     */
    public void ResetUI()
    {
        //Reset Buttons & Dropdowns
        addRuleButton.interactable = true;
        combinationContainer.Clear();

        //Reset rule list and text
        Debug.Log("Rules are resetting");
        ruleSummary.SetText("You have not added any triggers yet");
        ruleSummaryString.Clear();
    }

    public void PopupReset()
    {
        //Reset variables
        proximityOrNot = 0;
        proximityMinInput = 0;
        proximityMaxInput = 0;
        orientationInput = 0;
        triggerChosen = 0;

        //Reset Dropdowns
        saveButton.interactable = false;
        proximityMin.value = 0;
        proximityMax.value = 0;
        triggerConfiguration.value = 0;
    }
}