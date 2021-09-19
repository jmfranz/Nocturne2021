using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;

public class Inventory : MonoBehaviour
{
    public List<GameObject> inventory;


    // Start is called before the first frame update
    void Start()
    {
        inventory = new List<GameObject>(); 
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void AddItem(GameObject item)
    {
        inventory.Add(item);
        item.SetActive(false);
        Debug.Log(item.name + " has been added to player inventory");
    }

    public bool CheckInventoryForItem(GameObject item)
    {
        if (inventory.Contains(item))
        {
            Debug.Log(item.name + " is in player inventory.");
            return true;
        }
        else
        {
            Debug.Log("Inventory does NOT contain " + item.name);
            return false;
        }
    }

    public void RemoveItem(GameObject item)
    {
        inventory.Remove(item);
        Debug.Log(item.name + " has been successfully removed from player inventory");
    }
}
