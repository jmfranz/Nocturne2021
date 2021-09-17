using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterOverride : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CharacterController controller = GetComponent<CharacterController>();
        controller.detectCollisions = false;
    }
}
