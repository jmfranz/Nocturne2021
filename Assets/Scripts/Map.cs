/*
 * This will hold information about a map. 
 */

using System;
using UnityEngine;

[Serializable]
public class Map
{
    public string MapName;
    public float MapWidth;
    public float MapHeight;

    public Map(string name, float width, float height)
    {
        MapName = name;
        MapWidth = width;
        MapHeight = height;
    }
}
