using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;




[Serializable]
public class CorrectQRCodePosition
{
    [SerializeField]
    public string id;
    [SerializeField]
    public Vector3 anchorPos;
    [SerializeField]
    public Vector3 anhorRot;

    [SerializeField]
    public Vector3 mapCameraPos;
    [SerializeField]
    public Vector3 mapCameraRot;

    [SerializeField]
    public float cameraSize;

}

[Serializable]
public class ListQrFix
{
    [SerializeField]
    public List<CorrectQRCodePosition> qrs;
}


//1 - save parenachor pos and rot
//2 - save map camera pos and rot
//3 - save mapcamera camera component size

//4 - load parntachor pos
// 5- load map camera pos and rot
// 3 load camdra size


public class InvertMap : MonoBehaviour
{
    [SerializeField]
    public ListQrFix fix = new ListQrFix();
    public bool invertedMap = false;


    public GameObject parentAnchor;
    public GameObject mapCamera;


    //public GameObject linePath;
    public Text userIDText;
    public string fileName;
    private Controller controller;

    private bool isGeneratingFiles = false;
    void Start()
    {
        fix.qrs = new List<CorrectQRCodePosition>();
        controller = GameObject.Find("Controller").GetComponent<Controller>();
        ReadJson();


    }

   
    [EasyButtons.Button]
    void SaveInfoToList()
    {
        CorrectQRCodePosition qr = new CorrectQRCodePosition();

        GameObject anchor = parentAnchor;

        GameObject cam = mapCamera;

        string id = userIDText.text;
     
        qr.id = id;
        qr.anchorPos = anchor.transform.position;
        qr.anhorRot = anchor.transform.rotation.eulerAngles;
        qr.mapCameraPos = cam.transform.position;
        qr.mapCameraRot = cam.transform.rotation.eulerAngles;
        qr.cameraSize = cam.GetComponent<Camera>().orthographicSize;


        //if (fix.qrs.Count > 0)
        //{
        //    for (int i = 0; i < fix.qrs.Count; i++)
        //    {
        //        if (qr.id == fix.qrs[i].id)
        //        {
        //            fix.qrs.Insert(i, qr);
        //        }
        //    }
        //}
        //else
        //{
            fix.qrs.Add(qr);
        //}
    }

    [EasyButtons.Button]
    public void SaveIntoJson()
    {
        string str = JsonUtility.ToJson(fix,true);
        System.IO.File.WriteAllText(Application.dataPath + "/" + fileName, str);
    }

    [EasyButtons.Button]
    public void ReadJson()
    {
        string jsonFile = File.ReadAllText(Application.dataPath + "/" + fileName);
        fix = JsonConvert.DeserializeObject<ListQrFix>(jsonFile);
    }

    [EasyButtons.Button]
    public void AlignHeatmap()
    {
        ResetAll();

        foreach (CorrectQRCodePosition qr in fix.qrs)
        {
            if (qr.id.Split(':')[1] == userIDText.text.Split(':')[1]) 
            {
                //linePath.transform.position = new Vector3(qr.position.x, qr.position.y, qr.position.z);
                //linePath.transform.eulerAngles = new Vector3(qr.rotation.x, qr.rotation.y, qr.rotation.z);
                parentAnchor.transform.position = new Vector3(qr.anchorPos.x, qr.anchorPos.y, qr.anchorPos.z);
                parentAnchor.transform.eulerAngles = new Vector3(qr.anhorRot.x, qr.anhorRot.y, qr.anhorRot.z);

                mapCamera.transform.position = new Vector3(qr.mapCameraPos.x, qr.mapCameraPos.y, qr.mapCameraPos.z);
                mapCamera.transform.eulerAngles = new Vector3(qr.mapCameraRot.x, qr.mapCameraRot.y, qr.mapCameraRot.z);

                mapCamera.GetComponent<Camera>().orthographicSize = qr.cameraSize;
            }
        }

       
    }

    [EasyButtons.Button]
    public void ResetAll()
    {
        mapCamera.transform.position = new Vector3(-0.971f, 10, 4.2376f);
        mapCamera.transform.eulerAngles = new Vector3(90, -180, 0);

        parentAnchor.transform.position = new Vector3(-0.26f, 4.002f, -0.24f);
        parentAnchor.transform.eulerAngles = new Vector3(0, 0, 0);

        mapCamera.GetComponent<Camera>().orthographicSize = 10;

    }

    [EasyButtons.Button]
    public void GenratePngBatch()
    {
        Debug.Log("Please Wait Generating Files..");
        string path = UnityEditor.EditorUtility.OpenFolderPanel(".CSV files Folder", "", "");
        string[] files = System.IO.Directory.GetFiles(path);
        string destination = UnityEditor.EditorUtility.OpenFolderPanel("Destination Folder", "", "");


        try
        {
            foreach (string file in files)
            {
                string fileName = Path.GetFileName(file);
                controller.OpenFile(file);
                controller.GenerateHeatmap();
                controller.GeneratePng(destination, fileName.Replace(".csv", ""));
            }
        }
        catch (Exception)
        {

        }
        finally
        {
            Debug.Log("Finished! All files generated at: " + destination);
        }
      

    }

}
