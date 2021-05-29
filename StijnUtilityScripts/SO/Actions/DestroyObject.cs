using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DestroyObject", menuName = "ScriptableObjects/Action/DestroyObject")]
public class DestroyObject : ScriptableObject {
    public void Destroy(GameObject @object) {
        Object.Destroy(@object);
    }
    public void Destroy(GameObject @object, float delay) {
        Object.Destroy(@object, delay);
    }
}