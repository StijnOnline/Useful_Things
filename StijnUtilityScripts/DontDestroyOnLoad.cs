using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StijnUtility {
    public class DontDestroyOnLoad : MonoBehaviour {
        public void Awake() {
            DontDestroyOnLoad(gameObject);
        }
    }
}