using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

/* Author: Jake Moore
 * The purpose of this class is to load a json file, and store its data in a string array.  
 * Once this class is done executing, it will add a spawnObjects script to the gameObject,
 * and call the spawnGameObjects(string[]) function.
 */

public class loadJson : MonoBehaviour
{
    List<string> templist;
    private string jsonFileName;

    public void loadJsonFile() {
        if (jsonFileName.Equals("")) {
            Debug.Log("Please enter a file name to read from (file.json)");
            return;
        }

        //Loads json file from the application.dataPath file path
        string json = File.ReadAllText(Application.dataPath + "/"+jsonFileName);

        //converts json file into a jsonData object with fields populated
        JsonTextReader reader = new JsonTextReader(new StringReader(json));
        templist = new List<string>();

        //read in the json, token by token and store into the string array templist
        while (reader.Read()) {
            if (reader.Value != null) {
                templist.Add(reader.Value.ToString());
            }
        }

        //send array to spawn game objects
        GetComponent<spawnObjects>().spawnGameObjects(templist);
    }
    public void setFilePath(string jsonFileName) {
        this.jsonFileName = jsonFileName;
    }
}

