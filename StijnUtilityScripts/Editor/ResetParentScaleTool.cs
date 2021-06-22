using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace StijnUtility
{
    public class ResetParentScale : Editor
    {
        [MenuItem("Custom/ResetParentScale")]
        static void Reset()
        {
            if ( Selection.count != 1 ) {
                Debug.LogWarning("Can only select one object to reset parent scale");
                return;
            }


            Transform parent = Selection.activeTransform;

            for ( int i = 0; i < parent.childCount; i++ ) {
                Transform child = parent.GetChild(i);

                Undo.RecordObject(child, "ResetParentScale");

                child.localScale = Vector3.Scale(child.localScale, parent.localScale);
                child.localPosition = Vector3.Scale(child.localPosition, parent.localScale);

            }
            Undo.RecordObject(parent, "ResetParentScale");
            parent.localScale = Vector3.one;
        }

    }
}
