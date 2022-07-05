using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour {

    [Header("Cameras")]
    public Transform viewCamera;
    public Camera mapCamera;
    public RenderTexture map;

    public Transform viewCamera2;
    public Camera mapCamera2;
    public RenderTexture map2;

    [Header("Playback Controller")]
    public Slider timeSlider;
    bool playing;

    public Slider timeSlider2;
    bool playing2;

    [Header("Line Path")]
    public LineRenderer linePath;
    public Button enableLinePathButton;
    public Button generateLinePathButton;
    public Text enableLinePathText;
    Gradient linePathGradient;

    [Header("Heatmap")]
    public MeshRenderer heatmap;
    public Button enableHeatmapButton;
    public Button generateHeatmapButton;
    public Text enableHeatmapText;
    Texture2D heatmapTexture;
    int heatmapWidth = 128;
    int heatmapHeight = 128;

    [Header("Display")]
    public Text userIDText;
    public Text dateText;
    public Text timeText;
    public Text posXText;
    public Text posYText;
    public Text posZText;
    public Text rotXText;
    public Text rotYText;
    public Text rotZText;
    public Text rotWText;
    public Text sceneText;
    public Text isMasterText;

    public Text userIDText2;
    public Text dateText2;
    public Text timeText2;
    public Text posXText2;
    public Text posYText2;
    public Text posZText2;
    public Text rotXText2;
    public Text rotYText2;
    public Text rotZText2;
    public Text rotWText2;
    public Text sceneText2;
    public Text isMasterText2;

    [Header("Menu")]
    public InputField openField;
    public InputField saveField;


    [Header("Menu")]
    public InputField openField2;
    public InputField saveField2;

    //GOD... this should have been an animation timeline..
    string id;
    string date;
    string scene;
    List<int[]> times = new List<int[]>();
    List<Vector3> positions = new List<Vector3>();
    List<Quaternion> rotations = new List<Quaternion>();
    List<string> masters = new List<string>();
    List<float> distances = new List<float>();

    string id2;
    string date2;
    string scene2;
    List<int[]> times2 = new List<int[]>();
    List<Vector3> positions2 = new List<Vector3>();
    List<Quaternion> rotations2 = new List<Quaternion>();
    List<string> masters2 = new List<string>();
    List<float> distances2 = new List<float>();

    GameObject FixMapTool;

    void Update() {
        if (playing) {
            float value = timeSlider.value + Time.deltaTime;
            if (value > timeSlider.maxValue)
                value = 0;
            timeSlider.value = value;
        }

        if (playing2)
        {
            float value2 = timeSlider2.value + Time.deltaTime;
            if (value2 > timeSlider2.maxValue)
                value2 = 0;
            timeSlider2.value = value2;
        }
        
    }

    public void Start()
    {
        FixMapTool = GameObject.Find("InvertMa");
    }
    public void Play()
    {
        playing = true;
        playing2 = true;
    }

    public void Pause()
    {
        playing = false;
        playing2 = false;
    }

    public void Stop() {
        playing = false;
        playing2 = false;
        timeSlider.value = 0;
        timeSlider2.value = 0;
    }

    public void ToggleLinePath() {
        linePath.enabled = !linePath.enabled;
        enableLinePathText.text = linePath.enabled ? "Disable Line Path" : "Enable Line Path";
        Seek();
    }

    public void ToggleHeatmap() {
        heatmap.enabled = !heatmap.enabled;
        enableHeatmapText.text = heatmap.enabled ? "Disable Heatmap" : "Enable Heatmap";
    }

    public void Seek() {
        if (times.Count == 0) return;
        int i;
        float startTime = Read(0);
        for (i = 1; i < times.Count; i++)
            if (Read(i) - startTime >= timeSlider.value)
                break;
        float lerp = (timeSlider.value - Read(i - 1)) / (Read(i) - Read(i - 1));
        viewCamera.position = Vector3.Lerp(positions[i - 1], positions[i], lerp);
        viewCamera.rotation = Quaternion.Lerp(rotations[i - 1], rotations[i], lerp);
        userIDText.text = "User ID\t: " + id;
        posXText.text = "Pos X\t\t: " + viewCamera.position.x.ToString("0.00");
        posYText.text = "Pos Y\t\t: " + viewCamera.position.y.ToString("0.00");
        posZText.text = "Pos Z\t\t: " + viewCamera.position.z.ToString("0.00");
        rotXText.text = "Rot X\t\t: " + viewCamera.rotation.x.ToString("0.00");
        rotYText.text = "Rot Y\t\t: " + viewCamera.rotation.y.ToString("0.00");
        rotZText.text = "Rot Z\t\t: " + viewCamera.rotation.z.ToString("0.00");
        rotWText.text = "Rot W\t\t: " + viewCamera.rotation.w.ToString("0.00");
        sceneText.text = "Scene\t\t: " + scene;
        isMasterText.text = "Is Master\t: " + masters[i - 1];
        dateText.text = "Date\t\t: " + date;
        timeText.text = "Time\t: " +
            times[i - 1][0].ToString("00") + ":" +
            times[i - 1][1].ToString("00") + ":" +
            times[i - 1][2].ToString("00") + ":" +
            times[i - 1][3].ToString("000");
        if (!linePath.enabled)
            return;
        float time = Mathf.Lerp(distances[i - 1], distances[i], lerp) / distances[distances.Count - 1];
        linePathGradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(Color.black, 0), new GradientColorKey(Color.black, 1) },
            new GradientAlphaKey[] { new GradientAlphaKey(1, time), new GradientAlphaKey(0, 1) }
            );
        linePath.colorGradient = linePathGradient;

        FixMapTool.GetComponent<InvertMap>().AlignHeatmap();
    }

    public void Seek2()
    {
        if (times2.Count == 0) return;
        int i;
        float startTime = Read2(0);
        for (i = 1; i < times2.Count; i++)
            if (Read2(i) - startTime >= timeSlider2.value)
                break;
        float lerp = (timeSlider2.value - Read2(i - 1)) / (Read2(i) - Read2(i - 1));
        viewCamera2.position = Vector3.Lerp(positions2[i - 1], positions2[i], lerp);
        viewCamera2.rotation = Quaternion.Lerp(rotations2[i - 1], rotations2[i], lerp);
        userIDText2.text = "User ID\t: " + id2;
        posXText2.text = "Pos X\t\t: " + viewCamera2.position.x.ToString("0.00");
        posYText2.text = "Pos Y\t\t: " + viewCamera2.position.y.ToString("0.00");
        posZText2.text = "Pos Z\t\t: " + viewCamera2.position.z.ToString("0.00");
        rotXText2.text = "Rot X\t\t: " + viewCamera2.rotation.x.ToString("0.00");
        rotYText2.text = "Rot Y\t\t: " + viewCamera2.rotation.y.ToString("0.00");
        rotZText2.text = "Rot Z\t\t: " + viewCamera2.rotation.z.ToString("0.00");
        rotWText2.text = "Rot W\t\t: " + viewCamera2.rotation.w.ToString("0.00");
        sceneText2.text = "Scene\t\t: " + scene2;
        isMasterText2.text = "Is Master\t: " + masters2[i - 1];
        dateText2.text = "Date\t\t: " + date2;
        timeText2.text = "Time\t: " +
            times2[i - 1][0].ToString("00") + ":" +
            times2[i - 1][1].ToString("00") + ":" +
            times2[i - 1][2].ToString("00") + ":" +
            times2[i - 1][3].ToString("000");
        if (!linePath.enabled)
            return;
        float time = Mathf.Lerp(distances2[i - 1], distances2[i], lerp) / distances2[distances2.Count - 1];
        linePathGradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(Color.black, 0), new GradientColorKey(Color.black, 1) },
            new GradientAlphaKey[] { new GradientAlphaKey(1, time), new GradientAlphaKey(0, 1) }
            );
        linePath.colorGradient = linePathGradient;

        FixMapTool.GetComponent<InvertMap>().AlignHeatmap();
    }

    void ReadCSV(string path) {
        heatmap.enabled = false;
        enableLinePathButton.interactable = false;
        linePath.enabled = false;
        enableHeatmapButton.interactable = false;
        bool header = true;
        times.Clear();
        positions.Clear();
        rotations.Clear();
        masters.Clear();
        float maxX = 0, maxZ = 0;
        foreach (string line in File.ReadAllLines(path)) {
            if (header) {
                header = false;
                continue;
            }
            string[] parts = line.Split(',');
            id = parts[0];
            date = parts[1];
            times.Add(new int[] { int.Parse(parts[2]), int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]) });
            positions.Add(new Vector3(float.Parse(parts[6]), float.Parse(parts[7]), float.Parse(parts[8])));
            rotations.Add(new Quaternion(float.Parse(parts[9]), float.Parse(parts[10]), float.Parse(parts[11]), float.Parse(parts[12])));
            scene = parts[13];
            masters.Add(parts[14]);
            maxX = Mathf.Max(maxX, Mathf.Abs(positions[positions.Count - 1].x - mapCamera.transform.position.x));
            maxZ = Mathf.Max(maxZ, Mathf.Abs(positions[positions.Count - 1].z - mapCamera.transform.position.z));
        }
        mapCamera.orthographicSize = Mathf.Max(maxX, maxZ) + 1;
        timeSlider.maxValue = Read(times.Count - 1) - Read(0);
        generateHeatmapButton.interactable = true;
        generateLinePathButton.interactable = true;
        Seek();
    }

    void ReadCSV2(string path)
    {
        heatmap.enabled = false;
        enableLinePathButton.interactable = false;
        linePath.enabled = false;
        enableHeatmapButton.interactable = false;
        bool header = true;
        times2.Clear();
        positions2.Clear();
        rotations2.Clear();
        masters2.Clear();
        float maxX = 0, maxZ = 0;
        foreach (string line in File.ReadAllLines(path))
        {
            if (header)
            {
                header = false;
                continue;
            }
            string[] parts = line.Split(',');
            id2 = parts[0];
            date2 = parts[1];
            times2.Add(new int[] { int.Parse(parts[2]), int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]) });
            positions2.Add(new Vector3(float.Parse(parts[6]), float.Parse(parts[7]), float.Parse(parts[8])));
            rotations2.Add(new Quaternion(float.Parse(parts[9]), float.Parse(parts[10]), float.Parse(parts[11]), float.Parse(parts[12])));
            scene2 = parts[13];
            masters2.Add(parts[14]);
            maxX = Mathf.Max(maxX, Mathf.Abs(positions2[positions2.Count - 1].x - mapCamera2.transform.position.x));
            maxZ = Mathf.Max(maxZ, Mathf.Abs(positions2[positions2.Count - 1].z - mapCamera2.transform.position.z));
        }
        mapCamera2.orthographicSize = Mathf.Max(maxX, maxZ) + 1;
        timeSlider2.maxValue = Read2(times2.Count - 1) - Read2(0);
        generateHeatmapButton.interactable = true;
        generateLinePathButton.interactable = true;
        Seek2();
    }

    public void GenerateLinePath() {
        if (enableLinePathButton.interactable) return;
        distances.Clear();
        distances.Add(0);
        for (int i = 1; i < positions.Count; i++)
            distances.Add(distances[i - 1] + Vector3.Distance(positions[i], positions[i - 1]));
        linePath.positionCount = positions.Count;
        linePath.SetPositions(positions.ToArray());
        linePathGradient = new Gradient();
        linePathGradient.mode = GradientMode.Fixed;
        enableLinePathButton.interactable = true;
        ToggleLinePath();
        FixMapTool.GetComponent<InvertMap>().AlignHeatmap();
    }

    public void GenerateHeatmap() {
        if (enableHeatmapButton.interactable) return;
        heatmapTexture = new Texture2D(heatmapWidth, heatmapHeight, TextureFormat.RGB24, false);
        heatmapTexture.filterMode = FilterMode.Point;
        float[,] data = new float[heatmapHeight, heatmapWidth];
        for (int i = 1; i < positions.Count; i++) {
            Vector2 pos0 = mapCamera.WorldToScreenPoint(positions[i - 1]);
            Vector2 pos1 = mapCamera.WorldToScreenPoint(positions[i]);
            int x0 = Mathf.RoundToInt(pos0.x * heatmapWidth / mapCamera.pixelWidth);
            int y0 = Mathf.RoundToInt(pos0.y * heatmapHeight / mapCamera.pixelHeight);
            int x1 = Mathf.RoundToInt(pos1.x * heatmapWidth / mapCamera.pixelWidth);
            int y1 = Mathf.RoundToInt(pos1.y * heatmapHeight / mapCamera.pixelHeight);
            List<int[]> lines = new List<int[]>();
            int deltaX = Mathf.Abs(x1 - x0);
            int signX = x0 < x1 ? 1 : -1;
            int deltaY = -Mathf.Abs(y1 - y0);
            int signY = y0 < y1 ? 1 : -1;
            int error = deltaX + deltaY;
            while (true) {
                if (x0 == x1 && y0 == y1) break;
                lines.Add(new int[] { x0, y0 });
                int error2 = 2 * error;
                if (error2 >= deltaY) {
                    error += deltaY;
                    x0 += signX;
                }
                if (error2 <= deltaX) {
                    error += deltaX;
                    y0 += signY;
                }
            }
            if (lines.Count <= 0)
                lines.Add(new int[] { x0, y0 });
            float value = (Read(i) - Read(i - 1)) / lines.Count;
            for (int j = 0; j < lines.Count; j++)
                data[lines[j][1], lines[j][0]] += value;
        }
        float[,] smoothed = new float[heatmapHeight, heatmapWidth];
        for (int i = 0; i < heatmapHeight; i++)
            for (int j = 0; j < heatmapWidth; j++)
                for (int k = 0, y = i - 2; k < 5; k++, y++)
                    for (int l = 0, x = j - 2; l < 5; l++, x++)
                        if (x >= 0 && y >= 0 && x < heatmapWidth && y < heatmapHeight)
                            smoothed[i, j] += data[y, x] * kernel[k, l] / 273f;
        float max = 0;
        for (int i = 0; i < heatmapHeight; i++)
            for (int j = 0; j < heatmapWidth; j++)
                max = Mathf.Max(max, smoothed[i, j]);
        for (int i = 0; i < heatmapHeight; i++) {
            for (int j = 0; j < heatmapWidth; j++) {
                float h = Mathf.Exp(-50 * smoothed[i, j] / max) * 2f / 3f;
                float s = smoothed[i, j] == 0 ? 0 : 1;
                heatmapTexture.SetPixel(j, i, Color.HSVToRGB(h, s, 1));
            }
        }
        heatmapTexture.Apply();
        heatmap.GetComponent<Renderer>().sharedMaterial.mainTexture = heatmapTexture;
        heatmap.transform.localScale = new Vector3(mapCamera.orthographicSize * 2, mapCamera.orthographicSize * 2);
        enableHeatmapButton.interactable = true;
        ToggleHeatmap();
        FixMapTool.GetComponent<InvertMap>().AlignHeatmap();
    }

    public void OpenFile(GameObject button) {


        string path = UnityEditor.EditorUtility.OpenFilePanel("open .csv log file", "", "csv");
        if (path.Length != 0)
        {
            if (!button.name.Contains("2"))
            {
                openField.text = path;

                FixMapTool.GetComponent<InvertMap>().ResetAll();
                ReadCSV(path);
                FixMapTool.GetComponent<InvertMap>().ReadJson();
            }
            else
            {
                openField2.text = path;

                FixMapTool.GetComponent<InvertMap>().ResetAll();
                ReadCSV2(path);
                FixMapTool.GetComponent<InvertMap>().ReadJson();
            }


        }
    }

    public void OpenFile(string path)
    {
        //string path = UnityEditor.EditorUtility.OpenFilePanel("open .csv log file", "", "csv");
        if (path.Length != 0)
        {
            FixMapTool.GetComponent<InvertMap>().ResetAll();
            ReadCSV(path);
            FixMapTool.GetComponent<InvertMap>().ReadJson();

        }
    }

    public void OpenFolder() {

        string path = UnityEditor.EditorUtility.OpenFolderPanel("Save png", "", "");
        if (path.Length != 0)
        {
            saveField.text = path;
        }
    }

    public void GeneratePng() {

        RenderTexture temp = RenderTexture.active;
        mapCamera.targetTexture = new RenderTexture(1024, 1024, 24);
        mapCamera.Render();
        RenderTexture.active = mapCamera.targetTexture;
        Texture2D result = new Texture2D(1024, 1024, TextureFormat.RGB24, false);
        result.ReadPixels(new Rect(0, 0, 1024, 1024), 0, 0);
        RenderTexture.active = temp;
        mapCamera.targetTexture = map;
        string heatmapStatus = heatmap.enabled ? "1" : "0";
        string linePathStatus = linePath.enabled ? "1" : "0";
        string name = dateText.text.Split(' ')[1] + "_" + timeText.text.Split(' ')[1].Replace(':', '-') + "_" + heatmapStatus + "_" + linePathStatus;
        File.WriteAllBytes(saveField.text + "\\" + name + ".png", result.EncodeToPNG());
    }

    public void GeneratePng(string path, string fileName)
    {
        RenderTexture temp = RenderTexture.active;
        mapCamera.targetTexture = new RenderTexture(1024, 1024, 24);
        mapCamera.Render();
        RenderTexture.active = mapCamera.targetTexture;
        Texture2D result = new Texture2D(1024, 1024, TextureFormat.RGB24, false);
        result.ReadPixels(new Rect(0, 0, 1024, 1024), 0, 0);
        RenderTexture.active = temp;
        mapCamera.targetTexture = map;
        string heatmapStatus = heatmap.enabled ? "1" : "0";
        string linePathStatus = linePath.enabled ? "1" : "0";
        string name = fileName + "_" + dateText.text.Split(' ')[1] + "_" + timeText.text.Split(' ')[1].Replace(':', '-') + "_" + heatmapStatus + "_" + linePathStatus;
        File.WriteAllBytes(path + "\\" + name + ".png", result.EncodeToPNG());
    }

    float Read(int i) => times[i][0] * 3600f + times[i][1] * 60f + times[i][2] + times[i][3] / 1000f;

    float Read2(int i) => times2[i][0] * 3600f + times2[i][1] * 60f + times2[i][2] + times2[i][3] / 1000f;

    readonly float[,] kernel = {
        { 1, 4, 7, 4, 1 },
        { 4, 16, 26, 16, 4 },
        { 7, 26, 41, 26, 7 },
        { 4, 16, 26, 16, 4 },
        { 1, 4, 7, 4, 1 }
    };
}