using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggers : MonoBehaviour
{
    public ContextAwareGuide guide;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {




        if (other.gameObject.tag == "Room")
        {
            guide.OnRoomChange(other.gameObject.name);
        }



    }
}
