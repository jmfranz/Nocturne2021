using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using System;
using System.IO;

public class ViewRoomsUIController : MonoBehaviour
{
    public GameObject FloorplanImagePlaceHolder;
    public TMP_Dropdown MapsDropdown;
    
    string mapName = "";

    float height, width;

    public ScrollViewController ScrollViewController;
    public RoomsIDinImage RoomsIDinImage;

    private void OnEnable()
    {
        ChangeMap();
    }

    void PopulateRoomsScrollView()
    {
        Stories stories = StandaloneSaveLoad.Instance.Load();

        RoomController roomController = stories.CurrentStory.RoomController;

        List<Room> rooms = roomController.GetRooms();

        ScrollViewController.PopulateScrollViewItems(rooms.Count);

        List<GameObject> scrollviewGameObjects = ScrollViewController.GetScrollViewGameObjects();

        for (int i = 0; i < scrollviewGameObjects.Count; i++)
        {
            TextMeshProUGUI name = scrollviewGameObjects[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI associatedWithRoom = scrollviewGameObjects[i].transform.GetChild(2).GetComponent<TextMeshProUGUI>();

            name.text = rooms[i].Name;
            associatedWithRoom.text = (rooms[i].GetRoomID(mapName)+1).ToString();
        }
    }

    void Update()
    {
        //Current story could have changed
        if (mapName != GameState.Instance.GetCurrentStoryData().MapSelected)
        {
            mapName = GameState.Instance.GetCurrentStoryData().MapSelected;

            //set value of map in dropdown
            List<TMP_Dropdown.OptionData> options = MapsDropdown.options;
            for (int i = 0; i < options.Count; i++)
            {
                if (options[i].text == mapName)
                {
                    MapsDropdown.value = i;
                }
            }

            UpdateUI();
        }
    }

    public void DeleteRoom(GameObject roomGameObject)
    {
        RoomController roomController = Stories.Instance.CurrentStory.RoomController;
        int roomID = int.Parse(roomGameObject.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text) - 1;

        roomController.DeleteRoom(roomID, GameState.Instance.GetCurrentStoryData().MapSelected);
        string roomName = roomGameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text;

        List<StoryElement> storyElements = Stories.Instance.CurrentStory.GetStoryElements();
        for (int i = 0; i < storyElements.Count; i++)
        {
            if (storyElements[i].Attributes.Contains(roomName))
            {
                storyElements[i].RemoveAttribute(roomName);
            }
        }

        List<ConversationNodeData> conversationNodeDatas = Stories.Instance.CurrentStory.GetConversationNodeDatas();
        for (int i = 0; i < conversationNodeDatas.Count; i++)
        {
            if (conversationNodeDatas[i].Attributes.Contains(roomName))
            {
                conversationNodeDatas[i].RemoveAttribute(roomName);
            }
        }

        Stories.Instance.DeleteAttribute(roomName);

        StandaloneSaveLoad.Instance.Save();
        ChangeMap();
        UpdateUI();
    }

    void UpdateUI()
    {
        FloorplanImagePlaceHolder.GetComponent<Image>().sprite = Resources.Load<Sprite>("Maps/FloorplanImages/" + mapName + "Floorplan");

        // scale the images width and height
        Texture2D tmpTexture = new Texture2D(1, 1);
        byte[] tmpBytes = File.ReadAllBytes(Application.dataPath + "/Resources/Maps/FloorplanImages/" + mapName + "Floorplan.png");
        tmpTexture.LoadImage(tmpBytes);

        height = tmpTexture.height / 4.0f;
        width = tmpTexture.width / 4.0f;
        FloorplanImagePlaceHolder.GetComponent<RectTransform>().sizeDelta = new Vector2(tmpTexture.width / 4.0f, tmpTexture.height / 4.0f);
        FloorplanImagePlaceHolder.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 180, 180);

        PopulateRoomsScrollView();
    }

    //Called when the dropdown option has changed value
    public void ChangeMap()
    {
        mapName = MapsDropdown.options[MapsDropdown.value].text;
        GameState.Instance.GetCurrentStoryData().MapSelected = mapName;
        StandaloneSaveLoad.Instance.Save();
        UpdateUI();
        RoomsIDinImage.ShowMarkers(width*4f/5f, height*4f/5f); // 1/5 of the image is a border
    }

}
