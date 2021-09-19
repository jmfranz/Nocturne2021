using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ConversationInstaller : Editor
{
    //Using the blueprint of a conversation node, add component with specified settings
    public static void InstallConversation(ConversationNodeData data)
    {
        GameObject conversationNodeObject = GameObject.Find(data.Title);

        //Add conversation placement details
        ConversationNode conversationNodeComponent = conversationNodeObject.AddComponent<ConversationNode>();
        conversationNodeComponent.Radius = CalculateProxemicRadius(data.InitialPlacedAvatars.Count, data.PlacementType);
        conversationNodeComponent.PlacementType = data.PlacementType;
        conversationNodeComponent.InitialAvatars = new List<GameObject>();

        //Add proxemic tracker
        conversationNodeObject.AddComponent<VirtualProxemicTracker>();

        //Add conversation audio source (used for background noise)
        var audioSource = conversationNodeObject.AddComponent<AudioSource>();
        audioSource.loop = true;
        audioSource.volume = 0.6f;
        audioSource.playOnAwake = false;

        //Instaniate the initial avatars
        foreach (string avatarName in data.InitialPlacedAvatars)
        {
            if(avatarName == "")
            {
                break;
            }
            string avatarReference = GameState.Instance.GetCurrentStoryData().FindStoryElement(avatarName).Reference;
            string avatarPrefabPath = avatarReference + "/Export/" + avatarReference.Split('/')[1];

            GameObject newAvatar = AvatarInstaller.InstantiateAvatar(avatarPrefabPath);
            newAvatar.name = avatarName;

            conversationNodeComponent.InitialAvatars.Add(newAvatar);
        }

        foreach(var avatar in conversationNodeComponent.InitialAvatars)
        {
            avatar.transform.SetParent(conversationNodeObject.transform);
            avatar.transform.localPosition = Vector3.zero;
            avatar.transform.localRotation = Quaternion.identity;
        }

        //TODO: Props maybe?

        //Add conversation dialogue
        ConversationPlayer avatarConversationPlayer = null;
        if(data.ConversationFocusedDialogue != null && !data.ConversationFocusedDialogue.isEmpty())
        {
            avatarConversationPlayer = conversationNodeObject.AddComponent<ConversationPlayer>();
            SetupDialoguePlayer(conversationNodeComponent, avatarConversationPlayer, data.ConversationFocusedDialogue, "ConversationFocused", data.OutOfRangeClip, ChangeContainers(data.ConversationFocusedDialogue.ConversationRules, conversationNodeComponent), data.IncludedAvatars.Count);
        }

        ConversationPlayer playerConversationPlayer = null;
        if (data.PlayerFocusedDialogue != null && !data.PlayerFocusedDialogue.isEmpty())
        {
            playerConversationPlayer = conversationNodeObject.AddComponent<ConversationPlayer>();
            SetupDialoguePlayer(conversationNodeComponent, playerConversationPlayer, data.PlayerFocusedDialogue, "PlayerFocused", data.OutOfRangeClip, ChangeContainers(data.PlayerFocusedDialogue.ConversationRules, conversationNodeComponent), data.IncludedAvatars.Count);
        }


        //Add a controller to manage the direct introduction player
        if(playerConversationPlayer != null)
        {
            //Add direct introduction controller
            var directIntroController = conversationNodeObject.AddComponent<DirectIntroductionController>();
            directIntroController.RuleInfo = playerConversationPlayer.ConversationInfo;
            directIntroController.GeneralLoop = avatarConversationPlayer;
            directIntroController.DirectIntroduction = playerConversationPlayer;
            playerConversationPlayer.enabled = false;
        }
    }


    //Might want to extract this to somewhere else
    //Returns radius based on proxemic distance type and number of avatars
    public static float CalculateProxemicRadius(int numberOfAvatars, ConversationNodeData.ConversationPlacementTypes type)
    {
        float baseRadius;
        
        switch(type)
        {
            case ConversationNodeData.ConversationPlacementTypes.Intimate:
                baseRadius = 0.25f;
                break;
            case ConversationNodeData.ConversationPlacementTypes.Personal:
                baseRadius = 0.6f;
                break;
            case ConversationNodeData.ConversationPlacementTypes.Social:
                baseRadius = 0.9f;
                break;
            default:
                Debug.LogErrorFormat("Conversation Placement Type not handled to produce proxemic radius '{0}", type);
                return -1f;
        }

        //Equation could be refined in the future
        float result = baseRadius + (Mathf.Max(numberOfAvatars-2, 0) * 0.15f);

        return result;
    }

    //Similar to the above function, may need to move somewhere else.
    //TODO: Expand something more elaborate maybe?
    static float CalculateProxemicDialogueThreshold(string conversationPlayerType, float conversationRadius)
    {
        switch (conversationPlayerType)
        {
            case "ConversationFocused":
                return conversationRadius + 2f; //arbritary values
            case "PlayerFocused":
                return conversationRadius + 0.8f; //arbritary values
            default:
                Debug.LogErrorFormat("Conversation Player Type '{0}' not found", conversationPlayerType);
                return -1;
        }
    }

    static StoryProxemicUIHost.RuleContainer ChangeContainers(RulesContainer.RuleContainer rules, ConversationNode node)
    {
        StoryProxemicUIHost.RuleContainer newContainer = new StoryProxemicUIHost.RuleContainer();
        List<StoryProxemicUIHost.RelativeDistanceRulesInfo> distanceRules;
        List<StoryProxemicUIHost.RelativeOrientationRulesInfo> orientationRules;
        List<StoryProxemicUIHost.IsFacingRulesInfo> isFacingRules;
        //List<StoryProxemicUIHost.ComboRuleInfo> comboRules;

        if (rules.DistanceMaximum > 0 && rules.DistanceMinimum != -1)
        {
            //DistanceRule
            distanceRules = new List<StoryProxemicUIHost.RelativeDistanceRulesInfo>();
            StoryProxemicUIHost.RelativeDistanceRulesInfo newDI = new StoryProxemicUIHost.RelativeDistanceRulesInfo();
            newDI.MinimumThreshold = rules.DistanceMinimum;
            newDI.MaximumThreshold = rules.DistanceMaximum;
            switch(rules.DistanceInOrOut)
            {
                case true:
                    newDI.withinRange = true;
                    break;
                case false:
                    newDI.withinRange = false;
                    break;
            }
            distanceRules.Add(newDI);
            newContainer.DistanceRules = distanceRules;
        }
        
        if (rules.OrientationRules != 0)
        {
            orientationRules = new List<StoryProxemicUIHost.RelativeOrientationRulesInfo>();
            StoryProxemicUIHost.RelativeOrientationRulesInfo newOI = new StoryProxemicUIHost.RelativeOrientationRulesInfo();
            switch (rules.OrientationRules)
            {
                case 1:
                    newOI.facing = true;
                    break;
                case 2:
                    newOI.facing = false;
                    break;
            }
            orientationRules.Add(newOI);
            newContainer.OrientationRules = orientationRules;
        }

        if (rules.IsFacingRules != 0)
        {
            isFacingRules = new List<StoryProxemicUIHost.IsFacingRulesInfo>();
            StoryProxemicUIHost.IsFacingRulesInfo newFacing = new StoryProxemicUIHost.IsFacingRulesInfo();
            switch (rules.IsFacingRules)
            {
                case 1:
                    newFacing.isFacing = true;
                    break;
                case 2:
                    newFacing.isFacing = false;
                    break;
            }
            List<float> location = new List<float>();
            location.Add(node.transform.position.x);
            location.Add(node.transform.position.y);
            location.Add(node.transform.position.z);

            newFacing.ConversationCenter = location;
            isFacingRules.Add(newFacing);
            newContainer.IsFacingRules = isFacingRules;
        }

        ///////*********REMOVED FOR INTERFACE APPROACH WITH AUTHORS*********/////// 
        /*
        if (rules.CombinationRules.Count > 1)
        {
            comboRules = new List<StoryProxemicUIHost.ComboRuleInfo>();
            StoryProxemicUIHost.ComboRuleInfo newCombo = new StoryProxemicUIHost.ComboRuleInfo();
            StoryProxemicUIHost.RelativeDistanceRulesInfo distance = new StoryProxemicUIHost.RelativeDistanceRulesInfo();
            StoryProxemicUIHost.IsFacingRulesInfo facing = new StoryProxemicUIHost.IsFacingRulesInfo();

            distance.MinimumThreshold = rules.CombinationRules[0];
            distance.MaximumThreshold = rules.CombinationRules[1];
            //For within range or not
            switch (rules.CombinationRules[2])
            {
                case 1:
                    distance.withinRange = true;
                    break;
                case 2:
                    distance.withinRange = false;
                    break;
            }
            //For facing or not
            switch (rules.CombinationRules[3])
            {
                case 1:
                    facing.isFacing = true;
                    facing.Radius = 45;
                    break;
                case 2:
                    facing.isFacing = false;
                    facing.Radius = 0;
                    break;
            }
            //For rule type
            switch (rules.CombinationRules[4])
            {
                case 1:
                    newCombo.RuleType = "andRule";
                    break;
                case 2:
                    newCombo.RuleType = "xorRule";
                    break;
            }
            distance.FirstListEntities = new List<Transform>();
            distance.FirstListEntities.Add(conversationPlayer.transform);

            distance.SecondListEntities = new List<Transform>();
            Transform playerTracker = Camera.main.transform.root;
            distance.SecondListEntities.Add(playerTracker);

            facing.Entity = playerTracker;


            newCombo.ProximityRule = distance;
            newCombo.FacingRule = facing;
            comboRules.Add(newCombo);

            newContainer.CombinationRules = comboRules;

        }
        */
        newContainer.ruleCounter = rules.ruleCounter;

        return newContainer;
    }


    static void SetupDialoguePlayer(ConversationNode node, ConversationPlayer conversationPlayer, ConversationDialogueData data, string conversationPlayerType, string outOfRangeClip, 
        StoryProxemicUIHost.RuleContainer listOfRules, int allAvatarsInvolved)
    {
        //Add looping information
        conversationPlayer.isLoopConversation = data.IsLooping;
        conversationPlayer.LoopBufferTime = data.LoopBufferTime;
        conversationPlayer.AllAvatarsInConvo = allAvatarsInvolved;

        //Add out of range clip
        //TODO: Move this out of dialogue player and into conversation in future perhaps
        if(outOfRangeClip != null)
        {
            conversationPlayer.OutOfRangeLoopClip = Resources.Load("Conversations/BackgroundAudio/" + outOfRangeClip.Split('.')[0]) as AudioClip;
        }

        //Add voice lines
        foreach (VoiceLineData voiceLineData in data.VoiceLines)
        {
            ConversationPlayer.VoiceLine voiceLine;
            voiceLine.voiceLine = Resources.Load<AudioClip>("Conversations/ConversationLines/"+voiceLineData.VoiceClip);
            Debug.Log(GameObject.Find(voiceLineData.VoiceOrigin).GetComponent<AudioSource>());
            voiceLine.voiceOrigin = GameObject.Find(voiceLineData.VoiceOrigin).GetComponent<AudioSource>();
            voiceLine.volume = voiceLineData.Volume;

            voiceLine.beforeVoiceDelay = voiceLineData.BeforeVoiceDelay;
            voiceLine.afterVoiceDelay = voiceLineData.AfterVoiceDelay;

            conversationPlayer.ConversationLines.Add(voiceLine);
        }

        List<string> validRules = StoryProxemicUIHost.GetRulesContainers(listOfRules);
        System.Numerics.Vector3 conversationLocation = new System.Numerics.Vector3(node.transform.position.x, node.transform.position.y, node.transform.position.z);

        
        
       conversationPlayer.ConversationInfo = CalculateOrRuleInfo(validRules, listOfRules, conversationPlayer, node, conversationPlayerType);
    }

    public static void LoadStoryJsonData()
    {
        List<ConversationNodeData> nodeDatas = GameState.Instance.GetCurrentStoryData().ConversationNodeDatas;

        foreach(var nodeData in nodeDatas)
        {
            InstallConversation(nodeData);
        }
    }

    public static StoryProxemicUIHost.RelativeDistanceRulesInfo CalculateDistanceInfo(StoryProxemicUIHost.RuleContainer rules, ConversationPlayer conversationPlayer) 
    {
        StoryProxemicUIHost.RelativeDistanceRulesInfo rDRule = new StoryProxemicUIHost.RelativeDistanceRulesInfo();
        
        List<StoryProxemicUIHost.RelativeDistanceRulesInfo> DistanceRules = StoryProxemicUIHost.GetDistanceRules(rules);
        foreach (StoryProxemicUIHost.RelativeDistanceRulesInfo rule in DistanceRules)
        {
            rDRule.MinimumThreshold = rule.MinimumThreshold;
            rDRule.MaximumThreshold = rule.MaximumThreshold;
            rDRule.withinRange = rule.withinRange;

            rDRule.TestCondition = StoryProxemicUIHost.TestConditions.ANY;

            rDRule.FirstListEntities = new List<Transform>();
            rDRule.FirstListEntities.Add(conversationPlayer.transform);

            rDRule.SecondListEntities = new List<Transform>();
            Transform playerTracker = Camera.main.transform.root; 
            rDRule.SecondListEntities.Add(playerTracker);
        }
        return rDRule;
    }

    public static StoryProxemicUIHost.IsFacingRulesInfo CalculateIsFacingInfo(StoryProxemicUIHost.RuleContainer rules)
    {
        StoryProxemicUIHost.IsFacingRulesInfo isFRule = new StoryProxemicUIHost.IsFacingRulesInfo();
            
        List<StoryProxemicUIHost.IsFacingRulesInfo> IsFaceingRule = StoryProxemicUIHost.GetIsFacingRules(rules);
        foreach (StoryProxemicUIHost.IsFacingRulesInfo rule in IsFaceingRule)
        {
            isFRule.Radius = 45;
           
            isFRule.isFacing = rule.isFacing;
            isFRule.ConversationCenter = rule.ConversationCenter;

            Transform playerTracker = Camera.main.transform.root;
            isFRule.Entity = playerTracker;
        }
        return isFRule;
    }

    public static StoryProxemicUIHost.ComboRuleInfo CalculateAndInfo(StoryProxemicUIHost.RuleContainer rules)
    {
        StoryProxemicUIHost.ComboRuleInfo AndRule = new StoryProxemicUIHost.ComboRuleInfo();

        List<StoryProxemicUIHost.ComboRuleInfo> ComboRules = StoryProxemicUIHost.GetCombinationRules(rules);
        foreach (StoryProxemicUIHost.ComboRuleInfo rule in ComboRules)
        {
           switch (rule.RuleType)
            {
                case "andRule":
                    AndRule.ProximityRule = rule.ProximityRule;
                    AndRule.FacingRule = rule.FacingRule;
                    break;
                case "xorRule":
                    break;
            }
        }
        return AndRule;
    }

    public static StoryProxemicUIHost.ComboRuleInfo CalculateXorInfo(StoryProxemicUIHost.RuleContainer rules)
    {
        StoryProxemicUIHost.ComboRuleInfo XorRule = new StoryProxemicUIHost.ComboRuleInfo();

        List<StoryProxemicUIHost.ComboRuleInfo> ComboRules = StoryProxemicUIHost.GetCombinationRules(rules);
        foreach (StoryProxemicUIHost.ComboRuleInfo rule in ComboRules)
        {
            switch (rule.RuleType)
            {
                case "andRule":
                    break;
                case "xorRule":
                    XorRule.ProximityRule = rule.ProximityRule;
                    XorRule.FacingRule = rule.FacingRule;
                    break;
            }
        }
        return XorRule;
    }

    public static StoryProxemicUIHost.OrRuleInfo CalculateOrRuleInfo(List<string> convoRules, StoryProxemicUIHost.RuleContainer rules, ConversationPlayer conversationPlayer,
                                                                     ConversationNode node, string conversationPlayerType)
    {
        StoryProxemicUIHost.OrRuleInfo finalOrRule = new StoryProxemicUIHost.OrRuleInfo();
        StoryProxemicUIHost.RelativeDistanceRulesInfo distance;
        StoryProxemicUIHost.IsFacingRulesInfo facing;
        StoryProxemicUIHost.ComboRuleInfo andRule;
        StoryProxemicUIHost.ComboRuleInfo xorRule;

        finalOrRule.RequiredRules = convoRules;

        if (convoRules.Count < 2)
        {
            distance = CalculateDefaultRule(conversationPlayer, node, conversationPlayerType);
            finalOrRule.RequiredRules.Add("default");
            finalOrRule.DefaultRule = distance;
            
        }

        if (convoRules.Contains("distance"))
        {
            distance = CalculateDistanceInfo(rules, conversationPlayer);
            finalOrRule.ProximityRule = distance;
        }

        if (convoRules.Contains("isFacing"))
        {
            facing = CalculateIsFacingInfo(rules);
            finalOrRule.FacingRule = facing;
        }

        if (convoRules.Contains("andRule"))
        {
            andRule = CalculateAndInfo(rules);
            finalOrRule.AndCombo = andRule;
        }

        if (convoRules.Contains("xorRule"))
        {
            xorRule = CalculateXorInfo(rules);
            finalOrRule.XorCombo = xorRule;
        }

        return finalOrRule;
    }

    public static StoryProxemicUIHost.RelativeDistanceRulesInfo CalculateDefaultRule(ConversationPlayer conversationPlayer, ConversationNode node, string conversationPlayerType)
    {
        StoryProxemicUIHost.RelativeDistanceRulesInfo defaultRule = new StoryProxemicUIHost.RelativeDistanceRulesInfo();
        defaultRule.MinimumThreshold = 0;
        defaultRule.MaximumThreshold = (int)CalculateProxemicDialogueThreshold(conversationPlayerType, node.Radius);

        defaultRule.withinRange = true;
        defaultRule.TestCondition = StoryProxemicUIHost.TestConditions.ANY;

        defaultRule.FirstListEntities = new List<Transform>();
        defaultRule.FirstListEntities.Add(conversationPlayer.transform);

        defaultRule.SecondListEntities = new List<Transform>();
        Transform playerTracker = Camera.main.transform.root;
        defaultRule.SecondListEntities.Add(playerTracker);

        return defaultRule;
    }
  
}
