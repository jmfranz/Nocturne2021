using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System;

[System.Serializable]
public class RoomController
{
    public List<Room> _rooms = new List<Room>();
    public List<MapRoomData> _mapsRoomsData = new List<MapRoomData>(); //for each map

    public List<Room> GetRoomsByMapName(string mapName)
    {
        List<Room> roomsInMap = new List<Room>();

        //TODO: Find rooms associated with a map using the dictionary associated by each room

        return roomsInMap;
    }

    public List<Room> GetRooms() { return _rooms; }

    public void AddRoom(Room room)
    {
        _rooms.Add(room);
    }

    public void DeleteRoom(int roomID, string mapName)
    {
        for(int i = 0; i < _rooms.Count; i++)
        {
            Room room = _rooms[i];
            for(int j = 0; j < room.MapNameToRoomIDs.Count; j++)
            {
                MapNameToRoomID mapNameToRoomID = room.MapNameToRoomIDs[j];
                if(mapNameToRoomID.MapName == mapName && roomID == mapNameToRoomID.RoomID)
                {
                    _rooms.Remove(room);
                }
            }
        }
    }

    public bool IsRoomNameUnique(string name)
    {
        foreach (Room room in _rooms)
        {
            if (room.Name == name)
            {
                return false;
            }
        }

        return true;
    }

    Room FindRoom(string roomName)
    {
        foreach (Room room in _rooms)
        {
            if (room.Name == roomName)
            {
                return room;
            }
        }

        return null;
    }

    public List<int> CalculateRoomIDs(string size)
    {
        string originalSize = size;
        List<Map> maps = Stories.Instance.maps;
        List<int> roomIDs = new List<int>();

        for(int i = 0; i < maps.Count; i++)
        {
            string mapName = maps[i].MapName;
            List<int> roomIDsAlreadyUsed = new List<int>();

            // Go through all rooms for that map and keep track of room IDs currently used
            foreach (Room room in _rooms)
            {
                roomIDsAlreadyUsed.Add(room.MapNameToRoomIDs[i].RoomID);
            }

            // Used greedy approach to find a room that has an unused room ID and fits the size property
            MapRoomData currentMapRoomData = _mapsRoomsData[i];

            bool roomIDSatisfied = false;
            while (!roomIDSatisfied)
            {
                // Number of items in room category are the number of rooms
                for (int j = 0; j < currentMapRoomData.RoomCategory.Count; j++)
                {
                    if (!roomIDsAlreadyUsed.Contains(j) && currentMapRoomData.RoomCategory[j] == size)
                    {
                        roomIDSatisfied = true;
                        roomIDs.Add(j);
                        break;
                    }
                }

                // small -> medium -> large
                // large -> medium -> small
                // medium -> large -> small
                // relax the size condition
                if (!roomIDSatisfied)
                {
                    if(size == "Small" || size == "large")
                    {
                        if(size == originalSize)
                        {
                            size = "Medium";
                        }
                        else if (size == "large" && originalSize != size)
                        {
                            size = "Small";
                        }
                    }
                    else // size == "Medium"
                    {
                        // if original size = medium or 
                        if(size == originalSize || originalSize == "Small")
                        {
                            size = "Large";
                        }
                        else
                        {
                            size = "Small";
                        }
                    }
                }
            }
        }

        return roomIDs;
    }

    public void ReadCSVRoomData()
    {
        StandaloneSaveLoad.Instance.Load();
        List<Map> maps = Stories.Instance.maps;
        string dataString;
        int indexID = 0;
        int indexArea = 0;
        int startIndexVerticies = 0;
        List<float> areas;

        for (int i = 0; i < maps.Count; i++)
        {
            areas = new List<float>();

            string mapname = maps[i].MapName;
            MapRoomData newMapRoomData = new MapRoomData();
            newMapRoomData.MapName = mapname;

            float minX=float.PositiveInfinity, maxX=float.NegativeInfinity, minY=float.PositiveInfinity, maxY=float.NegativeInfinity;
 
            string FilePath = Application.dataPath + "/Resources/Rooms/" + mapname + ".csv";
            StreamReader streamReader = new StreamReader(FilePath);

            // used to get the index of the columns of each data category of interest
            if ((dataString = streamReader.ReadLine()) != null)
            {
                string[] data_values = dataString.Split(',');

                for (int j = 0; j < data_values.Length; j++)
                {
                    if (data_values[j] == "id")
                    {
                        indexID = j;
                    }
                    else if (data_values[j] == "pixel")
                    {
                        indexArea = j;
                    }
                    else if(data_values[j] == "vertices(x;y)")
                    {
                        startIndexVerticies = j;
                        break;
                    }
                }
            }

            while ((dataString = streamReader.ReadLine()) != null)
            {
                Verticies verticies = new Verticies();

                string[] data_values = dataString.Split(',');               

                areas.Add(float.Parse(data_values[indexArea]));

                float minRoomX = float.PositiveInfinity, 
                    maxRoomX = float.NegativeInfinity, 
                    minRoomY = float.PositiveInfinity, 
                    maxRoomY = float.NegativeInfinity;

                for (int j = startIndexVerticies; j < data_values.Length; j++)
                {
                    string temp = data_values[j];
                    if (data_values[j] != "")
                    {
                        //parse vertex string for x and y coordinates (x;y)
                        string[] coordinates = data_values[j].Split(';');
                        float xCoordinate = float.Parse(coordinates[0]);
                        float yCoordinate = float.Parse(coordinates[1]);

                        if(xCoordinate < minRoomX)
                        {
                            minRoomX = xCoordinate;
                        }
                        if (xCoordinate > maxRoomX)
                        {
                            maxRoomX = xCoordinate;
                        }
                        if(yCoordinate < minRoomY)
                        {
                            minRoomY = yCoordinate;
                        }
                        if(yCoordinate > maxRoomY)
                        {
                            maxRoomY = yCoordinate;
                        }

                        verticies.AddVertex(xCoordinate, yCoordinate);
                    }
                }

                verticies.SetRoomMaxX(maxRoomX);
                verticies.SetRoomMinX(minRoomX);
                verticies.SetRoomMaxY(maxRoomY);
                verticies.SetRoomMinY(minRoomY);

                if (minRoomX < minX)
                {
                    minX = minRoomX;
                }
                if (maxRoomX > maxX)
                {
                    maxX = maxRoomX;
                }
                if (minRoomY < minY)
                {
                    minY = minRoomY;
                }
                if (maxRoomY > maxY)
                {
                    maxY = maxRoomY;
                }

                newMapRoomData.VerticiesPerRoom.Add(verticies);
            }

            CalculateAreaCategories(newMapRoomData, areas);
            newMapRoomData.minX = minX;
            newMapRoomData.minY = minY;
            newMapRoomData.maxX = maxX;
            newMapRoomData.maxY = maxY;

            _mapsRoomsData.Add(newMapRoomData);
        }

        StandaloneSaveLoad.Instance.Save();
    }

    // Take the <float> areas and translate them into "small" (bottom 33% of areas), "medium" (33-66%), "large" (top 33%)
    public void CalculateAreaCategories(MapRoomData mapRoomData, List<float> areas)
    {
        float[] areasSorted = areas.ToArray();
        Array.Sort(areasSorted);
        
        int count = areas.Count;
        for(int i = 0; i < count; i++)
        {
            int lowerBoundIndex = count / 3;
            int upperBoundIndex = 2 * count / 3;

            int index = Array.IndexOf(areasSorted, areas.ToArray()[i]);

            if(index < lowerBoundIndex)
            {
                mapRoomData.RoomCategory.Add("Small");
            }
            else if (index < upperBoundIndex)
            {
                mapRoomData.RoomCategory.Add("Medium");
            }
            else
            {
                mapRoomData.RoomCategory.Add("Large");
            }
        }
    }

}
