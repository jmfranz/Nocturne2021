/// ------------------------------------------------------------------------------------------------
/// 
/// Project:        ProxemicUIFramework
/// Description:    This framework was build to provide developers the support to build proxemics
///                 aware applications. It provides developers a set of proxemic events based on 
///                 proxemics data of entities , that include absolute data of entities in an 
///                 environment, relative data between entities in that environment, and combanation
///                 of any of these data. It also provides developers with a combanation of proxemic
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
    /// <c>RelativeOrientationRule</c> is a class that check if the orientation of an entity
    /// is within a threshold relative to another entity
    /// </summary>
    public class RelativeOrientationRule : RelativeProximityRules
    {
        //public override event RuleHandler OnEvent;

        //private double _Minimumthreshold, _MaximumThreshold;

        private List<string> _FirstListOfEntities = new List<string>(), _SecondListOfEntities = new List<string>();

        private double _Threshold;

        private string _TestCondition = "ALL";

        /*public RelativeOrientationRule(double Minimumthreshold, double MaximumThreshold, List<string> FirstListOfEntities, List<string> SecondListOfEntities)
        {
            if (FirstListOfEntities.Count == 0)
                throw new ArgumentException("First list of entities in the constructor for the relative distance rule cannot be empty", "FirstListOfEntities");
            if (SecondListOfEntities.Count == 0)
                throw new ArgumentException("Second list of entities in the constructor for the relative distance rule cannot be empty", "SecondListOfEntities");

            this._Minimumthreshold = Minimumthreshold;
            this._MaximumThreshold = MaximumThreshold;
            this._FirstListOfEntities = FirstListOfEntities;
            this._SecondListOfEntities = SecondListOfEntities;
            base.Entities = FirstListOfEntities.Union(SecondListOfEntities).ToList();
        }*/

        public RelativeOrientationRule(double Threshold, string FirstEntity, string SecondEntity, string TestCondition)
        {
            if (FirstEntity == null)
                throw new ArgumentException("First entity in the constructor for the relative orientation rule cannot be empty", "FirstEntity");
            if (SecondEntity == null)
                throw new ArgumentException("Second entity in the constructor for the relative orientation rule cannot be empty", "SecondEntity");

            this._Threshold = Threshold;
            this._FirstListOfEntities.Add(FirstEntity);
            this._SecondListOfEntities.Add(SecondEntity);
            this._TestCondition = TestCondition;
            base.Entities = _FirstListOfEntities.Union(_SecondListOfEntities).ToList();
        }

        public RelativeOrientationRule(double Threshold, string FirstEntity, List<string> SecondListOfEntities, string TestCondition)
        {
            if (FirstEntity == null)
                throw new ArgumentException("First entity in the constructor for the relative orientation rule cannot be empty", "FirstEntity");
            if (SecondListOfEntities.Count == 0)
                throw new ArgumentException("Second list of entities in the constructor for the relative orientation rule cannot be empty", "SecondListOfEntities");

            this._Threshold = Threshold;
            this._FirstListOfEntities.Add(FirstEntity);
            this._SecondListOfEntities = SecondListOfEntities;
            this._TestCondition = TestCondition;
            base.Entities = _FirstListOfEntities.Union(SecondListOfEntities).ToList();
        }

        public RelativeOrientationRule(double Threshold, List<string> FirstListOfEntities, List<string> SecondListOfEntities, string TestCondition)
        {
            if (FirstListOfEntities.Count == 0)
                throw new ArgumentException("First list of entities in the constructor for the relative orientation rule cannot be empty", "FirstListOfEntities");
            if (SecondListOfEntities.Count == 0)
                throw new ArgumentException("Second list of entities in the constructor for the relative orientation rule cannot be empty", "SecondListOfEntities");

            this._Threshold = Threshold;
            this._FirstListOfEntities = FirstListOfEntities;
            this._SecondListOfEntities = SecondListOfEntities;
            this._TestCondition = TestCondition;
            base.Entities = FirstListOfEntities.Union(SecondListOfEntities).ToList();
        }

        public override bool Test()
        {
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

        // In this test: all thresholds test are true for at least two entities, and each entity in the list is within at least one threshold of another entity 
        private bool TestForAll()
        {
            List<bool> checkList = new List<bool>();

            foreach (string firstID in _FirstListOfEntities)
            {
                foreach (string secondID in _SecondListOfEntities)
                {
                    if (firstID != secondID)
                    {
                        checkList.Add(EntityContainer.ListOfEntities[firstID].Shape.CheckRelativeOrientation(EntityContainer.ListOfEntities[secondID].Shape, _Threshold));
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

        // In this test: any entities are at least within one threshold of each other.
        private Dictionary<string, List<string>> TestForAny()
        {
            List<bool> checkList = new List<bool>();
            List<string> returnList = new List<string>();
            Dictionary<string, List<string>> returnDic = new Dictionary<string, List<string>>();

            foreach (string firstID in _FirstListOfEntities)
            {
                foreach (string secondID in _SecondListOfEntities)
                {
                    if (firstID != secondID)
                    {
                        if (EntityContainer.ListOfEntities[firstID].Shape.CheckRelativeOrientation(EntityContainer.ListOfEntities[secondID].Shape, _Threshold))
                        {
                            checkList.Add(true);
                            returnList.Add(secondID);
                            
                        }
                    }
                }
                if (returnList.Count > 0 && returnDic.ContainsKey(firstID) == false)
                {
                    returnDic.Add(firstID, returnList);
                }
            }

            if (returnDic.Count > 0)
            {
                return returnDic;
            }
            else
                return new Dictionary<string, List<string>>();
        }

        /*private void FireEvent(ProximityEventArgs args)
        {
            if (OnEvent != null)
            {
                OnEvent(this, args);
            }
        }*/
    }
}
