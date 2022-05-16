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

    [Header("Playback Controller")]
    public Slider timeSlider;
    bool playing;

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

    [Header("Menu")]
    public InputField openField;
    public InputField saveField;

    string id;
    string date;
    string scene;
    List<int[]> times = new List<int[]>();
    List<Vector3> positions = new List<Vector3>();
    List<Quaternion> rotations = new List<Quaternion>();
    List<string> masters = new List<string>();
    List<float> distances = new List<float>();

    void Update() {
        if (playing) {
            float value = timeSlider.value + Time.deltaTime;
            if (value > timeSlider.maxValue)
                value = 0;
            timeSlider.value = value;
        }
    }

    public void Play() => playing = true;

    public void Pause() => playing = false;

    public void Stop() {
        playing = false;
        timeSlider.value = 0;
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
    }

    public void OpenFile() {
        string path = UnityEditor.EditorUtility.OpenFilePanel("open .csv log file", "", "csv");
        if (path.Length != 0)
        {
            openField.text = path;
            ReadCSV(openField.text);
        }

        //ReadCSV(openField.text);
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

    float Read(int i) => times[i][0] * 3600f + times[i][1] * 60f + times[i][2] + times[i][3] / 1000f;

    readonly float[,] kernel = {
        { 1, 4, 7, 4, 1 },
        { 4, 16, 26, 16, 4 },
        { 7, 26, 41, 26, 7 },
        { 4, 16, 26, 16, 4 },
        { 1, 4, 7, 4, 1 }
    };
}