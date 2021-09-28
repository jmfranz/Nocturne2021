using UnityEngine;

[System.Serializable]
public class MapNameToRoomID
{
    public string MapName;
    public int RoomID; // somewhere between 0 - n-1 (n = #rooms)

    public MapNameToRoomID(string mapName, int roomID)
    {
        MapName = mapName;
        RoomID = roomID;
    }
}
