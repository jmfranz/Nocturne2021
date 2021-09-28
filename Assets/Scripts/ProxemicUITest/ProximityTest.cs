using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProxemicUIFramework;
using System.Threading.Tasks;
using UnityEngine.UI;

public class ProximityTest : MonoBehaviour
{
    [SerializeField] Transform _Center;
    [SerializeField] Text _Text1;
    [SerializeField] Text _Text2;
    [SerializeField] Text _Text3;
    [SerializeField] Text _Text4;

    List<string> entities = new List<string>();

    bool _rulecreated = false;

    // using Vector3 from System.Numerics.Vector3 because it is different than Vector3 in unity
    System.Numerics.Vector3 _CenterPoint = new System.Numerics.Vector3();

    // Start is called before the first frame update
    void Start()
    {
        DataReceiver receiver = new DataReceiver(5103, "127.0.0.1");
        

        // assign the center point to Vector3 to pass it to ProxemicUI
        _CenterPoint.X = _Center.transform.position.x;
        _CenterPoint.Y = _Center.transform.position.y;
        _CenterPoint.Z = _Center.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        // to make sure the ProxemicUI received data for entities before creating the rules otherwise we will pass empty list
        if (EntityContainer.ListOfEntities.Count > 0)
        {
            entities = EntityContainer.EntityRetrievalAll();
        }

        // to create the rule once. if we create the rule above in the start method then the list of entities might be empty
        if (_rulecreated == false && entities.Count >= 4)
        {
            IsFacingRule isFacingRule = new IsFacingRule(90, entities, _CenterPoint, "ANY");
            RuleEngine.Instance.AddToRuleList(isFacingRule);
            isFacingRule.OnEventTrue += IsFacingRule_OnEventTrue;
            isFacingRule.OnEventFalse += IsFacingRule_OnEventFalse;

            RelativeOrientationRule RelativeOrientation = new RelativeOrientationRule(45, _Center.name, entities, "ANY");
            RuleEngine.Instance.AddToRuleList(RelativeOrientation);
            RelativeOrientation.OnEventTrue += RelativeOrientation_OnEventTrue;
            RelativeOrientation.OnEventFalse += RelativeOrientation_OnEventFalse;
            _rulecreated = true;
        }

        // to keep runing the test methods for all rules becuse unity doesn't allow us to run another thread
        for (int i = 0; i < RuleEngine.Instance.listOfRules.Count; i++)
        {
            Rules rule = RuleEngine.Instance.listOfRules[i];
            RuleEngine.Instance.TestRunner(rule);
        }
    }

    private void IsFacingRule_OnEventFalse(Rules rule, ProximityEventArgs proximityEvent)
    {
        _Text1.text = "";
        _Text2.text = "";
        _Text3.text = "";
        _Text4.text = "";
    }

    private void IsFacingRule_OnEventTrue(Rules rule, ProximityEventArgs proximityEvent)
    {
        RelativeBasicProximityEventArgs eventArgs = (RelativeBasicProximityEventArgs)proximityEvent;

        foreach (string id in eventArgs.EntityListForIsFacing)
        {
            switch (id)
            {
                case "Cube 1":
                    _Text1.text = "CUBE 1 IS FACING CENTER";
                    _Text2.text = "";
                    _Text3.text = "";
                    _Text4.text = "";
                    break;
                case "Cube 2":
                    _Text1.text = "";
                    _Text2.text = "CUBE 2 IS FACING CENTER";
                    _Text3.text = "";
                    _Text4.text = "";
                    break;
                case "Cube 3":
                    _Text1.text = "";
                    _Text2.text = "";
                    _Text3.text = "CUBE 3 IS FACING CENTER";
                    _Text4.text = "";
                    break;
                case "Cube 4":
                    _Text1.text = "";
                    _Text2.text = "";
                    _Text3.text = "";
                    _Text4.text = "CUBE 4 IS FACING CENTER";
                    break;
            }
        }
    }

    private void RelativeDistanceRule_OnEventTrue(Rules rule, ProximityEventArgs proximityEvent)
    {
        
    }

    private void RelativeDistanceRule_OnEventFalse(Rules rule, ProximityEventArgs proximityEvent)
    {
        
    }

    private void RelativeOrientation_OnEventFalse(Rules rule, ProximityEventArgs proximityEvent)
    {
        _Text1.text = "";
        _Text2.text = "";
        _Text3.text = "";
        _Text4.text = "";
    }

    private void RelativeOrientation_OnEventTrue(Rules rule, ProximityEventArgs proximityEvent)
    {
        RelativeBasicProximityEventArgs eventArgs = (RelativeBasicProximityEventArgs)proximityEvent;

        foreach (string id in eventArgs.EntityDictionaryForAny[_Center.name])
        {
            switch (id)
            {
                case "Cube 1":
                    _Text1.text = "CUBE 1 IS FACING CENTER";
                    _Text2.text = "";
                    _Text3.text = "";
                    _Text4.text = "";
                    break;
                case "Cube 2":
                    _Text1.text = "";
                    _Text2.text = "CUBE 2 IS FACING CENTER";
                    _Text3.text = "";
                    _Text4.text = "";
                    break;
                case "Cube 3":
                    _Text1.text = "";
                    _Text2.text = "";
                    _Text3.text = "CUBE 3 IS FACING CENTER";
                    _Text4.text = "";
                    break;
                case "Cube 4":
                    _Text1.text = "";
                    _Text2.text = "";
                    _Text3.text = "";
                    _Text4.text = "CUBE 4 IS FACING CENTER";
                    break;
            }
        }
    }
}
