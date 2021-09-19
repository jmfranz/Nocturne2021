using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    float timeElapsed;
    float lerpDuration = 1;
    public Vector3 initialStartRotation;
    public Vector3 initialEndRotation;
    Vector3 valueToLerp;
    bool isOpening = false;

    public GameObject Door;
    public FokthipurRoomController roomController;

    public enum DoorStatus { Open, Close }
    public DoorStatus Status = DoorStatus.Close; // At RunTime Door is closed 


    public IEnumerator MoveDoor(Vector3 start, Vector3 end)
    {
        float timeElapsed = 0;

        while (timeElapsed < lerpDuration)
        {
            float t = timeElapsed / lerpDuration;
            t = t * t * (3f - 2f * t);
            valueToLerp = Vector3.Lerp(start, end, t);

            Door.transform.localRotation = Quaternion.Euler(valueToLerp.x, valueToLerp.y, valueToLerp.z);
            timeElapsed += Time.deltaTime;

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
                return;
            case (DoorStatus.Open):
                Status = DoorStatus.Close;
                return;
        }

    }
}