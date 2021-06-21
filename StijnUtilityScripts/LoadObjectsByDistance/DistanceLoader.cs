using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StijnUtility
{
    public class DistanceLoader : MonoBehaviour {

        /*Vector3 lastPos;
        public bool CheckMoved { 
            get {
                bool m = (lastPos != transform.position);
                lastPos = transform.position;
                return m;
            } 
        }*/

        public LoadDistanceGroup loadDistanceGroup;
        private void Awake() {
            loadDistanceGroup.loaders.Add(this);
        }
    }
}
