using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class BackgroundAudioData : MonoBehaviour
{
    public ScrollViewController ScrollViewController;

    public void DisplayBackgroundAudio()
    {
        string[] backgroundAudioNames = Directory.GetFiles(Application.dataPath + "/Resources/Conversations/BackgroundAudio/");
        int size = backgroundAudioNames.Length; 

        ScrollViewController.PopulateScrollViewItems(size/2); // accounts for the .meta files
        List<GameObject> scrollviewGameObjects = ScrollViewController.GetScrollViewGameObjects();

        for (int i = 0; i < size; i++)
        {
            string audioFileName = Path.GetFileName(backgroundAudioNames[i]);
            if (audioFileName.Contains(".meta"))
            {
                break;
            }

            GameObject scrollviewGameObject = scrollviewGameObjects[i];

            Transform toggle = scrollviewGameObject.transform.GetChild(0);
            toggle.gameObject.SetActive(false);
            Transform buttonBackground = scrollviewGameObject.transform.GetChild(1);
            buttonBackground.gameObject.SetActive(true);

            buttonBackground.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = audioFileName;
        }
    }
}
