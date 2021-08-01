using StijnUtility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace StijnUtility.SO_Actions {
    [CreateAssetMenu(fileName = "SetFrameRate", menuName = "ScriptableObjects/Action/SetFrameRate")]
    public class SetFrameRate : ScriptableObject, ICreatableScriptableObject {

        public void Set( int framerate ) {
            Application.targetFrameRate = framerate;
        }

        public void Set60() {
            Application.targetFrameRate = 60;
        }
    }

}