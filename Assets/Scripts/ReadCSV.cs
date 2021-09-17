/*
 * Author: Ramanpreet Kaur
 * This script will read the CSV for DepthMap analysis.
 */

using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ReadCSV : MonoBehaviour
{
    private string directory;
    private string directoryPath;
    private string filePath;
    private string Map;
    private List<string> xPoint = new List<string>();
    private List<string> yPoint = new List<string>();
    public List<string> VisualIntegration;
    public List<string> visualComplexity;
    public List<string> openness;
    private int xValues;
    private int yValues;
    private int levels = 2;
    private int opennessValues;
    private int visualcomplexityValues;
    private int VisualIntegrationValues;
    public ViewStoriesController view = new ViewStoriesController();

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void ReadCSVfile()
    {
        Map = GameState.Instance.GetCurrentStoryData().MapSelected;
      
        VisualIntegration = new List<string>();
        visualComplexity = new List<string>();
        openness = new List<string>();
        #if UNITY_STANDALONE_OSX
            directory = "/Library/SpaceSyntaxData/";

        #endif

        #if UNITY_STANDALONE_WIN
            directory = "/SpaceSyntaxData/";
            directoryPath = Path.GetPathRoot(Application.dataPath) + "SpaceSyntaxData";

        #endif

        #if UNITY_STANDALONE_LINUX
            directory = "~/SpaceSyntaxData/";

        #endif
        
        filePath = directoryPath + "/Maps/Details/" + Map+"Details.csv";
        StreamReader streamReader = new StreamReader(filePath);
        bool endOfFile = false;
        while (!endOfFile)
        {
            string data_string = streamReader.ReadLine();
            if (data_string == null)
            {
                endOfFile = true;
                break;
            }

            string[] data_values = data_string.Split(',');
            for (int i = 1; i < data_values.Length; i++)
            {
                //Fetching the x cordinate
                if (data_values[i].ToString() == "x")
                {
                    xValues = i;
                }

                //Fetching the y cordinate
                if (data_values[i].ToString() == "y")
                {
                    yValues = i;
                    
                }

                //Fetching the Openness"
                if (data_values[i].ToString() == "Isovist Area")
                {
                    opennessValues = i;
                }

                //Fetching the VisualIntegration"
                if (data_values[i].ToString() == "Visual Integration [HH]")
                {
                    VisualIntegrationValues = i;
                }

                //Fetching the Visual Complexity"
                if (data_values[i].ToString() == "Isovist Perimeter")
                {
                    visualcomplexityValues = i;
                }
            }

            //Storing the values into the respective list

            if (xValues != 0 && yValues != 0 && VisualIntegrationValues != 0 && opennessValues != 0 && visualcomplexityValues != 0)
            {
                string x = data_values[xValues].ToString();
                string y = data_values[yValues].ToString();
                string open = data_values[opennessValues].ToString();
                string visual = data_values[visualcomplexityValues].ToString();
                string visualIntegration = data_values[VisualIntegrationValues].ToString();
                xPoint.Add(x);
                yPoint.Add(y);
                openness.Add(open);
                visualComplexity.Add(visual);
                VisualIntegration.Add(visualIntegration);
            }
        }
    }
}