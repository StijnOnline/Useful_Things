///Generates an enum with all Layers

using UnityEditor;
using UnityEngine;
using System.IO;

namespace StijnUtility {
    [InitializeOnLoad]
    class LayerSystem : UnityEditor.AssetModificationProcessor {

        static bool importing = false;

        //Called via AssetModificationProcessor
        static string[] OnWillSaveAssets( string[] paths ) {
            if ( !importing ) GenerateNewLayersFile();
            return paths;
        }

        static void GenerateNewLayersFile() {
            Debug.Log("Updating Layers Enum");

            //Get layers
            string[] layers = new string[32];
            for ( int i = 0; i <= 31; i++ ) {
                layers[i] = LayerMask.LayerToName(i);
            }

            //Generate file contents
            string fileContents = "public enum Layers {";
            for ( int i = 0; i <= 31; i++ ) {
                if ( layers[i].Length > 0 ) {
                    fileContents += "\n\t";//New Line + Tab
                    fileContents += layers[i].Replace(" ", "_") + "=" + i + ","; //LayerName=LayerInt,
                }
            }
            fileContents += "\n}";

            //Write to file
            string path = Application.dataPath + "/Generated/Layers.cs";
            Directory.CreateDirectory(Application.dataPath + "/Generated");
            File.WriteAllText(path, fileContents);

            //Reimport
            importing = true;
            AssetDatabase.ImportAsset("Assets/Generated/Layers.cs");
            importing = false;
        }


    }
}