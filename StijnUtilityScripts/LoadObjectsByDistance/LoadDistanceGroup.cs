using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StijnUtility
{
    [CreateAssetMenu(fileName = "LoadDistanceGroup", menuName = "ScriptableObjects/LoadDistanceGroup")]
    public class LoadDistanceGroup : ScriptableObject
    {
        public float loadDistance;
        public float updateInterval;
        [ReadOnly] public float lastUpdate;
        public List<DistanceLoader> loaders;
        public List<LoadDistance> objects;

        private void OnEnable() {
            lastUpdate = 0;
            loaders.Clear();
            objects.Clear();
        }
    }
}
