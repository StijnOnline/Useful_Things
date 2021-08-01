using System.Collections;
using System.Collections.Generic;
using TypeReferences;
using TypeReferences.Editor.Drawers;
using UnityEditor;
using UnityEngine;


namespace StijnUtility {
    [InitializeOnLoad]
    public class CreateScriptableObjectWindow : EditorWindow {

        [Inherits(typeof(ICreatableScriptableObject), ExcludeNone = true, SearchbarMinItemsCount = 0)]
        public TypeReference type;

        public string path = "Assets";

        static CreateScriptableObjectWindow() {
        }

        [MenuItem("Custom/CreateScriptableObjectWindow")]
        static void Init() {
            CreateScriptableObjectWindow window = (CreateScriptableObjectWindow) EditorWindow.GetWindow(typeof(CreateScriptableObjectWindow));
        }

        void OnGUI() {
            EditorGUILayout.LabelField("Info", EditorStyles.boldLabel);
            EditorGUILayout.LabelField("Another Way to create ScriptableObjects");
            EditorGUILayout.LabelField("ScriptableObjects need to inherit ICreatableScriptableObject)");
            EditorGUILayout.LabelField("This allows you to keep the create asset menu cleaner");
            EditorGUILayout.Space(20);

            SerializedObject serializedObject = new SerializedObject(this);
            SerializedProperty serializedProperty = serializedObject.FindProperty("type");

            EditorGUILayout.PropertyField(serializedProperty);

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Path", path);

            if ( GUILayout.Button("Browse", GUILayout.Width(100)) ) {
                var filepath = EditorUtility.OpenFolderPanel("ScriptableObject save location", "Assets", "");
                path = "Assets";
                if ( filepath.Contains(Application.dataPath) )
                    path += filepath.Replace(Application.dataPath, "");
                
                
            }

            EditorGUILayout.EndHorizontal();


            if ( GUILayout.Button("Create") ) {
                CreateScriptableObject(type, path);
            }
        }

        public static void CreateScriptableObject(System.Type type, string path) {
            ScriptableObject asset = ScriptableObject.CreateInstance(type);
            string name = UnityEditor.AssetDatabase.GenerateUniqueAssetPath($"{path}/{type.Name}.asset");

            AssetDatabase.CreateAsset(asset, name);
            AssetDatabase.SaveAssets();

            EditorUtility.FocusProjectWindow();

            Selection.activeObject = asset;
        }

    }

    public interface ICreatableScriptableObject { }
}
