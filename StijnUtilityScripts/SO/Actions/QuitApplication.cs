﻿using Sirenix.OdinInspector;
using StijnUtility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace StijnUtility.SO_Actions {
    [CreateAssetMenu(fileName = "QuitApplication", menuName = "ScriptableObjects/Action/QuitApplication")]
    public class QuitApplication : ScriptableObject {

        public void Quit() {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
              Application.Quit();
#endif
        }
    }
}