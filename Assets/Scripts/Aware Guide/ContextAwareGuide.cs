using UnityEngine;
using System;
using Vuplex.WebView;

public class ContextAwareGuide : MonoBehaviour
{
    WebViewPrefab _webViewPrefab;
    WebViewPrefab _webViewPrefab2;
    WebViewPrefab _webViewPrefab3;
    WebViewPrefab _webViewPrefab4;
    public float nextGuide = 0.0f;
    public float period = 20.0f;
    public int count = 1;
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

    public void SetEventData(string eventName, bool eventStatus)
    {
        Debug.LogFormat("Received '{0}' with status '{1}'", eventName, eventStatus);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Box Collide")
        {
            
            _webViewPrefab.WebView.LoadUrl("http://134.190.132.41:8080/Context/DOGSROOM1.html");
        }
        if(other.gameObject.name == "Box Collide 2")
        {
            _webViewPrefab.WebView.LoadUrl("http://134.190.132.41:8080/Context/ASTRONOMYROOM2.html");
        }
        if (other.gameObject.name == "MAIN_ROOM1")
        {
            _webViewPrefab.WebView.LoadUrl("http://134.190.132.41:8080/Context/MAINROOM1.html");
        }
        if (other.gameObject.name == "LAST_ROOM1")
        {
            _webViewPrefab.WebView.LoadUrl("http://134.190.132.41:8080/Context/LASTROOM1.html");
        }
        if (other.gameObject.name == "ASTRONOMY_ROOM1")
        {
            _webViewPrefab.WebView.LoadUrl("http://134.190.132.41:8080/Context/ASTRONOMYROOM1.html");
        }
        if (other.gameObject.name == "DOGS_ROOM1")
        {
            _webViewPrefab.WebView.LoadUrl("http://134.190.132.41:8080/Context/DOGSROOM1.html");
        }
        if (other.gameObject.name == "WASHROOM_1")
        {
            _webViewPrefab.WebView.LoadUrl("http://134.190.132.41:8080/Context/MAINROOM1.html");
        }
    }
}
