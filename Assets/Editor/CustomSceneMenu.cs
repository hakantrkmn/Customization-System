// Assets/Editor/CustomSceneMenu.cs
using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class CustomSceneMenu
{
    private static List<string> fbxFiles;
    private static Vector2 scrollPosition = Vector2.zero;

    [MenuItem("GameObject/Custom Scene Menu", false, 10)]
    private static void CreateCustomSceneMenu()
    {
        SceneView.duringSceneGui += DuringSceneGUI;
    }

    

    private static void DuringSceneGUI(SceneView sceneView)
    {
        Handles.BeginGUI();

        GUILayout.BeginArea(new Rect(10, 10, 150, 450));
        GUILayout.Label("Custom Scene Menu");
        fbxFiles = GetFBXFiles("Assets/_game/Models");

        // Draw buttons for each FBX file when FBX Files menu is opened
        if (fbxFiles != null)
        {
            DrawFBXButtons();
        }

        GUILayout.EndArea();

        Handles.EndGUI();
    }

    private static void DrawFBXButtons()
    {
        // Create a scrollable area for the buttons
        scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Width(150), GUILayout.Height(100));

        // Draw buttons for each FBX file
        foreach (string filePath in fbxFiles)
        {
            DrawFBXButton(filePath);
        }

        GUILayout.EndScrollView();
    }

    private static void DrawFBXButton(string filePath)
    {
        // Get the FBX file name without extension
        string fileName = Path.GetFileNameWithoutExtension(filePath);

        // Draw a button for the FBX file name
        if (GUILayout.Button(fileName))
        {
            // When the button is clicked, load and instantiate the corresponding FBX model
            GameObject fbxModel = AssetDatabase.LoadAssetAtPath<GameObject>(filePath);
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
        List<string> files = new List<string>();

        if (Directory.Exists(folderPath))
        {
            files.AddRange(Directory.GetFiles(folderPath, "*.fbx"));
        }
        else
        {
            Debug.LogError("Folder not found: " + folderPath);
        }

        return files;
    }
}
