using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandvilleMuseumEventsController : MonoBehaviour
{
    public GameObject Shadow;
    public GameObject Player;
    public GameObject Bathroom;

    public GameObject TutorialLocation1;
    public GameObject TutorialLocation2;
    public GameObject TutorialLocation3;
    public GameObject TutorialLocation4;
    public GameObject TutorialLocation5;

    public GameObject ShadowTraversal1;
    public GameObject ShadowTraversal2;
    public GameObject ShadowTraversal3;
    public GameObject ShadowTraversal4;
    public GameObject ShadowTraversal5;

    List<GameObject> tutorialLocations;


    // Start is called before the first frame update
    void Start()
    {
        //Initializing and adding tutorial locations to list
        tutorialLocations = new List<GameObject>();
        tutorialLocations.Add(TutorialLocation1);
        tutorialLocations.Add(TutorialLocation2);
        tutorialLocations.Add(TutorialLocation3);
        tutorialLocations.Add(TutorialLocation4);
        tutorialLocations.Add(TutorialLocation5);
    }

    // Update is called once per frame
    void Update()
    {
        setShadowAppearances();
    }


    public void setShadowAppearances()
    {
        if (isClose(Player.transform.position, TutorialLocation1.transform.position, 2))
        {
            Shadow.transform.position = ShadowTraversal1.transform.position;
        }
        else if (isClose(Player.transform.position, TutorialLocation2.transform.position, 2))
        {
            Shadow.transform.position = ShadowTraversal2.transform.position;
        }
        else if (isClose(Player.transform.position, TutorialLocation3.transform.position, 2))
        {
            Shadow.transform.position = ShadowTraversal3.transform.position;
        }
        else if (isClose(Player.transform.position, TutorialLocation4.transform.position, 2))
        {
            Shadow.transform.position = ShadowTraversal4.transform.position;
        }
        else if (isClose(Player.transform.position, TutorialLocation5.transform.position, 2))
        {
            Shadow.transform.position = ShadowTraversal5.transform.position;
        }
        else
        {
            Shadow.transform.position = Bathroom.transform.position;
        }
    }

    public bool isClose(Vector3 tutorialLocation, Vector3 playerLocation, int distance)
    {
        if (Math.Abs(playerLocation.x - tutorialLocation.x) <= distance && Math.Abs(playerLocation.z - tutorialLocation.z) <= distance)
        {
            return true;
        } else
        {
            return false;
        }
        
    }
}
