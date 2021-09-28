using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.UI;

public class CreateConversationNodeUIController : MonoBehaviour
{
    public TMP_InputField NameInputField;
    public TMP_Dropdown PlacementTypeDropdownField;
    public TMP_Dropdown FormationTypeDropdownField;
    public TextMeshProUGUI InitialAvatarsPlacedText;
    public TextMeshProUGUI AllAvatarsInvolvedText;
    public TextMeshProUGUI BackgroundAudioText;
    public GameObject AvatarsRequiredForDialogueText;
    public Button AvatarsTalkingToVRARPlayerButton;
    public Button AvatarsTalkingToEachOtherButton;
    public TextMeshProUGUI ConversationDialoguePlayer;
    public TextMeshProUGUI ConverstionDialogueActors;
    public GameObject Warning;

    //min and max dropdowns for proximity
    public int proximityMinInput;
    public int proximityMaxInput;


    public GameObject Popup;
    public GameObject PopupTitle;
    public GameObject ConversationDialogueScreen;

    public PopupController ConversationAvatarsPopup;

    ConversationDialogueData ConversationDialogueDataToPlayer = null;
    ConversationDialogueData ConversationDialogueDataToAvatars = null;

    public ControlStandalone ControlStandalone;
    public ConversationDialogueUIController ConversationDialogueUIController;

    // The ability to edit is future work
    public enum States { Create }
    States UIstate;
    static string currentConversationNodeName;

    private void Start()
    {
        UIstate = States.Create;

       proximityMinInput = 0;
       proximityMaxInput = 1;
    }

    public void GotoConversationDialogueScreen(GameObject gameObjectSelected)
    {
        ConversationDialogueScreen.SetActive(true);
        string name = gameObjectSelected.name;

        if (name.Contains("AR"))
        {
            ConversationDialogueUIController.SetDescription("for avatars talking to VR/AR player");
            ConversationDialogueUIController.currentState = ConversationDialogueUIController.States.ToVRARPlayer;
        }
        else if (name.Contains("Each"))
        {
            ConversationDialogueUIController.SetDescription("for avatars talking to each other");
            ConversationDialogueUIController.currentState = ConversationDialogueUIController.States.ToEachOther;
        }
    }

    public void SetConversationDialogueDataToPlayer(ConversationDialogueData conversationDialogueData)
    {
        AvatarsTalkingToVRARPlayerButton.interactable = false;
        ConversationDialogueDataToPlayer = conversationDialogueData;
        ConversationDialoguePlayer.gameObject.SetActive(true);
        ConversationDialoguePlayer.text = "added";
    }

    public void SetConversationDialogueDataToAvatars(ConversationDialogueData conversationDialogueData)
    {
        AvatarsTalkingToEachOtherButton.interactable = false;
        ConversationDialogueDataToAvatars = conversationDialogueData;
        ConverstionDialogueActors.gameObject.SetActive(true);
        ConverstionDialogueActors.text = "added";
    }

    public void RemoveConversationDialogueDataToPlayer()
    {
        ConversationDialogueDataToPlayer = null;
        ConversationDialoguePlayer.gameObject.SetActive(false);
    }

    public void RemoveConversationDialogueDataToAvatars()
    {
        ConversationDialogueDataToAvatars = null;
        ConverstionDialogueActors.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        Warning.SetActive(false);

        if (UIstate == States.Create)
        {
            ResetFields();
        }

        ConversationDialogueDataToPlayer = null;
        ConversationDialogueDataToAvatars = null;
    }

    public void SetState(States currentState)
    {
        UIstate = currentState;
    }

    public void SetState(States currentState, string conversationNodeName)
    {
        UIstate = currentState;
        currentConversationNodeName = conversationNodeName;
    }

    void ResetFields()
    {
        NameInputField.GetComponent<TMP_InputField>().text = "";
        PlacementTypeDropdownField.GetComponent<TMP_Dropdown>().value = 1;
        InitialAvatarsPlacedText.text = "";
        AllAvatarsInvolvedText.text = "";
        BackgroundAudioText.text = "";
        AvatarsTalkingToEachOtherButton.interactable = false;
        AvatarsTalkingToVRARPlayerButton.interactable = false;
        AvatarsRequiredForDialogueText.SetActive(true);
        ConverstionDialogueActors.gameObject.SetActive(false);
        ConversationDialoguePlayer.gameObject.SetActive(false);
    }

    public void SetInitialAvatarsPlacedText(string text)
    {
        InitialAvatarsPlacedText.text = text;
    }

    public void SetAllAvatarsInvolvedText(string text)
    {
        AllAvatarsInvolvedText.text = text;

        if(text == "")
        {
            AvatarsTalkingToEachOtherButton.interactable = false;
            AvatarsTalkingToVRARPlayerButton.interactable = false;
            RemoveConversationDialogueDataToAvatars();
            RemoveConversationDialogueDataToPlayer();
            AvatarsRequiredForDialogueText.SetActive(true);
        }
        else
        {
            AvatarsTalkingToEachOtherButton.interactable = true;
            AvatarsTalkingToVRARPlayerButton.interactable = true;
            AvatarsRequiredForDialogueText.SetActive(false);
        }
    }

    public void SetBackgroundAudioText(string text)
    {
        BackgroundAudioText.text = text;
    }


    public void SaveConversationNode()
    {
        ConversationNodeData conversationNodeDataToSave = new ConversationNodeData
        (
            NameInputField.GetComponent<TMP_InputField>().text,
            GetPlacementType(PlacementTypeDropdownField.options[PlacementTypeDropdownField.value].text),
            GetFormationType(FormationTypeDropdownField.options[FormationTypeDropdownField.value].text),
            new List<string> (DataFormatHandler.Instance.ConvertCSVStringToStringArray(InitialAvatarsPlacedText.text)),
            new List<string> (DataFormatHandler.Instance.ConvertCSVStringToStringArray(AllAvatarsInvolvedText.text)),
            BackgroundAudioText.text,
            ConversationDialogueDataToPlayer,
            ConversationDialogueDataToAvatars
        );

        bool uniqueConversation = true;
        string conversationName = NameInputField.GetComponent<TMP_InputField>().text;
        if (conversationName == "")
        {
            uniqueConversation = false;
        }

        if (InitialAvatarsPlacedText.text != "")
        {
            uniqueConversation = true;
            string[] initialAvatarsPlacedNames = DataFormatHandler.Instance.ConvertCSVStringToStringArray(InitialAvatarsPlacedText.text);
            StoryData storyData = GameState.Instance.GetCurrentStoryData();
            foreach (string name in initialAvatarsPlacedNames)
            {
                StoryElement avatarStoryElement = storyData.FindStoryElement(name);
                avatarStoryElement.ShouldPlace = false;
            }
        }


        List<ConversationNodeData> conversationNodeDataList = GameState.Instance.GetCurrentStoryData().GetConversationNodeDatas();
        foreach(ConversationNodeData conversationNodeData in conversationNodeDataList)
        {
            if(conversationNodeData.Title == conversationNodeDataToSave.Title)
            {
                uniqueConversation = false;
                break;
            }
        }

        if (uniqueConversation && States.Create == UIstate)
        {
            conversationNodeDataList.Add(conversationNodeDataToSave);
        }
        else if (!uniqueConversation && States.Create == UIstate)
        {
            Warning.SetActive(true);
            return;
        }

        ControlStandalone.GoToScreen("ViewSecondaryStoryElementsScreen");
        StandaloneSaveLoad.Instance.Save();
    }

    ConversationNodeData.ConversationPlacementTypes GetPlacementType(string conversationType)
    {
        switch (conversationType)
        {
            case "Intimate":
                return ConversationNodeData.ConversationPlacementTypes.Intimate;
            case "Personal":
                return ConversationNodeData.ConversationPlacementTypes.Personal;
            case "Social":
                return ConversationNodeData.ConversationPlacementTypes.Social;
            default:
                Debug.LogErrorFormat("ERROR: Conversation Type '{0}' is not defined", conversationType);
                return ConversationNodeData.ConversationPlacementTypes.Personal;
        }
    }

    ConversationNodeData.ConversationFormationTypes GetFormationType(string formationType)
    {
        switch (formationType)
        {
            case "Circle":
                return ConversationNodeData.ConversationFormationTypes.Circle;
            case "SemiCircle":
                return ConversationNodeData.ConversationFormationTypes.SemiCircle;
            case "Line":
                return ConversationNodeData.ConversationFormationTypes.Line;
            default:
                Debug.LogErrorFormat("ERROR: Formation Type '{0}' is not defined", formationType);
                return ConversationNodeData.ConversationFormationTypes.Circle;
        }
    }
}
