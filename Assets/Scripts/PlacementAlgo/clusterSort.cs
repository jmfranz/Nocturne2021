using UnityEngine;
using System.IO;

public class ClusterSort : MonoBehaviour {

    //integer used to describe how big the cluster squares will be
    public int ClusterSize = 25;
    private int imageWidth, imageHeight;

    //passed a 2d array of pixels from the texture map, the obj list, and an a string rgb
    public int[] FindBestPlacement(int[,] pixels, GameObject obj, int bestPos, int precision, int imageWidth, int imageHeight) {

        //Write some text to the test.txt file
        string path = "Assets/Resources/debug.txt";

        this.imageWidth = imageWidth;
        this.imageHeight = imageHeight;
        int clusterSize = 25;
        int currWidth = GetRandomNum(imageWidth - 1);
        int currHeight = GetRandomNum(imageHeight - 1);
        double currPos = CalculateClusterMean(clusterSize, currWidth, currHeight, pixels);
        int[] nextPos = new int[2];
        int takeNextBest = 0;//after 5 resets, take the next local best

        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine("Starting Position: [" + currWidth + "," + currHeight + "]");
        writer.Close();

        while ((Mathf.Abs((float)currPos - bestPos) > precision)) {

            nextPos = FindBestNeighboringCluster(clusterSize, bestPos, currWidth, currHeight, pixels);

            if (currPos != NumClosestToGoal(bestPos, currPos, CalculateClusterMean(clusterSize, nextPos[0], nextPos[1], pixels))) {
                currWidth = nextPos[0];
                currHeight = nextPos[1];
                currPos = CalculateClusterMean(clusterSize, nextPos[0], nextPos[1], pixels);
                Debug.Log("NextPos => Curr pos :" + currPos);
            }
                
            else {
                Debug.Log("Local best found!");
                if (takeNextBest > 5) {
                    //moveGameObj(obj, currWidth, currHeight);
                    Debug.Log(takeNextBest+" failed local bests, non-optimal placement has occured.");
                    break;
                }

                if ((Mathf.Abs((float)currPos - bestPos) < precision)) {
                    Debug.Log("The local best was optimal!");
                    break;
                }
                  
                currWidth = GetRandomNum(imageWidth-1);
                currHeight = GetRandomNum(imageHeight-1);
                currPos = CalculateClusterMean(clusterSize, currWidth, currHeight, pixels);
                takeNextBest++;

                Debug.Log("Resetting current position: "+ currPos);
                writer = new StreamWriter(path, true);
                writer.WriteLine("Resseting Position: [" + currWidth + "," + currHeight + "]");
                writer.Close();
            }
        }
        Debug.Log("Best Position found: " + currPos);
        //moveGameObj(obj, currWidth, currHeight);
        return new int[] { currWidth, currHeight };
    }

    private double CalculateClusterMean(int clusterSize, int centroidWidth, int centroidHeight, int[,] pixels) {

        double clusterMean = 0;
        int clusterTotal = 0;
        //find top left corner of cluster
        float cornerOffset = Mathf.Floor((float)(Mathf.Sqrt(clusterSize)) / 2f);
        int botLeftCornerWidth = centroidWidth - (int)cornerOffset;
        int botLeftCornerHeight = centroidHeight - (int)cornerOffset;
        int numRows = (int)Mathf.Sqrt(clusterSize);
        int numCols = numRows;//clusters are always perfect squares
        for (int i = 0; i < numRows; i++) {
            for (int j = 0; j < numCols; j++) {
                clusterTotal += pixels[botLeftCornerWidth + i, botLeftCornerHeight + j];
            }
        }
        clusterMean = (double)clusterTotal / clusterSize;
        return clusterMean;
    }

    //finds the best neighbouring cluster, and returns the centroid of it to use as the new currPos
    private int[] FindBestNeighboringCluster(int clusterSize, int bestPos, int centroidWidth, int centroidHeight, int[,] pixels) {

        int[] bestNeighbouringCentroid;
        double topClusterMean, leftClusterMean, rightClusterMean, bottomClusterMean;
        double[] meanArray;
        int clusterOffset = (int)Mathf.Sqrt(clusterSize);
        int skipValue = -256;

        //Base cases for checking the neighboring centroids
        //Makes sure the centroid above the current isn't outside the upper bounds of the image
        if (centroidHeight + clusterOffset < imageHeight) {
            topClusterMean = CalculateClusterMean(clusterSize, centroidWidth, centroidHeight + clusterOffset, pixels);
        }
        else
            topClusterMean = skipValue;

        //makes sure the centroid below the current isn't outside the lower bounds
        if (centroidHeight - clusterOffset > 0)
            bottomClusterMean = CalculateClusterMean(clusterSize, centroidWidth, centroidHeight - clusterOffset, pixels);
        else
            bottomClusterMean = skipValue;

        //makes sure the centroid left of the current isn't outside the left bounds
        if (centroidWidth - clusterOffset > 0)
            leftClusterMean = CalculateClusterMean(clusterSize, centroidWidth - clusterOffset, centroidHeight, pixels);
        else
            leftClusterMean = skipValue;

        //makes sure centroid right of the current isn't outside the right bounds
        if (centroidWidth + clusterOffset < imageWidth)
            rightClusterMean = CalculateClusterMean(clusterSize, centroidWidth + clusterOffset, centroidHeight, pixels);
        else
            rightClusterMean = skipValue;

        Debug.Log("Potential options:");
        Debug.Log("Top: " + topClusterMean);
        Debug.Log("Bottom: " + bottomClusterMean);
        Debug.Log("Left: " + leftClusterMean);
        Debug.Log("Right: " + rightClusterMean);

        //add means to the array
        meanArray = new double[] { topClusterMean, bottomClusterMean, leftClusterMean, rightClusterMean };
        int index = GetBestCluster(bestPos, meanArray);

        //index 0 = topCluster, index 1 = bottomCluster, index 2 = leftCluster, index 3 = rightCluster
        if (index == 0) {
            bestNeighbouringCentroid = new int[] { centroidWidth, centroidHeight + clusterOffset };
        }
        else if (index == 1) {
            bestNeighbouringCentroid = new int[] { centroidWidth, centroidHeight - clusterOffset };
        }
        else if (index == 2) {
            bestNeighbouringCentroid = new int[] { centroidWidth - clusterOffset, centroidHeight };
        }
        else {
            bestNeighbouringCentroid = new int[] { centroidWidth + clusterOffset, centroidHeight };
        }

        Debug.Log("Selected Value: " + CalculateClusterMean(clusterSize, bestNeighbouringCentroid[0], bestNeighbouringCentroid[1], pixels));

        //returns the best centroid to move to, out of the possible neighbours.*/
        return bestNeighbouringCentroid;
    }

    //returns the index of the number closest to the goal
    private int GetBestCluster(int goal, double[] array) {
        int bestIndex = 0;
        double currentBest = array[0];
        for (int i = 1; i < array.Length; i++) {
            if (Mathf.Abs((float)goal - (float)array[i]) < Mathf.Abs((float)goal - (float)currentBest)) {
                currentBest = array[i];
                bestIndex = i;
            }
        }
        return bestIndex;
    }

    //returns number closest to the goal
    private double NumClosestToGoal (int goal, double num1, double num2) {
        double closestNum = 0;
        double diff1 = Mathf.Abs((float)num1 - goal);
        double diff2 = Mathf.Abs((float)num2 - goal);

        if (diff1 < diff2) {
            closestNum = num1;
        }
        else {
            closestNum = num2;
        }
        return closestNum;
    }

    private int GetRandomNum(int range) {
        return Random.Range(ClusterSize, range - ClusterSize);
    }
}