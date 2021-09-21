﻿using ProxemicUIFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTalking : MonoBehaviour
{
    StoryProxemicUIHost.OrRuleInfo orRule;

    public DavidStoryControllerPath2BathroomEvent DavidStoryControllerPath2BathroomEvent;

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
        AudioClip audioClip = Resources.Load<AudioClip>("Conversations/ConversationLines/John_26");

        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(audioClip);
        rule.OnEventTrue -= PlayDialogue;

        StartCoroutine(WaitForAudioToFinish());
    }

    IEnumerator WaitForAudioToFinish()
    {
        yield return new WaitUntil(() => !GetComponent<AudioSource>().isPlaying);

        GetComponent<ConversationPlayer>()._hasCompletedConversation = true;
        DavidStoryControllerPath2BathroomEvent.UnHighlightSecurityCamera();
    }
}