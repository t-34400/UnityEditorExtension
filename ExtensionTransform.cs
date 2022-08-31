/* 
 * 
 */

using UnityEditor;
using UnityEngine;

namespace Extention34400
{
    
    public class EditorExtentionTransform : EditorWindow
    {
        private static Vector3 change = new Vector3(1, 0, 0);

        // unimplemented
        [MenuItem("Extention/Transform/Move #t", false, 1)]
        static void MoveGameObject()
        {
            Selection.activeGameObject.transform.position += change;
        }
        // Disable the menu item if no selection is in place.
        [MenuItem("Extention/Transform/Move #t", true)]
        static bool ValidateMoveGameObject()
        {
            return Selection.activeGameObject != null && !EditorUtility.IsPersistent(Selection.activeGameObject);
        }
    }
}