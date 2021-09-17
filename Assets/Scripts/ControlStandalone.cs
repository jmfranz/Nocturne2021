 /*
 * Author: Abbey Singh
 * This script will control switching screens functionality for the standalone application.
 */

using UnityEngine;
using UnityEngine.UI;

public class ControlStandalone : MonoBehaviour
{
    public GameObject[] Screens;
    public string CurrentScreenName;

    public StoryElementsController ManageGroupsStoryElementController;
    public StoryElementsController AddStoryElementsController;
    public DotNavigationController DotNavigationControllerLevel1;
    public DotNavigationController DotNavigationControllerLevel2;
    public AddBasicInfoToStoryManager AddBasicInfoToStoryManager;
    public ViewStoryElementsController ViewStoryElementsController;
    public PlacementRulesController PlacementRulesController;
    public UserInput UserInput;

    public GameObject AvatarScreenScrollBarVertical;

    void Start()
    {
        SetAllScreensToINActiveBut("TitlePage");
        CurrentScreenName = "TitlePage";
    }

    public void GoToScreen(string scene)
    {
        bool changeScene = SetAllScreensToINActiveBut(scene);

        if (changeScene)
        {
            CurrentScreenName = scene;
        }
    }

    public void OnQuit()
    {
        //Using unity editor, so simply stop playing the scene
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    //Set all screen GameObjects to inactive except for the one passed in as 'name'
    bool SetAllScreensToINActiveBut(string name)
    {
        if (CurrentScreenName == "AddBasicInfoToStory" && (name == "ViewStoryElementsScreen"  || name == "PlacementRules" || name == "ViewSecondaryStoryElementsScreen" || 
                                                        name == "Rooms" || name == "GlobalEvents"))
        {
            bool validInfo = AddBasicInfoToStoryManager.AddBasicInfo();

            if (!validInfo)
            {
                DotNavigationControllerLevel2.SetInitialDotsPosition(0);
                return false;
            }
        }

        if(name == "AddBasicInfoToStory" && GameState.Instance.GetMode())
        {
            AddBasicInfoToStoryManager.ClearInputs();
        }

        for (int i = 0; i < Screens.Length; i++)
        {
            if (name == Screens[i].name)
            {
                Screens[i].SetActive(true);
            }
            else
            {
                // If one screen needs to be active while other screens are active
                // Screens[i].name should be equal to the screen that should be active while others are active
                // name are the screens used while the other is active
                if ((name == "ViewStoryElementsScreen" || name == "SelectAudioFromComputer" || name == "CustomizeStoryElement")
                    && Screens[i].name == "StoryElementsUIController")
                {
                    Screens[i].SetActive(true);
                }
                else if ((name == "ViewStoriesScreen" || name == "AddMapScreen")
                    && Screens[i].name == "DotNavigationLevel1")
                {
                    Screens[i].SetActive(true);
                }
                else if ((name == "ViewStoryElementsScreen" || name == "AddBasicInfoToStory" || name == "PlacementRules" || name == "ViewSecondaryStoryElementsScreen"
                        || name == "Rooms" || name == "GlobalEvents")
                        && Screens[i].name == "DotNavigationLevel2")
                {
                    Screens[i].SetActive(true);
                }
                else
                {
                    Screens[i].SetActive(false);
                }
            }
        }

        if (CurrentScreenName == "ViewStoryElementsScreen" || CurrentScreenName == "PlacementRules" || CurrentScreenName == "ViewSecondaryStoryElementsScreen"
                                                            || CurrentScreenName == "Rooms" || CurrentScreenName == "GlobalEvents"
            && name == "AddBasicInfoToStory")
        {
            AddBasicInfoToStoryManager.SetInputs();
        }

        if (CurrentScreenName == "ViewStoryElementsScreen")
        {
            ViewStoryElementsController.ClearStoryElements();
        }

        //Current map data is none
        //Reset createMode to true (default)
        if (name == "ViewStoriesScreen")
        {
            GameState.Instance.NewStoryData();
            GameState.Instance.SetMode(true);

            GameState.Instance.NewStoryElement();
            GameState.Instance.SetModeForStoryElement(true);

            DotNavigationControllerLevel1.SetInitialDotsPosition(0);
        }
        
        if(name == "AddBasicInfoToStory")
        {
            DotNavigationControllerLevel2.SetInitialDotsPosition(0);
        }

        if (name == "ViewStoryElementsScreen")
        {
            ManageGroupsStoryElementController.SetMenuIn();
            AddStoryElementsController.SetMenuIn();
            DotNavigationControllerLevel2.SetInitialDotsPosition(1);
            ViewStoryElementsController.PopulateViewStoryElements();
        }

        if(name == "PlacementRules")
        {
            PlacementRulesController.ClearStoryElementItems();
            PlacementRulesController.PopulateStoryElementsGroups();

            if(CurrentScreenName != "AddAttributes")
            {
                UserInput.SetInputs();
            }
        }

        if(name == "SelectAvatar")
        {

            //Reset Scroll Bar
            AvatarScreenScrollBarVertical.GetComponent<Scrollbar>().value = 1;
        }

        return true;
    }
}
