using UnityEngine;
using System;


public class ContextAwareGuide : MonoBehaviour
{
    
    public TextureTextControl aware;
    AudioSource audioContext;
    private string _room;
    private string _eventName = "Game Start";
    private bool _eventStatus = true;
    private string _securityroomState;
    private string _lastRoomState;
    private string _dogsRoomState;
    private string _washroomState;
    private string _mainroomState;
    private string _astronomyRoomState;

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

    void UpdateAwareGuideContent(string name)
    {
        aware.ChangeImage(name);

        audioContext.clip = Resources.Load<AudioClip>("Conversations/All Audio/AwareGuideConversations/" + name);
        audioContext.Play();
    }

    void UpdateGuideState()
    {
        if (_eventName == "Game Start" && _eventStatus) // Game not started
        {
            _washroomState = "WASHROOM_0";
            _astronomyRoomState = "WRONG_ROOM_1";
            _dogsRoomState = "WRONG_ROOM_1";
            _lastRoomState = "WRONG_ROOM_1";
            _securityroomState = "WRONG_ROOM_1";
            _mainroomState = "MAIN_ROOM_1";

            if(_room == "WASHROOM")
            {
                UpdateAwareGuideContent(_washroomState);
            }
            else if(_room == "MAINROOM")
            {
                UpdateAwareGuideContent(_mainroomState);
            }
            else
            {
                UpdateAwareGuideContent(_astronomyRoomState);
            }
        }
        else if (_eventName == "Game Start" && !_eventStatus) // Story has started
        {
            _washroomState = "WASHROOM_1";
            _astronomyRoomState = "ASTRONOMY_ROOM_1";
            _dogsRoomState = "DOGS_ROOM_1";
            _lastRoomState = "LAST_ROOM_1";
            _securityroomState = "SECURITY_ROOM_1";
            _mainroomState = "MAIN_ROOM_2";


            if (_room == "WASHROOM")
            {
                UpdateAwareGuideContent(_washroomState);
            }
            else if (_room == "MAINROOM")
            {
                UpdateAwareGuideContent(_mainroomState);
            }
            else if(_room == "ASTRONOMYROOM")
            {
                UpdateAwareGuideContent(_astronomyRoomState);
            }
            else if(_room == "DOGROOM")
            {
                UpdateAwareGuideContent(_dogsRoomState);
            }
            else if (_room == "LASTROOM")
            {
                UpdateAwareGuideContent(_lastRoomState);
            }
            else if (_room == "SECURITYROOM")
            {
                UpdateAwareGuideContent(_securityroomState);
            }
        }
        else if (_eventName == "Entered Security Room" && !_eventStatus)
        {
            _securityroomState = "SECURITYROOM_2";

            if(_room == "SECURITYROOM")
            {
                UpdateAwareGuideContent(_securityroomState);
            }
        }
        else if (_eventName == "Start Chase" && _eventStatus)
        {
            _dogsRoomState = "ALL_OTHER_SPACES_1";
            _washroomState = "ALL_OTHER_SPACES_1";
            _mainroomState = "ALL_OTHER_SPACES_1";
            _astronomyRoomState = "ALL_OTHER_SPACES_1";
            _securityroomState = "SECURITY_ROOM_3";

            if (_room == "SECURITYROOM")
            {
                UpdateAwareGuideContent(_securityroomState);
            }
            else if(_room != "LASTROOM")
            {
                UpdateAwareGuideContent(_lastRoomState);
            }          
        }
        else if (_eventName == "Escaped Shadow" && !_eventStatus)
        {
            _securityroomState = "SECURITYROOM_4";
            _washroomState = "WASHROOM_1";
            _mainroomState = "MAIN_ROOM_2";
            _astronomyRoomState = "ASTRONOMY_ROOM_1";

            if(_room == "WASHROOM")
            {
                UpdateAwareGuideContent(_washroomState);
            }
            else if(_room == "MAINROOM")
            {
                UpdateAwareGuideContent(_mainroomState);    

            }
            else if (_room == "SECURITYROOM")
            {
                UpdateAwareGuideContent(_securityroomState);
            }
            else if (_room == "ASTRONOMYROOM")
            {
                UpdateAwareGuideContent(_astronomyRoomState);
            }
        }
        else if (_eventName == "Player entered dog room" && !_eventStatus)
        {
            _dogsRoomState = "DOGS_ROOM_3";

            if(_room == "DOGSROOM")
            {
                UpdateAwareGuideContent(_dogsRoomState);
            }
        }
        else if(_eventName == "Yes trust dog" && !_eventStatus)
        {
            _lastRoomState = "LAST_ROOM_2";
            if(_room == "LASTROOM")
            {
                UpdateAwareGuideContent(_lastRoomState);
            }
        }
        else if(_eventName == "Ending John enters Main Room" && !_eventStatus)
        {
            _mainroomState = "MAIN_ROOM_3";

            if(_room == "MAINROOM")
            {
                UpdateAwareGuideContent(_mainroomState);
            }
        }
        else if(_eventName == "Ending John enters Main Room No" && !_eventStatus)
        {
            _mainroomState = "MAIN_ROOM_4";

            if ( _room == "MAINROOM")
            {
                UpdateAwareGuideContent(_mainroomState);
            }
        }    
        else if (_eventName == "Entered Astronomy Room" && !_eventStatus)
        {
            _astronomyRoomState = "ASTRONOMY_ROOM_2";

            if(_room == "ASTRONOMYROOM")
            {
                UpdateAwareGuideContent(_astronomyRoomState);
            }
        }
        else if (_eventName == "Finished Reading Mural" && !_eventStatus)
        {
            _astronomyRoomState = "ASTRONOMY_ROOM_3";

            if (_room == "ASTRONOMYROOM")
            {
                UpdateAwareGuideContent(_astronomyRoomState);
            }
        }
        else if (_eventName == "Shadow Disappears" && !_eventStatus)
        {
            _astronomyRoomState = "ASTRONOMY_ROOM_4";

            if (_room == "ASTRONOMYROOM")
            {
                UpdateAwareGuideContent(_astronomyRoomState);
            }
        }
 
        else if (_room == "SECURITYROOM")
        {
            aware.ChangeImage(_securityroomState);
            audioContext.clip = Resources.Load<AudioClip>("Conversations/All Audio/AwareGuideConversations/" + _securityroomState);
            audioContext.Play();
        }
        else if (_room == "LASTROOM")
        {
            aware.ChangeImage(_lastRoomState);
            audioContext.clip = Resources.Load<AudioClip>("Conversations/All Audio/AwareGuideConversations/" + _lastRoomState);
            audioContext.Play();

        }
        else if (_room == "MAINROOM")
        {
            aware.ChangeImage(_mainroomState);
            audioContext.clip = Resources.Load<AudioClip>("Conversations/All Audio/AwareGuideConversations/" + _mainroomState);
            audioContext.Play();

        }
        else if (_room == "WASHROOM")
        {
            aware.ChangeImage(_washroomState);
            audioContext.clip = Resources.Load<AudioClip>("Conversations/All Audio/AwareGuideConversations/" + _washroomState);
            audioContext.Play();
        }
        else if (_room == "ASTRONOMYROOM")
        {
            aware.ChangeImage(_astronomyRoomState);
            audioContext.clip = Resources.Load<AudioClip>("Conversations/All Audio/AwareGuideConversations/" + _astronomyRoomState);
            audioContext.Play();
        }
        else if (_room == "DOGSROOM")
        {
            aware.ChangeImage(_dogsRoomState);
            audioContext.clip = Resources.Load<AudioClip>("Conversations/All Audio/AwareGuideConversations/" + _dogsRoomState);
            audioContext.Play();
        }
    }

    public void restartAudio()
    {
        if(audioContext.clip != null)
        {
            audioContext.Play();
        }
    }

    public void StopAudio()
    {
        if (audioContext.clip != null)
        {
            audioContext.Stop();
        }
    }
}
