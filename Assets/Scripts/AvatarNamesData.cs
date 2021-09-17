using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AvatarNamesData : MonoBehaviour
{
    public ScrollViewController ScrollViewController;
    public ConversationPopupDataController ConversationPopupDataController;
    public CreateConversationNodeUIController CreateConversationNodeUIController;

    int size;
    List<GameObject> scrollviewGameObjects;

    public void DisplayAvatarNames(string name, bool all) //all is true if it is all avatars, false if it is initial avatars
    {
        StandaloneSaveLoad.Instance.Load();
        List<StoryElement> avatarsList = new List<StoryElement>();

        //find avatars in list of primary story elements
        foreach (StoryElement storyElement in GameState.Instance.GetCurrentStoryData().GetStoryElements())
        {
            if (storyElement.Reference.Contains("Avatars") && storyElement.ShouldPlace)
            {
                avatarsList.Add(storyElement);
            }
            else if (all && storyElement.Reference.Contains("Avatars"))
            {
                avatarsList.Add(storyElement);
            }
        }

        size = avatarsList.Count;
        ScrollViewController.PopulateScrollViewItems(size);
        scrollviewGameObjects = ScrollViewController.GetScrollViewGameObjects();

        string text = "";

       switch (ConversationPopupDataController.GetCurrentPopupState())
        {
            case ConversationPopupDataController.PopupStates.InitialAvatars:
                text = CreateConversationNodeUIController.InitialAvatarsPlacedText.GetComponent<TextMeshProUGUI>().text;
                break;
            case ConversationPopupDataController.PopupStates.AllAvatars:
                text =  CreateConversationNodeUIController.AllAvatarsInvolvedText.GetComponent<TextMeshProUGUI>().text;
                break;
            default:
                Debug.LogErrorFormat("ERROR: Popup in undefined state '{0}'", ConversationPopupDataController.GetCurrentPopupState());
                break;
        }

        if (ConversationPopupDataController.GetCurrentPopupState() == ConversationPopupDataController.PopupStates.InitialAvatars)
        {
            
        }
        else if (ConversationPopupDataController.GetCurrentPopupState() == ConversationPopupDataController.PopupStates.AllAvatars)
        {
            text = CreateConversationNodeUIController.AllAvatarsInvolvedText.GetComponent<TextMeshProUGUI>().text;
        }

        string[] names = DataFormatHandler.Instance.ConvertCSVStringToStringArray(text);

        for (int i = 0; i < size; i++)
        {
            string avatarName = avatarsList[i].Name;
            GameObject scrollviewGameObject = scrollviewGameObjects[i];

            Transform toggle = scrollviewGameObject.transform.GetChild(0);
            Transform button = scrollviewGameObject.transform.GetChild(1);
            button.gameObject.SetActive(false);
            toggle.gameObject.SetActive(true);

            if (names.Contains(avatarName))
            {
                toggle.GetComponent<Toggle>().isOn = true;
            }
            else
            {
                toggle.GetComponent<Toggle>().isOn = false;
            }

            Transform label = toggle.GetChild(1);
            label.GetComponent<TextMeshProUGUI>().text = avatarName;

        }
    }

    public string GetListAvatarsWanted()
    {
        string avatarList = "";
        for (int i = 0; i < size; i++)
        {
            GameObject scrollviewGameObject = scrollviewGameObjects[i];

            Transform toggle = scrollviewGameObject.transform.GetChild(0);
            if (toggle.GetComponent<Toggle>().isOn)
            {
                Transform label = toggle.GetChild(1);
                string avatarName = label.GetComponent<TextMeshProUGUI>().text;

                if (avatarList == "")
                {
                    avatarList += avatarName;
                }
                else
                {
                    avatarList += ", " + avatarName;
                }
            }
        }

        if (ConversationPopupDataController.GetCurrentPopupState() == ConversationPopupDataController.PopupStates.InitialAvatars)
        {
            // also need to add the initial avatars to the all avatars list
            string currentAllAvatarsText = CreateConversationNodeUIController.AllAvatarsInvolvedText.text;
            string[] currentAllAvatarsNames = currentAllAvatarsText.Split(',');
            string[] currentInitialAvatarNames = avatarList.Split(',');

            for (int i = 0; i < currentAllAvatarsNames.Length; i++)
            {
                currentAllAvatarsNames[i] = currentAllAvatarsNames[i].Trim();
            }

            for (int i = 0; i < currentInitialAvatarNames.Length; i++)
            {
                currentInitialAvatarNames[i] = currentInitialAvatarNames[i].Trim();
                bool isFound = false;

                foreach (string allAvatarName in currentAllAvatarsNames)
                {
                    if (allAvatarName == currentInitialAvatarNames[i])
                    {
                        isFound = true;
                        break;
                    }
                }

                if (!isFound)
                {
                    if (currentAllAvatarsText == "")
                    {
                        currentAllAvatarsText += currentInitialAvatarNames[i];
                    }
                    else
                    {
                        currentAllAvatarsText += ", " + currentInitialAvatarNames[i];
                    }
                }
            }
            CreateConversationNodeUIController.SetAllAvatarsInvolvedText(currentAllAvatarsText);
        }

        if (ConversationPopupDataController.GetCurrentPopupState() == ConversationPopupDataController.PopupStates.AllAvatars)
        {
            // Removing one from all should remove it from initial
            string currentInitialAvatarText = CreateConversationNodeUIController.InitialAvatarsPlacedText.text;
            string[] currentAllAvatarsNames = avatarList.Split(',');
            List<string> currentInitialAvatarNames = currentInitialAvatarText.Split(',').ToList();

            for (int i = 0; i < currentAllAvatarsNames.Length; i++)
            {
                currentAllAvatarsNames[i] = currentAllAvatarsNames[i].Trim();
            }

            for (int i = 0; i < currentInitialAvatarNames.Count; i++)
            {
                currentInitialAvatarNames[i] = currentInitialAvatarNames[i].Trim();
                bool isFound = false;

                foreach (string allAvatarName in currentAllAvatarsNames)
                {
                    if (allAvatarName == currentInitialAvatarNames[i])
                    {
                        isFound = true;
                        break;
                    }
                }

                if (!isFound)
                {
                    currentInitialAvatarNames.RemoveAt(i);
                    i--;
                }
            }

            currentInitialAvatarText = "";
            foreach (string initialAvatarName in currentInitialAvatarNames)
            {
                if (currentInitialAvatarText == "")
                {
                    currentInitialAvatarText += initialAvatarName;
                }
                else
                {
                    currentInitialAvatarText += ", " + initialAvatarName;
                }
            }

            CreateConversationNodeUIController.SetInitialAvatarsPlacedText(currentInitialAvatarText);

        }

        return avatarList;
    }
}
