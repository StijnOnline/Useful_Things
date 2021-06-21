/*
System to disable and enable objects based on distance from 'loader' objects
Possible Improvement: Async or Jobified
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StijnUtility {

    [CreateAssetMenu(fileName = "LoadDistanceSystem", menuName = "ScriptableObjects/Systems/LoadDistanceSystem")]
    public class LoadDistanceSystem : GameSystem
    {
        public List<LoadDistanceGroup> groups;

        public override void Init() {

        }

        public override void Update() {
            foreach ( var group in groups ) {
                if ( Time.time > group.lastUpdate + group.updateInterval ) {
                    UpdateGroup(group);
                }
            }
        }

        void UpdateGroup( LoadDistanceGroup group ) {
            float sqrDist = group.loadDistance * group.loadDistance;
            foreach ( var ob in group.objects ) {
                bool inDist = false;
                foreach ( var l in group.loaders ) {
                    if ( (l.transform.position - ob.transform.position).sqrMagnitude < sqrDist ) {
                        inDist = true;
                        break;
                    }
                }
                ob.gameObject.SetActive(inDist);
            }
            group.lastUpdate = Time.time;
        }
    }
}
