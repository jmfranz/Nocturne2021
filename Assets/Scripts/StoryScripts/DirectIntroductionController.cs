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

    private void Awake()
    {
        var defaultRule = RuleInfo.DefaultRule;
        var proximityRule = RuleInfo.ProximityRule;
        var facingRule = RuleInfo.FacingRule;

        var defaultRule1 = defaultRule.FirstListEntities;
        var defaultRule2 = defaultRule.SecondListEntities;
        var proximityRule1 = proximityRule.FirstListEntities;
        var proximityRule2 = proximityRule.SecondListEntities;

        var facingRule1 = new List<Transform>();
        if (facingRule.Entity != null)
        {
            facingRule1 = new List<Transform> { facingRule.Entity };
        }
        //StartCoroutine(SetUpRule());
    }

    //IEnumerator SetUpRule()
    //{
    //    // Wait for Calibration
    //    yield return new WaitUntil(() => ClickPlacer.CalibrationState == ClickPlacer.CalibrationStates.Finished);

    //    var defaultRule = RuleInfo.DefaultRule;
    //    var proximityRule = RuleInfo.ProximityRule;
    //    var facingRule = RuleInfo.FacingRule;

    //    var defaultRule1 = defaultRule.FirstListEntities;
    //    var defaultRule2 = defaultRule.SecondListEntities;
    //    var proximityRule1 = proximityRule.FirstListEntities;
    //    var proximityRule2 = proximityRule.SecondListEntities;

    //    var facingRule1 = new List<Transform>();
    //    if (facingRule.Entity != null)
    //    {
    //        facingRule1 = new List<Transform> { facingRule.Entity };
    //    }

    //    //if (DeploymentOption.Instance.DeploymentType == DeploymentOption.DeploymentTypes.AR)
    //    //{
    //    //    DeploymentOption.Instance.CheckEntity(defaultRule1, "VRPlayerController(Clone)");
    //    //    DeploymentOption.Instance.CheckEntity(defaultRule2, "VRPlayerController(Clone)");
    //    //    DeploymentOption.Instance.CheckEntity(proximityRule1, "VRPlayerController(Clone)");
    //    //    DeploymentOption.Instance.CheckEntity(proximityRule2, "VRPlayerController(Clone)");
    //    //    DeploymentOption.Instance.CheckEntity(facingRule1, "VRPlayerController(Clone)");
    //    //}
    //    //else if (DeploymentOption.Instance.DeploymentType == DeploymentOption.DeploymentTypes.VR)
    //    //{
    //    //    DeploymentOption.Instance.CheckEntity(defaultRule1, "Main Camera");
    //    //    DeploymentOption.Instance.CheckEntity(defaultRule2, "Main Camera");
    //    //    DeploymentOption.Instance.CheckEntity(proximityRule1, "Main Camera");
    //    //    DeploymentOption.Instance.CheckEntity(proximityRule2, "Main Camera");
    //    //    DeploymentOption.Instance.CheckEntity(facingRule1, "Main Camera");
    //    //}
    //}

    void Start()
    {
        _ruleToSwitchToDirectIntro = StoryProxemicUIHost.Instance.AddOrRule(RuleInfo);

        _ruleToSwitchToDirectIntro.OnEventTrue += _ruleToSwitchToDirectIntro_OnEventTrue;
        _ruleToSwitchToDirectIntro.OnEventFalse += _ruleToSwitchToDirectIntro_OnEventFalse;

        _conversationNode = GetComponent<ConversationNode>();
    }

    //IEnumerator SetUpConversationTriggers()
    //{
    //    // Wait for Calibration 
    //    yield return new WaitUntil(() => ClickPlacer.CalibrationState == ClickPlacer.CalibrationStates.Finished);

    //    _ruleToSwitchToDirectIntro = StoryProxemicUIHost.Instance.AddOrRule(RuleInfo);

    //    _ruleToSwitchToDirectIntro.OnEventTrue += _ruleToSwitchToDirectIntro_OnEventTrue;
    //    _ruleToSwitchToDirectIntro.OnEventFalse += _ruleToSwitchToDirectIntro_OnEventFalse;

    //    _conversationNode = GetComponent<ConversationNode>();
    //}


    //    // Update is called once per frame
    //    void Update()
    //{
    //    /*for (int i = 0; i < RuleEngine.Instance.listOfRules.Count; i++)
    //    {
    //        Rules rule = RuleEngine.Instance.listOfRules[i];
    //        RuleEngine.Instance.TestRunner(rule);
    //    }*/

    //    /*bool inRange = _ruleToSwitchToDirectIntro.Test();
    //    bool inRangeChanged = (inRange && !_inRangeBefore) || (!inRange && _inRangeBefore);
    //    _inRangeBefore = inRange;
        

    //    //Transition from general to direct intro when in range
    //    if (inRange)
    //    {
    //        Debug.Log("Conversation Starting");
    //        if(inRangeChanged)
    //        {
    //            if (GeneralLoop != null)
    //            {
    //                GeneralLoop.InteruptConversation();
    //                GeneralLoop.enabled = false;
    //            }

    //            DirectIntroduction.enabled = true;
    //        }

    //        _conversationNode.AllAvatarsLookAt(Camera.main.transform);
    //    }
    //    //Switch back to general conversation once stepped away
    //    else if(!inRange && inRangeChanged)
    //    {
    //        Debug.Log("Conversation Stopping");

    //        DirectIntroduction.InteruptConversation();
    //        DirectIntroduction.enabled = false;

    //        if (GeneralLoop != null)
    //        {
    //            GeneralLoop.enabled = true;
    //        }

    //        _conversationNode.ResetAvatarLookAt();
    //    }
    //    */
    //}

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
