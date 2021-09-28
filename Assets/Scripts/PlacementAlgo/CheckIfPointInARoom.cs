using System;
using UnityEngine;

public class CheckIfPointInARoom : MonoBehaviour
{
    //Singleton
    private static CheckIfPointInARoom _instance;
    public static CheckIfPointInARoom Instance
    {
        get
        {
            if (_instance == null)
            {
                var singletonObject = GameObject.Find("Game Handler");
                _instance = singletonObject.AddComponent<CheckIfPointInARoom>();
            }
            return _instance;
        }
    }


    // adapted from: https://wiki.unity3d.com/index.php/PolyContainsPoint and http://www.eecs.umich.edu/courses/eecs380/HANDOUTS/PROJ2/InsidePoly.html
    // return true if point inside, ow return false 
    public static bool CheckIfPointIsInRoom(SpaceSyntaxAttributesPoint point, Verticies verticies, MapRoomData mapRoomData)
    {
        var j = verticies.XVertex.Count - 1;
        var inside = false;

        // min, max of range verticies need to be converted to
        string mapName = GameState.Instance.GetCurrentStoryData().MapSelected;
        Map currentMap = Stories.Instance.GetMap(mapName);
        float modelWidth = currentMap.MapWidth;
        float modelHeight = currentMap.MapHeight;

        //float minX = verticies.MinX, maxX = verticies.MaxX, minY = verticies.MinY, maxY = verticies.MaxY;
        float minX = mapRoomData.minX, maxX = mapRoomData.maxX, minY = mapRoomData.minY, maxY = mapRoomData.maxY;

        float minXTest = SpaceSyntaxInputInterface.Instance.CsvDetails.GetMinX(), maxXTest = SpaceSyntaxInputInterface.Instance.CsvDetails.GetMaxX(),
              minYTest = SpaceSyntaxInputInterface.Instance.CsvDetails.GetMinY(), maxYTest = SpaceSyntaxInputInterface.Instance.CsvDetails.GetMaxY();

        float pointWidth = point.getWidth(), pointHeight = point.getHeight();

        for (int i = 0; i < verticies.XVertex.Count; j = i++) // go through all verticies
        {
            // x and y from Verticies need to be converted to the range in the space syntax attributes point
            float x1 = (((verticies.XVertex[i] - minX) * (modelWidth)) / (maxX - minX));
            float x2 = (((verticies.XVertex[j] - minX) * (modelWidth)) / (maxX - minX));
            float xTest = (((pointWidth - minXTest) * (modelWidth)) /
                (maxXTest - minXTest));

            float y1 = (((verticies.YVertex[i] - minY) * (modelHeight)) / (maxY - minY));
            float y2 = (((verticies.YVertex[j] - minY) * (modelHeight)) / (maxY - minY));
            float yTest = (((pointHeight - minYTest) * (modelHeight)) /
                (maxYTest - minYTest));
            yTest = Math.Abs(yTest - modelHeight);

            if ((((y1 <= yTest) && (yTest < y2)) || 
                ((y2 <= yTest) && (yTest < y1))) &&
                    (xTest < (x2 - x1) * (yTest - y1) / (y2 - y1) + x1))
                inside = !inside;
        }
        return inside;
    }
}
