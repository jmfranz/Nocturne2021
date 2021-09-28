using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Author: Jake Moore
 * This script defines a game object, and contains set and get functions for all of its config file properties, as well as 
 * some additional properties used throughout the program.
 */
public class genericGameObject : MonoBehaviour {
    //Game object format in config file: "Game Object": ["TypeID", "GroupID", int Priority, int Cardinality, int Openness, 
    //                                                    int Visual Complexity, int Connectivity, int Precision, int distance, int distancePriority, int distanceID]

    public int id;
    public string type;
    public int cardinality;
    public int openness;
    public int opennessPriority;
    public int precision;
    public int visualComplexity;
    public int visualComplexityPriority;
    public int connectivity;
    public int connectivityPriority;
    public int visualIntegration;
    public int visualIntegrationPriority;
    public int distance;
    public int distancePriority;
    public int distanceID;
    public Room Room = null;
    public int[] bestOpenness;
    public int[] bestVisualComplexity;
    public int[] bestConnectivity;
    public bool hasPlaced = false;
    public SpaceSyntaxAttributesPoint finalPoint;

    //start of config file functions
    public void setID (string id) {
        int.TryParse (id, out this.id);
    }
    public void setType (string type) {
        this.type = type;
    }
    public void setCardinality (string cardinality) {
        int.TryParse (cardinality, out this.cardinality);
    }
    public void setOpenness (string openness) {
        int.TryParse (openness, out this.openness);
    }
    public void setOpennessPriority (string opennessPriority) {
        int.TryParse (opennessPriority, out this.opennessPriority);
    }
    public void setVisualComplexity (string visualComplexity) {
        int.TryParse (visualComplexity, out this.visualComplexity);
    }
    public void setVisualComplexityPriority (string visualComplexityPriority) {
        int.TryParse (visualComplexityPriority, out this.visualComplexityPriority);
    }
    public void setConnectivity (string connectivity) {
        int.TryParse (connectivity, out this.connectivity);
    }
    public void setConnectivityPriority (string connectivityPriority) {
        int.TryParse (connectivityPriority, out this.connectivityPriority);
    }
    public void setVisualIntegration (string visualIntegration) {
        int.TryParse (visualIntegration, out this.visualIntegration);
    }
    public void setVisualIntegrationPriority (string visualIntegrationPriority) {
        int.TryParse (visualIntegrationPriority, out this.visualIntegrationPriority);
    }
    public void setPrecision (string precision) {
        int.TryParse (precision, out this.precision);
    }
    public void setDistance (string distance) {
        int.TryParse (distance, out this.distance);
    }
    public void setDistancePriority (string distancePriority) {
        int.TryParse (distancePriority, out this.distancePriority);
    }
    public void setDistanceID (string distanceID) {
        int.TryParse (distanceID, out this.distanceID);
    }
    //start of non-config functions
    public void setBestOpenness (int[] bestOpenness) {
        this.bestOpenness = bestOpenness;
    }
    public void setBestVisualComplexity (int[] bestVisualComplexity) {
        this.bestVisualComplexity = bestVisualComplexity;
    }
    public void setBestConnectivity (int[] bestConnectivity) {
        this.bestConnectivity = bestConnectivity;
    }
    public void setHasPlaced (bool hasPlaced) {
        this.hasPlaced = hasPlaced;
    }
    public void setFinalPoint (SpaceSyntaxAttributesPoint finalPoint) {
        this.finalPoint = finalPoint;
    }

    public void SetRoom(Room room)
    {
        Room = room; 
    }

    //start of config file functions
    public int getID () {
        return id;
    }
    public string getType () {
        return type;
    }
    public int getCardinality () {
        return cardinality;
    }
    public int getOpenness () {
        return openness;
    }
    public int getOpennessPriority () {
        return opennessPriority;
    }
    public int getVisualComplexity () {
        return visualComplexity;
    }
    public int getVisualComplexityPriority () {
        return visualComplexityPriority;
    }
    public int getConnectivity () {
        return connectivity;
    }
    public int getConnectivityPriority () {
        return connectivityPriority;
    }
    public int getVisualIntegration () {
        return visualIntegration;
    }
    public int getVisualIntegrationPriority () {
        return visualIntegrationPriority;
    }
    public int getPrecision () {
        return precision;
    }
    public int getDistance () {
        return distance;
    }
    public int getDistancePriority () {
        return distancePriority;
    }
    public int getDistanceID () {
        return distanceID;
    }
    //start of non-config functions
    public int[] getBestOpenness () {
        return bestOpenness;
    }
    public int[] getBestVisualComplexity () {
        return bestVisualComplexity;
    }
    public int[] getBestConnectivity () {
        return bestConnectivity;
    }
    public bool getHasPlaced () {
        return hasPlaced;
    }
    public SpaceSyntaxAttributesPoint getFinalPoint () {
        return finalPoint;
    }

    public Room GetRoom()
    {
        return Room;
    }
}