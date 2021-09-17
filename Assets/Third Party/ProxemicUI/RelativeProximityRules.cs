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
    /// <c> RelativeProximityRules </c> is the parent class of all Relative Rules. It is implemented
    /// as an abstract class to include any shared code between Relative Rules.
    /// </summary>
    public abstract class RelativeProximityRules : ProximityRules
    {

    }
}
