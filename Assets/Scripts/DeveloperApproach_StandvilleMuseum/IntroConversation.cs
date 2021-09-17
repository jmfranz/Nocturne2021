using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is for Standville Museum implementation where player(John) is conversing with Max at the beginning.  
public class IntroConversation : MonoBehaviour
{

    public ConversationPlayer OpeningConvo;
    public GameObject Max;
    public GameObject Player;

    List<ConversationPlayer.VoiceLine> voiceLines;

    public bool fullConvoAdded = false;

    public TimerEventComponent converstationTimer;


    // Start is called before the first frame update
    void Start()
    {
        voiceLines = new List<ConversationPlayer.VoiceLine>();

    }

    // Update is called once per frame
    void Update()
    {
        if (OpeningConvo.enabled && OpeningConvo.IsConversationFinished && !fullConvoAdded)
        {
            CompleteConversation();
        }
        else if (OpeningConvo.IsConversationFinished && fullConvoAdded)
        {
            EndConvoTimer();
        }
    }

    void CompleteConversation()
    {
        //Add the players first response to Max's first line
        ConversationPlayer.VoiceLine voiceLine_PlayerResponse1 = new ConversationPlayer.VoiceLine();
        voiceLine_PlayerResponse1.voiceLine = Resources.Load<AudioClip>("Conversations/ConversationLines/John_1");
        voiceLine_PlayerResponse1.voiceOrigin = Player.GetComponent<AudioSource>();
        voiceLine_PlayerResponse1.volume = ConversationPlayer.VoiceVolumes.Normal;
        voiceLine_PlayerResponse1.beforeVoiceDelay = 0;
        voiceLine_PlayerResponse1.afterVoiceDelay = 0;
        this.voiceLines.Add(voiceLine_PlayerResponse1);

        //Add the players first response to Max's first line
        ConversationPlayer.VoiceLine voiceLine_MaxsResponse1 = new ConversationPlayer.VoiceLine();
        voiceLine_MaxsResponse1.voiceLine = Resources.Load<AudioClip>("Conversations/ConversationLines/Max_2");
        voiceLine_MaxsResponse1.voiceOrigin = Max.GetComponent<AudioSource>();
        voiceLine_MaxsResponse1.volume = ConversationPlayer.VoiceVolumes.Normal;
        voiceLine_MaxsResponse1.beforeVoiceDelay = 0;
        voiceLine_MaxsResponse1.afterVoiceDelay = 0;
        this.voiceLines.Add(voiceLine_MaxsResponse1);

        //Add Max's response
        ConversationPlayer.VoiceLine voiceLine_PlayerResponse2 = new ConversationPlayer.VoiceLine();
        voiceLine_PlayerResponse2.voiceLine = Resources.Load<AudioClip>("Conversations/ConversationLines/John_2");
        voiceLine_PlayerResponse2.voiceOrigin = Player.GetComponent<AudioSource>();
        voiceLine_PlayerResponse2.volume = ConversationPlayer.VoiceVolumes.Normal;
        voiceLine_PlayerResponse2.beforeVoiceDelay = 0;
        voiceLine_PlayerResponse2.afterVoiceDelay = 0;
        this.voiceLines.Add(voiceLine_PlayerResponse2);

        //Add Max's response
        ConversationPlayer.VoiceLine voiceLine_MaxsResponse2 = new ConversationPlayer.VoiceLine();
        voiceLine_MaxsResponse2.voiceLine = Resources.Load<AudioClip>("Conversations/ConversationLines/Max_3");
        voiceLine_MaxsResponse2.voiceOrigin = Max.GetComponent<AudioSource>();
        voiceLine_MaxsResponse2.volume = ConversationPlayer.VoiceVolumes.Normal;
        voiceLine_MaxsResponse2.beforeVoiceDelay = 0;
        voiceLine_MaxsResponse2.afterVoiceDelay = 0;
        this.voiceLines.Add(voiceLine_MaxsResponse2);

        fullConvoAdded = true;
        OpeningConvo._remainingLines = voiceLines;
        OpeningConvo._hasCompletedConversation = false;
    }

    void EndConvoTimer()
    {
        converstationTimer.WaitTime = 2;
        converstationTimer.Status = StoryEventComponent.StoryEventStatus.Running;
    }
}
