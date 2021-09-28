/**
    A simple script to ensure that file dependencies are automatically maintained for the AvatarSelection Screen.
    Author: Matt P.
*/
using System.Text.RegularExpressions;
using UnityEditor;

class AvatarImportHandler : AssetPostprocessor {
    static void OnPostprocessAllAssets (string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths) {

        // If a Microsoft Rocketbox Avatar is imported, ensure that the correct .png file is copied to 'Assets/Resources/' 
        foreach (string filePath in importedAssets) {

            // This REGEX will grab a properly imported Avatar's preview .png file.
            Regex regex = new Regex (@"Assets/Avatars/.*/(.*.png)");

            // Check if the current asset being imported matches the REGEX
            Match match = regex.Match (filePath);

            if (match.Success) {
                //Extract the fileName from the filePath, then copy the file to 'Assets/Resources'
                string fileName = filePath.Split ('/') [3];
                FileUtil.CopyFileOrDirectory (filePath, "Assets/Resources/AvatarImages/" + fileName);
            }
        }

        // If an Avatar is removed from the asset manager, ensure that the .png image is also removed from resources.
        foreach (string filePath in deletedAssets) {
            // This REGEX will grab a properly imported Avatar's preview .png file.
            Regex regex = new Regex (@"Assets/Avatars/.*/(.*.png)");

            // Check if the current asset being imported matches the REGEX
            Match match = regex.Match (filePath);

            if (match.Success) {
                //Extract the fileName from the filePath, then delete the file from 'Assets/Resources' to maintain a clean workspace
                string fileName = filePath.Split ('/') [3];
                FileUtil.DeleteFileOrDirectory ("Assets/Resources/AvatarImages/" + fileName);
                FileUtil.DeleteFileOrDirectory ("Assets/Resources/AvatarImages/" + fileName + ". meta");

            }
        }
    }
}