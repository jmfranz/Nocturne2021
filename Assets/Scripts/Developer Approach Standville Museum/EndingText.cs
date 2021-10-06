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
    bool _waitingForEndingText = false;
    float _timeSinceStart = 0f;

    void Awake()
    {
        _text = GetComponent<TextMeshPro>();
    }

    private void OnEnable()
    {
        P2.SetActive(false);
        _text.text = "Thanks for experiencing " + StoryName;
        _waitingForEndingText = true;
    }

    private void FixedUpdate()
    {
        if (_waitingForEndingText)
        {
            if (_timeSinceStart < timeToWaitForFirstMessage)
            {
                _timeSinceStart += Time.deltaTime;
            }
            else
            {
                _waitingForEndingText = false;
                _text.text = "Please give your headset to the docent";
            }
        }
    }
}
