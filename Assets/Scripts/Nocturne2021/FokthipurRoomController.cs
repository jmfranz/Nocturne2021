using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


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


    List<GameObject> lockpicks;
    float lerpDuration = 1;
    Vector3 valueToLerp;

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
    }

    private void Update()
    {
        if (cogs.isClose(Player, doorChain, 2))
        {
            ApproachDoor();
            Debug.Log("Player approached the door");
        }

        if (!doorLocked && cogs.isClose(Player, door, 1) && openDoor.Status == OpenDoor.DoorStatus.Close)
        {
            StartCoroutine(openDoor.MoveDoor(openDoor.initialStartRotation, openDoor.initialEndRotation));
        } 
        else if (!doorLocked && !cogs.isClose(Player, door, 1) && openDoor.Status == OpenDoor.DoorStatus.Open)
        {
            StartCoroutine(openDoor.MoveDoor(openDoor.initialEndRotation, openDoor.initialStartRotation));
        }
    }

    public void ApproachDoor()
    {
        Debug.Log("approach started");
        if (doorLocked)
        {
            Debug.Log("Door has been approached");
            UnlockDoorButton.gameObject.SetActive(true);
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
                    UnlockDoorButton.gameObject.SetActive(false);
                    GameObject.Find("Event Data Synchronization").GetComponent<EventDataSync>().SetEventData("DoorUnlocked", true);
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
        return doorLocked;
    }

    IEnumerator NoLockpickInInventory()
    {
        noLockpickText.SetText("There must be something that can help me open this lock");
        yield return new WaitForSeconds(2);
        noLockpickText.SetText(" ");
        UnlockDoorButton.gameObject.SetActive(false);
    }

    IEnumerator LockpickInInventory()
    {
        noLockpickText.SetText("Door is unlocked.  Lockpick has been removed from inventory.");
        yield return new WaitForSeconds(2);
        noLockpickText.SetText(" ");
    }
}
