using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
    private Animator animator;
    public bool doorOpened = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (doorOpened)
        {
            Debug.Log("Set to true");
            animator.SetBool("doorOpen", true);
        }
        
    }
}
