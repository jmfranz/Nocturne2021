using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

/* Author: Jake Moore
 * The purpose of this class is to sort through the string array of text and determine which type of rules there are.  Currently there are exclude region 
 * rules, and Game Object rules.  The game objects will also be created, with a genericGameObject script added.  The properties of each game object are stored
 * in the genericGameObject script, and are set in the setGameObject function.
 * This script will also assign a mesh, material, and duplicate game objects based on the cardinality property.
 * Each game object will be created, set, and added to a game object list. 
 * A positionObjects script is then added, and the function calculateRules(objList, excludeRegionObj) is passed to it.
 */

public class spawnObjects : MonoBehaviour {

    List<GameObject> objList;

    List<GameObject> colorsList;
    List<Color> colors; //in the same order as colorsList

    GameObject excludeRegionObj;


    public void spawnGameObjects (List<string> templist) {

        excludeRegionObj = new GameObject ("Exclude Regions");
        excludeRegionObj.tag = ("Exclude Regions");
        objList = new List<GameObject> ();
        colorsList = new List<GameObject>();
        colors = new List<Color>();

        for (int i = 0; i < templist.Count; i++) {
            if (templist[i].Equals ("GameObjects")) {
                //If rule in config has title Game Object, each game object will be spawned and set
                setGameObject (templist, i);

                if (templist[i + 1].Contains("Avatar") || templist[i + 1].Contains("Music") || templist[i+1].Contains("NewObjects") || templist[i+1].Contains("ConversationNodeData"))
                {
                    AddColorOfStoryElement(objList[(i-1)/16].name);
                }
            } else if (templist[i].Equals ("Exclude Region")) {
                //if rule in config is titled Exclude region, each exclude region is set
                excludeRegionFromMap (templist, i);
            }
        }
        //calls the function in the positionObjects script that starts calculating space syntax positoning
        //for each object in objList
        GetComponent<positionObjects> ().calculateRules (objList, excludeRegionObj);

        //create a sphere on top of each story element that is an object (avatar)
        for(int i = 0; i < colorsList.Count; i++)
        {
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.position = new Vector3 (objList[i].transform.position.x, 2, objList[i].transform.position.z);
            sphere.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            sphere.GetComponent<Renderer>().material.SetColor("_Color", colors[i]);
            sphere.tag = "Sphere";
        }
    }

    void AddColorOfStoryElement(string path)
    {
        Stories stories = EditorSaveLoadDemo.Instance.Load();
        StoryData currentStory = Stories.Instance.FindUniqueStory(stories.CurrentStory.Title, stories.CurrentStory.Author);
        int index = path.LastIndexOf('/');
        string name = path.Substring(index + 1);
        StoryElement currentStoryElement = currentStory.FindStoryElement(name);
        ConversationNodeData currentConversationNodeData = currentStory.FindConversationNodeData(name);

        if (currentStoryElement != null)
        {
            colors.Add(currentStoryElement.Color);
        }
        else if (currentConversationNodeData != null)
        {
            colors.Add(currentConversationNodeData.Color);
        }
    }

    private void addComponents (string name, GameObject obj) {
        //loads the mesh depending on object type
        MeshFilter meshFilter = obj.AddComponent<MeshFilter> ();
        
        // obj already has a meshFilter
        if(meshFilter == null)
        {
            meshFilter = obj.GetComponent<MeshFilter>();
        }
        meshFilter.sharedMesh = loadMesh (obj);

        //loads material depending on object type
        MeshRenderer meshRenderer = obj.AddComponent<MeshRenderer> ();

        // obj already has a mesh renderer
        if(meshRenderer == null)
        {
            meshRenderer = obj.GetComponent<MeshRenderer>();
        }
        meshRenderer.material = loadMaterial (obj);
        obj.name = name; 

        //duplicates game object depending on cardinality
        duplicateObject (name, obj);
    }

    //Based on type loadMesh loads mesh, adds corresponding game logic script, and returns the mesh.
    private Mesh loadMesh (GameObject obj) {
        genericGameObject gameobj = obj.GetComponent<genericGameObject> ();
        Mesh mesh = new Mesh ();

        if (gameobj.getType ().Equals ("key")) {
            //extract mesh from a prefab named "MeshTest"
            mesh = ((GameObject) Resources.Load ("key")).GetComponent<MeshFilter> ().sharedMesh;
        } else if (gameobj.getType ().Equals ("chest")) {
            mesh = ((GameObject) Resources.Load ("chest")).GetComponent<MeshFilter> ().sharedMesh;
        }
        return mesh;
    }

    //loads the material based on the obj type
    private Material loadMaterial (GameObject obj) {
        Material material = Resources.Load ("white_mat", typeof (Material)) as Material;
        return material;
    }

    //duplicates the obj based on its cardinality, and adds the duplicates to the objList
    private void duplicateObject (string name, GameObject obj) {
        int duplicateAmount = obj.GetComponent<genericGameObject> ().getCardinality ();

        if (duplicateAmount > 1) {
            for (int i = 0; i < duplicateAmount - 1; i++) {
                GameObject duplicateObj = Instantiate (obj);
                duplicateObj.name = name;
                objList.Add (duplicateObj);
            }
        }
    }
 
    private void setGameObject (List<string> templist, int i) {
        GameObject obj; //= new GameObject ();
        
        if (templist[i + 1].Contains ("Avatar")) {
            // Generate the path of the avatar to be generated.
            string avatarPath = templist[i + 1] + "/Export/" + templist[i + 1].Split ('/') [1];

            // Implement a try catch to ensure that an invalid avatar path does not break the rest of the script.
            try {
                // Load the avatar as specified in the Json File
                obj = Instantiate (Resources.Load (avatarPath) as GameObject);
            } catch (Exception ex) {
                // Catch the error and log a message to the user
                Debug.Log ("Avatar Path is Invalid");
                obj = null;
            }
            colorsList.Add(obj);
        }
        else if (templist[i + 1].Contains("NewObjects"))
        {
            // Generate the path of the avatar to be generated.
            string objectPath = templist[i + 1];
            Debug.Log(objectPath);

            // Implement a try catch to ensure that an invalid path does not break the rest of the script.
            try
            {
                // Load the avatar as specified in the Json File
                obj = Instantiate(Resources.Load(objectPath) as GameObject);
            }
            catch (Exception ex)
            {
                Debug.Log("Object Path is Invalid");
                // Catch the error and log a message to the user
                obj = null;
            }
            colorsList.Add(obj);
        }
        else if (templist[i + 1].Contains("ConversationNodeData"))
        {
            // Generate the path of the avatar to be generated.
            string objectPath = templist[i + 1];
            Debug.Log(objectPath);

            // Implement a try catch to ensure that an invalid path does not break the rest of the script.
            try
            {
                // Load the avatar as specified in the Json File
                obj = new GameObject();
            }
            catch (Exception ex)
            {
                Debug.Log("Object Path is Invalid");
                // Catch the error and log a message to the user
                obj = null;
            }
            colorsList.Add(obj);
        }
        else {
            obj = new GameObject ();
        }

        if (obj != null) {
            // Tag this as a "Game Object"
            obj.tag = "Game Object";

            // Add proxemic tracker to object
            obj.AddComponent<VirtualProxemicTracker>();


            //Add generic game object script to the game object
            obj.AddComponent<genericGameObject>();

            //GameObject = {id, type, cardinality, openness, opennessPriority, visualComplexity, visualComplexityPriority, connectivity, connectivityPriority, precision, distance, distancePriority, roomName}
            //set the properties of the game object
            obj.GetComponent<genericGameObject> ().setType (templist[i + 1]);
            obj.GetComponent<genericGameObject> ().setID (templist[i + 2]);
            obj.GetComponent<genericGameObject> ().setCardinality (templist[i + 3]);
            obj.GetComponent<genericGameObject> ().setOpenness (templist[i + 4]);
            obj.GetComponent<genericGameObject> ().setOpennessPriority (templist[i + 5]);
            obj.GetComponent<genericGameObject> ().setVisualComplexity (templist[i + 6]);
            obj.GetComponent<genericGameObject> ().setVisualComplexityPriority (templist[i + 7]);
            obj.GetComponent<genericGameObject> ().setConnectivity (templist[i + 8]);
            obj.GetComponent<genericGameObject> ().setConnectivityPriority (templist[i + 9]);
            obj.GetComponent<genericGameObject> ().setPrecision (templist[i + 10]);
            obj.GetComponent<genericGameObject> ().setDistance (templist[i + 11]);
            obj.GetComponent<genericGameObject> ().setDistancePriority (templist[i + 12]);
            obj.GetComponent<genericGameObject> ().setDistanceID (templist[i + 13]);

            // find room from roomName
            string roomName = templist[i + 15];
            Room roomSelected = null;
            foreach(var room in Stories.Instance.CurrentStory.RoomController._rooms)
            {
                if(room.Name == roomName)
                {
                    roomSelected = room;
                }
            }

            obj.GetComponent<genericGameObject>().SetRoom(roomSelected);

            //This is 3D music
            if (templist[i + 1].Contains ("Music")) {
                // Attach an audio clip to the Avatar Game Object.
                AudioSource audioSource = obj.AddComponent<AudioSource> () as AudioSource;
                
                // Spawn the audioClip defined by the path in the config file
                AudioClip audioClip = Resources.Load<AudioClip> (templist[i + 1]);

                // Attach the clip to the audio source.
                audioSource.clip = audioClip;

                // NOTE: THIS IS WHY THE AUDIO PLAYS AS SOON AS THE SCENE STARTS.  SET THIS TO FALSE WHEN USING THE PROXIMITY TRIGGERS.
                audioSource.playOnAwake = true;

                // Make this audio source a fully 3D sound object by default.
                audioSource.spatialBlend = 1.0f;

                //add 3D music
                colorsList.Add(obj);
            }

            //add the game object to a List<GameObject>
            objList.Add (obj);

            //Get storyelements name
            string name = templist[i + 2]; 

            //begin adding components to the object
            addComponents (name, obj);
        }

    }

    //Places box colliders in the scene based on the exclude regions specified
    private void excludeRegionFromMap (List<string> templist, int i) {
        BoxCollider col = new BoxCollider ();
        col = excludeRegionObj.AddComponent<BoxCollider> ();
        float x = float.Parse (templist[i + 1]);
        float y = float.Parse (templist[i + 2]);
        float width = float.Parse (templist[i + 3]);
        float height = float.Parse (templist[i + 4]);
        float centerPointX = x + (width / 2);
        float centerPointY = y - (height / 2);

        Vector3 size = new Vector3 (width, 1, height);
        col.size = size;

        Vector3 center = new Vector3 (centerPointX, 0, centerPointY);
        col.center = center;
    }

}