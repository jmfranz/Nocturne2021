using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProxemicUIFramework;
using UnityEngine.UI;

public class ProxemicUIHost : MonoBehaviour
{
    DataReceiver _dataReceiver;

    [SerializeField] Transform _player;
    [SerializeField] Transform _father;
    [SerializeField] Transform _son;
    [SerializeField] Transform _bystander1;
    [SerializeField] Transform _bystander2;
    [SerializeField] Transform _bystander3;
    [SerializeField] Transform _bystander4;

    Dictionary<string, RelativeDistanceRule> _relativeDistanceRules = new Dictionary<string, RelativeDistanceRule>();
    Dictionary<string, List<string>> _nameLists = new Dictionary<string, List<string>>();
    List<string> _rulesToRemove = new List<string>();

    FatherStateController _fatherStateController;


    void Start()
    {
        // Define Foundations
        _dataReceiver = new DataReceiver(5103, "127.0.0.1"); //second field is IP address of device that runs the ProxemicUI code (only one device)

        // Everything in Proxemic's UI is currently using a list, setup for convenience
        AddEntityToSetupList(_player);
        AddEntityToSetupList(_father);
        AddEntityToSetupList(_son);
        AddEntityToSetupList(_bystander1);
        AddEntityToSetupList(_bystander2);
        AddEntityToSetupList(_bystander3);
        AddEntityToSetupList(_bystander4);

        // Create Releative Distance Rules
        _relativeDistanceRules.Add(_father.name,
            new RelativeDistanceRule(0, 2, _nameLists[_player.name], _nameLists[_father.name], "ANY"));

        _relativeDistanceRules.Add(_son.name,
            new RelativeDistanceRule(0, 2, _nameLists[_player.name], _nameLists[_son.name], "ANY"));

        _relativeDistanceRules.Add(_bystander1.name,
            new RelativeDistanceRule(0, 2, _nameLists[_player.name], _nameLists[_bystander1.name], "ANY"));

        _relativeDistanceRules.Add(_bystander2.name,
            new RelativeDistanceRule(0, 2, _nameLists[_player.name], _nameLists[_bystander2.name], "ANY"));

        _relativeDistanceRules.Add(_bystander3.name,
            new RelativeDistanceRule(0, 2, _nameLists[_player.name], _nameLists[_bystander3.name], "ANY"));

        _relativeDistanceRules.Add(_bystander4.name,
            new RelativeDistanceRule(0, 2, _nameLists[_player.name], _nameLists[_bystander4.name], "ANY"));

        ////Add rules to rule engine - but not working in this version of ProxemicUI, needs manually tested in Update
        foreach (var rule in _relativeDistanceRules.Values)
        {
            RuleEngine.Instance.AddToRuleList(rule);
        }

        _relativeDistanceRules[_father.name].OnEventTrue += ApproachedFather;
        _relativeDistanceRules[_son.name].OnEventTrue += ApproachedSon;
        _relativeDistanceRules[_bystander1.name].OnEventTrue += ApproachedBystander1;
        _relativeDistanceRules[_bystander2.name].OnEventTrue += ApproachedBystander2;
        _relativeDistanceRules[_bystander3.name].OnEventTrue += ApproachedBystander3;
        _relativeDistanceRules[_bystander4.name].OnEventTrue += ApproachedBystander4;

        //Get state controllers
        _fatherStateController = _father.GetComponent<FatherStateController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Test each rule
        foreach(var rule in _relativeDistanceRules.Values)
        {
            rule.Test();
        }

        foreach(var name in _rulesToRemove)
        {
            _relativeDistanceRules.Remove(name);
        }
        _rulesToRemove.Clear();

    }

    //Helper function to reduce redunancy
    void AddEntityToSetupList(Transform entity)
    {
        _nameLists.Add(entity.name, new List<string>());
        _nameLists[entity.name].Add(entity.name);
    }

    
    void ApproachedFather(Rules rules, ProximityEventArgs args)
    {
        Debug.Log("Approached Father!");
        _fatherStateController.OnApproach();
        _rulesToRemove.Add(_father.name);
    }


    void ApproachedSon(Rules rules, ProximityEventArgs args)
    {
        Debug.Log("Approached Son!");
        _son.GetComponent<ChildStateController>().OnApproach();
        _rulesToRemove.Add(_son.name);
    }


    void ApproachedBystander1(Rules rules, ProximityEventArgs args)
    {
        Debug.Log("Approached ByStander1!");
        _bystander1.GetComponent<BystanderStateController>().OnApproach();
        _rulesToRemove.Add(_bystander1.name);
    }


    void ApproachedBystander2(Rules rules, ProximityEventArgs args)
    {
        Debug.Log("Approached ByStander2!");
        _bystander2.GetComponent<BystanderStateController>().OnApproach();
        _rulesToRemove.Add(_bystander2.name);
    }

    void ApproachedBystander3(Rules rules, ProximityEventArgs args)
    {
        Debug.Log("Approached ByStander3!");
        _bystander3.GetComponent<BystanderStateController>().OnApproach();
        _rulesToRemove.Add(_bystander3.name);
    }


    void ApproachedBystander4(Rules rules, ProximityEventArgs args)
    {
        Debug.Log("Approached ByStander4!");
        _bystander4.GetComponent<BystanderStateController>().OnApproach();
        _rulesToRemove.Add(_bystander4.name);
    }

}