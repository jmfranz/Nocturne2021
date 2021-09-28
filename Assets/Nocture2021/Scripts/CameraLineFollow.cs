using System.Collections;
using System.Collections.Generic;
using PathCreation;
using UnityEngine;

public class CameraLineFollow : MonoBehaviour
{

    public Transform Camera;
    public Transform PathParent;
    public PathCreator PathCreator;
    [Range(-2, 2)]
    public float VerticalOffsetFromCamera;
    // Start is called before the first frame update
    void Start()
    {
        
        PathCreator.InitializeEditorData(true);
        var globalPosition = PathParent.InverseTransformPoint(Camera.position);
        PathCreator.bezierPath.AddSegmentToStart(globalPosition);

        AlignPathWithCamera();
        

    }

    // Update is called once per frame
    void Update()
    {
        var globalPosition = PathParent.InverseTransformPoint(Camera.position);
        PathCreator.bezierPath.MovePoint(0, globalPosition);
        AlignPathWithCamera();
    }

    private void AlignPathWithCamera()
    {
        for (int i = 0; i < PathCreator.bezierPath.NumPoints; i++)
        {
            var currentPos = PathCreator.bezierPath[i];

            currentPos.y = Camera.position.y - VerticalOffsetFromCamera - transform.position.y;
            Debug.Log(transform.position.y);

            PathCreator.bezierPath.MovePoint(i, currentPos);
        }
    }


}
