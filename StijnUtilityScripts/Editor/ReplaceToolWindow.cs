using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Threading.Tasks;

namespace StijnUtility {
    public class ReplaceToolWindow : EditorWindow {


        private Object prefab = null;
        private GameObject originalObject = null;
        private GameObject replacedObject = null;
        private bool keepParent;

        [MenuItem("Custom/Replace Tool")]
        static void Init() {
            ReplaceToolWindow window = (ReplaceToolWindow) EditorWindow.GetWindow(typeof(ReplaceToolWindow));
        }

        void OnGUI() {
            GUILayout.Label("Copy Replace", EditorStyles.boldLabel);
            EditorGUILayout.HelpBox(
    @"With this tool you can replace many objects at the same time, while only having to replace one object manually.
This action is Undo-able.
1. Replace one object manually but keep the original
2. Drag the objects in the fields below
3. Select all other (similar) objects that you want to replace
4. Press 'Replace Selection'"
                , MessageType.Info);
            prefab = EditorGUILayout.ObjectField("Replacement prefab", prefab, typeof(GameObject), false);
            EditorGUILayout.Space(5);
            originalObject = (GameObject) EditorGUILayout.ObjectField("Original Object", originalObject, typeof(GameObject), true);
            replacedObject = (GameObject) EditorGUILayout.ObjectField("Replaced Object", replacedObject, typeof(GameObject), true);

            EditorGUILayout.Space(10);
            GUILayout.Label("Options", EditorStyles.boldLabel);

            keepParent = EditorGUILayout.Toggle("Keep same parent", keepParent);

            if ( GUILayout.Button("Replace Selection") ) {
                CopyReplace();
            }
        }

        void CopyReplace() {
            if ( originalObject == null ) {
                Debug.LogError("Replace Tool Error: original object unknown");
                return;
            }
            if ( replacedObject == null ) {
                Debug.LogError("Replace Tool Error: replaced object unknown");
                return;
            }
            if ( Selection.transforms.Length == 0 ) {
                Debug.LogError("Replace Tool Error: nothing selected");
                return;
            }

            Quaternion relativeRotation = Quaternion.Inverse(originalObject.transform.rotation) * replacedObject.transform.rotation;
            Vector3 globalPositionOffset = replacedObject.transform.position - originalObject.transform.position;
            Vector3 relativePositionOffset = originalObject.transform.InverseTransformDirection(globalPositionOffset);

            foreach ( GameObject referenceObject in Selection.gameObjects ) {
                //Create New
                GameObject created = (GameObject) PrefabUtility.InstantiatePrefab(prefab);
                created.transform.rotation = referenceObject.transform.rotation * relativeRotation;
                created.transform.position = referenceObject.transform.position + referenceObject.transform.TransformDirection(relativePositionOffset);
                created.transform.localScale = replacedObject.transform.lossyScale;

                created.transform.parent = referenceObject.transform.parent;

                Undo.RegisterCreatedObjectUndo(created, "Created Replacement");
                Undo.DestroyObjectImmediate(referenceObject);
            }
        }
    }
}