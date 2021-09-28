using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewController : MonoBehaviour
{
    //Information from scroll view
    public GameObject ScrollViewItemGameObject;
    public Transform ScrollViewItemTransform; //copy of original position
    public GameObject NoScrollViewItemText;
    public GameObject Content;
    public GameObject ScrollBarVertical;

    public List<GameObject> ScrollViewItems = new List<GameObject>();

    
    public void PopulateScrollViewItems(int size)
    {
        ResetScrollViewGameObjects();

        //Reset Scroll Bar
        ScrollBarVertical.GetComponent<Scrollbar>().value = 1;
        ScrollViewItemGameObject.SetActive(true);

        if (size == 0)
        {
            NoScrollViewItemText.SetActive(true);
        }
        else
        {
            NoScrollViewItemText.SetActive(false);
        }


        int yJump = -60;
        for(int i = 0; i < size; i++)
        {
            //Get position of prefab
            Vector3 pos = ScrollViewItemTransform.GetComponent<RectTransform>().localPosition;

            //Instantiate a new GameObject
            GameObject newScrollViewItem = Instantiate(ScrollViewItemGameObject, new Vector3(0, pos.y + i * yJump, pos.z), ScrollViewItemTransform.rotation);
            newScrollViewItem.transform.SetParent(ScrollViewItemGameObject.transform.parent.transform, false);

            ScrollViewItems.Add(newScrollViewItem);
        }

        //Update the height of the container content to hold enough rows of story elements
        int dynamicHeight = Math.Abs(yJump * (ScrollViewItems.Count + 1));

        RectTransform rT = Content.GetComponent<RectTransform>();
        rT.sizeDelta = new Vector2(rT.sizeDelta.x, dynamicHeight);

        //Make original GameObject invisible
        ScrollViewItemGameObject.SetActive(false);
    }

    void ResetScrollViewGameObjects()
    {
        for(int i = 0; i < ScrollViewItems.Count; i++)
        {
            Destroy(ScrollViewItems[i]);
        }

        ScrollViewItems = new List<GameObject>();
    }

    public List<GameObject> GetScrollViewGameObjects()
    {
        return ScrollViewItems;
    }

}
