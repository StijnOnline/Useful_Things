using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StijnUtility
{
    public class LoadDistance : MonoBehaviour {

        public LoadDistanceGroup loadDistanceGroup;
        private void Awake() {
            loadDistanceGroup.objects.Add(this);
        }
    }
}
