using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextureTextControl : MonoBehaviour
{
    public GameObject ImageObject;
    public TextMeshPro textMesh;

    private MeshRenderer imageRenderer;
    public void Awake()
    {
        imageRenderer = ImageObject.GetComponent<MeshRenderer>();
        //  Texture2D imageTexture = Resources.Load<Texture2D>($"AwareGuide/puppy1");
        // imageRenderer.material.mainTexture = imageTexture;
        Debug.Log(imageRenderer);

    }

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
