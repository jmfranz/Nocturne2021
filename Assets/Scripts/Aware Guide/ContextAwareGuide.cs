using UnityEngine;
using System;
//using Vuplex.WebView;

public class ContextAwareGuide : MonoBehaviour
{
   // WebViewPrefab _webViewPrefab;
   // WebViewPrefab _webViewPrefab2;
   // WebViewPrefab _webViewPrefab3;
   // WebViewPrefab _webViewPrefab4;
    public float nextGuide = 0.0f;
    public float period = 20.0f;
    public int count = 1;
    TextureTextControl aware;

    private string _room;
    private string _eventName;
    private bool _eventStatus;

    private void Awake()
    {
        aware = GameObject.Find("AwareGuide").GetComponent<TextureTextControl>();

    }
    //public AroundDisplayLong script;
    // Start is called before the first frame update
    void Start()
    {
        // Create a 0.6 x 0.3 instance of the prefab.
        //  _webViewPrefab = WebViewPrefab.Instantiate(2, 1);
        //  _webViewPrefab.transform.parent = transform;
        //  _webViewPrefab.transform.localPosition = new Vector3(1, 1, 1);
        //  _webViewPrefab.transform.localEulerAngles = new Vector3(0, 180, 0);
        //   _webViewPrefab.SetCutoutRect(new Rect(0, 0, 1, 1));
        //  _webViewPrefab.Initialized += (sender, e) => {
        //    _webViewPrefab.WebView.LoadUrl("http://134.190.132.41:8080/Context/ASTRONOMYROOM1.html");
        // };

        Debug.Log("Game starts!");

        aware.ChangeImage("MAIN_ROOM_1");

    }

    // Update is called once per frame
    void Update()
    {
        // if (Time.time > nextGuide && count < 5)
       /// {
           // nextGuide += period;
            
           // if (count == 2)
           // {
               // _webViewPrefab.Destroy();
                // Create a 0.6 x 0.3 instance of the prefab.
               // _webViewPrefab2 = WebViewPrefab.Instantiate(2, 1);
            //    _webViewPrefab2.transform.parent = transform;
              //  _webViewPrefab2.transform.localPosition = new Vector3(0, 1, 1);
              //  _webViewPrefab2.transform.localEulerAngles = new Vector3(0, 180, 0);
              //  _webViewPrefab2.SetCutoutRect(new Rect(0, 0, 1, 1));
              //  _webViewPrefab.Initialized += (sender, e) =>
              //  {
             //       _webViewPrefab.WebView.LoadUrl("http://134.190.133.9:8080/Context/ASTRONOMYROOM2.html");
              //  };
           // }
          //  if (count == 3)
              
           // {  // Create a 0.6 x 0.3 instance of the prefab.
               //  _webViewPrefab2.Destroy();
               //  _webViewPrefab3 = WebViewPrefab.Instantiate(2, 1);
               // _webViewPrefab3.transform.parent = transform;
               // _webViewPrefab3.transform.localPosition = new Vector3(0, 1, 1);
               // _webViewPrefab3.transform.localEulerAngles = new Vector3(0, 180, 0);
               // _webViewPrefab3.SetCutoutRect(new Rect(0, 0, 1, 1));
               // _webViewPrefab.Initialized += (sender, e) =>
              //  {
                   // _webViewPrefab.WebView.LoadUrl("http://134.190.133.9:8080/Context/ASTRONOMYROOM4.html");
               // };
           // }
          //  if (count == 4)
          //  {
                //_webViewPrefab3.Destroy();
                // Create a 0.6 x 0.3 instance of the prefab.
               // _webViewPrefab4 = WebViewPrefab.Instantiate(2, 1);
               // _webViewPrefab4.transform.parent = transform;
               // _webViewPrefab4.transform.localPosition = new Vector3(0, 1, 1);
               // _webViewPrefab4.transform.localEulerAngles = new Vector3(0, 180, 0);
               // _webViewPrefab4.SetCutoutRect(new Rect(0, 0, 1, 1));
              //  _webViewPrefab.Initialized += (sender, e) =>
              //  {
             //       _webViewPrefab.WebView.LoadUrl("http://134.190.133.9:8080/Context/DOGSROOM1.html");
              //  };
           // }
           // count++;
        //}

    }

    public void OnEventDataChange(string eventName, bool eventStatus)
    {
        Debug.LogFormat("Received '{0}' with status '{1}'", eventName, eventStatus);
        _eventName = eventName;
        _eventStatus = eventStatus;

        UpdateGuideState();
    }

    
    private void OnTriggerEnter(Collider other)
    {

        //aware.ChangeImage("WASHROOM_1");


        if (other.gameObject.tag == "Room")
        {
            _room = other.gameObject.name;
            Debug.Log(_room);

            UpdateGuideState();
        }


       //else if (other.gameObject.name == "SECURITYROOM")
       // {

       //     Debug.Log("Entered security room");
       //     //aware.ChangeImage("SECURITY_ROOM_2");
       //     room = "SECURITYROOM";
       // }
       // else if (other.gameObject.name == "MAINROOM")
       // {

       //     Debug.Log("Entered Main room");
       //    // aware.ChangeImage("MAIN_ROOM_1");
       //     room = "MAINROOM";

       // }
       // else if (other.gameObject.name == "ASTRONOMYROOM")
       // {

       //     Debug.Log("Entered Main room");
       //     //aware.ChangeImage("ASTRONOMYROOM_1");
       //     room = "ASTRNOMYROOM";
       // }
       // else if (other.gameObject.name == "LASTROOM")
       // {

       //     Debug.Log("Entered Main room");
       //     aware.ChangeImage("LASTROOM_1");
       //     room = "LASTROOM";
       // }
       // else if (other.gameObject.name == "DOGSROOM")
       // {

       //     Debug.Log("Entered Main room");
       //     aware.ChangeImage("DOGSROOM");
       //     room = "DOGSROOM";
       // }
        // if(other.gameObject.name == "Box Collide 2")
        //{
        //  _webViewPrefab.WebView.LoadUrl("http://134.190.132.41:8080/Context/ASTRONOMYROOM2.html");
        //}
        //if (other.gameObject.name == "MAIN_ROOM1")
        // {
        //   _webViewPrefab.WebView.LoadUrl("http://134.190.132.41:8080/Context/MAINROOM1.html");
        // }
        // if (other.gameObject.name == "LAST_ROOM1")
        // {
        //   _webViewPrefab.WebView.LoadUrl("http://134.190.132.41:8080/Context/LASTROOM1.html");
        //}
        // if (other.gameObject.name == "ASTRONOMY_ROOM1")
        // {
        //   _webViewPrefab.WebView.LoadUrl("http://134.190.132.41:8080/Context/ASTRONOMYROOM1.html");
        // }
        // if (other.gameObject.name == "DOGS_ROOM1")
        // {
        //   _webViewPrefab.WebView.LoadUrl("http://134.190.132.41:8080/Context/DOGSROOM1.html");
        // }
        // if (other.gameObject.name == "WASHROOM_1")
        // {
        //   _webViewPrefab.WebView.LoadUrl("http://134.190.132.41:8080/Context/MAINROOM1.html");
        // }
    }

    void UpdateGuideState()
    {
        if (_eventName == "Game Start" && !_eventStatus && _room == "WASHROOM")
        {
            Debug.Log("Story starts");
            aware.ChangeImage("WASHROOM_1");

        }

        else if (_eventName == "Entered Security Room" && !_eventStatus && _room == "WASHROOM")
        {
            Debug.Log("Entered security room");
            aware.ChangeImage("SECURITYROOM_1");

        }

        else if (_eventName == "Start Chase" && _eventStatus && _room == "SECURITYROOM")
        {
            Debug.Log("Start chase!");
            aware.ChangeImage("SECURITYROOM_3");
        }
        else if (_eventName == "Escaped Shadow" && !_eventStatus && _room == "SECURITYROOM")
        {
            Debug.Log("Escaped shadow");
            aware.ChangeImage("SECURITYROOM_4");
        }
        else if (_eventName == "Player entered dog room" && !_eventStatus && _room == "DOGSROOM")
        {
            Debug.Log("Player entered the dog room");
            aware.ChangeImage("DOGS_ROOM_1");
        }
        else if (_eventName == "No don't trust dog" && !_eventStatus && _room == "DOGSROOM")
        {
            Debug.Log("Don't trust the dog");
            aware.ChangeImage("DOGS_ROOM_3");
        }
        else if (_eventName == "Yes trust dog" && !_eventStatus && _room == "DOGSROOM")
        {
            Debug.Log("Trust the dog");
            aware.ChangeImage("DOGS_ROOM_2");
        }
        else if (_eventName == "Ending John enters Main Room" && !_eventStatus && _room == "LASTROOM") //For ending like I trust the dog
        {
            Debug.Log("Ending john enters the main room");
            aware.ChangeImage("LAST_ROOM_2");
        }
        else if (_eventName == "Entered Astronomy Room" && !_eventStatus && _room == "ASTRONOMYROOM")
        {
            Debug.Log("Entering the astronmy room");
            aware.ChangeImage("ASTRONOMY_ROOM_1");
        }
        else if (_eventName == "Finished Reading Mural" && !_eventStatus && _room == "ASTRONOMYROOM")
        {
            Debug.Log("Finished reading the mural");
            aware.ChangeImage("ASTRONOMY_ROOM_3");
        }
        else if (_eventName == "Shadow Disappears" && !_eventStatus && _room == "ASTRONOMYROOM")
        {
            Debug.Log("Shadow disappears");
            aware.ChangeImage("ASTRONOMY_ROOM_4");
        }
        else if (_eventName == "Ending John enters Main Room No" && !_eventStatus && _room == "LASTROOM")
        {
            Debug.Log("Ending John enters Main Room No");
            aware.ChangeImage("LAST_ROOM_1");
        }
    }
}
