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
    /// <c> ProximityRules </c> is the parent class of all <c>ProximityRules</c> (relative, compound, and
    /// absolute rules. It is implemented as an abstract class to include any shared code between Proximity Rules.
    /// </summary>
    public abstract class ProximityRules : Rules
    {
        /// <summary>
        /// gets the absolute difference between two values
        /// </summary>
        /// <param name="value1">first value</param>
        /// <param name="value2">second value</param>
        /// <returns>absolute difference</returns>
        public static int GetAbsDifference(int value1, int value2)
        {
            return Math.Abs(value1 - value2);
        }  
    }
}
