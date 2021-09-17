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
using System.Timers;
using System.Threading;
using System.Diagnostics;

namespace ProxemicUIFramework
{
    public class MobilityRule : Rules
    {
        //public override event RuleHandler OnEvent;
        /// <summary>
        /// to store distance threshold and duration to re-capture the position to run the test
        /// </summary>
        private int _duration;
        private double _threshold;

        //private Timer timer;
        //private Thread thread = new Thread(new ThreadStart(test));

        private AbsoluteBasicProximityEventArgs eventArgs = new AbsoluteBasicProximityEventArgs();

        private List<string> _EntitiesList = new List<string>();

        private List<ProximityEntity> _proximityEntities = new List<ProximityEntity>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Entity"></param>
        /// <param name="Duration"></param>
        /// <param name="Threshold"></param>
        public MobilityRule(string Entity, int Duration, double Threshold)
        {
            if (Entity == null)
                throw new ArgumentException("Entity is empty, make sure you recive entities data through OSC");

            this._EntitiesList.Add(Entity);
            this._duration = Duration;
            this._threshold = Threshold;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="EntitiesList"></param>
        /// <param name="Duration"></param>
        /// <param name="Threshold"></param>
        public MobilityRule(List<string> EntitiesList, int Duration, double Threshold)
        {
            if (EntitiesList.Count == 0)
                throw new ArgumentException("The main list of entities is empty, make sure you recive entities data through OSC");
            
            this._EntitiesList = EntitiesList;
            this._duration = Duration;
            this._threshold = Threshold;
        }
        /// <summary>
        /// <c>test</c> method is used to check if the rule is valid and update IsStable feild based on the result of the test
        /// </summary>
        /// <returns><c>test</c> method reutrns true if the rule is valid and false if the
        /// rule is not valid</returns>
        public override bool Test()
        {
            foreach(string EntityID in _EntitiesList)
            {
                this._proximityEntities.Add(EntityContainer.ListOfEntities[EntityID]);
            }

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            while(true)
            {
                if (stopwatch.ElapsedMilliseconds.Equals(_duration * 1000))
                {
                    stopwatch.Stop();
                    break;
                }
            }

            foreach (ProximityEntity value in _proximityEntities)
            {
                string id = value.EntityID;

                Position oldPosition = value.GetPosition(), newPosition = EntityContainer.ListOfEntities[id].GetPosition();

                // call CheckStability method to check if the difference between old and new position grater than the threshold then the entity is mobile
                bool mobile = EntityContainer.ListOfEntities[id].Shape.MobilityCheck(oldPosition, newPosition, _threshold);

                if (mobile)
                {
                    EntityContainer.ListOfEntities[id].IsStable = false;
                    this.eventArgs.ListOfEntities.Add(id);
                }
            }
            FireEventTrue(this, eventArgs);
            return true;
        }
        /*private void FireEvent(ProximityEventArgs args)
        {
            if (OnEvent != null)
                OnEvent(this, args);
        }*/
    }
}
