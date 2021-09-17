/*
 * Author: Ramanpreet Kaur
 * This script will run the DepthMap Analysis on the selected Map from the AddMap Screen. This file will create the CSV file from 
 * containing the values for visual integration, connectivity and openness.
 */


using System.Diagnostics;
using System.IO;
using UnityEditor;
using UnityEngine;

public class UploadMap : MonoBehaviour
{
    private string directoryInfo;
    private string directoryPath;
    private string file;
    private string fileName;
    private string pathInfo;
    private string root;
    // Use this for initialization

    public void FileExecution()
    {

        //To fetch the path for Assets Folder and fetch the depthmapXcli exe and place in the Space Syntax Folder.
        string exePath=Application.dataPath;
        string copyExe = exePath + "/Resources/DPX/depthmapXcli.exe";
        

        #if UNITY_STANDALONE_OSX
             directoryInfo = "/Library/SpaceSyntaxData/";

        #endif

        #if UNITY_STANDALONE_WIN
            directoryInfo = "/SpaceSyntaxData/";
            directoryPath = Path.GetPathRoot(Application.dataPath)+"SpaceSyntaxData";

        #endif

        #if UNITY_STANDALONE_LINUX
            directoryInfo = "~/SpaceSyntaxData/";

        #endif
        string mapPath = directoryInfo + "Maps";
        string mapExe = mapPath + "/" + "depthmapXcli.exe";
        string graphPath = mapPath + "/"+"Graphs";
        string detailsPath = mapPath + "/" + "Details";
        string visualPath = mapPath + "/" + "VisualDPX";

        // To create Folders to save the graph and csv files generated from the DepthMap.
        if (!Directory.Exists(mapPath))
        {
            Directory.CreateDirectory(mapPath);
        }
        if (!Directory.Exists(graphPath))
        {
            Directory.CreateDirectory(graphPath);
        }
        if (!Directory.Exists(visualPath))
        {
            Directory.CreateDirectory(visualPath);
        }
        if (!Directory.Exists(detailsPath))
        {
            Directory.CreateDirectory(detailsPath);
        }

        // To copy the Exe if it does not exist in the path.
        if (!File.Exists(mapExe))
        {
            string copyDest = mapPath + "/depthmapXcli.exe";
            File.Copy(copyExe, copyDest);
        } 

        ProcessStartInfo processInfo;

        //To copy the file from Directory to Space Syntax Folder
        string copyPath = pathInfo.Replace("/", "\\");
        directoryPath = directoryPath + "\\" + "Maps";
        string moveGraphs = directoryPath + "\\" + "Graphs";
        string moveDetails = directoryPath + "\\" + "Details";
        string moveVisualDPX = directoryPath + "\\" + "VisualDPX";

        string command = "copy " + copyPath + " " + directoryPath;
        command = command + " & cd " + directoryPath;

        //CLI commands to run the depthmap analysis and create the visibility graph from VGA.
        command = command + " & " + "depthmapXcli.exe -f " + file + " -o " + fileName + "Visibility.graph" + " -m VGA -vm visibility -vg -vr n";
        command = command + " & " + "depthmapXcli.exe -f " + fileName + "Visibility.graph" + " -o " + fileName + "Isovist.graph" + " -m VGA - vm isovist";

        // command to store data in the CSV file.
        command = command + " & " + "depthmapXcli.exe -f " + fileName + "Isovist.graph " + " -o " + fileName + "Details.csv -em pointmap-data-csv -m EXPORT";
        command = command + " & " + "move " + directoryPath + "\\*Isovist.graph " + moveVisualDPX;
        command = command + " & " + "move " + directoryPath + "\\*.graph " + moveGraphs;
        command = command + " & " + "move " + directoryPath + "\\*.csv " + moveDetails;

        UnityEngine.Debug.Log(command);
        processInfo = new ProcessStartInfo("cmd.exe", "/C " + command);
        processInfo.CreateNoWindow = true;
        processInfo.UseShellExecute = false;
        Process process = Process.Start(processInfo);
        process.WaitForExit();
        process.Close();
    }

    //To get the Path and Extensions of the file selected 
    public void FileInfo()
    {
        WWW www = new WWW("file:///" + pathInfo);
        
        // If the User selects the Cancel clicks on the Cancel Button in the Explorer.
        if (pathInfo.Length==0)
        {
            return;
        }

        // If the User selects the File, all the related Paths and directory Paths are stored.
        root = Path.GetPathRoot(pathInfo);
        directoryInfo = Path.GetDirectoryName(pathInfo);
        file = Path.GetFileName(pathInfo);
        fileName = Path.GetFileNameWithoutExtension(pathInfo);
        FileExecution();
    }

    public void OpenExplorer()
    {

        // This means only .graph file can be loaded
        #if UNITY_EDITOR
            pathInfo = EditorUtility.OpenFilePanel("Select only  .graph or .dxf", "", "graph,dxf");
            FileInfo();
        #endif
    }
}