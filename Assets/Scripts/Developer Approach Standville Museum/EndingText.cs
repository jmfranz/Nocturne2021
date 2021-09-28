using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndingText : MonoBehaviour
{
    public string StoryName;
    public GameObject P2;
    [SerializeField] float timeToWaitForFirstMessage; 

    private TextMeshPro _text;

    void Awake()
    {
        _text = GetComponent<TextMeshPro>();
    }

    private void OnEnable()
    {
        P2.SetActive(false);
        _text.text = "Thanks for experiencing " + StoryName;
        StartCoroutine(WaitToReadFirstMessage());
    }

    IEnumerator WaitToReadFirstMessage()
    {
        yield return new WaitForSeconds(timeToWaitForFirstMessage);
        _text.text = "Please give your headset to the docent";
    }
}
