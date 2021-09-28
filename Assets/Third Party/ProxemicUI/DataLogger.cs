using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ProxemicUIFramework
{
    public sealed class DataLogger
    {
        public static void EntityDataLogger()
        {

        }
        /*rivate static DataLogger instance = new DataLogger();

        public static DataLogger Instance
        {
            get { return instance; }

        }
        // dictionary to keep record of entity data over time
        public static Dictionary<string, List<ProximityEntity>> LoggerDictionary = new Dictionary<string, List<ProximityEntity>>();

        public static List<ProximityRules> ListOfProximityRules = new List<ProximityRules>();

        // logger method to keep records of entity data over time
        public static void EntityDataLogger()
        {
            foreach (KeyValuePair<string, ProximityEntity> pair in EntityContainer.ListOfEntities)
            {
                // if the entitiy already exists, this will add the data to previous data
                if (LoggerDictionary.ContainsKey(pair.Key))
                {
                    LoggerDictionary[pair.Key].Add(pair.Value);
                }
                // if the entity doesn't exists, this adds it as new entity
                else
                {
                    List<ProximityEntity> list = new List<ProximityEntity>();
                    list.Add(pair.Value);
                    LoggerDictionary.Add(pair.Key, list);
                }
            }
        }
        public void BasicRuleLogger(ProximityRules proximityRules)
        {
            ListOfProximityRules.Add(proximityRules);
            Console.WriteLine(proximityRules);


        }
        public void RuleLogger(Rules rule, double MinimumThreshold, double MaximumThreshold, List<string> FirstListOfEntities, List<string> SecondListOfEntities)
        {
            using (StreamWriter writer = new StreamWriter("D:\\Dataset.txt"))
            {
                writer.WriteLine(rule.ToString() + ", " + MinimumThreshold.ToString() + ", " + MaximumThreshold + ", " + "Mobile, " + "Stable");
            }
        }
        public void CompoundRuleLogger()
        {

        }
        public void HybridRuleLogger()
        {

        }
        public void FiredEventsLogger()
        {

        }*/
    }
}