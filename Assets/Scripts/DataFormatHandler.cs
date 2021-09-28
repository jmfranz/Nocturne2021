using UnityEngine;

public class DataFormatHandler : MonoBehaviour
{
    //singleton
    private static DataFormatHandler _instance;
    public static DataFormatHandler Instance
    {
        get
        {
            if (_instance == null)
            {
                var singletonObject = GameObject.Find("GameManager");
                _instance = singletonObject.AddComponent<DataFormatHandler>();
            }
            return _instance;
        }
    }

    public string[] ConvertCSVStringToStringArray(string input)
    {
        string[] names = input.Split(',');
        for (int i = 0; i < names.Length; i++)
        {
            names[i] = names[i].Trim();
        }

        return names;
    }

    public string ConvertStringArrayToCSVString(string[] input)
    {
        string names = "";
        for (int i = 0; i < input.Length; i++)
        {
            if(i == 0)
            {
                names += input[i];
            }
            else
            {
                names += ", " + input[i];
            }
        }

        return names;
    }
}
