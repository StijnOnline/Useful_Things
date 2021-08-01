using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StijnUtility {
    public class Temporary : MonoBehaviour {
        public float lifetime;
        void Start() {
            Destroy(gameObject, lifetime);
        }
    }
}