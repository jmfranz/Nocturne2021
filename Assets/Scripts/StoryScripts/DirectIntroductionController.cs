using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProxemicUIFramework;

//Attach this with a node if there should be a direct introduction
public class DirectIntroductionController : MonoBehaviour
{
    [SerializeField] public StoryProxemicUIHost.OrRuleInfo RuleInfo;
    [SerializeField] public ConversationPlayer GeneralLoop;
    [SerializeField] public ConversationPlayer DirectIntroduction;

    bool _hasTransitionedToDirect = false;
    ORRule _ruleToSwitchToDirectIntro;
    ConversationNode _conversationNode;
    public bool IsPlayerEavesdropping = false;
    bool? isEventTrue = null;

    public Strikes Strikes;

    void Start()
    {
        _ruleToSwitchToDirectIntro = StoryProxemicUIHost.Instance.AddOrRule(RuleInfo);

        _ruleToSwitchToDirectIntro.OnEventTrue += _ruleToSwitchToDirectIntro_OnEventTrue;
        _ruleToSwitchToDirectIntro.OnEventFalse += _ruleToSwitchToDirectIntro_OnEventFalse;

        _conversationNode = GetComponent<ConversationNode>();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void _ruleToSwitchToDirectIntro_OnEventTrue(Rules rule, ProximityEventArgs proximityEvent)
    {
        // This OnEventTrue has already ran
        if (!isEventTrue.HasValue)
        {
            isEventTrue = true;
        }
        else if (isEventTrue.Value)
        {
            return;
        }

        isEventTrue = true;

        //IsPlayerEavesdropping = false;
        if (GeneralLoop != null)
        {
            GeneralLoop.InteruptConversation();
            GeneralLoop.enabled = false;
        }

        DirectIntroduction.enabled = true;

        _conversationNode.AllAvatarsLookAt(Camera.main.transform);
    }

    private void _ruleToSwitchToDirectIntro_OnEventFalse(Rules rule, ProximityEventArgs proximityEvent)
    {
        // This OnEventFalse has already ran
        if (!isEventTrue.HasValue)
        {
            isEventTrue = false;
        }
        else if (!isEventTrue.Value)
        {
            return;
        }
        isEventTrue = false;

        DirectIntroduction.InteruptConversation();
        DirectIntroduction.enabled = false;

        if (GeneralLoop != null)
        {
            GeneralLoop.enabled = true;
        }

        _conversationNode.ResetAvatarLookAt();
    }


    // Stops conversation from playing and does not check for changes in the direct introduction (with eavesdropping and talking to player)
    public void InterruptConversation()
    {
        _ruleToSwitchToDirectIntro.OnEventTrue -= _ruleToSwitchToDirectIntro_OnEventTrue;
        _ruleToSwitchToDirectIntro.OnEventFalse -= _ruleToSwitchToDirectIntro_OnEventFalse;

        if (GeneralLoop != null && GeneralLoop.enabled)
        {
            GeneralLoop.enabled = false;
            GeneralLoop.InteruptConversation();
        }
        else if (DirectIntroduction.enabled)
        {
            DirectIntroduction.enabled = false;
            DirectIntroduction.InteruptConversation();
        }
    }
}
