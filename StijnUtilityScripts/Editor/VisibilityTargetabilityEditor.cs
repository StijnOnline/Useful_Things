﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Threading.Tasks;

public class VisibilityTargetabilityEditor : Editor {

    [MenuItem("Custom/Visibilty/Show", false, 10)]
    static void ShowObject() {
        SceneVisibilityManager.instance.Show(Selection.gameObjects, true);
    }

    [MenuItem("Custom/Visibilty/Hide", false, 10)]
    static void Hide() {
        SceneVisibilityManager.instance.Hide(Selection.gameObjects, true);
    }

    [MenuItem("Custom/Visibilty/Toggle visibilty", false, 10)]
    static void ToggleVisibilty() {
        foreach ( var item in Selection.gameObjects ) {
            SceneVisibilityManager.instance.ToggleVisibility(item, true);
        }
    }

    [MenuItem("Custom/Selectable/Selectable", false, 10)]
    static void Selectable() {
        SceneVisibilityManager.instance.EnablePicking(Selection.gameObjects, true);
    }

    [MenuItem("Custom/Selectable/Unselectable", false, 10)]
    static void Unselectable() {
        SceneVisibilityManager.instance.DisablePicking(Selection.gameObjects, true);
    }

    [MenuItem("Custom/Selectable/Toggle selectable", false, 10)]
    static void ToggleSelectable() {
        foreach ( var item in Selection.gameObjects ) {
            SceneVisibilityManager.instance.TogglePicking(item, true);
        }
    }
}
