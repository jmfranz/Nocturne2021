using System.Collections.Generic;
using UnityEngine;

public class PointsInRoom
{ 
    public string mapName;
    public List<RoomCoordinates> RoomCoordinates = new List<RoomCoordinates>();

    public void FindPointsInRoomForMap(string mapName, List<SpaceSyntaxAttributesPoint> pointsList)
    {
        RoomController roomController = Stories.Instance.CurrentStory.RoomController;
        string mapSelected = Stories.Instance.CurrentStory.MapSelected;

        for (int i = 0; i < roomController._mapsRoomsData.Count; i++)
        {
            MapRoomData currentMapRoomData = roomController._mapsRoomsData[i];

            if (currentMapRoomData.MapName == mapSelected)
            {
                for (int j = 0; j < currentMapRoomData.VerticiesPerRoom.Count; j++)
                {
                    RoomCoordinates roomCoordinates = new RoomCoordinates();

                    Verticies roomVertexList = currentMapRoomData.VerticiesPerRoom[j];

                    // refine points list to points only in here
                    int size = pointsList.Count;
                    for (int k = 0; k < size; k++)
                    {
                        bool pointInRoom = CheckIfPointInARoom.CheckIfPointIsInRoom(pointsList[k], roomVertexList, currentMapRoomData);

                        //pointsList.Remove(pointsList[k]); // remove the point as it should not be in any other room

                        if (pointInRoom)
                        {
                            roomCoordinates.PointsInRoom.Add(pointsList[k]);
                        }
                    }

                    //Verify correctness of room coordinates - there should be none with 0 vertices.
                    if(roomCoordinates.PointsInRoom.Count == 0)
                    {
                        Debug.LogWarningFormat("Map '{0}' Room index '{1}' missing vertices. All rooms must have at least some vertices to be valid",currentMapRoomData.MapName, j);
                    }

                    RoomCoordinates.Add(roomCoordinates);
                }

                break;
            }
        }
    }

    public List<SpaceSyntaxAttributesPoint> GetRoomCoordinatesFor(int roomID)
    {
        return RoomCoordinates[roomID].PointsInRoom;
    }
}

