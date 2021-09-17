using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoomsIDinImage : MonoBehaviour
{
    public GameObject IDMarker;

    public List<GameObject> tempMarkers = new List<GameObject>();

    RoomController roomController;


    void Start()
    {

        IDMarker.SetActive(false);
        StandaloneSaveLoad.Instance.Load();
        if(Stories.Instance.CurrentStory != null)
        {
            roomController = Stories.Instance.CurrentStory.RoomController;

            if(roomController._mapsRoomsData.Count == 0){
                roomController.ReadCSVRoomData();
                Stories.Instance.CurrentStory.SetRoomController(roomController);
                StandaloneSaveLoad.Instance.Save();
            }
        }
    }

    public void ShowMarkers(float imageWidth, float imageHeight)
    {
        ClearMarkers();
        Stories stories = StandaloneSaveLoad.Instance.Load();
        string currentMapName = stories.CurrentStory.MapSelected;
        RoomController roomController = stories.CurrentStory.RoomController;
        List<MapRoomData> mapRoomDatas = roomController._mapsRoomsData;
        
        for(int i = 0; i < mapRoomDatas.Count; i++)
        {
            MapRoomData currentMapRoomData = mapRoomDatas[i];
            if(currentMapRoomData.MapName == currentMapName)
            {
                // go through all the rooms
                for(int j = 0; j < roomController._rooms.Count; j++)
                {
                    Room room = roomController._rooms[j];
                    for(int k = 0; k < room.MapNameToRoomIDs.Count; k++)
                    {
                        MapNameToRoomID mapNameToRoomID = room.MapNameToRoomIDs[k];
                        if(mapNameToRoomID.MapName == currentMapName)
                        {
                            // need to show the ID on the map
                            ShowIDonMap(currentMapRoomData, mapNameToRoomID.RoomID, imageWidth, imageHeight);
                        }
                    }
                }
            }
        }
    }


    float x, y;
    // mapName, room ID - index of which vertices per room
    public void ShowIDonMap(MapRoomData currentMapRoomData, int roomID, float imageWidth, float imageHeight)
    {
        Verticies roomVerticies = currentMapRoomData.VerticiesPerRoom[roomID]; //verticies for the correct room

        Vector3 pos = IDMarker.GetComponent<RectTransform>().localPosition;

        IDMarker.SetActive(true);

        FindMidPointOfRoom(roomVerticies);

        // convert the x,y pos
        float convertedX = (((x - currentMapRoomData.minX) * (imageWidth)) / (currentMapRoomData.maxX - currentMapRoomData.minX)) - imageWidth/2f;
        float convertedY = -(((y - currentMapRoomData.minY) * (imageHeight)) / (currentMapRoomData.maxY - currentMapRoomData.minY)) + imageHeight/2f;  

        GameObject newMarker = Instantiate(IDMarker, new Vector3(convertedX, convertedY, pos.z), IDMarker.transform.rotation);
        newMarker.transform.SetParent(IDMarker.transform.parent.transform, false);

        newMarker.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = (roomID + 1).ToString();

        tempMarkers.Add(newMarker);

        IDMarker.SetActive(false);
    }

    public void ClearMarkers()
    {
        for(int i = 0; i < tempMarkers.Count; i++)
        {
            Destroy(tempMarkers[i]);
        }
    }

    public void FindMidPointOfRoom(Verticies roomVerticies)
    {
        float minX = float.PositiveInfinity, maxX = float.NegativeInfinity, minY = float.PositiveInfinity, maxY = float.NegativeInfinity;

        for (int i = 0; i < roomVerticies.XVertex.Count; i++)
        {
            float xCoordinate = roomVerticies.XVertex[i];
            float yCoordinate = roomVerticies.YVertex[i];
            if (xCoordinate < minX)
            {
                minX = xCoordinate;
            }
            if (xCoordinate > maxX)
            {
                maxX = xCoordinate;
            }
            if (yCoordinate < minY)
            {
                minY = yCoordinate;
            }
            if (yCoordinate > maxY)
            {
                maxY = yCoordinate;
            }
        }

        x = (minX + maxX) / 2f;
        y = (minY + maxY) / 2f;
    }
}
