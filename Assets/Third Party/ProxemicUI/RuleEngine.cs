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
using System.Threading;
using System.Threading.Tasks;

namespace ProxemicUIFramework
{
    /// <summary>
    /// <c>RuleEngine</c> is a class that allows to check rules continuously as long as a rule in
    /// the rule list
    /// </summary>
    public sealed class RuleEngine
    {
        private static RuleEngine instance = new RuleEngine();
        private RuleEngine()
        { }

        public static RuleEngine Instance
        {
            get { return instance; }
        }
        /// <summary>
        /// to store all rules to be tested
        /// </summary>
        public List<Rules> listOfRules = new List<Rules>();
        /// <summary>
        /// to store formation to be tested
        /// </summary>
        public List<Fformation> listOfFormation = new List<Fformation>();
        /// <summary>
        /// a task to start running <c>TestRunner</c> and <c>FormationCreator</c> method
        /// </summary>
        private Task RuleTask, FormationTask;

        List<string> temporaryList = new List<string>();
        /// <summary>
        /// <c>AddToRuleList</c> allows developers to add rule to the list from their side
        /// </summary>
        /// <param name="r">a rule to be added to the list</param>
        public void AddToRuleList(Rules r)
        {
            // check and add the rule to the list
            if (listOfRules.Contains(r) == false)
            {
                listOfRules.Add(r);
                
                if (RuleTask == null)
                {
                    RuleTask = new Task(new Action(TestRunner));
                    RuleTask.Start();
                }
            }  
        }

        public void AddToFormationList(Fformation f)
        {
            if (listOfFormation.Contains(f) == false)
            {
                listOfFormation.Add(f);

                if (FormationTask == null)
                {
                    FormationTask = new Task(new Action(FormationCreator));
                    FormationTask.Start();
                }
            }
        }
        /// <summary>
        /// <c>RemoveFromRuleList</c> allows developers to remove rule from the list from their side
        /// </summary>
        /// <param name="r">a rule to be removed</param>
        public void RemoveFromRuleList(Rules r)
        {
            if (listOfRules.Contains(r))
                listOfRules.Remove(r);
        }

        public void RemoveFromFormationList(Fformation f)
        {
            if (listOfFormation.Contains(f))
                listOfFormation.Remove(f);
        }
        /// <summary>
        /// <c>TestRunner</c> will be running through <c>listOfRules</c> to test rules as long as
        /// <c>listOfRules</c> contains at least one rule
        /// </summary>
        private void TestRunner()
        {
            while (listOfRules.Count > 0)
            {
                // use this temporary list so the complier won't throw an error when the deleting a rule while running the loop
                //List<Rules> temporaryList = listOfRules;
                //if (temporaryList.Count > 0)
                //{

                // to copy all IDs from entity dictionary
                List<string> temporaryList = new List<string>(EntityContainer.ListOfEntities.Keys);

                /*foreach (KeyValuePair<string, ProximityEntity> pair in EntityContainer.ListOfEntities)
                {
                    temporaryList.Add(pair.Key);
                }*/

                for (int i = listOfRules.Count - 1; i >= 0; i--)
                {
                    Rules r = listOfRules[i];
                    if (r.Entities.All(temporaryList.Contains))
                    {
                        r.Test();
                    }
                }
                    /*foreach (Rules value in temporaryList)
                    {
                        value.Test();
                        // break if all rules were removed
                        //if (listOfRules.Count < 1)
                            //break;
                    }*/
                //}
            }
        }
        public void TestRunner(Rules rule)
        {
            if (rule == null)
                return;

            if (EntityContainer.ListOfEntities.Count > 0)
            {
                temporaryList.Clear();
                temporaryList = EntityContainer.ListOfEntities.Keys.ToList();

                if (rule.Entities.All(entity => temporaryList.Contains(entity)))//(rule.Entities.All(temporaryList.Contains))
                {
                    rule.Test();
                }
            }
        }
        private void FormationCreator()
        {
            while (listOfFormation.Count > 0)
            {
                // to copy all IDs from entity dictionary
                temporaryList.Clear();
                temporaryList = EntityContainer.ListOfEntities.Keys.ToList();

                for (int i = listOfFormation.Count - 1; i >= 0; i--)
                {
                    Fformation fformation = listOfFormation[i];
                    if (fformation.Entities.All(temporaryList.Contains))
                    {
                        fformation.CreateFormation();
                    }
                }
            }
        }
        public void FormationCreator(Fformation fformation)
        {
            if (fformation == null)
                return;

            if (EntityContainer.ListOfEntities.Count > 0)
            {
                List<string> temporaryList = new List<string>(EntityContainer.ListOfEntities.Keys);

                if (fformation.Entities.All(entity => temporaryList.Contains(entity)))
                {
                    fformation.CreateFormation();
                }
            }
        }
    }
}
