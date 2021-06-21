using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SetFrameRate", menuName = "ScriptableObjects/Action/SetFrameRate")]
public class SetFrameRate : ScriptableObject {

    public void Set(int framerate) {
        Application.targetFrameRate = framerate;
    }

    public void Set60() {
        Application.targetFrameRate = 60;
    }
}
