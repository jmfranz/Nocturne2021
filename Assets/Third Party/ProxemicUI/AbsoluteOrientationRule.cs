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
    /// <c>AbsoluteOrientationRule</c> is a class that check if the absolute oreientation
    /// is within a threshold in the environment
    /// </summary>
    public class AbsoluteOrientationRule : AbsoluteProximityRules
    {
        /// <summary>
        /// <c>OreientationEvent</c> is defind as public event and is listed within the rule 
        /// so the compiler will only fire the event of rule instance
        /// </summary>
        //public override event RuleHandler OnEvent;
        /// <summary>
        /// to store oreientation thresholds
        /// </summary>
        private double _Minimumthreshold, _MaximumThreshold;
        /// <summary>
        /// to store oreientation thresholds, the minimum threshold list contains the minimum for (yaw, pitch, roll) for the same order
        /// the maximum threshold list contains the maximum for (yaw, pitch, roll) for the same order
        /// </summary>
        private List<double> _minimumThresholds = new List<double>(), _maximumThresholds = new List<double>();
        /// <summary>
        /// to store IDs of entities
        /// </summary>
        private List<string> _ListOfEntities = new List<string>();
        /// <summary>
        /// to store which orientation axis to be tested
        /// </summary>
        string _OrientationAxis;
        /// <summary>
        /// to store test condition (ALL or ANY) 
        /// </summary>
        private string _TestCondition = "ALL";
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Minimumthreshold"></param>
        /// <param name="MaximumThreshold"></param>
        /// <param name="Entity"></param>
        /// <param name="OrientationAxis"></param>
        /// <param name="TestCondition"></param>
        public AbsoluteOrientationRule(double Minimumthreshold, double MaximumThreshold, string Entity, string OrientationAxis, string TestCondition)
        {
            if (Entity == null)
                throw new ArgumentException("Entity in the constructor for the absolute orientation rule cannot be empty", "Entity");

            this._Minimumthreshold = Minimumthreshold;
            this._MaximumThreshold = MaximumThreshold;
            this._ListOfEntities.Add(Entity);
            this._OrientationAxis = OrientationAxis;
            this._TestCondition = TestCondition;
            base.Entities = _ListOfEntities;
        }
        /// <summary>
        /// the class constructor that has one <c>ProximityRule</c> list, two thresholds, and what orientation axis to be tested as arguments
        /// pass string contains ("yaw","pitch", or "roll") as a value
        /// </summary>
        /// <param name="Minimumthreshold"></param>
        /// <param name="MaximumThreshold"></param>
        /// <param name="ListOfEntities"></param>
        /// <param name="OrientationAxis">"YAW","PITCH", "ROLL", or "ALL"</param>
        /// <param name="TestCondition">"ALL" or "ANY"</param>
        public AbsoluteOrientationRule(double Minimumthreshold, double MaximumThreshold, List<string> ListOfEntities, string OrientationAxis, string TestCondition)
        {
            if (ListOfEntities.Count == 0)
                throw new ArgumentException("List of entities in the constructor for the absolute orientation rule cannot be empty", "ListOfEntities");

            this._Minimumthreshold = Minimumthreshold;
            this._MaximumThreshold = MaximumThreshold;
            this._ListOfEntities = ListOfEntities;
            this._OrientationAxis = OrientationAxis;
            this._TestCondition = TestCondition;
            base.Entities = ListOfEntities;
        }
        public AbsoluteOrientationRule(List<double> Minimumthresholds, List<double> MaximumThresholds, string Entity, string TestCondition)
        {
            if (Entity == null)
                throw new ArgumentException("Entit in the constructor for the absolute orientation rule cannot be empty", "Entity");

            this._minimumThresholds = Minimumthresholds;
            this._maximumThresholds = MaximumThresholds;
            this._ListOfEntities.Add(Entity);
            this._TestCondition = TestCondition;
            base.Entities = _ListOfEntities;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Minimumthresholds"></param>
        /// <param name="MaximumThresholds"></param>
        /// <param name="ListOfEntities"></param>
        /// <param name="TestCondition"></param>
        public AbsoluteOrientationRule(List<double> Minimumthresholds, List<double> MaximumThresholds, List<string> ListOfEntities, string TestCondition)
        {
            if (ListOfEntities.Count == 0)
                throw new ArgumentException("List of entities in the constructor for the absolute orientation rule cannot be empty", "ListOfEntities");

            this._minimumThresholds = Minimumthresholds;
            this._maximumThresholds = MaximumThresholds;
            this._ListOfEntities = ListOfEntities;
            this._TestCondition = TestCondition;
            base.Entities = ListOfEntities;
        }
        /// <summary>
        /// <c>test</c> method is used to check if the rule is valid and call <c>OnAbsoluteOreientationEvent</c>
        /// upon rule validation to fire <c>OreientationEvent</c>
        /// </summary>
        /// <returns><c>test</c> method reutrns true if the rule is valid and false if the
        /// rule is not valid</returns>
        public override bool Test()
        {
            List<bool> checkList = new List<bool>();
            List<string> returnedIDs = new List<string>();
            AbsoluteBasicProximityEventArgs eventArgs = new AbsoluteBasicProximityEventArgs();

            if (this._TestCondition == "ALL")
            {
                checkList = TestAll();
                if (checkList.Count > 0 && checkList.Contains(false) == false)
                {
                    eventArgs.ListOfEntities = this._ListOfEntities;
                    //this.FireEvent(eventArgs);
                    FireEventTrue(this, eventArgs);
                    if (!EventTracker)
                    {
                        EventTracker = true;
                        FireEventChanged(this, eventArgs);
                    }
                    return true;
                }
                else
                {
                    FireEventFalse(this, null);
                    if (EventTracker)
                    {
                        EventTracker = false;
                        FireEventChanged(this, null);
                    }
                    return false;
                }
            }
            else if (this._TestCondition == "ANY")
            {
                returnedIDs = TestAny();
                if (returnedIDs.Count > 0)
                {
                    eventArgs.ListOfEntities = returnedIDs;
                    //this.FireEvent(eventArgs);
                    FireEventTrue(this, eventArgs);
                    if (!EventTracker)
                    {
                        EventTracker = true;
                        FireEventChanged(this, eventArgs);
                    }
                    return true;
                }
                else
                {
                    FireEventFalse(this, null);
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

        private List<bool> TestAll()
        {
            List<bool> checkList = new List<bool>();

            if (this._OrientationAxis != "ALL" && this._TestCondition == "ALL")
            {
                foreach (string value in _ListOfEntities)
                {
                    Orientation orientation = EntityContainer.ListOfEntities[value].GetOrientation();

                    if (this._OrientationAxis == "yaw")
                    {
                        checkList.Add(EntityContainer.ListOfEntities[value].Shape.CheckAbsoluteOrientation(orientation.Yaw, this._Minimumthreshold, this._MaximumThreshold));
                    }
                    else
                        if (this._OrientationAxis == "pitch")
                    {
                        checkList.Add(EntityContainer.ListOfEntities[value].Shape.CheckAbsoluteOrientation(orientation.Pitch, this._Minimumthreshold, this._MaximumThreshold));
                    }
                    else
                            if (this._OrientationAxis == "roll")
                    {
                        checkList.Add(EntityContainer.ListOfEntities[value].Shape.CheckAbsoluteOrientation(orientation.Roll, this._Minimumthreshold, this._MaximumThreshold));
                    }
                }
            }
            else
                if (this._OrientationAxis == "ALL" && this._TestCondition == "ALL")
            {
                foreach (string value in _ListOfEntities)
                {
                    Orientation orientation = EntityContainer.ListOfEntities[value].GetOrientation();

                    checkList.Add(EntityContainer.ListOfEntities[value].Shape.CheckAbsoluteOrientation(orientation, this._minimumThresholds, this._maximumThresholds));
                }
            }
            return checkList;
        }

        private List<string> TestAny()
        {
            List<string> returnedIDs = new List<string>();

            if (this._OrientationAxis != "ALL" && this._TestCondition == "ANY")
            {
                foreach (string value in _ListOfEntities)
                {
                    Orientation orientation = EntityContainer.ListOfEntities[value].GetOrientation();

                    if (this._OrientationAxis == "yaw")
                    {
                        if (EntityContainer.ListOfEntities[value].Shape.CheckAbsoluteOrientation(orientation.Yaw, this._Minimumthreshold, this._MaximumThreshold))
                            returnedIDs.Add(value);
                    }
                    else
                        if (this._OrientationAxis == "pitch")
                    {
                            if (EntityContainer.ListOfEntities[value].Shape.CheckAbsoluteOrientation(orientation.Pitch, this._Minimumthreshold, this._MaximumThreshold))
                            returnedIDs.Add(value);
                    }
                    else
                        if (this._OrientationAxis == "roll")
                    {
                            if (EntityContainer.ListOfEntities[value].Shape.CheckAbsoluteOrientation(orientation.Roll, this._Minimumthreshold, this._MaximumThreshold))
                            returnedIDs.Add(value);
                    }
                }
            }
            else
                if (this._OrientationAxis == "ALL" && this._TestCondition == "ANY")
            {
                foreach (string value in _ListOfEntities)
                {
                    Orientation orientation = EntityContainer.ListOfEntities[value].GetOrientation();

                    if (EntityContainer.ListOfEntities[value].Shape.CheckAbsoluteOrientation(orientation, this._minimumThresholds, this._maximumThresholds))
                        returnedIDs.Add(value);
                }
            }
            return returnedIDs;
        }
        /// <summary>
        /// <c>OnAbsoluteOreientationEvent</c> method is called to raise <c>OreientationEvent</c> in case of
        /// rule validation
        /// </summary>
        /*private void FireEvent(ProximityEventArgs args)
        {
            if (OnEvent != null)
                OnEvent(this, args);
        }*/
    }
}
