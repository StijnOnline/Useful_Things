using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StijnUtility {
    public class SystemManager : MonoBehaviour {

        public List<GameSystem> systems;

        void Start() {

            foreach ( GameSystem system in systems ) {
                system.Init();
            }
        }

        void Update() {
            foreach ( GameSystem system in systems ) {
                system.Update();
            }
        }
    } 
}
