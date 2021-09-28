using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/* Author: Jake Moore
 * This script is what sorts a composite map according to the properties and priorities of a game object.  The first priority item will be used to refine the list to
 * a new list of points that fit the first priorities criteria.  This process is repeated recursively until the list has been refined by all priorities.
 * If the list has multiple entries with points that fit all criteria, a final point is randomly selected.  If at any point the list is refined to 0, the refining process will be repeated,
 * except with a more lenient threshold.  The threshold is increased until at least one point is found.  This will guarentee the best combination of points even under impossible circumstances.
 *
 * @Author: Abbey
 * Adjusting the script by Jake to use csv values instead of a contour map.
 * Space syntax values (openness, visual complexity, and visual integration) are scaled in the range 0 - 100 instead of 0 - 255.
 */

public class linearSort : MonoBehaviour {

    private int imageHeight, imageWidth;

    //The point list is the global list that is recursed on and refined through the algorithm.
    List<SpaceSyntaxAttributesPoint> currentObjectsPointList;
    List<SpaceSyntaxAttributesPoint> pointsAlreadyUsed = new List<SpaceSyntaxAttributesPoint>();
    List<PointsInRoom> PointsInRooms = new List<PointsInRoom>(); // one for each map

    // Use this public boolean to choose the input (contour map or csv values) method.
    public bool useContourMap;

    public void ClearPointsAlreadyUsed()
    {
        pointsAlreadyUsed.Clear();
        PointsInRooms.Clear();
    }

    private void CreateRoomPointsList(List<SpaceSyntaxAttributesPoint> pointsList)
    {
        string mapSelected = Stories.Instance.CurrentStory.MapSelected;

        PointsInRoom newPointsInRoom = new PointsInRoom();
        newPointsInRoom.FindPointsInRoomForMap(mapSelected, pointsList);
        newPointsInRoom.mapName = mapSelected;
        PointsInRooms.Add(newPointsInRoom);
    }

    //Main function called by positionObjects, that sorts by priority and finds best pixels values.
    public void findBestPlacement (GameObject obj, List<GameObject> objList, int precision, int distance, string[] priorityList, Room room) {
        currentObjectsPointList  = SpaceSyntaxInputInterface.Instance.CreatePointsList();

        foreach (SpaceSyntaxAttributesPoint pointUsed in pointsAlreadyUsed)
        {
            currentObjectsPointList.Remove(pointUsed);
        }        

        // refine points list to points only in that room, if room specified as an attribute
        if (room != null)
        {
            bool createdRoomPointsList = false;
            for(int i = 0; i < PointsInRooms.Count; i++)
            {
                if(Stories.Instance.CurrentStory.MapSelected == PointsInRooms[i].mapName)
                {
                    createdRoomPointsList = true;
                }
            }

            if (!createdRoomPointsList)
            {
                CreateRoomPointsList(currentObjectsPointList);
            }

            for(int i = 0; i < PointsInRooms.Count; i++)
            {
                if(PointsInRooms[i].mapName == Stories.Instance.CurrentStory.MapSelected)
                {
                    currentObjectsPointList = PointsInRooms[i].GetRoomCoordinatesFor(room.GetRoomID(PointsInRooms[i].mapName));
                }
            }
        }

        //increments through priorities one at a time.  The list will always be in order from first to last.
        for (int i = 0; i < priorityList.Length; i++) {
            if (priorityList[i].Equals ("Openness")) {
                findBestLocationValues (priorityList[i], precision, obj);
            } else if (priorityList[i].Equals ("Visual Complexity")) {
                findBestLocationValues (priorityList[i], precision, obj);
            } else if (priorityList[i].Equals ("Connectivity")) {
                findBestLocationValues (priorityList[i], precision, obj);
            } else if (priorityList[i].Equals ("Distance")) {
                if (currentObjectsPointList.Count == 1) {
                    break;
                } else {
                    findBestLocationValues (obj, objList, distance);
                }
            }
        }

        //finds a random point based on the lists size
        int randomNum = getRandom (currentObjectsPointList.Count);
        SpaceSyntaxAttributesPoint bestPoint = currentObjectsPointList[randomNum];
        pointsAlreadyUsed.Add(bestPoint);
        bestPoint = SpaceSyntaxInputInterface.Instance.ScaleXYForBestPoint(bestPoint);


        //sets the selected point as the final point
        obj.GetComponent<genericGameObject> ().setFinalPoint (bestPoint);
    }

    public List<SpaceSyntaxAttributesPoint> RefinePointListToARoom(Room roomToRefineTo, List<SpaceSyntaxAttributesPoint> pointsList)
    {
        RoomController roomController = Stories.Instance.CurrentStory.RoomController;
        string mapSelected = Stories.Instance.CurrentStory.MapSelected;

        List<SpaceSyntaxAttributesPoint> pointsInRoom = new List<SpaceSyntaxAttributesPoint>();

        for(int i = 0; i < roomController._rooms.Count; i++)
        {
            Room currentRoom = roomController._rooms[i];

            // We want to refine points to this room
            if(currentRoom.Name == roomToRefineTo.Name)
            {
                for(int j = 0; j < roomController._mapsRoomsData.Count; j++)
                {
                    MapRoomData currentMapRoomData = roomController._mapsRoomsData[j];

                    if (currentMapRoomData.MapName == mapSelected)
                    {
                        Verticies roomVertexList = currentMapRoomData.VerticiesPerRoom[i];

                        // refine points list to points only in here
                        int size = pointsList.Count;
                        for(int k = 0; k < size; k++)
                        {
                            bool pointInRoom = CheckIfPointInARoom.CheckIfPointIsInRoom(pointsList[k], roomVertexList, currentMapRoomData);

                            // TODO: remove from points list
                            if (pointInRoom)
                            {
                                pointsInRoom.Add(pointsList[k]);
                            }
                        }

                        break;
                    }
                }
            }
        }

        return pointsInRoom;
    }

    //will refine the point list depending on the priority
    //if no search results occur, the function will run again with precsion + 10.  This occurs until results are found.
    private void findBestLocationValues (string priority, int precision, GameObject obj) {
        List<SpaceSyntaxAttributesPoint> refinedPointList = new List<SpaceSyntaxAttributesPoint> ();
        for (int i = 0; i < currentObjectsPointList.Count; i++) {
            if (priority.Equals ("Openness") && checkOpenness (currentObjectsPointList[i], obj, precision)) {
                refinedPointList.Add (currentObjectsPointList[i]);
            } else if (priority.Equals ("Visual Complexity") && checkVisualComplexity (currentObjectsPointList[i], obj, precision)) {
                refinedPointList.Add (currentObjectsPointList[i]);
            } else if (priority.Equals ("Connectivity") && checkConnectivity (currentObjectsPointList[i], obj, precision)) {
                refinedPointList.Add (currentObjectsPointList[i]);
            }
        }
        if (refinedPointList.Count == 0) {
            findBestLocationValues (priority, precision + 10, obj);
        } else {
            currentObjectsPointList = refinedPointList;
        }
    }

    //handles all calculations regarding distance, as distance requires different inputs compared to the other priorities, but the concept is the same as the above function.
    private void findBestLocationValues (GameObject obj, List<GameObject> objList, int distance) {
        List<SpaceSyntaxAttributesPoint> refinedPointList = checkDistance (obj, objList, distance);
        if (refinedPointList.Count == 0) {
            findBestLocationValues (obj, objList, distance - 1);
        } else {
            currentObjectsPointList = refinedPointList;
        }
    }

    //checks openness value to see if it is within the precision to the best value
    private bool checkOpenness (SpaceSyntaxAttributesPoint point, GameObject obj, int precision) {
        return Mathf.Abs ((float) point.getOpenness () - obj.GetComponent<genericGameObject> ().getOpenness ()) < precision;
    }
    //checks visual complexity value to see if it is within the precision to the best value
    private bool checkVisualComplexity (SpaceSyntaxAttributesPoint point, GameObject obj, int precision) {
        return Mathf.Abs ((float) point.getVisualComplexity () - obj.GetComponent<genericGameObject> ().getVisualComplexity ()) < precision;
    }
    //checks visual integration value to see if it is within the precision to the best value
    private bool checkVisualIntegration (SpaceSyntaxAttributesPoint point, GameObject obj, int precision) {
        return Mathf.Abs ((float) point.getVisualIntegration () - obj.GetComponent<genericGameObject> ().getVisualIntegration ()) < precision;
    }

    //checks connectivity value to see if it is within the precision to the best value
    private bool checkConnectivity (SpaceSyntaxAttributesPoint point, GameObject obj, int precision) {
        return Mathf.Abs ((float) point.getB () - obj.GetComponent<genericGameObject> ().getConnectivity ()) < precision;
    }

    //Checks if any objects have distance constraints.  If so, proceed in removing the points around them.
    private List<SpaceSyntaxAttributesPoint> checkDistance (GameObject obj, List<GameObject> objList, int distance) {
        List<GameObject> potentialObjectsWithinDistance = new List<GameObject> ();
        List<SpaceSyntaxAttributesPoint> refinedPointList = new List<SpaceSyntaxAttributesPoint> ();
        for (int i = 0; i < objList.Count; i++) {
            if (objList[i].GetComponent<genericGameObject> ().getHasPlaced ()) {
                if (obj.GetComponent<genericGameObject> ().getID () == objList[i].GetComponent<genericGameObject> ().getID () ||
                    obj.GetComponent<genericGameObject> ().getDistanceID () == objList[i].GetComponent<genericGameObject> ().getID ()) {
                    potentialObjectsWithinDistance.Add (objList[i]);
                }
            }
        }
        //If objects are found, pass the list of obj's to have the points where d*d <= r*r removed from pointList
        List<SpaceSyntaxAttributesPoint> allPointsToRemove;
        if (potentialObjectsWithinDistance.Count > 0) {
            allPointsToRemove = removePointsInDistanceRadius (potentialObjectsWithinDistance, distance);
            refinedPointList = getListDifference (currentObjectsPointList, allPointsToRemove);
        }
        //If no objects are found, then there are no objects yet placed.  Distance constraint is irrelavent, move onto next priority. 
        else {
            refinedPointList = currentObjectsPointList;
        }
        return refinedPointList;

    }

    //Concatenates each pointsToRemove list onto the end of a single list called allPointsToRemove and returns it
    public List<SpaceSyntaxAttributesPoint> removePointsInDistanceRadius (List<GameObject> potentialObjectsWithinDistance, int distance) {
        List<SpaceSyntaxAttributesPoint> allPointsToRemove = new List<SpaceSyntaxAttributesPoint> ();
        for (int i = 0; i < potentialObjectsWithinDistance.Count; i++) {
            SpaceSyntaxAttributesPoint centerPoint = potentialObjectsWithinDistance[i].GetComponent<genericGameObject> ().getFinalPoint ();
            allPointsToRemove.AddRange (calculateRadiusAroundPoint (centerPoint, distance));
        }
        return allPointsToRemove;
    }

    //calculates the radius around a center point, and adds the points within the radius to a list
    private List<SpaceSyntaxAttributesPoint> calculateRadiusAroundPoint (SpaceSyntaxAttributesPoint point, int distance) {
        List<SpaceSyntaxAttributesPoint> pointsToRemove = new List<SpaceSyntaxAttributesPoint> ();
        double pixelDistance = convertWorldDistanceToPixel (distance);

        for (int i = 0; i < currentObjectsPointList.Count; i++) {
            double radiusSquared = pixelDistance * pixelDistance;
            double dx = currentObjectsPointList[i].getWidth () - point.getWidth ();
            double dy = currentObjectsPointList[i].getHeight () - point.getHeight ();
            double distanceSquared = dx * dx + dy * dy;
            if (distanceSquared <= radiusSquared) {
                //removes points found in list
                pointsToRemove.Add (currentObjectsPointList[i]);
            }
        }
        return pointsToRemove;
    }

    //converts world distance to pixel distance
    private double convertWorldDistanceToPixel (double distance) {
        double pixelSizeInCM = 0.02;
        return distance / pixelSizeInCM;
    }

    //returns random number
    private int getRandom (int range) {
        return Random.Range (0, range - 1);
    }

    //returns list1 with matching items in list2 removed
    private List<SpaceSyntaxAttributesPoint> getListDifference (List<SpaceSyntaxAttributesPoint> list1, List<SpaceSyntaxAttributesPoint> list2) {
        return new List<SpaceSyntaxAttributesPoint> (list1.Except (list2).ToList ());
    }
}