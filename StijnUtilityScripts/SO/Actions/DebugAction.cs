﻿using StijnUtility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace StijnUtility.SO_Actions {
    [CreateAssetMenu(fileName = "DebugAction", menuName = "ScriptableObjects/Action/DebugAction")]
    public class DebugAction : ScriptableObject {
        public void Log( string message ) {
            Debug.Log(message);
        }

        public void Log( GameObject message ) {
            Debug.Log(message);
        }
    }

}