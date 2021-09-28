using TMPro;
using UnityEngine;

public class ConversationPopupDataController : MonoBehaviour
{
    public enum PopupStates {InitialAvatars, AllAvatars, BackgroundAudio};
    PopupStates currentState;

    public CreateConversationNodeUIController CreateConversationNodeUIController;
    public PopupController PopupController;
    public ScrollViewController ScrollViewController;
    public BackgroundAudioData BackgroundAudioData;
    public AvatarNamesData AvatarNamesData;

    private void OnEnable()
    {
        DisplayPopupData();
    }

    public void DisplayPopupData()
    {
        string name = PopupController.GetTitleText();

        if (name.ToLower().Contains("initial"))
        {
            currentState = PopupStates.InitialAvatars;
            AvatarNamesData.DisplayAvatarNames(name, false);
        }
        else if (name.ToLower().Contains("all"))
        {
            currentState = PopupStates.AllAvatars;
            AvatarNamesData.DisplayAvatarNames(name, true);
        }
        else if (name.ToLower().Contains("background"))
        {
            currentState = PopupStates.BackgroundAudio;
            BackgroundAudioData.DisplayBackgroundAudio();
        }
    }

    public PopupStates GetCurrentPopupState()
    {
        return currentState;
    }

    public void SaveData(TextMeshProUGUI objectToSave)
    {
        if (currentState == PopupStates.InitialAvatars)
        {
            CreateConversationNodeUIController.SetInitialAvatarsPlacedText(AvatarNamesData.GetListAvatarsWanted());
        }
        else if (currentState == PopupStates.AllAvatars)
        {
            CreateConversationNodeUIController.SetAllAvatarsInvolvedText(AvatarNamesData.GetListAvatarsWanted());
        }
        else if(currentState == PopupStates.BackgroundAudio)
        {
            CreateConversationNodeUIController.SetBackgroundAudioText(objectToSave.text);
        }
    } 
}
