/*
 * Author: Abbey
 * Based off of "PopulateAvatarSelection" with an adaption to populate the selection screen for audio files.
 */

using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class PopulateAudioFiles : MonoBehaviour {

    public GameObject gameManager;
    string[] _audioOptions = Directory.GetFiles("Assets/Resources/Music/");

    public GameObject AudioButton;

    public GameObject ScrollBarVertical;

    void Start () {
        //Reset Scroll Bar
        ScrollBarVertical.GetComponent<Scrollbar>().value = 1;

        // empty is currently a place holder for whether or not avatars are loaded.
        if (_audioOptions.Length != 0) {

            //First remove all children of the container (should only be one, but this covers every case)
            foreach (Transform child in transform) {
                if (child.name != "AudioButton") {
                    Destroy (child.gameObject);
                }
            }

            AudioButton.SetActive(true);

            // Create two variables to handle 'grid' positioning.
            int col = 0;
            int row = -1;
            int yJump = 370;

            // Instantiate the buttons needed on the fresh container.
            foreach (string audioPath in _audioOptions) {
                if (!audioPath.Contains(".meta"))
                {
                    string fileName = Path.GetFileName(audioPath);
                    //GameObject instance = Instantiate(Resources.Load("AudioButton"), gameObject.transform) as GameObject;

                    //Loop through children of PreFab Button to find the AvatarImage
                    foreach (Transform child in AudioButton.transform)
                    {
                        if (child.name == "AudioTitle")
                        {
                            // Dynamically edit name of avatar to include spaces as opposed to underscores.
                            child.GetComponent<Text>().text = fileName.Replace('_', ' ');
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
                    else if (col % 3 == 1)
                    {
                        xPos = 487;
                    }
                    else
                    {
                        xPos = 810;
                    }

                    GameObject audioButtonPrefab = Instantiate(AudioButton, new Vector3(xPos, AudioButton.transform.localPosition.y - row * yJump, 0),
                                                                AudioButton.transform.rotation);

                    audioButtonPrefab.transform.SetParent(AudioButton.transform.parent.transform, false);

                    //This clickListener will be the function that should be called when a button is clicked.
                    audioButtonPrefab.GetComponent<Button>().onClick.AddListener(() => {
                        GameState.Instance.NewStoryElement();
                        GameState.Instance.SaveReference("Music/" + audioPath);
                        gameManager.GetComponent<CustomizeStoryElementController>().Initialize();
                        gameManager.GetComponent<ControlStandalone>().GoToScreen("CustomizeStoryElement");
                    });

                    //This clickListener will be the function that should be called when a playButton is clicked.
                    GameObject playButton = audioButtonPrefab.transform.GetChild(2).gameObject;
                    playButton.GetComponent<Button>().onClick.AddListener(() => {

                        string path = audioPath.Replace("Assets/Resources/", string.Empty);
                        int index = path.LastIndexOf(".");
                        if(index > 0)
                        {
                            path = path.Substring(0, index);
                        }

                        AudioClip clip1 = Resources.Load<AudioClip>(path);
                        AudioSource audio = playButton.GetComponent<AudioSource>();
                        audio.clip = clip1;
                        audio.PlayOneShot(clip1);
                    });

                    // Update the col variable.
                    col++;
                }
            }

            //Update the height of the container (this) to hold enough rows of audio buttons
            int dynamicHeight = yJump * row;
            
            RectTransform rT = GetComponent<RectTransform> ();
            rT.sizeDelta = new Vector2 (rT.sizeDelta.x, dynamicHeight);

            AudioButton.SetActive(false);

        }
        else {
            // If there are no avatars loaded, do nothing.
            Debug.Log ("There is no audio.  Please load at least one audio file in Assets/Music/Audio.");
        }
    }
}
