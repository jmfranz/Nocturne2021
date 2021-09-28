/*
 * Author: Abbey Singh
 * This script will write to a json file in the format that Jake's work needs
 */

using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class StoryToRulesInterface : MonoBehaviour
{
    string directoryPath;

    //singleton
    private static StoryToRulesInterface _instance;
    public static StoryToRulesInterface Instance
    {
        get
        {
            if (_instance == null)
            {
                var singletonObject = GameObject.Find("GameManager");
                _instance = singletonObject.AddComponent<StoryToRulesInterface>();
            }
            return _instance;
        }
    }

    void Start()
    {
        PopulateRules();
    }

    // Start is called before the first frame update
    public void PopulateRules()
    {
        directoryPath = Application.dataPath;

        Stories stories = EditorSaveLoadUI.Instance.Load();
        if (stories != null)
        {
            List<string> currentStories = new List<string>();

            for (int j = 0; j < stories.GetStories().Count; j++)
            {
                StoryData story = stories.GetStories()[j];

                ListOfRules rulesList = new ListOfRules();

                List<string> storyElementNamesNotToAdd = new List<string>();

                for (int i = 0; i < story.GetConversationNodeDatas().Count; i++)
                {

                    //Save as json file to be used by Jake's work
                    //Write the text to the database file
                    //Make sure last write time is set to current time
                    RulesFormat rulesFormat = new RulesFormat();
                    rulesFormat.SetRules(story.GetConversationNodeDatas()[i], story);

                    foreach(string initialAvatarName in story.GetConversationNodeDatas()[i].InitialPlacedAvatars)
                    {
                        storyElementNamesNotToAdd.Add(initialAvatarName);
                    }

                    rulesList.AddRules(rulesFormat);
                }

                for (int i = 0; i < story.GetStoryElements().Count; i++)
                {

                    if (storyElementNamesNotToAdd.Contains(story.GetStoryElements()[i].Name))
                    {
                        continue;
                    }

                    //Save as json file to be used by Jake's work
                    //Write the text to the database file
                    //Make sure last write time is set to current time
                    RulesFormat rulesFormat = new RulesFormat();
                    rulesFormat.SetRules(story.GetStoryElements()[i], story);
                    rulesList.AddRules(rulesFormat);
                }

                string data = JsonUtility.ToJson(rulesList);

                currentStories.Add(story.Title + "-" + story.Author);

                File.WriteAllText(directoryPath + "/Rules/" + story.Title + "-" + story.Author + ".json", data);
            }

            //Check if any story was deleted
            var info = new DirectoryInfo(directoryPath + "/Rules/");
            var fileInfo = info.GetFiles();

            foreach (var file in fileInfo)
            {
                int last = file.ToString().LastIndexOf("Rules\\") + 6; //length of the word 'Rules/' is 6
                string fileName = file.ToString().Substring(last, file.ToString().Length - last);

                //remove file extension
                int fileExtPos = fileName.LastIndexOf(".");
                if (fileExtPos >= 0)
                    fileName = fileName.Substring(0, fileExtPos);

                //We must delete file from the 'Rules' folder if it is not in current stories
                if (!currentStories.Contains(fileName) && !fileName.Contains(".json"))
                {
                    File.Delete(directoryPath + "/Rules/" + fileName + ".json");
                    File.Delete(directoryPath + "/Rules/" + fileName + ".json.meta");
                }

            }

            string json = JsonUtility.ToJson(Stories.Instance);
        }
    }
}
