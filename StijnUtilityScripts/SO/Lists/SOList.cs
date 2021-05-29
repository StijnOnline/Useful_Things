using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SOList<T> : ScriptableObject {
    [NaughtyAttributes.ReorderableList] public List<T> List = new List<T>();
}