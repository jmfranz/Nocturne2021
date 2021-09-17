/*
 * Author: Abbey Singh
 * This script will open a file panel where the user may select audio from their computer to add.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class OpenFilePanel : EditorWindow
{
    public static OpenFilePanel window;

    float windowWidth;
    float windowHeight;

    Texture2D backgroundTexture;

    Rect backgroundSection;

    Color white = new Color(255, 255, 255);

    //Path means in menu bar go to Window and then go to drop down tab called Create Stories
    //A new editor window will appear
    [MenuItem("Window/Upload Story Elements")]
    static void OpenWindow()
    {
        window = (OpenFilePanel)GetWindow(typeof(OpenFilePanel));
        window.minSize = new Vector2(600, 300);
        window.Show();
    }


    //When the window is created this will be called
    void OnEnable()
    {
        InitializeBackgroundTextures();
    }


    void InitializeBackgroundTextures()
    {
        backgroundTexture = new Texture2D(1, 1);
        backgroundTexture.SetPixel(0, 0, white);
        backgroundTexture.Apply();
    }

    //OnGUI is like update
    //Can only call functions that use GUI with this 
    void OnGUI()
    {
        //set window width and height
        windowWidth = window.position.width;
        windowHeight = window.position.height;

        DrawBackground();
        DrawUI();
    }

    //Makes the background white
    public void DrawBackground()
    {
        backgroundSection.x = 0;
        backgroundSection.y = 0;
        backgroundSection.width = windowWidth;
        backgroundSection.height = windowHeight;

        GUI.DrawTexture(backgroundSection, backgroundTexture);
    }

    public void DrawUI()
    {
        if (GUI.Button(new Rect(50, 50, 50, 50), "Upload"))
        {
            OpenFile();
        }
    }

    public void OpenFile()
    {
        //OpenFilePane(Title, directory, extensions)
        string path = EditorUtility.OpenFilePanel("Add a story element", "/Desktop/", "aif,wav,mp3,ogg");
        if (path.Length != 0)
        {
            var fileContent = File.ReadAllBytes(path);
            var fileName = Path.GetFileName(path);
            UnityEngine.Debug.Log(fileContent);
            File.Create(Application.dataPath + "/Resources/Music/" + fileName).Dispose();
            File.WriteAllBytes(Application.dataPath + "/Resources/Music/" + fileName, fileContent);
        }
    }


}
