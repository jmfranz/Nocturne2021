/*
 * Author: Matt Peachey
 *  This will populate images of avatars in the avatar selection screen.
 */ 

using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PopulateAvatarSelection : MonoBehaviour {

    public GameObject gameManager;
    public GameObject AvatarButton;
    string[] _avatarOptions = Directory.GetFiles ("./Assets/Resources/AvatarImages").Select (file => Path.GetFileName (file).Split ('.') [0]).ToArray ();

    // Start is called when select avatar screen is on
    void Start () {
        // empty is currently a place holder for whether or not avatars are loaded.
        if (_avatarOptions.Length != 0) {

            //First remove all children of the container (should only be one, but this covers every case)
            foreach (Transform child in transform) {
                if (child.name != "AvatarButton") {
                    Destroy (child.gameObject);
                }
            }

            AvatarButton.SetActive(true);

            // Create two variables to handle 'grid' positioning.
            int col = 0;
            int row = -1;
            int yJump = 370;
            int i = 0; 

            // Instantiate the buttons needed on the fresh container.
            foreach (string avatarPath in _avatarOptions) {

                i++;
                if (i % 2 == 0)
                {
                    continue;
                }

                //Loop through children of PreFab Button to find the AvatarImage
                foreach (Transform child in AvatarButton.transform) {
                    if (child.name == "AvatarImage") {
                        // Get the RawImage Component and apply an image based on the path of this instace of the main loop.
                        child.GetComponent<RawImage> ().texture = Resources.Load<Texture2D> ("AvatarImages/" + avatarPath);
                        continue;
                    }
                    if (child.name == "AvatarTitle") {
                        // Dynamically edit name of avatar to include spaces as opposed to underscores.
                        child.GetComponent<Text> ().text = avatarPath.Replace ('_', ' ');
                        continue;
                    }
                }

                float xPos = 0;

                //X Position of the Buttons based on which element in the list they are
                if (col % 3 == 0)
                {
                    row++;
                    xPos = 165;
                }
                else if(col % 3 == 1)
                {
                    xPos = 487;
                }
                else
                {
                    xPos = 810;
                }

                GameObject avatarButtonPrefab = Instantiate(AvatarButton, new Vector3(xPos, AvatarButton.transform.localPosition.y - row * yJump, 0), 
                                                            AvatarButton.transform.rotation);

                avatarButtonPrefab.transform.SetParent(AvatarButton.transform.parent.transform, false);

                //This clickListener will be the function that should be called when a button is clicked.
                avatarButtonPrefab.GetComponent<Button> ().onClick.AddListener (() => {

                    GameState.Instance.NewStoryElement();
                    GameState.Instance.SaveReference("Avatars/" + avatarPath);
                    gameManager.GetComponent<CustomizeStoryElementController>().Initialize();
                    gameManager.GetComponent<ControlStandalone>().GoToScreen("CustomizeStoryElement");
                });

                // Update the col variable.
                col++;
            }

            //Update the height of the container (this) to hold enough rows of avatar buttons
            int dynamicHeight = yJump * row;
            
            RectTransform rT = GetComponent<RectTransform> ();
            rT.sizeDelta = new Vector2 (rT.sizeDelta.x, dynamicHeight);

            AvatarButton.SetActive(false);

        }
        else {
            // If there are no avatars loaded, do nothing.
            Debug.Log ("There are no avatars.  Please load at least one avatar in Assets/Avatars.");
        }
    }
}
