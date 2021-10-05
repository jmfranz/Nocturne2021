using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextureTextControl : MonoBehaviour
{
   
    public TextMeshPro textMesh;

    public MeshRenderer imageRenderer;
    

    public bool ChangeImage(string imageName)
    {
        Debug.Log(imageName);
        Texture2D imageTexture = Resources.Load<Texture2D>($"AwareGuide/{imageName}");
        imageRenderer.material.mainTexture = imageTexture;
        
        return imageTexture != null;
    }

    public void ChangeText(string newText)
    {
        textMesh.text = newText;
    }
}
