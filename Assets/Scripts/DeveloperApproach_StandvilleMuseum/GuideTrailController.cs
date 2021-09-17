using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class GuideTrailController : MonoBehaviour
{
    public GameObject IntroPathObject;
    public GameObject TutorialPath;
    public GameObject BacktoClues;
    public GameObject TeddyPath;
    public GameObject BusinessCardPath;

    public PathCreator IntroPath;
    public float speed = 1;
    float distanceTravelled;

    // Update is called once per frame
    void Update()
    {
        distanceTravelled += speed * Time.deltaTime;
        transform.position = IntroPath.path.GetPointAtDistance(distanceTravelled);
    }

}
