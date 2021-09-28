using System.Collections.Generic;
using UnityEngine;

/* Author: Jake Moore
 * The purpose of this script is to take the list of game objects it has been passed from spawnGameObjects, and calculate the rules for each one.
 * Rule calculation is not done in this script, but this script will create and add a linearSort script, which contains the code for
 * the actual calculations.
 * Once the best pixel values are found for a game object, it will then be moved in the Unity scene accordingly.
 */
public class positionObjects : MonoBehaviour {
    private Texture2D originalCompositeMap;
    private List<GameObject> objList;
    private int imageWidth, imageHeight;

    linearSort linearSort;
    ContourMap contourMap;

    void Start()
    {
        contourMap = gameObject.GetComponent<ContourMap>();
        linearSort = gameObject.GetComponent<linearSort>();
    }

    //Calculate finds the best pixel values
    public void calculateRules (List<GameObject> objList, GameObject excludeRegionObj) {
        contourMap.MapCalulations(excludeRegionObj);

        this.objList = objList;

        //Loops through the game object list, and passes itself, and its properties into the linear sort script.
        for (int i = 0; i < objList.Count; i++) {
            int openness = objList[i].GetComponent<genericGameObject> ().getOpenness ();
            int visualComplexity = objList[i].GetComponent<genericGameObject> ().getVisualComplexity ();
            int connectivity = objList[i].GetComponent<genericGameObject> ().getConnectivity ();
            int precision = objList[i].GetComponent<genericGameObject> ().getPrecision ();
            int distance = objList[i].GetComponent<genericGameObject> ().getDistance ();
            Room room = objList[i].GetComponent<genericGameObject>().GetRoom();
            string[] priorityList = sortPriorities (objList[i]);

            //Runs the findBestPlacement function in linearSort, which finds the best pixels values based on
            //the game objects properties and priorities.
            linearSort.findBestPlacement (objList[i], objList, precision, distance, priorityList, room);
            //Sets the hasPlaced variable to true within the game object.
            objList[i].GetComponent<genericGameObject> ().setHasPlaced (true);
            //Moves the game object based on the finalPoint found.  The finalPoint is set within the game object.
            //moveGameObj converts pixel coordinates to unity coordinates.  For this to work, several things must be setup properly:
            //1. Pixel size must be known and set in CM 2. The Unity map must be set so the bottom left hand corner is 0,0,0, and it is rotated to the positive quadrant (y = 180)
            moveGameObj (objList[i], objList[i].GetComponent<genericGameObject> ().getFinalPoint ().getWidth (),
                objList[i].GetComponent<genericGameObject> ().getFinalPoint ().getHeight ());
        }

    }

    //converts a location [width,height] to world coordinates in Unity
    private void moveGameObj (GameObject obj, float width, float height) {

        //move the game object's world location based on the final pixel value
        obj.transform.position = new Vector3 (width, 0, height);
    }

    //Sorts priorities from highest priority to lowest
    private string[] sortPriorities (GameObject obj) {
        int[] priorityValueList = new int[] {
            obj.GetComponent<genericGameObject> ().getOpennessPriority (),
            obj.GetComponent<genericGameObject> ().getVisualComplexityPriority (),
            obj.GetComponent<genericGameObject> ().getConnectivityPriority (),
            obj.GetComponent<genericGameObject> ().getDistancePriority ()
        };
        int tempInt;

        string[] priorityList = { "Openness", "Visual Complexity", "Connectivity", "Distance" };
        string tempString;

        for (int j = 0; j <= priorityList.Length - 2; j++) {
            for (int i = 0; i <= priorityList.Length - 2; i++) {
                if (priorityValueList[i] > priorityValueList[i + 1]) {
                    //sorting priority int values
                    tempInt = priorityValueList[i + 1];
                    priorityValueList[i + 1] = priorityValueList[i];
                    priorityValueList[i] = tempInt;
                    //matching the string array to the int changes
                    tempString = priorityList[i + 1];
                    priorityList[i + 1] = priorityList[i];
                    priorityList[i] = tempString;
                }
            }
        }
        return priorityList;
    }
}