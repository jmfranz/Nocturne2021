using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;
using System.Linq;
using System;


public class FokthipurRoomController : MonoBehaviour
{
    public GameObject door;
    public GameObject doorLock;
    public GameObject doorChain;
    public GameObject lockpick1;
    public GameObject lockpick2;
    public GameObject lockpick3;
    public GameObject lockpick4;
    public GameObject lockpick5;
    public Inventory inventory;
    public CognitiveWorldSwitch cogs;
    public OpenDoor openDoor;
    public Button UnlockDoorButton;
    public TMPro.TMP_Text noLockpickText;
    public bool doorLocked;
    public GameObject Player;
    public Transform DoorAxis;

    private Dictionary<string, Action> convoSecretKeyword = new Dictionary<string, Action>();
    private KeywordRecognizer keywordRecognizer;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip doorIsLocked;
    [SerializeField] AudioClip doorSound;
    public DoorAnimation doorAnimation;

    List<GameObject> lockpicks;
    float lerpDuration = 1;
    Vector3 valueToLerp;

    public StoryEventComponent storyEventComponent;

    // Start is called before the first frame update
    void Start()
    {
        lockpicks = new List<GameObject>();

        lockpicks.Add(lockpick1);
        lockpicks.Add(lockpick2); 
        lockpicks.Add(lockpick3);
        lockpicks.Add(lockpick4); 
        lockpicks.Add(lockpick5);

        doorLocked = true;
        convoSecretKeyword.Add("Unluck", UnlockDoor);
        convoSecretKeyword.Add("Open", UnlockDoor);

        keywordRecognizer = new KeywordRecognizer(convoSecretKeyword.Keys.ToArray(), ConfidenceLevel.Low);

        //Add the event RecognizeSpeech to the keywordRecognizer object
        keywordRecognizer.OnPhraseRecognized += RecocorgnizedSpeech;

        //Start the object recognizer to use the microphone service on the device.
        keywordRecognizer.Start();
    }

    private void RecocorgnizedSpeech(PhraseRecognizedEventArgs speech)
    {
        convoSecretKeyword[speech.text].Invoke();
    }


    private void Update()
    {
        if (!doorLocked && cogs.isClose(Player, door, 1) && openDoor.Status == OpenDoor.DoorStatus.Close)
        {
            StartCoroutine(openDoor.MoveDoor(openDoor.initialStartRotation, openDoor.initialEndRotation));
        } 
        else if (!doorLocked && !cogs.isClose(Player, door, 1) && openDoor.Status == OpenDoor.DoorStatus.Open)
        {
            
            StartCoroutine(openDoor.MoveDoor(openDoor.initialEndRotation, openDoor.initialStartRotation));

        }
    }

    public void UnlockDoor()
    {
        if (doorLocked)
        {
            foreach (var lockpick in lockpicks)
            {
                if (inventory.CheckInventoryForItem(lockpick))
                {
                    doorLocked = false;
                    doorChain.SetActive(false);
                    doorLock.SetActive(false);
                    StartCoroutine(LockpickInInventory());
                    GameObject.Find("Event Data Synchronization").GetComponent<EventDataSync>().SetEventData("DoorUnlocked", true);

                    storyEventComponent.WriteEventStartRequest("DoorUnlocked");

                    //Stop using the keyword Recorgnizer object
                    keywordRecognizer.Stop();
                    //Door animation
                    doorAnimation.doorOpened = true;
                    Debug.Log("Door has been unlocked");

                    return;
                }
                else
                {
                    StartCoroutine(NoLockpickInInventory());
                    UnlockDoorButton.gameObject.SetActive(true);
                }
            }
        }
    }

    public bool GetIsDoorLocked()
    {
        GameObject.Find("Event Data Synchronization").GetComponent<EventDataSync>().SetEventData("DoorLocked", true);
        storyEventComponent.WriteEventStartRequest("DoorLocked");
        return doorLocked;
    }

    IEnumerator NoLockpickInInventory()
    {
        audioSource.PlayOneShot(doorIsLocked);
        noLockpickText.SetText("There must be something that can help me open this lock");
        yield return new WaitForSeconds(2);
        noLockpickText.SetText(" ");
        UnlockDoorButton.gameObject.SetActive(false);
    }

    IEnumerator LockpickInInventory()
    {
        audioSource.PlayOneShot(doorSound);
        noLockpickText.SetText("Door is unlocked.  Lockpick has been removed from inventory.");
        yield return new WaitForSeconds(2);
        noLockpickText.SetText(" ");
    }
}
