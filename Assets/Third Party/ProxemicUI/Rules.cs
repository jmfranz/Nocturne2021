/// ------------------------------------------------------------------------------------------------
/// 
/// Project:        ProxemicUIFramework
/// Description:    This framework was build to provide developers the support to build proxemics
///                 aware applications. It provides developers a set of proxemic events based on 
///                 proxemics data of entities , that include absolute data of entities in an 
///                 environment, relative data between entities in that environment, and combanation
///                 of any of these data. It also provides developers with a combanation of proxemic
///                 events and UI events which we call Hybrid Events.
/// Author:         Mohammed Alnusayri
/// Contact:        m.alnusayri@gmail.com
/// 
/// ------------------------------------------------------------------------------------------------- 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace ProxemicUIFramework
{
    /// <summary>
    /// <c> Rules </c> is the base class of all rules, all shared code can be added here
    /// </summary>
    public abstract class Rules
    {
        /// <summary>
        ///  this is an abstract <c>test</c> method that represents all <c>test</c> methods
        ///  within all rules. it is used to check the validation of a rule and call, then 
        ///  call the right event
        /// </summary>
        /// <returns><c>test</c> method reutrns true if the rule is valid and false if the
        /// rule is not valid</returns>
        public abstract bool Test();

        /// <summary>
        /// This is a generic delegate for all events 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        //public delegate void RuleHandler(object sender, RuleArgs args);

        public delegate void RuleHandler(Rules rule, ProximityEventArgs proximityEvent);

        //public abstract event RuleHandler OnEvent;

        public event RuleHandler OnEventTrue, OnEventFalse, OnEventChanged;

        internal List<string> Entities = new List<string>();

        // this is to keep of event final output (true/false) to fire OnEventChanged
        internal bool EventTracker;

        // to pass test value from shape to the rule instead of return multiple types from the check distance method
        internal TemporaryArgs TemporaryArgs;

        protected void FireEventTrue(Rules rule, ProximityEventArgs args)
        {
            if (OnEventTrue != null)
            {
                OnEventTrue(rule, args);
            }
        }

        protected void FireEventFalse(Rules rule, ProximityEventArgs args)
        {
            if (OnEventFalse != null)
            {
                OnEventFalse(rule, args);
            }
        }

        protected void FireEventChanged(Rules rule, ProximityEventArgs args)
        {
            if (OnEventChanged != null)
            {
                OnEventChanged(rule, args);
            }
        }

        
    }

    /// <summary>
    /// <c>EntityLists</c> is a struct to combine two lists into one, it can be used to when
    /// a custom event args is implemented to return all lists 
    /// </summary>
    public struct EntityLists
    {
        private List<string> _firstList, _secondList;

        public List<string> FirstList
        {
            get { return _firstList; }
            set { _firstList = value; }
        }

        public List<string> SecondList
        {
            get { return _secondList; }
            set { _secondList = value; }
        }

        public EntityLists(List<string> _firstList, List<string> _secondList)
        {
            this._firstList = _firstList;
            this._secondList = _secondList;
        }
    }

    internal struct TemporaryArgs
    {
        private double distance, angle;
        private Vector2 xyDistacne;
        private Vector3 absOri;

        public double Diatance
        {
            get { return distance; }
            set { distance = value; }
        }

        public double Angle
        {
            get { return angle; }
            set { angle = value; }
        }

        public Vector2 XYDistance
        {
            get { return xyDistacne; }
            set { xyDistacne = value; }
        }

        public Vector3 AbsOrientation
        {
            get { return absOri; }
            set { absOri = value; }
        }

    }
    /// <summary>
    /// <c>RuleArgs</c> is a custom event args that can be used as required
    /// </summary>
    /*public class RuleArgs : EventArgs
    {
        /// <summary>
        /// this is used to store the external event object for Hybrid rules
        /// </summary>
        //public object SenderObject { get; set; }
        /// <summary>*******************
        /// this is for NOT Compound Rule which return a single rule
        /// </summary>
        //public Rules Rule { get; set; }
        /// <summary>********************
        /// this is for OR and XOR Compound Rules and Hybrid Rule which return the Rule and its argument if it passes the test
        /// </summary>
        //public Tuple<object, RuleArgs> RuleBasicArgs { get; set; }
        /// <summary>********************
        /// this is for baisc Absolute rule which return a list of entities that passed the test
        /// </summary>
        //public List<string> ListOfEntities { get; set; }
        /// <summary>*******************
        /// When the test condition for the basic rule is "ALL" this contains the two lists of entities that was passed to the rule
        /// </summary>
        //public EntityLists EntityLists { get; set; }
        /// <summary>*******************
        /// When the test condition for the basic rule is "ANY" this contains a dictionary where the keys are IDs from the first list
        /// and the value is a list with all IDs of entities that passed the test with the key
        /// </summary>
        //public Dictionary<string, List<string>> BasicRuleDictionary { get; set; }
        /// <summary>*******************
        /// The returning argument of Compound Rules is a dictionary that contains the rule as an object
        /// (key of the dictionary) and the returing argument of that rule (value of the dictionary)
        /// </summary>
        //public Dictionary<object, RuleArgs> RuleDictionaryArgs { get; set; }
    }*/
}
