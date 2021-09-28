/*
 * Author: Abbey Singh
 * This will hold a list of rules that will go into a json "Rules" file
 */

using System.Collections.Generic;

[System.Serializable]
public class ListOfRules
{
    public List<RulesFormat> RulesList = new List<RulesFormat>();

    public void AddRules(RulesFormat rule)
    {
        RulesList.Add(rule);
    }

    public List<RulesFormat> GetRules()
    {
        return RulesList;
    }
}
