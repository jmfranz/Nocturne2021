using System;

[Serializable]
public class VoiceLineData
{
    public string VoiceClip;
    public string VoiceOrigin;
    public float BeforeVoiceDelay; //TODO: Be used at some point
    public float AfterVoiceDelay;  //TODO: Be used at some point
    public ConversationPlayer.VoiceVolumes Volume;

    public VoiceLineData(string voiceClip, string voiceOrigin, ConversationPlayer.VoiceVolumes volume)
    {
        VoiceClip = voiceClip;
        VoiceOrigin = voiceOrigin;
        Volume = volume;
    }
}
