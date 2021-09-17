using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Room
{
    public string Name; //unique identifier
    public enum Sizes {Small, Medium, Large}
    public Sizes Size;
    public enum EntrancePoints {One, Two, Many}
    // public EntrancePoints NumEntrancePoints;
    // public List<string> DirectlyConnectedRoomNames = new List<string>(); FUTURE WORK

    public List<MapNameToRoomID> MapNameToRoomIDs = new List<MapNameToRoomID>(); // using a list as dictionary serialization is complex

    public Room(string name, Sizes size, RoomController roomController)//, EntrancePoints numEntrancePoints, List<string> directlyConnectedRooms = null)
    {
        Name = name;
        Size = size;
        //NumEntrancePoints = numEntrancePoints;
        // if (directlyConnectedRooms != null) { DirectlyConnectedRoomNames = directlyConnectedRooms; }

        List<Map> maps = Stories.Instance.maps;
        List<int> roomIDs = roomController.CalculateRoomIDs(size.ToString()); // gets room id for each room

        for(int i = 0; i < maps.Count; i++)
        {
            MapNameToRoomIDs.Add(new MapNameToRoomID(maps[i].MapName, roomIDs[i]));
        }
    }

    public int GetRoomID(string mapName)
    {
        foreach(MapNameToRoomID mapNameToRoomID in MapNameToRoomIDs)
        {
            if(mapNameToRoomID.MapName == mapName)
            {
                return mapNameToRoomID.RoomID;
            }
        }

        return -9999; // error
    }

    public static Sizes GetSize(string size)
    {
        switch (size)
        {
            case "Small":
                return Sizes.Small;
            case "Medium":
                return Sizes.Medium;
            case "Large":
                return Sizes.Large;
            default:
                Debug.LogErrorFormat("ERROR: Size '{0}' is undefined", size);
                return Sizes.Small;
        }
    }
}
