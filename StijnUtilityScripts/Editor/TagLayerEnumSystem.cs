///Generates an enum with all Tags
//usefull reference https://forum.unity.com/threads/create-tags-and-layers-in-the-editor-using-script-both-edit-and-runtime-modes.732119/


using UnityEditor;
using UnityEngine;
using System.IO;
using System.Reflection;
using System;

namespace StijnUtility {
    [InitializeOnLoad]
    class TagLayerEnumSystem {

        static bool wasSelectingTagManager;

        static SerializedObject tagManager;
        static SerializedProperty tagsProperty;
        static SerializedProperty layersProperty;

        static TagLayerEnumSystem() {

            tagManager = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset")[0]);
            tagsProperty = tagManager.FindProperty("tags");
            layersProperty = tagManager.FindProperty("layers");

            Selection.selectionChanged += OnSelectionChanged;
        }

        static void OnSelectionChanged() {
            bool selectingTagManager = Selection.activeObject?.GetType()?.FullName == "UnityEditor.TagManager";

            tagManager = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset")[0]);
            if ( wasSelectingTagManager ) {
                bool changed = false;
                //Check if Changed
                //Function not really intended for this but accidentally found this to work
                //Required to load tagmanager via assetdatabase every time (idk why)
                //Otherwise you need to check serializedProperty manually

                if ( tagsProperty != null ) {
                    changed |= tagManager.CopyFromSerializedPropertyIfDifferent(tagsProperty);
                }
                if ( layersProperty != null ) {
                    changed |= tagManager.CopyFromSerializedPropertyIfDifferent(layersProperty);
                }

                //save current
                tagsProperty = tagManager.FindProperty("tags");
                layersProperty = tagManager.FindProperty("layers");

                if (changed){
                    Debug.Log("Detected changes in Tags or Layers, updating enum (will recompile)");

                    GenerateTagsLayersEnumFile();

                    AssetDatabase.ImportAsset("Assets/Generated/TagsLayersEnum.cs");
                }
            }

            wasSelectingTagManager = selectingTagManager;
        }

        static void GenerateTagsLayersEnumFile() {

            //Get tags
            string[] tags = UnityEditorInternal.InternalEditorUtility.tags;

            //Generate file contents
            string fileContents = "public enum Tags {";
            for ( int i = 0; i < tags.Length; i++ ) {
                if ( tags[i].Length > 0 ) {
                    fileContents += "\n\t";//New Line + Tab
                    fileContents += tags[i].Replace(" ", "_") + ","; //LayerName=LayerInt,
                }
            }
            fileContents += "\n}";

            //Get layers
            string[] layers = new string[32];
            for ( int i = 0; i <= 31; i++ ) {
                layers[i] = LayerMask.LayerToName(i);
            }

            //Generate file contents
            fileContents += "\n\n";
            fileContents += "public enum Layers {";
            for ( int i = 0; i <= 31; i++ ) {
                if ( layers[i].Length > 0 ) {
                    fileContents += "\n\t";//New Line + Tab
                    fileContents += layers[i].Replace(" ", "_") + "=" + i + ","; //LayerName=LayerInt,
                }
            }
            fileContents += "\n}";

            //Write to file
            string path = Application.dataPath + "/Generated/TagsLayersEnum.cs";
            Directory.CreateDirectory(Application.dataPath + "/Generated");
            File.WriteAllText(path, fileContents);
        }

    }
}