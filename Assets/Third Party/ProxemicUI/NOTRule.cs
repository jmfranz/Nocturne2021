/// ------------------------------------------------------------------------------------------------
/// 
/// Project:        ProxemicUIFramework
/// Description:    This framework was build to provide developers the support to build proxemics
///                 aware applications. It provides developers a set of proxemic events based on 
///                 proxemics data of entities , that include absolute data of entities in an 
///                 environment, relative data between entities in that environment, and combanation
///                 of any of these data. It also provides developers with a combanation of proxemic
///                 events and UI events which we call Hybrid Events.
/// Version:        1.0
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
    /// <c>NOTRule</c> tests one <c>Rules</c> with NOT, if it is false
    /// it return true and fires the event
    /// </summary>
    public class NOTRule : CompoundRules
    {
        /// <summary>
        /// <c>NOTEvent</c> is defind as public event and is listed within the rule 
        /// so the compiler will only fire the event of rule instance
        /// </summary>
        //public override event RuleHandler OnEvent;
        /// <summary>
        /// to store the <c>ProximityRules</c> to be tested
        /// </summary>
        private Rules _Rule;

        CompoundRulesEventArgs CompoundRulesEventArgs = new CompoundRulesEventArgs();
        /// <summary>
        /// class constructor that has one <c>Rule</c> as an argument
        /// </summary>
        /// <param name="FirstRule"></param>
        public NOTRule(Rules Rule)
        {
            this._Rule = Rule;
        }
        /// <summary>
        /// <c>test</c> method is used to check if the rule is valid and call <c>OnNotEvent</c>
        /// upon rule validation to fire <c>XOREvent</c>
        /// </summary>
        /// <returns><c>test</c> method reutrns true if the rule is valid and false if the
        /// rule is not valid</returns>
        public override bool Test()
        {
            if (!this._Rule.Test())
            {
                CompoundRulesEventArgs.RuleForNOT = this._Rule;
                //FireEvent(CompoundRulesEventArgs);
                FireEventTrue(this, CompoundRulesEventArgs);
                if (!EventTracker)
                {
                    EventTracker = true;
                    FireEventChanged(this, CompoundRulesEventArgs);
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
        /// <summary>
        /// <c>OnNotEvent</c> method is called to raise <c>NOTEvent</c> if the rule is valid
        /// </summary>
        /*private void FireEvent(ProximityEventArgs args)
        {
            if (OnEvent != null)
                OnEvent(this, args);
        }*/
    }
}
