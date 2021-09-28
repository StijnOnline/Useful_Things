using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace StijnUtility.SO_Variables.Lists {


    [CreateAssetMenu(fileName = "WeightedValueList", menuName = "ScriptableObjects/Variables/Lists/WeightedValueList")]
    public class WeightedValueList : ScriptableObject {
        [ReadOnly] public int totalWeight;
        public List<WeightedValue> Weights = new List<WeightedValue>();

        private void OnValidate() {
            CalculateTotalWeight();
        }

        void CalculateTotalWeight() {
            totalWeight = 0;
            foreach ( var item in Weights ) {
                totalWeight += item.weigth;
            }
        }
    }


    [System.Serializable]
    public struct WeightedValue {
        public Object value;
        public int weigth;

#if UNITY_EDITOR

        [CustomPropertyDrawer(typeof(WeightedValue))]
        public class WeightedValueDrawer : PropertyDrawer {

            const int weightPropertyWidth = 100;

            public override float GetPropertyHeight( SerializedProperty property, GUIContent label ) {
                return EditorGUIUtility.singleLineHeight * (EditorGUIUtility.wideMode ? 1 : 2);
            }

            public override void OnGUI( Rect position, SerializedProperty property, GUIContent label ) {
                var _value = property.FindPropertyRelative(nameof(value));
                var _weigth = property.FindPropertyRelative(nameof(weigth));
                EditorGUI.BeginProperty(position, label, property);

                var valueRect = new Rect(position.x, position.y, position.width - weightPropertyWidth, position.height);
                var weigthRect = new Rect(position.xMax - weightPropertyWidth, position.y, weightPropertyWidth, position.height);

                EditorGUI.PropertyField(valueRect, _value, GUIContent.none);
                EditorGUI.PropertyField(weigthRect, _weigth, GUIContent.none);

                EditorGUI.EndProperty();
            }
        }

#endif
    }
}