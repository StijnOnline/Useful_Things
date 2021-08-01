using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace StijnUtility {
    [CustomPropertyDrawer(typeof(PercentageAttribute))]
    public class PercentageAttributeDrawer : PropertyDrawer {


        public override void OnGUI( Rect position, SerializedProperty property, GUIContent label ) {
            Rect propertyRect = position;
            propertyRect.width = EditorGUIUtility.labelWidth + 100;
            EditorGUI.PropertyField(propertyRect, property, label, true);

            Rect labelRect = new Rect(propertyRect.xMax, position.yMin, 100, position.height);
            GUI.Label(labelRect, $"({property.floatValue * 100}%)");

            EditorGUI.BeginChangeCheck();
        }

    }
}