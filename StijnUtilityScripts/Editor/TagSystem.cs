///Generates an enum with all Tags

using UnityEditor;
using UnityEngine;
using System.IO;

namespace StijnUtility {
    [InitializeOnLoad]
    class TagSystem : UnityEditor.AssetModificationProcessor {

        static bool importing = false;

        //Called via AssetModificationProcessor
        static string[] OnWillSaveAssets( string[] paths ) {
            if ( !importing ) GenerateNewLayersFile();
            return paths;
        }

        static void GenerateNewLayersFile() {
            Debug.Log("Updating Layers Enum");

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

            //Write to file
            string path = Application.dataPath + "/Generated/Tags.cs";
            Directory.CreateDirectory(Application.dataPath + "/Generated");
            File.WriteAllText(path, fileContents);

            //Reimport
            importing = true;
            AssetDatabase.ImportAsset("Assets/Generated/Tags.cs");
            importing = false;
        }



    }
}