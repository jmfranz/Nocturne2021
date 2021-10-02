using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollController: MonoBehaviour
{

    public GameObject canvasScroll;

    // Start is called before the first frame update
    void Start()
    {
        canvasScroll.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReadScrollRoutine()
    {
        canvasScroll.SetActive(true);
        StartCoroutine(ReadScroll());
    }

    public void PutDownScroll()
    {
        canvasScroll.SetActive(false);
    }

    IEnumerator ReadScroll()
    {
        yield return new WaitForSeconds(2);
        PutDownScroll();
    }
}
