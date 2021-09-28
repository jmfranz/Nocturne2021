using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProxemicUIFramework
{
    public class ProximityEventArgs : EventArgs
    {

    }
    public class RelativeBasicProximityEventArgs : ProximityEventArgs
    {
        /// <summary>
        /// When the test condition for the basic rule is "ALL" this contains the two lists of entities that was passed to the rule
        /// </summary>
        public EntityLists EntityListsForAll { get; set; }

        /// <summary>
        /// When the test condition for the basic rule is "ANY" this contains a dictionary where the keys are IDs from the first list
        /// and the value is a list with all IDs of entities that passed the test with the key
        /// </summary>
        public Dictionary<string, List<string>> EntityDictionaryForAny { get; set; }

        /// <summary>
        /// return a single list for IsFacing rule
        /// </summary>
        public List<string> EntityListForIsFacing { get; set; }
    }

    public class AbsoluteBasicProximityEventArgs : ProximityEventArgs
    {
        /// <summary>
        /// this is for baisc Absolute rule which return a list of entities that passed the test
        /// </summary>
        public List<string> ListOfEntities { get; set; }
    }

    public class CompoundRulesEventArgs : ProximityEventArgs
    {
        /// <summary>
        /// The returning argument of AND Rule is a dictionary that contains the rule as an object
        /// (key of the dictionary) and the returing argument of that rule (value of the dictionary)
        /// </summary>
        public Dictionary<Rules, ProximityEventArgs> RuleDictionaryForAND { get; set; }

        /// <summary>
        /// this is for OR and XOR Compound Rules which return the Rule and its argument if it passes the test
        /// </summary>
        public Tuple<Rules, ProximityEventArgs> RuleTupleForORandXOR { get; set; }

        /// <summary>
        /// this is for NOT Compound Rule which return a single rule
        /// </summary>
        public Rules RuleForNOT { get; set; }
    }

    public class HybridEventArgs: ProximityEventArgs
    {
        /// <summary>
        /// this is Hybrid Rule which return the proximity event arguments that was passed to the Hybrid rule
        /// </summary>
        public ProximityEventArgs RuleArgsForHybrid { get; set; }
    }

    public class FformationEventArgs: ProximityEventArgs
    {
        public List<Tuple<string, Position, Orientation>> TuplesForFformation { get; set; }
    }
}
