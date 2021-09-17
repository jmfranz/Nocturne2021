/*
 * @Author: Abbey Singh
 * This script will hold information for an object's transform
 */

using System;
using UnityEngine;

[Serializable]
public class TransformStoryElement
{
    public string Name;

    //Information for the objects transform 
    public float[] Position = new float[3];
    public float[] Rotation = new float[4];
    public float[] Scale = new float[3];
    
    public TransformStoryElement(string name, Transform transform)
    {
        this.Name = name;

        Position[0] = transform.localPosition.x;
        Position[1] = transform.localPosition.y;
        Position[2] = transform.localPosition.z;

        Rotation[0] = transform.localRotation.w;
        Rotation[1] = transform.localRotation.x;
        Rotation[2] = transform.localRotation.y;
        Rotation[3] = transform.localRotation.z;

        Scale[0] = transform.localScale.x;
        Scale[1] = transform.localScale.y;
        Scale[2] = transform.localScale.z;
    }
}
