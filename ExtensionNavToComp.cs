using UnityEditor;
using UnityEngine;

namespace Extention34400
{
    public class EditorExtentionNavToComp : EditorWindow
{
    [MenuItem("Extention/Prefab/Create Prefab from selected GameObject #p", false, 1)]
    static void CreatePrefab()
    {
        // Keep track of the currently selected GameObject(s)
        GameObject[] objectArray = Selection.gameObjects;

        // Loop through every GameObject in the array above
        foreach (GameObject gameObject in objectArray)
        {
            // Create folder Prefabs and set the path as within the Prefabs folder,
            // and name it as the GameObject's name with the .Prefab format
            if (!System.IO.Directory.Exists("Assets/Prefabs"))
                AssetDatabase.CreateFolder("Assets", "Prefabs");
            string localPath = "Assets/Prefabs/" + gameObject.name + ".prefab";

            // Make sure the file name is unique, in case an existing Prefab has the same name.
            localPath = AssetDatabase.GenerateUniqueAssetPath(localPath);

            // Create the new Prefab and log whether Prefab was saved successfully.
            bool prefabSuccess;
            PrefabUtility.SaveAsPrefabAssetAndConnect(gameObject, localPath, InteractionMode.UserAction, out prefabSuccess);
            if (prefabSuccess == true)
                Debug.Log("Prefab was saved successfully");
            else
                Debug.Log("Prefab failed to save" + prefabSuccess);
            // Focus Prefabs folder in Project window
            EditorUtility.FocusProjectWindow();
            Object obj = AssetDatabase.LoadAssetAtPath<Object>("Assets/Prefabs");
            Selection.activeObject = obj;
        }
    }

    // Disable the menu item if no selection is in place.
    [MenuItem("Extention/Prefab/Create Prefab from selected GameObject #p", true)]
    static bool ValidateCreatePrefab()
    {
        return Selection.activeGameObject != null && !EditorUtility.IsPersistent(Selection.activeGameObject);
    }

    // Create instance of selected prefab asset
    [MenuItem("Extention/Prefab/Create Instance #i", false, 1)]
    static void CreateInstance()
    {
        Selection.activeObject = PrefabUtility.InstantiatePrefab(Selection.activeObject);
    }
    // Disable the menu item if no selection is in place or selection is not Prefab asset.
    [MenuItem("Extention/Prefab/Create Instance #i", true)]
    static bool ValidateCreateInstance()
    {
        return (Selection.activeObject != null) && PrefabUtility.IsPartOfPrefabAsset(Selection.activeObject);
    }
}
}