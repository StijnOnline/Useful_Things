using NaughtyAttributes;
using StijnUtility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace StijnUtility.SO_Actions {
    [CreateAssetMenu(fileName = "DestroyObject", menuName = "ScriptableObjects/Action/DestroyObject")]
    public class DestroyObject : ScriptableObject {
        public void Destroy( GameObject @object ) {
            Object.Destroy(@object);
        }
        public void Destroy( GameObject @object, float delay ) {
            Object.Destroy(@object, delay);
        }
    }
}