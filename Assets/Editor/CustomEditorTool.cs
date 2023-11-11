// Assets/Editor/CustomEditorTool.cs
using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class CustomEditorMenu
{
    [MenuItem("Scene/Custom Editor Tool")]
    private static void CustomEditorTool()
    {
        // Specify the folder path where your FBX models are located
        string fbxFolderPath = "Assets/FBX";

        // Get a list of FBX files in the specified folder
        List<string> fbxFiles = GetFBXFiles(fbxFolderPath);

        // Instantiate each FBX model in the scene
        foreach (string filePath in fbxFiles)
        {
            // Load the FBX model
            GameObject fbxModel = AssetDatabase.LoadAssetAtPath<GameObject>(filePath);

            // Instantiate the FBX model in the scene
            if (fbxModel != null)
            {
                InstantiateFBXModel(fbxModel);
            }
            else
            {
                Debug.LogError("Failed to load FBX model: " + filePath);
            }
        }
    }

    private static void InstantiateFBXModel(GameObject fbxModel)
    {
        // Instantiate the FBX model in the scene
        GameObject instantiatedModel = PrefabUtility.InstantiatePrefab(fbxModel) as GameObject;
        if (instantiatedModel != null)
        {
            Debug.Log("FBX model instantiated: " + fbxModel.name);
        }
        else
        {
            Debug.LogError("Failed to instantiate FBX model: " + fbxModel.name);
        }
    }

    private static List<string> GetFBXFiles(string folderPath)
    {
        List<string> fbxFiles = new List<string>();

        if (Directory.Exists(folderPath))
        {
            string[] files = Directory.GetFiles(folderPath, "*.fbx");
            foreach (string file in files)
            {
                // Convert absolute path to relative path
                string relativePath = "Assets" + file.Replace(Application.dataPath, "").Replace("\\", "/");
                fbxFiles.Add(relativePath);
            }
        }
        else
        {
            Debug.LogError("Folder not found: " + folderPath);
        }

        return fbxFiles;
    }
}
