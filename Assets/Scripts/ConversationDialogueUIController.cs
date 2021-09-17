using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using ProxemicUIFramework;

public class ConversationDialogueUIController : MonoBehaviour
{
    public ScrollViewController ScrollViewController;
    public TextMeshProUGUI Description;
    public CreateConversationNodeUIController CreateConversationNodeUIController;
    public ProximityOrientationUI ProximityOrientationUI;
    public GameObject DialogueItemGameObject;
    public Toggle IsLoopingToggle;
    public TMP_InputField bufferTimeInputField;

    int numberOfVoiceLineData;

    List<string> actors = new List<string>();
    List<string> lines = new List<string>();
    List<Volumes> volumes = new List<Volumes>();

    public RulesContainer.RuleContainer convoRules = new RulesContainer.RuleContainer();

    public enum Volumes {Whisper, Normal, Yell}
    public enum States { ToVRARPlayer, ToEachOther}
    public States currentState;

    public void SetDescription (string text)
    {
        Description.text = text;
    }

    private void OnEnable()
    {
        SetLineDefaultInfo();

        //assume no edit function FOR NOW
        numberOfVoiceLineData = 0;
        ScrollViewController.PopulateScrollViewItems(numberOfVoiceLineData);

        //Reset values
        actors = new List<string>();
        lines = new List<string>();
        volumes = new List<Volumes>();
        bufferTimeInputField.text = "";
        IsLoopingToggle.isOn = true;
    }

    void SetLineDefaultInfo()
    {
        Transform actorsDropdown = DialogueItemGameObject.transform.GetChild(2);
        Transform linesDropdown  = DialogueItemGameObject.transform.GetChild(3);

        string allAvatarNamesText = CreateConversationNodeUIController.AllAvatarsInvolvedText.text;
        actorsDropdown.GetComponent<TMP_Dropdown>().ClearOptions();

        if (allAvatarNamesText != "")
        {
            string[] avatarNames = DataFormatHandler.Instance.ConvertCSVStringToStringArray(allAvatarNamesText);
            actorsDropdown.GetComponent<TMP_Dropdown>().AddOptions(new List<string>(avatarNames));
        }

        string[] audioLineNames = Directory.GetFiles(Application.dataPath + "/Resources/Conversations/ConversationLines/");
        List<string> audioLineNamesNoMeta = new List<string>();
        foreach(string audioLineName in audioLineNames)
        {
            if (!audioLineName.Contains(".meta"))
            {
                audioLineNamesNoMeta.Add(Path.GetFileNameWithoutExtension(audioLineName));
            }
        }
        linesDropdown.GetComponent<TMP_Dropdown>().ClearOptions();
        linesDropdown.GetComponent<TMP_Dropdown>().AddOptions(audioLineNamesNoMeta);
    }

    public void UpdateVoiceLineData()
    {
        List<GameObject> scrollviewGameObjects = ScrollViewController.GetScrollViewGameObjects();

        for(int i = 0; i < scrollviewGameObjects.Count; i++)
        {
            Transform orderInputField = scrollviewGameObjects[i].transform.GetChild(1);
            TMP_Dropdown actorsDropdown = scrollviewGameObjects[i].transform.GetChild(2).GetComponent<TMP_Dropdown>();
            TMP_Dropdown linesDropdown = scrollviewGameObjects[i].transform.GetChild(3).GetComponent<TMP_Dropdown>();
            TMP_Dropdown volumesDropdown = scrollviewGameObjects[i].transform.GetChild(4).GetComponent<TMP_Dropdown>();

            orderInputField.GetComponent<TMP_InputField>().text = (i + 1).ToString();
            SetDropdown(actorsDropdown, actors[i]);
            SetDropdown(linesDropdown, lines[i]);
            SetDropdown(volumesDropdown, volumes[i].ToString());
        }

        systemChange = false;
    }

    void SetDropdown(TMP_Dropdown dropdown, string option)
    {
        for(int i = 0; i < dropdown.options.Count; i++)
        {
            if(dropdown.options[i].text == option)
            {
                dropdown.value = i;
                break;
            }
        }
    }

    bool orderChanged = false;
    int previousOrder = 0;
    bool systemChange = false;
    public void SaveVoiceLineDataOnChange(GameObject DialogueItem)
    {
        if (systemChange)
        {
            return;
        }
        systemChange = true; //true so that updating voice line data will finish without interruption from this method
        Transform orderInputField = DialogueItem.transform.GetChild(1);
        TMP_Dropdown actorsDropdown = DialogueItem.transform.GetChild(2).GetComponent<TMP_Dropdown>();
        TMP_Dropdown linesDropdown = DialogueItem.transform.GetChild(3).GetComponent<TMP_Dropdown>();
        TMP_Dropdown volumesDropdown = DialogueItem.transform.GetChild(4).GetComponent<TMP_Dropdown>();

        int orderInput = int.Parse(orderInputField.GetComponent<TMP_InputField>().text);
        string actorSelected = actorsDropdown.options[actorsDropdown.value].text;
        string lineSelected = linesDropdown.options[linesDropdown.value].text;
        string volumeSelected = volumesDropdown.options[volumesDropdown.value].text;

        if (orderChanged)
        {
            if (orderInput < 1)
            {
                orderInput = 1;
            }
            else if (orderInput > numberOfVoiceLineData)
            {
                orderInput = numberOfVoiceLineData;
            }

            actors.RemoveAt(previousOrder - 1);
            actors.Insert(orderInput - 1, actorSelected);

            lines.RemoveAt(previousOrder - 1);
            lines.Insert(orderInput - 1, lineSelected);

            volumes.RemoveAt(previousOrder - 1);
            volumes.Insert(orderInput - 1, GetVolumes(volumeSelected));

            orderChanged = false;
        }
        else
        {
            actors[orderInput - 1] = actorSelected;
            lines[orderInput - 1] = lineSelected;
            volumes[orderInput - 1] = GetVolumes(volumeSelected);
        }

        UpdateVoiceLineData();
    }

    Volumes GetVolumes(string volumeInput)
    {
        switch (volumeInput)
        {
            case "Normal":
                return Volumes.Normal;
            case "Whisper":
                return Volumes.Whisper;
            case "Yell":
                return Volumes.Yell;
            default:
                Debug.LogErrorFormat("ERROR: Volumes inout '{0}' is undefined", volumeInput);
                return Volumes.Normal;
        }
    }

    public void SelectOrder(GameObject DialogueItem)
    {
        Transform orderInputField = DialogueItem.transform.GetChild(1);
        previousOrder = int.Parse(orderInputField.GetComponent<TMP_InputField>().text);
        orderChanged = true;
    }

    public void AddVoiceLineData()
    {
        numberOfVoiceLineData++;

        if(CreateConversationNodeUIController.AllAvatarsInvolvedText.text != "")
        {
            actors.Add(DataFormatHandler.Instance.ConvertCSVStringToStringArray(CreateConversationNodeUIController.AllAvatarsInvolvedText.text)[0]);
        }
        lines.Add(Path.GetFileNameWithoutExtension(Directory.GetFiles(Application.dataPath + "/Resources/Conversations/ConversationLines/")[0]));
        volumes.Add(Volumes.Normal);

        ScrollViewController.PopulateScrollViewItems(numberOfVoiceLineData);
        UpdateVoiceLineData();
    }

    public void Close(string status)
    {
        this.gameObject.SetActive(false);
        if (status == "Cancel")
        {
            return;
        }
        List<VoiceLineData> voiceLines = new List<VoiceLineData>();

        for(int i = 0; i < numberOfVoiceLineData; i++)
        {
            VoiceLineData voiceLineData = new VoiceLineData(lines[i], actors[i], 
                                                        ConversationPlayer.GetVoiceVolumes(volumes[i].ToString()));
            voiceLines.Add(voiceLineData);
        }

        ConversationDialogueData conversationDialogueData;

        if (bufferTimeInputField.text != "")
        {
            conversationDialogueData = new ConversationDialogueData(IsLoopingToggle.isOn, voiceLines, convoRules,  
                                                                   float.Parse(bufferTimeInputField.text));
        }
        else
        {
            conversationDialogueData = new ConversationDialogueData(IsLoopingToggle.isOn, voiceLines, convoRules);
        }

        if(currentState == States.ToVRARPlayer)
        {
            CreateConversationNodeUIController.SetConversationDialogueDataToPlayer(conversationDialogueData);
        }
        else if(currentState == States.ToEachOther)
        {
            CreateConversationNodeUIController.SetConversationDialogueDataToAvatars(conversationDialogueData);
        }
        ResetRules();
    }

    public int GetRuleCount()
    {
        return convoRules.ruleCounter;
    }

    public void SetDistanceRule(int min, int max, bool withinOrNot)
    {
        convoRules.ruleCounter += 1;
        convoRules.DistanceMinimum = min;
        convoRules.DistanceMaximum = max;
        convoRules.DistanceInOrOut = withinOrNot;
        
    }

    public void SetOrientationRule(int newRule)
    {
        convoRules.OrientationRules = newRule;
        convoRules.ruleCounter += 1;
    }

    public void SetIsFacingRule(int newRule)
    {
        convoRules.IsFacingRules = newRule;
        convoRules.ruleCounter += 1;

    }

    public void SetCombinationRule(List<int> newRule)
    {
        if (convoRules.CombinationRules == null)
        {
            convoRules.CombinationRules = new List<int>();
        }
        convoRules.CombinationRules = newRule;
        convoRules.ruleCounter += 1;
    }

    public void ResetRules()
    {
        if (convoRules.CombinationRules != null)
        {
            convoRules.CombinationRules.Clear();
        }
        convoRules.DistanceMinimum = 0;
        convoRules.DistanceMaximum = 0;
        convoRules.DistanceInOrOut = false;
        convoRules.OrientationRules = 0;
        convoRules.IsFacingRules = 0;
        convoRules.ruleCounter = 0;
    }

}
