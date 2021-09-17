/*
 * @Author: Abbey Singh
 * I am moving all of the contour related functions to this script so that it is still able to be used in the future if we want
 * This keeps it out of the way, but still usable 
 */

using System.Collections.Generic;
using UnityEngine;

public class ContourMap : MonoBehaviour
{
    Texture2D originalCompositeMap;
    Texture2D instantiatedCompositeMap;
    int compositeMapWidth;
    int compositeMapHeight;
    Color32[,] pixels2D;

    const float PixelSizeInCM = 0.02f;

    List<SpaceSyntaxAttributesPoint> currentObjectsPointList;

    //Passed a prefab and set the composite map on it.  Used to get the corresponding composite map on the walls.
    public void SetCompositeMap(GameObject prefab)
    {
        originalCompositeMap = prefab.GetComponent<compositeMap>().getCompositeMap();
    }

    public void MapCalulations(GameObject excludeRegionObj)
    {
        FindHeightAndWidthOfCompositeMap();
        excludePixelRegions(excludeRegionObj);
        FindPixels2D();
    }

    public Texture2D GetCompositeMap()
    {
        return originalCompositeMap;
    }

    void FindHeightAndWidthOfCompositeMap()
    {
        //clone map so pixel changes dont persist
        instantiatedCompositeMap = Instantiate(originalCompositeMap);

        //setting image width and height
        compositeMapWidth = instantiatedCompositeMap.width;
        compositeMapHeight = instantiatedCompositeMap.height;
    }

    public int GetCompositeMapWidth()
    {
        return compositeMapWidth;
    }

    public int GetCompositeMapHeight()
    {
        return compositeMapHeight;
    }

    public Color32[,] GetPixels2D()
    {
        return pixels2D;
    }

    public void FindPixels2D()
    {
        Color32[] pixels1D = instantiatedCompositeMap.GetPixels32();
        Color32[,] openPix2d = new Color32[compositeMapWidth, compositeMapHeight];

        int row = 0;
        int col = 0;

        for (int i = 0; i < pixels1D.Length; i++)
        {

            if (i != 0 && i % compositeMapWidth == 0)
            {
                row++;
                col = 0;
            }
            openPix2d[col, row] = pixels1D[i];
            col++;
        }
        pixels2D = openPix2d;
    }

    //Excludes specified regions by setting pixels within region to 255
    public void excludePixelRegions(GameObject excludeRegionObj)
    {
        BoxCollider[] col = excludeRegionObj.GetComponents<BoxCollider>();
        for (int i = 0; i < col.Length; i++)
        {
            int[] coordArr = convertToPixelXY(col[i].center.x, col[i].center.z, col[i].size.x, col[i].size.z);
            setExcludedRegionsToWhite(coordArr);
        }
    }

    //Passed a top left corner x,y, and the width and height.  It converts unity coordinates to pixel coordinates.
    //The most important part is knowing the size in CM for a single pixel in the texture (in this case it is 0.02).
    private int[] convertToPixelXY(double x, double y, double width, double height)
    {
        x = (x - width / 2) / PixelSizeInCM;
        y = (y - height / 2) / PixelSizeInCM;
        width = width / PixelSizeInCM;
        height = height / PixelSizeInCM;

        int x1 = Mathf.FloorToInt((float)x);
        int y1 = Mathf.FloorToInt((float)y);
        int width1 = Mathf.FloorToInt((float)width);
        int height1 = Mathf.FloorToInt((float)height);

        int[] coordArr = new int[] { x1, y1, width1, height1 };
        return coordArr;
    }

    //Passed a texture3D and a coordArr, this function will convert each pixel within the coordArr to white
    private void setExcludedRegionsToWhite(int[] coordArr)
    {
        int x = coordArr[0];
        int y = coordArr[1];
        int width = coordArr[2];
        int height = coordArr[3];
        Color white = new Color(1, 1, 1, 1);
        for (int i = x; i < x + width; i++)
        {
            for (int j = y; j < y + height; j++)
            {
                instantiatedCompositeMap.SetPixel(i, j, white);
            }
        }
    }

    public List<SpaceSyntaxAttributesPoint> GetPointsListFromContourMap()
    {
        convertToSpaceSyntaxAttributesPointArray(pixels2D);
        removeWhitePixels();

        return currentObjectsPointList;
    }

    //converts the color32 2D array to a single list containing of objects containing rgb value, and width and height in the 2D array
    private void convertToSpaceSyntaxAttributesPointArray(Color32[,] rgbPixels)
    {
        currentObjectsPointList = new List<SpaceSyntaxAttributesPoint>();

        for (int i = 0; i < compositeMapWidth; i++)
        { 
            for (int j = 0; j < compositeMapHeight; j++)
            {
                currentObjectsPointList.Add(new SpaceSyntaxAttributesPoint(i, j, rgbPixels[i, j].r, rgbPixels[i, j].g, rgbPixels[i, j].b));
            }
        }
    }

    //removes white pixels from the list, in hopes of:
    //reducing the amount of useless computation that occurs, and
    //helping prevent objects from spawning inside of walls (which are white = 255)
    private void removeWhitePixels()
    {
        List<SpaceSyntaxAttributesPoint> tempList = new List<SpaceSyntaxAttributesPoint>();
        for (int i = 0; i < currentObjectsPointList.Count; i++)
        {
            if (currentObjectsPointList[i].getOpenness() < 255)
            {
                tempList.Add(currentObjectsPointList[i]);
            }
        }
        currentObjectsPointList = tempList;
    }

    public SpaceSyntaxAttributesPoint ConvertXYtoModelScale(SpaceSyntaxAttributesPoint bestPoint)
    {
        bestPoint.setWidth(bestPoint.getWidth() * PixelSizeInCM);
        bestPoint.setHeight(bestPoint.getHeight() * PixelSizeInCM);

        return bestPoint;
    }
}
