using StijnUtility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StijnUtility.SO_Variables.Lists {

    public abstract class SOList<T> : ScriptableObject {
        public bool clearOnLoad;
        [NaughtyAttributes.ReorderableList] public List<T> List = new List<T>();

        private void OnEnable() {
            if ( clearOnLoad ) List.Clear();
        }
    } 
}