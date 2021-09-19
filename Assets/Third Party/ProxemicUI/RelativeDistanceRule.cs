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

namespace ProxemicUIFramework
{
    /// <summary>
    /// <c> RelativeDistanceRule </c> is a class that check the relative distance between entities 
    /// </summary>
    public class RelativeDistanceRule : RelativeProximityRules
    {
        /// <summary>
        /// <c>DistanceEvent</c> is defind as public event to check the relative distance between 
        /// entities and is listed within the rule so the compiler will only fire the event of rule instance
        /// </summary>
        //public override event RuleHandler OnEvent;
        /// <summary>
        /// to store distance thresholds
        /// </summary>
        private double _MinimumThreshold, _MaximumThreshold;
        /// <summary>
        /// to store lists of entities
        /// </summary>
        private List<string> _FirstListOfEntities = new List<string>(), _SecondListOfEntities = new List<string>();

        /// <summary>
        /// to store test condition (ALL or ANY) 
        /// </summary>
        private string _TestCondition = "ALL";
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Minimumthreshold"></param>
        /// <param name="MaximumThreshold"></param>
        /// <param name="FirsEntity"></param>
        /// <param name="SecondEntity"></param>
        /// <param name="TestCondition"></param>
        public RelativeDistanceRule(double Minimumthreshold, double MaximumThreshold, string FirstEntity, string SecondEntity, string TestCondition)
        {
            if (FirstEntity == null)
                throw new ArgumentException("First entity in the constructor for the relative distance rule cannot be empty", "FirstEntity");
            if (SecondEntity == null)
                throw new ArgumentException("Second entities in the constructor for the relative distance rule cannot be empty", "SecondEntity");

            this._MinimumThreshold = Minimumthreshold;
            this._MaximumThreshold = MaximumThreshold;
            this._FirstListOfEntities.Add(FirstEntity);
            this._SecondListOfEntities.Add(SecondEntity);
            this._TestCondition = TestCondition;
            base.Entities = _FirstListOfEntities.Union(_SecondListOfEntities).ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Minimumthreshold"></param>
        /// <param name="MaximumThreshold"></param>
        /// <param name="FirstEntity"></param>
        /// <param name="SecondListOfEntities"></param>
        /// <param name="TestCondition"></param>
        public RelativeDistanceRule(double Minimumthreshold, double MaximumThreshold, string FirstEntity, List<string> SecondListOfEntities, string TestCondition)
        {
            if (FirstEntity == null)
                throw new ArgumentException("First entity in the constructor for the relative distance rule cannot be empty", "FirstEntity");
            if (SecondListOfEntities.Count == 0)
                throw new ArgumentException("Second list of entities in the constructor for the relative distance rule cannot be empty", "SecondListOfEntities");

            this._MinimumThreshold = Minimumthreshold;
            this._MaximumThreshold = MaximumThreshold;
            this._FirstListOfEntities.Add(FirstEntity);
            this._SecondListOfEntities = SecondListOfEntities;
            this._TestCondition = TestCondition;
            base.Entities = _FirstListOfEntities.Union(SecondListOfEntities).ToList();
        }
        /// <summary>
        /// the class constructor that has two <c>ProximityRule</c> lists and two thresholds as arguments
        /// </summary>
        /// <param name="Minimumthreshold"></param>
        /// <param name="MaximumThreshold"></param>
        /// <param name="FirstListOfEntities"></param>
        /// <param name="SecondListOfEntities"></param>
        /// <param name="TestCondition">"ALL" of "ANY"</param>
        public RelativeDistanceRule(double Minimumthreshold, double MaximumThreshold, List<string> FirstListOfEntities, List<string> SecondListOfEntities, string TestCondition)
        {
            if (FirstListOfEntities.Count == 0)
                throw new ArgumentException("First list of entities in the constructor for the relative distance rule cannot be empty", "FirstListOfEntities");
            if (SecondListOfEntities.Count == 0)
                throw new ArgumentException("Second list of entities in the constructor for the relative distance rule cannot be empty", "SecondListOfEntities");

            this._MinimumThreshold = Minimumthreshold;
            this._MaximumThreshold = MaximumThreshold;
            this._FirstListOfEntities = FirstListOfEntities;
            this._SecondListOfEntities = SecondListOfEntities;
            this._TestCondition = TestCondition;
            base.Entities = FirstListOfEntities.Union(SecondListOfEntities).ToList();
        }
        /// <summary>
        /// <c>test</c> method is used to check if the rule is valid and call <c>OnDistanceEvent</c>
        /// upon rule validation to fire <c>DistanceEvent</c>
        /// </summary>
        /// <returns><c>test</c> method reutrns true if the rule is valid and false if the
        /// rule is not valid</returns>
        public override bool Test()
        {
            List<bool> checkList = new List<bool>();

            RelativeBasicProximityEventArgs eventArgs = new RelativeBasicProximityEventArgs();

            if (_TestCondition == "ALL")
            {
                if (TestForAll())
                {
                    eventArgs.EntityListsForAll = new EntityLists(this._FirstListOfEntities, this._SecondListOfEntities);
                    base.FireEventTrue(this, eventArgs);
                    if (!EventTracker)
                    {
                        EventTracker = true;
                        FireEventChanged(this, eventArgs);
                    }
                    return true;
                }
                else
                {
                    base.FireEventFalse(this, null);
                    if (EventTracker)
                    {
                        EventTracker = false;
                        FireEventChanged(this, null);
                    }
                    return false;
                }
            }
            else
            if (_TestCondition == "ANY")
            {
                Dictionary<string, List<string>> result = new Dictionary<string, List<string>>();
                result = TestForAny();

                if (result.Count > 0)
                {
                    eventArgs.EntityDictionaryForAny = result;
                    base.FireEventTrue(this, eventArgs);
                    if (!EventTracker)
                    {
                        EventTracker = true;
                        FireEventChanged(this, eventArgs);
                    }
                    return true;
                }
                else
                {
                    base.FireEventFalse(this, null);
                    if (EventTracker)
                    {
                        EventTracker = false;
                        FireEventChanged(this, null);
                    }
                    return false;
                }
            }
            else
                throw new ArgumentException("Test condition in the constructor is not 'ALL' or 'ANY", "TestCondition");
        }

        /*public override bool Test()
        {
            List<bool> checkList = new List<bool>();
            checkList.Clear();

            RelativeBasicProximityEventArgs eventArgs = new RelativeBasicProximityEventArgs();
            // the differnce between two thresholds
            //double threshold = _MaximumThreshold - _MinimumThreshold;

            // to be used for recording entities with the test condition "ANY"
            Dictionary<string, List<string>> returnDictionary = new Dictionary<string, List<string>>();

            foreach (string firstId in _FirstListOfEntities)
            {
                // to be used for recording entities with "ANY" test condition
                List<string> returnList = new List<string>();

                foreach (string secondId in _SecondListOfEntities)
                {
                    if (firstId != secondId && this._TestCondition == "ALL")
                    {
                        // calculate and check distance between positions of two entities
                        checkList.Add(EntityContainer.ListOfEntities[firstId].Shape.CheckDistance(EntityContainer.ListOfEntities[secondId].Shape, _MinimumThreshold, _MaximumThreshold));
                    }
                    else 
                    if(firstId != secondId && this._TestCondition == "ANY")
                    {
                        if (EntityContainer.ListOfEntities[firstId].Shape.CheckDistance(EntityContainer.ListOfEntities[secondId].Shape, _MinimumThreshold, _MaximumThreshold))
                        {
                            checkList.Add(true);
                            returnList.Add(secondId);
                        }
                    }
                }
                if (this._TestCondition == "ANY" && returnList.Count > 0 && returnDictionary.ContainsKey(firstId) == false)
                {
                    returnDictionary.Add(firstId, returnList);
                }
            }

            if (checkList.Count > 0 && checkList.Contains(false) == false)
            {
                if (this._TestCondition == "ALL")
                {
                    eventArgs.EntityListsForAll = new EntityLists(this._FirstListOfEntities, this._SecondListOfEntities);
                    //this.FireEvent(eventArgs);
                    base.FireEventTrue(this, eventArgs);
                    return true;
                }
                else if (this._TestCondition == "ANY")
                {
                    eventArgs.EntityDictionaryForAny = returnDictionary;
                    //this.FireEvent(eventArgs);
                    base.FireEventTrue(this, eventArgs);
                    return true;
                }
                else
                    return false;
            }
            else
            {
                base.FireEventFalse(this, eventArgs);
                return false;
            }
        }*/

        private bool TestForAll()
        {
            List<bool> checkList = new List<bool>();

            foreach (string firstID in _FirstListOfEntities)
            {
                foreach (string secondID in _SecondListOfEntities)
                {
                    if (firstID != secondID)
                    {
                        checkList.Add(EntityContainer.ListOfEntities[firstID].Shape.CheckDistance(EntityContainer.ListOfEntities[secondID].Shape, _MinimumThreshold, _MaximumThreshold, this));
                    }
                }
            }

            if (checkList.Contains(false))
            {
                return false;
            }
            else
                return true;
        }

        private Dictionary<string, List<string>> TestForAny()
        {
            List<bool> checkList = new List<bool>();
            List<string> returnList = new List<string>();
            Dictionary<string, List<string>> returnDictionary = new Dictionary<string, List<string>>();

            foreach (string firstID in _FirstListOfEntities)
            {
                foreach (string secondID in _SecondListOfEntities)
                {
                    if (firstID != secondID)
                    {
                        if (EntityContainer.ListOfEntities[firstID].Shape.CheckDistance(EntityContainer.ListOfEntities[secondID].Shape, _MinimumThreshold, _MaximumThreshold, this))
                        {
                            checkList.Add(true);
                            returnList.Add(secondID);
                        }
                    }
                }
                if (returnList.Count > 0 && returnDictionary.ContainsKey(firstID) == false)
                {
                    returnDictionary.Add(firstID, returnList);
                }
            }

            if (returnDictionary.Count > 0)
                return returnDictionary;
            else
                return new Dictionary<string, List<string>>();
        }
        /// <summary>
        /// <c>OnDistanceEvent</c> method is called to raise <c>DistanceEvent</c> in case of
        /// rule validation
        /// </summary>
        /*private void FireEvent(ProximityEventArgs args)
        {
            if (OnEvent != null)
            {
                OnEvent(this, args);
            }
        }*/
    }
}
