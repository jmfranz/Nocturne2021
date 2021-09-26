using System.Collections;
using System.Collections.Generic;
using PathCreation;
using UnityEngine;

public class CameraLineFollow : MonoBehaviour
{

    public Transform Camera;
    public Transform PathParent;
    public PathCreator PathCreator;
    // Start is called before the first frame update
    void Start()
    {
        PathCreator.bezierPath.Space = PathSpace.xz;
        PathCreator.InitializeEditorData(true);

        var globalPosition = PathParent.InverseTransformPoint(Camera.position);

        PathCreator.bezierPath.AddSegmentToStart(globalPosition);

    }

    // Update is called once per frame
    void Update()
    {
        var globalPosition = PathParent.InverseTransformPoint(Camera.position);
        PathCreator.bezierPath.MovePoint(0, globalPosition);
    }
}
