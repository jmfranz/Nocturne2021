using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class ShadowPathController : MonoBehaviour
{
    public GameObject Max;
    public GameObject Shadow;

    public PathCreator AbductionPath;
    public float speed = 6;
    float distanceTravelled;
    public bool abductionComplete = false;

    public MT_Controller MT_Controller;

    //Start is called before the first Update
    void Start()
    {
        Max.GetComponent<ShadowPathController>().enabled = false;
        GetComponent<ShadowPathController>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        distanceTravelled += speed * Time.deltaTime;
        transform.position = AbductionPath.path.GetPointAtDistance(distanceTravelled);
    }

    public void StalkingToAbduction()
    {
        Max.GetComponent<ShadowPathController>().enabled = true;
        GetComponent<ShadowPathController>().enabled = true;
    }

    public void CompleteAbduction()
    {
        ShadowPathController pathComponent = GetComponent<ShadowPathController>();
        Destroy(pathComponent);
        Destroy(Max.GetComponent<ShadowPathController>());
        Max.SetActive(false);
        Shadow.SetActive(false);
        abductionComplete = true;
    }
}