using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    float timeElapsed;
    float lerpDuration = 2;
    public Vector3 initialStartRotation;
    public Vector3 initialEndRotation;
    Vector3 valueToLerp;
    bool isOpen = false;
    bool neverOpened = true;

    public GameObject Door;
    public FokthipurRoomController roomController;
    private float speed = 0.5f;


    public enum DoorStatus { Open, Close }
    public DoorStatus Status = DoorStatus.Close; // At RunTime Door is closed 


    private void Update()
    {
        if (neverOpened && isOpen)
        {
           GameObject.Find("Event Data Synchronization").GetComponent<EventDataSync>().SetEventData("InFoksRoom", true);
            neverOpened = false;
        }
    }

    public IEnumerator MoveDoor(Vector3 start, Vector3 end)
    {
        float timeElapsed = 0;

        while (timeElapsed < lerpDuration)
        {
            float t = timeElapsed / lerpDuration;
            t = t * t * (3f - 2f * t);
            valueToLerp = Vector3.Lerp(start, end, t);

            Door.transform.localRotation = Quaternion.Euler(valueToLerp.x, valueToLerp.y, valueToLerp.z);
            timeElapsed += Time.deltaTime * speed;

            yield return null;
        }
        UpdateDoorStatus();
    }

    public void UpdateDoorStatus()
    {
        switch (Status)
        {
            case (DoorStatus.Close):
                Status = DoorStatus.Open;
                isOpen = true;
                return;
            case (DoorStatus.Open):
                Status = DoorStatus.Close;
                isOpen = false;
                return;
        }

    }
}