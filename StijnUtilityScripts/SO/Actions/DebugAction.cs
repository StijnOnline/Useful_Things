using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DebugAction", menuName = "ScriptableObjects/Action/DebugAction")]
public class DebugAction : ScriptableObject
{
    public void Log(string message ) {
        Debug.Log(message);
    }

    public void Log(GameObject message ) {
        Debug.Log(message);
    }
}
