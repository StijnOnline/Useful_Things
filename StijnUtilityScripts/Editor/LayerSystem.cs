///System that will read current layers and generate an enum 


using UnityEditor;
using UnityEngine;
using System.IO;


[InitializeOnLoad]
class LayerSystem : UnityEditor.AssetModificationProcessor {

    //Called via AssetModificationProcessor
    static string[] OnWillSaveAssets( string[] paths ) {
        GenerateNewLayersFile();
        return paths;
    }

    static void GenerateNewLayersFile() {
        Debug.Log("Saving Project: Updating Layers Enum");

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
        string path = Application.dataPath + "/Layers.cs";
        File.WriteAllText(path, fileContents);

        //Reimport
        AssetDatabase.ImportAsset("Assets/Layers.cs");
    }

    

}