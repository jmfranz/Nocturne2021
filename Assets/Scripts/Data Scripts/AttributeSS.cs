/*
 * Author: Abbey Singh
 * This holds information about an attribute
 */

using System.Collections.Generic;

[System.Serializable]
public class AttributeSS
{
    //consists of attribute name
    public string AttributeName;

    public List<string> SpaceSyntaxOptions; //options such as lowest, low, moderate, high, highest, or none

    public AttributeSS(string name, List<string> options = null)
    {
        AttributeName = name;
        SpaceSyntaxOptions = options;
    }
}
