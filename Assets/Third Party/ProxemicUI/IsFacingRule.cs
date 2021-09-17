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
//ing System.Windows.Media.Media3D;
using System.Numerics;

namespace ProxemicUIFramework
{
    public class IsFacingRule : RelativeProximityRules
    {
        private double _Threshold;
        private List<string> _ListOfEntities = new List<string>();
        private Vector3 _TargetPoint;
        private string _TestCondition = "ALL";

        public IsFacingRule(double Threshold, string Entity, Vector3 TargetPoint)
        {
            this._Threshold = Threshold;
            this._ListOfEntities.Add(Entity);
            this._TargetPoint = TargetPoint;
            base.Entities = _ListOfEntities;
        }

        public IsFacingRule(double Threshold, List<string> ListOfEntities, Vector3 TargetPoint, string TestCondition)
        {
            this._Threshold = Threshold;
            this._ListOfEntities = ListOfEntities;
            this._TargetPoint = TargetPoint;
            this._TestCondition = TestCondition;
            base.Entities = _ListOfEntities;
        }

        public override bool Test()
        {
            RelativeBasicProximityEventArgs eventArgs = new RelativeBasicProximityEventArgs();

            if (_TestCondition == "ALL")
            {
                if (TestForALL())
                {
                    eventArgs.EntityListForIsFacing = _ListOfEntities;
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
                List<string> result = TestForAny();
                if (result.Count > 0 || result != null)
                {
                    eventArgs.EntityListForIsFacing = result;
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

        private bool TestForALL()
        {
            List<bool> checkList = new List<bool>();

            foreach (string ID in _ListOfEntities)
            {
                checkList.Add(EntityContainer.ListOfEntities[ID].Shape.IsFacing(_TargetPoint, _Threshold));
            }

            if (checkList.Contains(false))
            {
                return false;
            }
            else
                return true;
        }

        private List<string> TestForAny()
        {
            List<bool> checkList = new List<bool>();
            List<string> returnList = new List<string>();

            foreach (string ID in _ListOfEntities)
            {
                if (EntityContainer.ListOfEntities[ID].Shape.IsFacing(_TargetPoint, _Threshold))
                {
                    returnList.Add(ID);
                }
            }

            if (returnList.Count > 0)
                return returnList;
            else
                return null;
        }
    }
}
