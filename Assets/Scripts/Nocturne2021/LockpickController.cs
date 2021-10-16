using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockpickController : MonoBehaviour
{
    public GameObject lockpick1;
    public GameObject lockpick2;
    public GameObject lockpick3;
    public GameObject lockpick4;
    public GameObject lockpick5;

    public TMPro.TMP_Text noLockpickText;

    public Inventory inventory;

    public AudioSource Source;
    public AudioClip AddedLockpick;

    List<GameObject> allLockpicks;

    public StoryEventComponent storyEventComponent;

    // Start is called before the first frame update
    void Start()
    {
        allLockpicks = new List<GameObject>();

        allLockpicks.Add(lockpick1);
        allLockpicks.Add(lockpick2);
        allLockpicks.Add(lockpick3);
        allLockpicks.Add(lockpick4);
        allLockpicks.Add(lockpick5);
    }

    public void TakeLockpick(GameObject thisLockpick)
    {
        StartCoroutine(TakeLockpickInfoText());
        inventory.AddItem(thisLockpick);
        GameObject.Find("Event Data Synchronization").GetComponent<EventDataSync>().SetEventData("TookLockpick", true);
        storyEventComponent.WriteEventStartRequest("TookLockpick");
        RemoveLockpick(thisLockpick);
    }

    IEnumerator TakeLockpickInfoText()
    {
        noLockpickText.SetText("A lockpick has been added to your inventory");
        Source.PlayOneShot(AddedLockpick);
        yield return new WaitForSeconds(5);
        noLockpickText.SetText(" ");

    }
    
    void RemoveLockpick(GameObject lockpick)
    {
        foreach (GameObject lockpicks in allLockpicks)
        {
            if (lockpick.Equals(lockpicks))
            {
                lockpick.SetActive(false);
            }
        }
    }
}
