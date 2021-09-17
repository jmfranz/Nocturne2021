using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProxemicUIFramework;

public class StoryProxemicUIHost : MonoBehaviour
{
    [System.Serializable]

    public struct RuleContainer
    {
        public List<RelativeDistanceRulesInfo> DistanceRules;
        public List<RelativeOrientationRulesInfo> OrientationRules;
        public List<IsFacingRulesInfo> IsFacingRules;
        public List<ComboRuleInfo> CombinationRules;
        public int ruleCounter;
    }

    [System.Serializable]
    public struct RelativeDistanceRulesInfo
    {
        public int MinimumThreshold;
        public int MaximumThreshold;
        public List<Transform> FirstListEntities;
        public List<Transform> SecondListEntities;
        public TestConditions TestCondition;
        public bool withinRange;
    }

    [System.Serializable]
    public struct RelativeOrientationRulesInfo
    {
        public double Radius;
        public List<Transform> FirstListEntities;
        public List<Transform> SecondListEntities;
        public TestConditions TestConditions;
        public bool facing;
    }

    [System.Serializable]
    public struct IsFacingRulesInfo
    {
        public double Radius;
        public Transform Entity;
        public List<float> ConversationCenter;
        public bool isFacing;
    }

    [System.Serializable]
    public struct ComboRuleInfo
    {
        public RelativeDistanceRulesInfo ProximityRule;
        public IsFacingRulesInfo FacingRule;
        public string RuleType;
    }

    [System.Serializable]
    public struct OrRuleInfo
    {
        public RelativeDistanceRulesInfo DefaultRule;
        public RelativeDistanceRulesInfo ProximityRule;
        public IsFacingRulesInfo FacingRule;
        public ComboRuleInfo AndCombo;
        public ComboRuleInfo XorCombo;
        public List<string> RequiredRules;
    }

    public enum TestConditions
    {
        ANY,
        ALL,
    }

    public static StoryProxemicUIHost Instance { get; private set; }

    DataReceiver _dataReceiver;
    List<RelativeDistanceRule> _relativeDistanceRules = new List<RelativeDistanceRule>();
    List<RelativeOrientationRule> _relativeOrientationRules = new List<RelativeOrientationRule>();
    List<IsFacingRule> _isFacingRules = new List<IsFacingRule>();
    List<ANDRule> _andRules = new List<ANDRule>();
    List<XORRule> _xorRules = new List<XORRule>();
    List<ORRule> _orRules = new List<ORRule>();


    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("Cannot have more than one StoryProxemicUIHost as it is a singleton");
        }

        // Define Foundations
        _dataReceiver = new DataReceiver(5103, "127.0.0.1"); //second field is IP address of device that runs the ProxemicUI code (only one device)
    }

    void Update()
    {
        for (int i = 0; i < RuleEngine.Instance.listOfRules.Count; i++)
        {
            Rules rule = RuleEngine.Instance.listOfRules[i];
            RuleEngine.Instance.TestRunner(rule);
        }
    }


    public RelativeDistanceRule AddRelativeRule(RelativeDistanceRulesInfo info)
    {
        //Get names of transforms in rule info
        List<string> firstNames = new List<string>();
        foreach (var entity in info.FirstListEntities)
        {
            firstNames.Add(entity.name);
        }

        List<string> secondNames = new List<string>();
        foreach (var entity in info.SecondListEntities)
        {
            secondNames.Add(entity.name);
        }

        //Generate relative distance rule given specifications
        var relRule = new RelativeDistanceRule(
            info.MinimumThreshold,
            info.MaximumThreshold,
            firstNames,
            secondNames,
            ParseTestCondition(info.TestCondition)
        );

        ////****ADDED TO RULE ENGUINE IN OR RULE****////
        //RuleEngine.Instance.AddToRuleList(relRule);

        return relRule; //returns a copy if caller is interested
    }

    public RelativeOrientationRule AddOrientationRule(RelativeOrientationRulesInfo info)
    {
        //Get names of transforms in rule info
        List<string> firstNames = new List<string>();
        foreach (var entity in info.FirstListEntities)
        {
            firstNames.Add(entity.name);
        }

        List<string> secondNames = new List<string>();
        foreach (var entity in info.SecondListEntities)
        {
            secondNames.Add(entity.name);
        }

        var orientationRule = new RelativeOrientationRule(
            info.Radius,
            firstNames,
            secondNames,
            ParseTestCondition(info.TestConditions)
            );

        ////****ADDED TO RULE ENGUINE IN OR RULE****////
        //RuleEngine.Instance.AddToRuleList(orientationRule);

        return orientationRule; //returns a copy if caller is interested
    }
    
    public IsFacingRule AddFacingRule(IsFacingRulesInfo info)
    {
        System.Numerics.Vector3 newVector = new System.Numerics.Vector3(info.ConversationCenter[0], info.ConversationCenter[1], info.ConversationCenter[2]);

        //Generate isFacingRule given specifications
        var facingRule = new IsFacingRule(
            info.Radius,
            info.Entity.name,
            newVector
        );

        ////****ADDED TO RULE ENGUINE IN OR RULE****////
        //RuleEngine.Instance.AddToRuleList(facingRule);

        return facingRule;  //returns a copy if caller is interested
    }

    public ANDRule AddAndRule(ComboRuleInfo info)
    {
        var andRule = new ANDRule(AddRelativeRule(info.ProximityRule), AddFacingRule(info.FacingRule));

        ////****ADDED TO RULE ENGUINE IN OR RULE****////
        //RuleEngine.Instance.AddToRuleList(andRule);

        return andRule;  //returns a copy if caller is interested
    }

    public XORRule AddXorRule(ComboRuleInfo info)
    {

        var xorRule = new XORRule(AddRelativeRule(info.ProximityRule), AddFacingRule(info.FacingRule));

        ////****ADDED TO RULE ENGUINE IN OR RULE****////
        //RuleEngine.Instance.AddToRuleList(xorRule);

        return xorRule;  //returns a copy if caller is interested
    }

    public NOTRule AddNotFacing(IsFacingRule facingRule)
    {
        var notFacing = new NOTRule(facingRule);

        return notFacing;
    }

    public ORRule AddOrRule(OrRuleInfo rules)
    {
        ORRule orRule;
        RelativeDistanceRule relRule;
        IsFacingRule facingRule;
        NOTRule notFacing;
        ANDRule andRule;
        XORRule xorRule;
        List<Rules> finalRules = new List<Rules>();

        for (int rule = 0; rule < rules.RequiredRules.Count; rule++)
        {
            switch (rules.RequiredRules[rule])
            {
                case "distance":
                    relRule = AddRelativeRule(rules.ProximityRule);
                    finalRules.Add(relRule);
                    break;
                case "isFacing":
                    facingRule = AddFacingRule(rules.FacingRule);
                    if (rules.FacingRule.isFacing) 
                    {
                        finalRules.Add(facingRule);
                    } else
                    {
                        notFacing = AddNotFacing(facingRule);
                        finalRules.Add(notFacing);
                    }
                    break;
                case "andRule":
                    andRule = AddAndRule(rules.AndCombo);
                    finalRules.Add(andRule);
                    break;
                case "xorRule":
                    xorRule = AddXorRule(rules.XorCombo);
                    finalRules.Add(xorRule);
                    break;
                case "default":
                    relRule = AddRelativeRule(rules.DefaultRule);
                    finalRules.Add(relRule);
                    break;
            }
        }

        if (finalRules.Count == 2)
        {
            orRule = new ORRule(finalRules[0], finalRules[1]);
        } else
        {
            orRule = new ORRule(finalRules[0], finalRules[0]);
        }
        

        RuleEngine.Instance.AddToRuleList(orRule);

        return orRule;
    }

    public void AddOrRule(IsFacingRule isFacingRule)
    {
        ORRule orRule = new ORRule(isFacingRule, isFacingRule);

        RuleEngine.Instance.AddToRuleList(orRule);
    }

    public static List<string> GetRulesContainers(RuleContainer container)
    {
        List<string> activeRules = new List<string>();
        string none = "";
        if (container.DistanceRules == null)
        {
            none += "no distance";
        }
        else
        {
            string distance = "distance";
            activeRules.Add(distance);
        }

        if (container.OrientationRules == null)
        {
            none += "no orientation";
        }
        else
        {
            string orientation = "orientation";
            activeRules.Add(orientation);
        }

        if (container.IsFacingRules == null)
        {
            none += "no isFacing";
        }
        else
        {
            string isFacing = "isFacing";
            activeRules.Add(isFacing);
        }

        if (container.CombinationRules == null)
        {
            none += "no comboRules";
        }
        else
        {
            foreach (ComboRuleInfo rule in container.CombinationRules)
            {
                string combinationRules = rule.RuleType;
                activeRules.Add(combinationRules);
            }
        }

        return activeRules;
    }

    public static List<RelativeDistanceRulesInfo> GetDistanceRules(RuleContainer container)
    {
        return container.DistanceRules;
    }

    public static List<RelativeOrientationRulesInfo> GetOrientationRules(RuleContainer container)
    {
        return container.OrientationRules;
    }

    public static List<IsFacingRulesInfo> GetIsFacingRules(RuleContainer container)
    {
        return container.IsFacingRules;
    }

    public static List<ComboRuleInfo> GetCombinationRules(RuleContainer container)
    {
        return container.CombinationRules;
    }

    public static int CountRules(RuleContainer container)
    {
        return container.ruleCounter;
    }


    //Helper function - Parse enum of test condition and return string format
    string ParseTestCondition(TestConditions condition)
    {
        switch (condition)
        {
            case TestConditions.ALL:
                return "ALL";
            case TestConditions.ANY:
                return "ANY";
        }

        Debug.LogErrorFormat("TestCondition '{0}' not declared in parser", condition);
        return "";
    }
}
