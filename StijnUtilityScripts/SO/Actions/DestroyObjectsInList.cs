using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DestroyObjectsInList", menuName = "ScriptableObjects/Action/DestroyObjectsInList")]
public class DestroyObjectsInList : ScriptableObject {

    public void DestroyObjects( GameObjectSOList list )
    {
        foreach ( var ob in list.List ) {
            Destroy(ob);
        }
    }
}
