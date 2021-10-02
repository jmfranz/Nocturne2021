using UnityEngine;
using System;


public class ContextAwareGuide : MonoBehaviour
{
    
    public TextureTextControl aware;
    AudioSource audioContext;
    private string _room;
    private string _eventName;
    private bool _eventStatus;
    private string _securityroomState;
    private string _lastRoomState;
    private string _dogsRoomState;
    private string _washroomState;
    private string _mainroomState;
    private string _astronomyRoomState;

    private void Awake()
    {
    
        
        
     
 


}

void Start()
    {
        
       
        audioContext = GetComponent<AudioSource>();

        Debug.Log("Game starts!");
 
        aware.ChangeImage("MAIN_ROOM_1");
        audioContext.clip = Resources.Load<AudioClip>("Conversations/All Audio/AwareGuideConversations/MAIN_ROOM_1");
        audioContext.Play();
        Debug.Log(audioContext.clip.name);

    }

   

    public void OnEventDataChange(string eventName, bool eventStatus)
    {
        Debug.LogFormat("Received '{0}' with status '{1}'", eventName, eventStatus);
        _eventName = eventName;
        _eventStatus = eventStatus;

        UpdateGuideState();
    }


    public void OnRoomChange(string roomname)
    {





           _room = roomname;
            Debug.Log(_room);

            UpdateGuideState();
       



    }

    void UpdateGuideState()
    {
        if (_room == "WASHROOM" && _eventName != "Start Chase" && !_eventStatus)
        {
            Debug.Log("Story starts");
            aware.ChangeImage("WASHROOM_1");
            _washroomState = "WASHROOM_1";
            //Play Conversation
            audioContext.clip = Resources.Load<AudioClip>("Conversations/All Audio/AwareGuideConversations/WASHROOM_1​​​");
            audioContext.Play();

        }
        else if (_eventName == "Game Start" && _eventStatus && _room != "MAINROOM")
        {
            aware.ChangeImage("WRONG_ROOM_1"); //image needs to be changed
            
        }
        else if (_eventName == "Game Start" && _eventStatus && _room == "MAINROOM")
        {
            aware.ChangeImage("MAINROOM_1"); //image needs to be changed
            _mainroomState = "MAINROOM_1";
            //Play Conversation
            audioContext.clip = Resources.Load<AudioClip>("Conversations/All Audio/AwareGuideConversations/MAIN_ROOM_1​​​");
            audioContext.Play();
            
        }
        else if (_eventName == "Game Start" && !_eventStatus && _room == "MAINROOM")
        {
            aware.ChangeImage("MAINROOM_2");
            _mainroomState = "MAINROOM_2";
            //Play Conversation
            audioContext.clip = Resources.Load<AudioClip>("Conversations/All Audio/AwareGuideConversations/MAIN_ROOM_2​​​");
            audioContext.Play();
        }
        else if (_eventName == "Ending John enters Main Room" && !_eventStatus && _room == "MAINROOM")
        {
            aware.ChangeImage("MAINROOM_3");
            _mainroomState = "MAINROOM_3";
            //Play Conversation
            audioContext.clip = Resources.Load<AudioClip>("Conversations/All Audio/AwareGuideConversations/MAIN_ROOM_3​​");
            audioContext.Play();
        }
        else if (_eventName == "Ending John enters Main Room No" && !_eventStatus && _room == "MAINROOM")
        {
            aware.ChangeImage("MAINROOM_4");
            _mainroomState = "MAINROOM_4";
            //Play Conversation
            audioContext.clip = Resources.Load<AudioClip>("Conversations/All Audio/AwareGuideConversations/MAIN_ROOM_4​​​");
            audioContext.Play();
        }
        else if (_eventName == "Entered Security Room" && !_eventStatus && _room == "SECURITYROOM")
        {
            Debug.Log("Entered security room");
            aware.ChangeImage("SECURITYROOM_2");
            _securityroomState = "SECURITYROOM_2"; 
            //Play Conversation
            audioContext.clip = Resources.Load<AudioClip>("Conversations/All Audio/AwareGuideConversations/SECURITY_ROOM_2");
            audioContext.Play();


        }
        else if (_eventName == "Game Start" && !_eventStatus && _room == "SECURITYROOM")
        {
            Debug.Log("Entered security room");
            aware.ChangeImage("SECURITYROOM_1");
            _securityroomState = "SECURITYROOM_1";
            //Play Conversation
            audioContext.clip = Resources.Load<AudioClip>("Conversations/All Audio/AwareGuideConversations/SECURITY_ROOM_1");
            audioContext.Play();

        }
        else if (_eventName == "Start Chase" && _eventStatus && _room != "SECURITYROOM")
        {
            Debug.Log("Entered security room");
            aware.ChangeImage("ALL_OTHER_SPACES_1");
            _securityroomState = "ALL_OTHER_SPACES_1";
            //Play Conversation
            audioContext.clip = Resources.Load<AudioClip>("Conversations/All Audio/AwareGuideConversations/ALL_OTHER_SPACES_1");
            audioContext.Play();

        }

        else if (_eventName == "Start Chase" && _eventStatus && _room == "SECURITYROOM")
        {
            Debug.Log("Start chase!");
            aware.ChangeImage("SECURITYROOM_3");
            _securityroomState = "SECURITYROOM_3";
            //Play Conversation
            audioContext.clip = Resources.Load<AudioClip>("Conversations/All Audio/AwareGuideConversations/SECURITY_ROOM_1");
            audioContext.Play();
        }
        else if (_eventName == "Escaped Shadow" && !_eventStatus && _room == "SECURITYROOM")
        {
            Debug.Log("Escaped shadow");
            aware.ChangeImage("SECURITYROOM_4");
            _securityroomState = "SECURITYROOM_4";

            //Play Conversation
            audioContext.clip = Resources.Load<AudioClip>("Conversations/All Audio/AwareGuideConversations/SECURITY_ROOM_4");
            audioContext.Play();
        }
        else if (_eventName == "Start Chase" && !_eventStatus && _room == "DOGSROOM")
        {
            Debug.Log("Player entered the dog room on chase");
            aware.ChangeImage("DOGS_ROOM_2");
            _dogsRoomState = "DOGS_ROOM_2";

            //Play Conversation
            audioContext.clip = Resources.Load<AudioClip>("Conversations/All Audio/AwareGuideConversations/DOGS_ROOM_2");
            audioContext.Play();

        }
        else if (_eventName == "Game Start" && !_eventStatus && _room == "DOGSROOM")
        {
            Debug.Log("Player entered the dog room");
            aware.ChangeImage("DOGS_ROOM_1");
            _dogsRoomState = "DOGS_ROOM_1";

            //Play Conversation
            audioContext.clip = Resources.Load<AudioClip>("Conversations/All Audio/AwareGuideConversations/DOGS_ROOM_1");
            audioContext.Play();

        }
        else if (_eventName == "Player entered dog room" && !_eventStatus && _room == "DOGSROOM")
        {
            Debug.Log("Player entered the dog room");
            aware.ChangeImage("DOGS_ROOM_1");
            _dogsRoomState = "DOGS_ROOM_1";
            //Play Conversation
            audioContext.clip = Resources.Load<AudioClip>("Conversations/All Audio/AwareGuideConversations/DOGS_ROOM_1");
            audioContext.Play();
        }
        else if (_eventName == "No don't trust dog" && !_eventStatus && _room == "DOGSROOM")
        {
            Debug.Log("Don't trust the dog");
            aware.ChangeImage("DOGS_ROOM_3");
            _dogsRoomState = "DOGS_ROOM_3";
            //Play Conversation
            audioContext.clip = Resources.Load<AudioClip>("Conversations/All Audio/AwareGuideConversations/DOGS_ROOM_3");
            audioContext.Play();
        }
        else if (_eventName == "Yes trust dog" && !_eventStatus && _room == "DOGSROOM")
        {
            Debug.Log("Trust the dog");
            aware.ChangeImage("DOGS_ROOM_2");
            _dogsRoomState = "DOGS_ROOM_2";
            //Play Conversation
            audioContext.clip = Resources.Load<AudioClip>("Conversations/All Audio/AwareGuideConversations/DOGS_ROOM_2");
            audioContext.Play();
        }
        else if (_eventName == "Ending John enters Main Room" && !_eventStatus && _room == "LASTROOM") //For ending like I trust the dog
        {
            Debug.Log("Ending john enters the main room");
            aware.ChangeImage("LAST_ROOM_2");
            _lastRoomState = "LAST_ROOM_2"; 
                //Play Conversation
            audioContext.clip = Resources.Load<AudioClip>("Conversations/All Audio/AwareGuideConversations/LAST_ROOM_1");
            audioContext.Play();

        }
        else if (_eventName == "Entered Astronomy Room" && !_eventStatus && _room == "ASTRONOMYROOM")
        {
            Debug.Log("Entering the astronmy room");
            aware.ChangeImage("ASTRONOMY_ROOM_2");
            _astronomyRoomState = "ASTRONOMY_ROOM_2";
            //Play Conversation
            audioContext.clip = Resources.Load<AudioClip>("Conversations/All Audio/AwareGuideConversations/ASTRONOMY_ROOM_2");
            audioContext.Play();
        }
        else if(_eventName =="Game Starts" && !_eventStatus && _room == "ASTRONOMYROOM")
        {
            Debug.Log("Entering the astronmy room");
            aware.ChangeImage("ASTRONOMY_ROOM_1");
            _astronomyRoomState = "ASTRONOMY_ROOM_1";
            //Play Conversation
            audioContext.clip = Resources.Load<AudioClip>("Conversations/All Audio/AwareGuideConversations/ASTRONOMY_ROOM_1");
            audioContext.Play();
        }
        else if (_eventName == "Start Chase" && !_eventStatus && _room == "ASTRONOMYROOM")
        {
            Debug.Log("Entering the astronmy room"); 
            aware.ChangeImage("ASTRONOMY_ROOM_1");
            _astronomyRoomState = "ASTRONOMY_ROOM_1";
            //Play Conversation
            audioContext.clip = Resources.Load<AudioClip>("Conversations/All Audio/AwareGuideConversations/ASTRONOMY_ROOM_1");
            audioContext.Play();
        }
        else if (_eventName == "Escaped Shadow" && !_eventStatus && _room == "ASTRONOMYROOM")
        {
            Debug.Log("Entering the astronmy room");
            aware.ChangeImage("ASTRONOMY_ROOM_1");
            _astronomyRoomState = "ASTRONOMY_ROOM_1";
            //Play Conversation
            audioContext.clip = Resources.Load<AudioClip>("Conversations/All Audio/AwareGuideConversations/ASTRONOMY_ROOM_1");
            audioContext.Play();
        }
        else if (_eventName == "Finished Reading Mural" && !_eventStatus && _room == "ASTRONOMYROOM")
        {
            Debug.Log("Finished reading the mural");
            aware.ChangeImage("ASTRONOMY_ROOM_3");
            _astronomyRoomState = "ASTRONOMY_ROOM_3";
            //Play Conversation
            audioContext.clip = Resources.Load<AudioClip>("Conversations/All Audio/AwareGuideConversations/ASTRONOMY_ROOM_3");
            audioContext.Play();
        }
        else if (_eventName == "Shadow Disappears" && !_eventStatus && _room == "ASTRONOMYROOM")
        {
            Debug.Log("Shadow disappears");
            aware.ChangeImage("ASTRONOMY_ROOM_4");
            _astronomyRoomState = "ASTRONOMY_ROOM_4";
            //Play Conversation
            audioContext.clip = Resources.Load<AudioClip>("Conversations/All Audio/AwareGuideConversations/ASTRONOMY_ROOM_4");
            audioContext.Play();
        }
        else if (_eventName == "Ending John enters Main Room No" && !_eventStatus && _room == "LASTROOM")
        {
            Debug.Log("Ending John enters Main Room No");
            aware.ChangeImage("LAST_ROOM_1");
            _lastRoomState = "LAST_ROOM_1";
            //Play Conversation
            audioContext.clip = Resources.Load<AudioClip>("Conversations/All Audio/AwareGuideConversations/LAST_ROOM_1");
            audioContext.Play();
        }

        else if (_room == "SECURITYROOM")
        {
            aware.ChangeImage(_securityroomState);
            //Play Conversation
            
        }
        else if (_room == "LASTROOM")
        {
            aware.ChangeImage(_lastRoomState);
            
        }
        else if (_room == "MAINROOM")
        {
            aware.ChangeImage(_mainroomState);
            
        }
        else if (_room == "WASHROOM")
        {
            aware.ChangeImage(_washroomState);
        }
        else if (_room == "ASTRONOMYROOM")
        {
            aware.ChangeImage(_astronomyRoomState);
        }
        else if (_room == "DOGSROOM")
        {
            aware.ChangeImage(_dogsRoomState);
        }
    }
    public void restartAudio()
    {
        if(audioContext.clip != null)
        {
            audioContext.Play();
        }
    }
}
