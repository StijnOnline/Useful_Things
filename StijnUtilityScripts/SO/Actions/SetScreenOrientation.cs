using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "SetScreenOrientation", menuName = "ScriptableObjects/Action/SetScreenOrientation")]
public class SetScreenOrientation : ScriptableObject {

    public void Set( ScreenOrientation orientation) {
        Screen.orientation = orientation;
    }

    public void SetLandscape() {
        Screen.orientation = ScreenOrientation.Landscape;
    }

    public void SetPortrait() {
        Screen.orientation = ScreenOrientation.Portrait;
    }
}
