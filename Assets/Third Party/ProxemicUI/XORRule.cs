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
    /// <c>XORRule</c> tests any two <c>Rules</c> with XOR one <c>Rules</c>
    /// must be true and the other one must be false in order to the <c>XORRule</c> to pass.
    /// </summary>
    public class XORRule : CompoundRules
    {
        /// <summary>
        /// <c>XORRule</c> is defind as public event and is listed within the rule 
        /// so the compiler will only fire the event of rule instance
        /// </summary>
        //public override event RuleHandler OnEvent;
        /// <summary>
        /// to store the two <c>Rules</c> to be tested
        /// </summary>
        private Rules _FirstRule, _SecondRule;

        private CompoundRulesEventArgs CompoundRulesEventArgs = new CompoundRulesEventArgs();
        /// <summary>
        /// class constructor that has two <c>Rule</c> as arguments
        /// </summary>
        /// <param name="FirstRule"></param>
        /// <param name="SecondRule"></param>
        public XORRule(Rules FirstRule, Rules SecondRule)
        {
            this._FirstRule = FirstRule;
            this._SecondRule = SecondRule;

            this._FirstRule.OnEventTrue += _FirstRule_OnEventTrue;
            this._SecondRule.OnEventTrue += _SecondRule_OnEventTrue;
        }
        /// <summary>
        /// <c>test</c> method is used to check if the rule is valid and call <c>OnXorEvent</c>
        /// upon rule validation to fire <c>XOREvent</c>
        /// </summary>
        /// <returns><c>test</c> method reutrns true if the rule is valid and false if the
        /// rule is not valid</returns>
        public override bool Test()
        {
            if ((this._FirstRule.Test() && !this._SecondRule.Test()) || (!this._FirstRule.Test() && this._SecondRule.Test()))
            {
                if (this.CompoundRulesEventArgs.RuleTupleForORandXOR != null)
                {
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
                    return false;
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

        private void _SecondRule_OnEventTrue(Rules sender, ProximityEventArgs args)
        {
            this.CompoundRulesEventArgs.RuleTupleForORandXOR = new Tuple<Rules, ProximityEventArgs>(sender, args);
        }

        private void _FirstRule_OnEventTrue(Rules sender, ProximityEventArgs args)
        {
            this.CompoundRulesEventArgs.RuleTupleForORandXOR = new Tuple<Rules, ProximityEventArgs>(sender, args);
        }

        /// <summary>
        /// <c>OnXorEvent</c> method is called to raise <c>XOREvent</c> if the rule is valid
        /// </summary>
        /*private void FireEvent(ProximityEventArgs args)
        {
            if (OnEvent != null)
                OnEvent(this, args);
        }*/
    }
}
