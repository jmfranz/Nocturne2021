using UnityEngine;

public abstract class ContextAwareGuide: MonoBehaviour
{ 
    public TextureTextControl AwareGuide;
    public AudioSource AudioSource;
    public string Room;
    public string EventName = "Game Start";
    public bool EventStatus = true;
    public bool isSpill = true;

    void Awake()
    {
        AudioSource = GetComponent<AudioSource>();

        Debug.Log("game starts!");


        UpdateGuideState(true);

        // This is to allow the switching between Awareguides. If it needs to be changed, that's fine.
        if(isSpill){
            UpdateAwareGuideContent("Spill/MAIN_ROOM_0");
        }else{
            UpdateAwareGuideContent("main_room_1");
        }
    }


    public void OnEventDataChange(string eventName, bool eventStatus)
    {
        Debug.LogFormat("Received '{0}' with status '{1}'", eventName, eventStatus);
        EventName = eventName;
        EventStatus = eventStatus;

        UpdateGuideState(true);
    }


    public void OnRoomChange(string roomname)
    {
        Room = roomname;
        //todo: Remove the Debug when necessary
        Debug.Log("Room Update: " + Room);

        UpdateGuideState(false);
    }


    public virtual void UpdateGuideState(bool eventChange)
    {

    }


    public void UpdateAwareGuideContent(string name)
    {
        AwareGuide.ChangeImage(name);

        AudioSource.clip = Resources.Load<AudioClip>("Conversations/All Audio/AwareGuideConversations/" + name);
        Debug.Log("UPDATE AUDIO CLIP: " + name);
        AudioSource.Play();
    }


    public void RestartAudio()
    {
        if(AudioSource.clip != null)
        {
            AudioSource.Play();
        }
    }


    public void StopAudio()
    {
        if (AudioSource.clip != null)
        {
            AudioSource.Stop();
        }
    }
}
