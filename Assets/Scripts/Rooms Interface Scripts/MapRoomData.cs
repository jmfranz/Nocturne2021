using System.Collections.Generic;

[System.Serializable]
public class MapRoomData 
{
    public string MapName; //unique 

    public List<string> RoomCategory = new List<string>();

    public List<Verticies> VerticiesPerRoom = new List<Verticies>();

    public float minX, maxX, minY, maxY; // needed for conversion purposes
}
