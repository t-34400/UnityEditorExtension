/* 
 * Outline:
 *   Editor Extension to add menuitems which navigate to component of selected Object
 * Description:
 *   This function is still unimplemented.
 * Date: 
 * Changes:
 * Reference:
 */

using UnityEditor;
using UnityEngine;

namespace Extention34400
{
    public class EditorExtentionNavToComp : EditorWindow
    {
        [MenuItem("Extention/Navigate to component #u", false, 1)]
        static void NavToComp()
        {
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
        [MenuItem("Extention/Navigate to component #u", true)]
        static bool ValidateNavToComp()
        {
            return Selection.activeObject != null && !EditorUtility.IsPersistent(Selection.activeObject);
        }

    }
}