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
using System.Windows.Input;
                                                                                       
namespace ProxemicUIFramework
{
    /// <summary>
    /// <c>HybridRule</c> is a class that combine both Proximity events with any external events
    /// </summary>
    public class HybridRule : Rules
    {
        /// <summary>
        /// <c>HybridEvent</c> is defind as public event and is listed within the rule 
        /// so the compiler will only fire the event of rule instance
        /// </summary>
        //public override event RuleHandler OnEvent;
        /// <summary>
        /// to store <c>ProximityRule</c> instance
        /// </summary>
        private Rules _Rule;
      
        private ProximityEventArgs _ProximityEventArgs = new ProximityEventArgs();

        private HybridEventArgs eventArgs = new HybridEventArgs();
        /// <summary>
        /// class constructor that has only one <c>ProximityRule</c> as an argument
        /// </summary>
        /// <param name="rule"></param>
        public HybridRule(Rules Rule)
        {
            this._Rule = Rule;
        }
        /// <summary>
        /// <c>test</c> method is used to check if the rule is valid and call <c>OnHybridEvent</c>
        /// upon rule validation to fire <c>HybridEvent</c>
        /// </summary>
        /// <returns><c>test</c> method reutrns true if the rule is valid and false if the
        /// rule is not valid</returns>
        public override bool Test()
        {
            this._Rule.OnEventTrue += _Rule_OnEventTrue;

            if (this._Rule.Test())
            {
                if (this._ProximityEventArgs != null)
                {
                    eventArgs.RuleArgsForHybrid = _ProximityEventArgs;
                    //FireEvent(eventArgs);
                    FireEventTrue(this, eventArgs);
                    if (!EventTracker)
                    {
                        EventTracker = true;
                        FireEventChanged(this, eventArgs);
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

        private void _Rule_OnEventTrue(Rules sender, ProximityEventArgs args)
        {
            this._ProximityEventArgs = args;
        }

        /// <summary>
        /// <c>UIEvent</c> is called as a handler of UI events, its job is to call <c>test</c> 
        /// mothod of the current instance of the <c>HybridRule</c> to validate the rule
        /// </summary>
        /// <param name="sender">UI Object the raises UI event</param>
        /// <param name="e">External event data</param>
        public void ExternalEvent(object sender, EventArgs e)
        {
            // call test method of this class
            this.Test();
        }

        public void ExternalEvent()
        {
            // call test method of this class
            this.Test();
        }
        /// <summary>
        /// <c>OnHybridEvent</c> method is called to raise <c>HybridEvent</c> if the rule is valid
        /// </summary>
        /*private void FireEvent(ProximityEventArgs args)
        {
            if (OnEvent != null)
                OnEvent(this, args);
        }*/
    }
}
