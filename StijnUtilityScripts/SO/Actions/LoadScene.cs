using NaughtyAttributes;
using StijnUtility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace StijnUtility.SO_Actions {
    [CreateAssetMenu(fileName = "LoadScene", menuName = "ScriptableObjects/Action/LoadScene")]
    public class LoadScene : ScriptableObject {

        [Scene]
        public int scene;

        public void Load() {
            SceneManager.LoadScene(scene);
        }
    }
}