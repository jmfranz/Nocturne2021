using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProxemicUIFramework
{
    public abstract class Fformation
    {
        public delegate void FformationHandler(Fformation fformation, ProximityEventArgs proximityEvent);

        public event FformationHandler OnFormationCompleted, OnFormationUpdated;

        internal abstract void CreateFormation();

        internal List<string> Entities = new List<string>();

        protected void FireEventCompleted(Fformation fformation, ProximityEventArgs proximityEvent)
        {
            if (OnFormationCompleted != null)
            {
                OnFormationCompleted(fformation, proximityEvent);
            }
        }

        protected void FireEventUpdated(Fformation fformation, ProximityEventArgs proximityEvent)
        {
            if (OnFormationUpdated != null)
            {
                OnFormationUpdated(fformation, proximityEvent);
            }
        }
    }
}
