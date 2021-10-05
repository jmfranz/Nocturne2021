using ProxemicUIFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTalking : MonoBehaviour
{
    StoryProxemicUIHost.OrRuleInfo orRule;
    bool _waitingForAudioToFinish = false;
    float _timeSinceStart = 0f;

    public DavidStoryControllerPath2BathroomEvent DavidStoryControllerPath2BathroomEvent;
    public AudioSource MainCamera;

    // Start is called before the first frame update
    void Start()
    {
        orRule.RequiredRules = new List<string>();
        orRule.RequiredRules.Add("isFacing");

        StoryProxemicUIHost.IsFacingRulesInfo facingRule = new StoryProxemicUIHost.IsFacingRulesInfo();
        facingRule.Radius = 20f;
        facingRule.isFacing = true;

        Vector3 pos = this.transform.position;
        facingRule.ConversationCenter = new List<float> { pos.x, pos.y, pos.z };
        facingRule.Entity = Camera.main.transform;

        orRule.FacingRule = facingRule;
        ORRule rule = StoryProxemicUIHost.Instance.AddOrRule(orRule);

        rule.OnEventTrue += PlayDialogue;
    }

    void PlayDialogue(Rules rule, ProximityEventArgs proximityEvent)
    {
        DavidStoryControllerPath2BathroomEvent.HighlightSecurityCamera();
        AudioClip audioClip = Resources.Load<AudioClip>("Conversations/All Audio/John_26");
        MainCamera.clip = audioClip;
        MainCamera.Play();
        rule.OnEventTrue -= PlayDialogue;

        _waitingForAudioToFinish = true;
    }

    public void FixedUpdate()
    {
        if (_waitingForAudioToFinish && !MainCamera.isPlaying)
        {
            _waitingForAudioToFinish = false;
            GetComponent<ConversationPlayer>()._hasCompletedConversation = true;
            DavidStoryControllerPath2BathroomEvent.UnHighlightSecurityCamera();
        }
    }
}
