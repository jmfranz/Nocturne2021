using System.Collections.Generic;

[System.Serializable]
public class Verticies
{
    public float MinX, MaxX, MinY, MaxY;

    public List<float> XVertex = new List<float>();
    public List<float> YVertex = new List<float>();

    public void AddVertex(float xPos, float yPos)
    {
        XVertex.Add(xPos);
        YVertex.Add(yPos);
    }

    public void SetRoomMinX(float minX)
    {
        MinX = minX;
    }

    public void SetRoomMaxX(float maxX)
    {
        MaxX = maxX;
    }

    public void SetRoomMinY(float minY)
    {
        MinY = minY;
    }

    public void SetRoomMaxY(float maxY)
    {
        MaxY = maxY;
    }
}
