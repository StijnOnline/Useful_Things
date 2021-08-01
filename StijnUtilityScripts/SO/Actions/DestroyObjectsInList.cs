using StijnUtility;
using StijnUtility.SO_Variables.Lists;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace StijnUtility.SO_Actions {
    [CreateAssetMenu(fileName = "DestroyObjectsInList", menuName = "ScriptableObjects/Action/DestroyObjectsInList")]
    public class DestroyObjectsInList : ScriptableObject, ICreatableScriptableObject {

        public void DestroyObjects( GameObjectSOList list ) {
            foreach ( var ob in list.List ) {
                Destroy(ob);
            }
        }
    }

}