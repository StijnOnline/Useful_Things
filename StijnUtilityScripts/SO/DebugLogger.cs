/*
Custom DebugLogger with filtering capabilities
*/

using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor;
using System.IO;

namespace StijnUtility {
    [CreateAssetMenu(fileName = "DebugLogger", menuName = "ScriptableObjects/DebugLogger")]
    public class DebugLogger : ScriptableObject {

        [System.Serializable]
        public struct DebugCategoryItem {
            public string categoryName;
            public bool enabled;
        }

        public List<DebugCategoryItem> debugCategories = new List<DebugCategoryItem>();
        public static Dictionary<string, bool> _debugCategories = new Dictionary<string, bool>();


        private void OnValidate() {
            if ( !debugCategories.Any(c => c.categoryName == "Default") ) {
                debugCategories.Insert(0, new DebugCategoryItem { categoryName = "Default", enabled = true });
            }
            bool duplicate = debugCategories.GroupBy(c => c.categoryName).Any(g => g.Count() > 1);
            if ( duplicate ) {
                Debug.LogWarning("DebugLogger shouldn't have duplicate category names");
                return;
            }
            _debugCategories.Clear();
            foreach ( var item in debugCategories ) {
                _debugCategories.Add(item.categoryName, item.enabled);
            }
        }

        public static void Log( object message, string category ) {
            if ( !_debugCategories.ContainsKey(category) ) {
                Debug.LogWarning("DebugLogger.Log: Couldn't find category " + category + ", using 'Default'");
                category = "Default";
            }
            if ( _debugCategories[category] ) Debug.Log(message);
        }
        public static void LogWarning( object message, string category ) {
            if ( !_debugCategories.ContainsKey(category) ) {
                Debug.LogWarning("DebugLogger.Log: Couldn't find category " + category + ", using 'Default'");
                category = "Default";
            }
            if ( _debugCategories[category] ) Debug.LogWarning(message);

        }
        public static void LogError( object message, string category ) {
            if ( !_debugCategories.ContainsKey(category) ) {
                Debug.LogWarning("DebugLogger.Log: Couldn't find category " + category + ", using 'Default'");
                category = "Default";
            }
            if ( _debugCategories[category] ) Debug.LogError(message);
        }

    }

}