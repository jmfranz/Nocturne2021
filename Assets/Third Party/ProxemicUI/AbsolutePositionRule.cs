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


//*****************************************
//***** This class is not implemented *****
//*****************************************


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProxemicUIFramework
{
    /// <summary>
    /// <c>AbsolutePositionRule</c> is a class that check if the absolute position
    /// is within a threshold in the environment
    /// </summary>
    public class AbsolutePositionRule : AbsoluteProximityRules
    {
        //public override event RuleHandler OnEvent;
        /// <summary>
        /// to store oreientation thresholds
        /// </summary>
        private Position _Minimumthreshold, _MaximumThreshold;
        /// <summary>
        /// to store IDs of entities
        /// </summary>
        private List<string> _ListOfEntities = new List<string>();
        /// <summary>
        /// to store test condition (ALL or ANY) 
        /// </summary>
        private string _TestCondition = "ALL";
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Minimumthreshold"></param>
        /// <param name="MaximumThreshold"></param>
        /// <param name="ListOfEntities"></param>
        /// <param name="TestCondition"></param>
        public AbsolutePositionRule(Position Minimumthreshold, Position MaximumThreshold, List<string> ListOfEntities, string TestCondition)
        {
            if (ListOfEntities.Count == 0)
                throw new ArgumentException("List of entities in the constructor for the absolute position rule cannot be empty", "ListOfEntities");

            this._Minimumthreshold = Minimumthreshold;
            this._MaximumThreshold = MaximumThreshold;
            this._ListOfEntities = ListOfEntities;
            this._TestCondition = TestCondition;
            base.Entities = ListOfEntities;
        }

        public override bool Test()
        {
            throw new NotImplementedException();
        }
        /*private void FireEvent(ProximityEventArgs args)
        {
            if (OnEvent != null)
                OnEvent(this, args);
        }*/
    }
}
