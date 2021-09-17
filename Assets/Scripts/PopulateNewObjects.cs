/*
 * Author: Abbey Singh
 *  This will populate a list of objects on the SelectExternalObjects screen.
 *  If you have a new object to add, please drag the file to the location Assets/Resources/NewObjects.
 */ 

using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopulateNewObjects : MonoBehaviour {

    public GameObject GameManager;
    public GameObject ExternalObjectButton;
    string[] _objectOptions = Directory.GetFiles("Assets/Resources/NewObjects/");

    // Start is called when select object screen is on
    void Start () {
        // empty is currently a place holder for whether or not avatars are loaded.
        if (_objectOptions.Length != 0) {

            //First remove all children of the container
            foreach (Transform child in transform) {
                if(child.name == "NoObjects")
                {
                    child.gameObject.SetActive(false);
                }
                else if (child.name == "NewObjectButton")
                {
                    child.gameObject.SetActive(true);
                }
                else
                {
                    Destroy(child.gameObject);
                }
            }

            // Handle Positioning
            int row = 0;
            int yJump = 50;

            // Instantiate the buttons needed on the fresh container.
            foreach (string objectPath in _objectOptions) {
                if (objectPath.Contains(".meta"))
                {
                    continue;
                }

                string name = objectPath.Substring(objectPath.LastIndexOf("/") + 1, objectPath.Length - objectPath.LastIndexOf("/") 
                                                                                  - Path.GetExtension(objectPath).Length - 1);

                //Loop through children of PreFab Button to find the AvatarImage
                foreach (Transform child in ExternalObjectButton.transform) {
                    if (child.name == "Name") {
                        // Dynamically edit name of avatar to include spaces as opposed to underscores.
                        child.GetComponent<TextMeshProUGUI> ().text = name.Replace ('_', ' ');
                        continue;
                    }
                }

                GameObject objectButtonPrefab = Instantiate(ExternalObjectButton, new Vector3(0, ExternalObjectButton.transform.localPosition.y - row * yJump, 0), 
                                                            ExternalObjectButton.transform.rotation);

                objectButtonPrefab.transform.SetParent(ExternalObjectButton.transform.parent.transform, false);

                //This clickListener will be the function that should be called when a button is clicked.
                objectButtonPrefab.GetComponent<Button> ().onClick.AddListener (() => {
                    GameState.Instance.NewStoryElement();
                    GameState.Instance.SaveReference("NewObjects/" + name);
                    GameManager.GetComponent<CustomizeStoryElementController>().Initialize();
                    GameManager.GetComponent<ControlStandalone>().GoToScreen("CustomizeStoryElement");
                });

                //update row
                row++;
            }


            //Update the height of the container (this) to hold enough rows of buttons
            int dynamicHeight = yJump * row;
            
            RectTransform rT = GetComponent<RectTransform> ();
            rT.sizeDelta = new Vector2 (rT.sizeDelta.x, dynamicHeight);

            ExternalObjectButton.SetActive(false);

        }
        else
        {

            //Set NoObjects gameObject to active
            foreach (Transform child in transform)
            {
                if (child.name == "NoObjects")
                {
                    child.gameObject.SetActive(true);
                }
                else if (child.name == "NewObjectButton")
                {
                    child.gameObject.SetActive(false);
                }
                else
                {
                    Destroy(child.gameObject);
                }
            }
        }
    }
}
