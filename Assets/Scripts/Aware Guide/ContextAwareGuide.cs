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
    public string room;
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

        if(eventName =="Game Start" && !eventStatus && room=="WASHROOM")
        {
            Debug.Log("Story starts");
            aware.ChangeImage("WASHROOM_1");
            
        }
       
       else if(eventName == "Entered Security Room" && !eventStatus && room == "WASHROOM")
        {
            Debug.Log("Entered security room");
            aware.ChangeImage("SECURITYROOM_1");
            
        }
        
       else if(eventName == "Start Chase" && eventStatus && room == "SECURITYROOM")
        {
            Debug.Log("Start chase!");
            aware.ChangeImage("SECURITYROOM_3");
        }
        else if(eventName== "Escaped Shadow" && !eventStatus && room == "SECURITYROOM")
        {
            Debug.Log("Escaped shadow");
            aware.ChangeImage("SECURITYROOM_4");
        }
        else if(eventName== "Player entered dog room" && !eventStatus && room == "DOGSROOM")
        {
            Debug.Log("Player entered the dog room");
            aware.ChangeImage("DOGS_ROOM_1");
        }
        else if(eventName== "No don't trust dog" && !eventStatus && room == "DOGSROOM")
        {
            Debug.Log("Don't trust the dog");
            aware.ChangeImage("DOGS_ROOM_3");
        }
        else if(eventName== "Yes trust dog" && !eventStatus && room == "DOGSROOM")
        {
            Debug.Log("Trust the dog");
            aware.ChangeImage("DOGS_ROOM_2");
        }
        else if(eventName== "Ending John enters Main Room" && !eventStatus && room == "LASTROOM") //For ending like I trust the dog
        {
            Debug.Log("Ending john enters the main room");
            aware.ChangeImage("LAST_ROOM_2");
        }
        else if(eventName== "Entered Astronomy Room" && !eventStatus && room == "ASTRONOMYROOM")
        {
            Debug.Log("Entering the astronmy room");
            aware.ChangeImage("ASTRONOMY_ROOM_1");
        }
        else if(eventName== "Finished Reading Mural" && !eventStatus && room == "ASTRONOMYROOM")
        {
            Debug.Log("Finished reading the mural");
            aware.ChangeImage("ASTRONOMY_ROOM_3");
        }
        else if(eventName== "Shadow Disappears" && !eventStatus && room == "ASTRONOMYROOM")
        {
            Debug.Log("Shadow disappears");
            aware.ChangeImage("ASTRONOMY_ROOM_4");
        }
        else if(eventName== "Ending John enters Main Room No" && !eventStatus && room == "LASTROOM")
        {
            Debug.Log("Ending John enters Main Room No");
            aware.ChangeImage("LAST_ROOM_1");
        }
    }

    
    private void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.name == "WASHROOM")
        {

            Debug.Log("Entered washroom");
            aware.ChangeImage("WASHROOM_1");
            room = "WASHROOM";
        }
       else if (other.gameObject.name == "SECURITYROOM")
        {

            Debug.Log("Entered security room");
            aware.ChangeImage("SECURITY_ROOM_2");
            room = "SECURITYROOM";
        }
        else if (other.gameObject.name == "MAINROOM")
        {

            Debug.Log("Entered Main room");
            aware.ChangeImage("MAIN_ROOM_1");
            room = "MAINROOM";

        }
        else if (other.gameObject.name == "ASTRONOMYROOM")
        {

            Debug.Log("Entered Main room");
            aware.ChangeImage("ASTRONOMYROOM_1");
            room = "ASTRNOMYROOM";
        }
        else if (other.gameObject.name == "LASTROOM")
        {

            Debug.Log("Entered Main room");
            aware.ChangeImage("LASTROOM_1");
            room = "LASTROOM";
        }
        else if (other.gameObject.name == "DOGSROOM")
        {

            Debug.Log("Entered Main room");
            aware.ChangeImage("DOGSROOM");
            room = "DOGSROOM";
        }
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
}
