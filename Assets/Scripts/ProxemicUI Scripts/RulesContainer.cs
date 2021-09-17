using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProxemicUIFramework;

public class RulesContainer : MonoBehaviour
{
    [System.Serializable]

    /*
     * Rule Container is passed from the UI to the JSON and saved
     * All variables are lists for scalability and the ability to later add more than 2 rules at a time
     */
    public struct RuleContainer
    {
        //Distance variables
        public int DistanceMinimum;
        public int DistanceMaximum;
        public bool DistanceInOrOut;

        //Orientation and is facing variables
        public int OrientationRules;
        public int IsFacingRules;

        //Combo variable and rule count
        public List<int> CombinationRules;
        public int ruleCounter;
    }

    public struct DistanceContainer
    {
        public int Minimum;
        public int Maximum;
        public int withinRange;             //Where 1 = withinRange and 2 = !withinRange
    }

    public struct OrientationContainer
    {
        public int facing;                  //Where 1 = facing and 2 = !facing
    }

    public struct IsFacingContainer
    {
        public int isFacing;                //Where 1 = facing and 2 = !facing
    }

    public struct CombinationContainer
    {
        public DistanceContainer ProximityRule;
        public IsFacingContainer IsFacingRule;
        public string RuleType;
    }

    public static RulesContainer Instance { get; private set; }

    DataReceiver _dataReceiver;

    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("Cannot have more than one");
        }

        // Define Foundations
        _dataReceiver = new DataReceiver(5103, "127.0.0.1"); //second field is IP address of device that runs the ProxemicUI code (only one device)
    }

    //Returns list of active rules to prevent null pointer exception 
    public static List<string> GetRulesContainers(RuleContainer container)
    { 
        List<string> activeRules = new List<string>();
        string none = "";
        if (container.DistanceMinimum != -1 && container.DistanceMaximum != 0)
        {
            none += "no distance";
        } else
        {
            string distance = "distance";
            activeRules.Add(distance);
        }

        if (container.OrientationRules > 0)
        {
            none += "no orientation";
        }
        else
        {
            string orientation = "orientation";
            activeRules.Add(orientation);
        }

        if (container.IsFacingRules > 0)
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
            if (container.CombinationRules[4] == 1)
            {
                string combination = "andRule";
                activeRules.Add(combination);
            } else if (container.CombinationRules[5] == 2)
            {
                string combination = "xorRule";
                activeRules.Add(combination);
            }
            
        }

        return activeRules;
    }
}
