using UnityEngine;
using TMPro;

public class RoomPropertiesUIController : MonoBehaviour
{
    public TMP_InputField NameInputField;
    public TMP_Dropdown SizeDropdown;
    public TMP_Dropdown EntrancePointsDropdown; // future work
    public string RoomsConnectedTo; // future work
    public GameObject NameNotUniqueWarningMessage;

    public ControlStandalone ControlStandalone;

    RoomController roomController;
    Stories stories;

    private void OnEnable()
    {
        stories = StandaloneSaveLoad.Instance.Load();
        roomController = stories.CurrentStory.RoomController;
        ResetFields();
    }

    void ResetFields()
    {
        NameInputField.text = "";
        SizeDropdown.value = 0;
        EntrancePointsDropdown.value = 0;
        RoomsConnectedTo = "";
        NameNotUniqueWarningMessage.SetActive(false);
    }

    public void SaveRoom()
    {
        string roomName = NameInputField.text;

        if (!roomController.IsRoomNameUnique(roomName) || roomName == "" || !Stories.Instance.IsUniqueAttributeName(roomName))
        {
            NameNotUniqueWarningMessage.SetActive(true);
            return;
        }

        Room room = new Room(
                        roomName,
                        Room.GetSize(SizeDropdown.options[SizeDropdown.value].text), 
                            roomController){ };
        roomController.AddRoom(room);

        AttributeSS newAttribtue = new AttributeSS(roomName);
        Stories.Instance.AddNewAttribute(newAttribtue);
        Stories.Instance.CurrentStory.SetRoomController(roomController);

        StandaloneSaveLoad.Instance.Save();
        ControlStandalone.GoToScreen("Rooms");
    }
}