using System;
using System.Collections.Generic;
using ProxemicUIFramework;

[Serializable]
public class ConversationDialogueData
{
    public bool IsLooping;
    public float LoopBufferTime; //in seconds
    public List<VoiceLineData> VoiceLines;
    public RulesContainer.RuleContainer ConversationRules;
    
    public ConversationDialogueData(bool isLooping, List<VoiceLineData> voiceLines, RulesContainer.RuleContainer rules, float loopBufferTime = 10)
    {
        IsLooping = isLooping;
        VoiceLines = voiceLines;
        LoopBufferTime = loopBufferTime;
        ConversationRules = rules;
    }

    public bool isEmpty()
    {
        return IsLooping == false
            && LoopBufferTime == 0
            && (VoiceLines == null || VoiceLines.Count == 0);
    }
}
