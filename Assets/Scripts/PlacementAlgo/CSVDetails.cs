/*
 * @Author: Abbey Singh
 * 
 * This script will have the helper functions for using a csv to get the space syntax data per point location
 * This script will be used by linearSort.cs.
 */


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class CSVDetails : MonoBehaviour
{
    string directoryPath;
    int minX, maxX, minY, maxY;
    List<SpaceSyntaxAttributesPoint> SpaceSyntaxAttributesPoints;

    Dictionary<string, List<SpaceSyntaxAttributesPoint>> pointsDict = new Dictionary<string, List<SpaceSyntaxAttributesPoint>>();
    Dictionary<string, List<int>> xDict = new Dictionary<string, List<int>>();
    Dictionary<string, List<int>> yDict = new Dictionary<string, List<int>>();

    public int GetMinX()
    {
        return minX;
    }

    public int GetMaxX()
    {
        return maxX;
    }

    public int GetMinY()
    {
        return minY;
    }

    public int GetMaxY()
    {
        return maxY;
    }


    void Awake()
    {
        //for editor
        #if UNITY_EDITOR_OSX
            directoryPath = "/Library/SpaceSyntaxData/Maps/Details/";
        #endif

        #if UNITY_EDITOR_WIN
            directoryPath = "/SpaceSyntaxData/Maps/Details/";
        #endif

        #if UNITY_EDITOR_LINUX
            directoryPath = "~/SpaceSyntaxData/Maps/Details/";
        #endif

        //for Standalone
        #if UNITY_STANDALONE_OSX
            directoryPath = "/Library/SpaceSyntaxData/Maps/Details/";
        #endif

        #if UNITY_STANDALONE_WIN
            directoryPath = "/SpaceSyntaxData/Maps/Details/";
        #endif

        #if UNITY_STANDALONE_LINUX
            directoryPath = "~/SpaceSyntaxData/Maps/Details/";
        #endif

        //Make sure directory exists
        if (!Directory.Exists (directoryPath)) {
            Directory.CreateDirectory (directoryPath);

            //Create default files
            string defaultCSVFilePath = Application.dataPath + "/Maps/CSVdetails/";
            string[] csvFileNames = Directory.GetFiles(defaultCSVFilePath);

            for (int i = 0; i < csvFileNames.Length; i++)
            {
                string fileName = csvFileNames[i].ToString().Substring(csvFileNames[i].ToString().LastIndexOf('/') + 1);

                if (fileName.Contains(".meta"))
                {
                    continue;
                }

                string filePath = directoryPath + fileName;

                File.Create(filePath).Dispose();

                string[] details = File.ReadAllLines(defaultCSVFilePath + fileName);
                File.WriteAllLines(filePath, details);
            }
        }

    }

    private void Start()
    {
        // Create a list of points for each map name on start so it only needs to be done once
        StandaloneSaveLoad.Instance.Load();
        List<Map> mapNames = Stories.Instance.maps;

        foreach(Map mapName in mapNames)
        {
            pointsDict.Add(mapName.MapName, makePointListFromCSV(mapName.MapName));
        }
    }

    public List<SpaceSyntaxAttributesPoint> GetPointsList(string mapName)
    {
        // Set min and max x, y values
        minX = xDict[mapName].Min();
        maxX = xDict[mapName].Max();
        minY = yDict[mapName].Min();
        maxY = yDict[mapName].Max();

        return pointsDict[mapName];
    }

    public List<SpaceSyntaxAttributesPoint> makePointListFromCSV(string mapName)
    {

        List<SpaceSyntaxAttributesPoint> toRtn = new List<SpaceSyntaxAttributesPoint>();

        string csvFilePath = directoryPath + mapName.Replace(" ", "_") + "Details.csv"; //csv file will have '_' instead of spaces ' '.

        StreamReader streamReader = new StreamReader(csvFilePath);
        bool endOfFile = false;
        bool header = true;

        // Init lists for values of interest
        List<float> opennessValues = new List<float>();
        List<float> vcValues = new List<float>();
        List<float> viValues = new List<float>();
        List<int> xValues = new List<int>();
        List<int> yValues = new List<int>();

        int count = 0;

        while (!endOfFile)
        {
            string data_string = streamReader.ReadLine();
            if (data_string == null)
            {
                endOfFile = true;
                break;
            }

            string[] data_values = data_string.Split(',');
            if (header)
            {
                header = false;
                continue;
            }

            // Extract all of the important values.
            float opennessValue = float.Parse((string)data_values[4].Split('.')[0]);
            float vcValue = float.Parse((string)data_values[11].Split('.')[0]);
            float viValue = float.Parse((string)data_values[16].Split('.')[0]);

            // that means there is no VI value at that point
            if (viValue < 0)
            {
                continue;
            }

            opennessValues.Add(opennessValue); // has header "Isovist Area"
            vcValues.Add(vcValue); // has header "Isovist Perimeter"
            viValues.Add(viValue); // has header "Visual Integration [HH] R2"

            if((string)data_values[1] == "-3.5527136788e-15")
            {
                xValues.Add(0);
            }
            else
            {
                xValues.Add(System.Convert.ToInt32((string)data_values[1]));
            }

            if((string)data_values[2] == "-3.5527136788e-15")
            {
                yValues.Add(0);
            }
            else
            {
                yValues.Add(System.Convert.ToInt32((string)data_values[2]));
            }

            count++;
        }

        // Find the maximum and minimum values from all of the attribute lists.
        float maxO = opennessValues.Max();
        float minO = opennessValues.Min();

        float maxVC = vcValues.Max();
        float minVC = vcValues.Min();

        float maxVI = viValues.Max();
        float minVI = viValues.Min();

        List<float> opennessValuesFormatted = new List<float>();
        List<float> vcValuesFormatted = new List<float>();
        List<float> viValuesFormatted = new List<float>();

        // Scale the values down from their max and min range to a 0 - 100 (a - b) range.
        int a = 0; //lowest value in range to be scaled in
        int b = 100; //highest value in range to be scaled in

        // Formula for linear scaling is: (max is assumed to not be equal to min or else the data is useless)
        // f(x) = [((x - min) * (b - a)) / (max - min)] + a
        // We have already calculated the min, max, and a, b are shown above
        // x is the value[i]
        // This means that high and low values are relative to the space (it can differ between different spaces)
        for (int i = 0; i < opennessValues.Count; i++)
        {
            float opennessFormatted = (((opennessValues[i] - minO) * (b - a)) / (maxO - minO)) + a;
            float vcFormatted = (((vcValues[i] - minVC) * (b - a)) / (maxVC - minVC)) + a;
            float viFormatted = (((viValues[i] - minVI) * (b - a)) / (maxVI - minVI)) + a;

            toRtn.Add(new SpaceSyntaxAttributesPoint(xValues[i], yValues[i], opennessFormatted, vcFormatted, viFormatted));
        }

        xDict.Add(mapName, xValues);
        yDict.Add(mapName, yValues);

        // Return the list!!
        return toRtn;
    }

    // Converts the x,y value of the best point (from csv) to a point in the model
    // This assumes the model starts at 0,0
    public SpaceSyntaxAttributesPoint ConvertXYtoModelScale(SpaceSyntaxAttributesPoint bestPoint, float modelWidth, float modelHeight)
    {
        SpaceSyntaxAttributesPoint adjustedPoint = new SpaceSyntaxAttributesPoint();

        adjustedPoint.setWidth((((bestPoint.getWidth() - minX) * (modelWidth)) / (maxX - minX)));
        adjustedPoint.setHeight((((bestPoint.getHeight() - minY) * (modelHeight)) / (maxY - minY)));

        //Scale height as it is flipped in depthmapx
        adjustedPoint.setHeight(Math.Abs(adjustedPoint.getHeight() - modelHeight));

        return adjustedPoint;
    }
} 