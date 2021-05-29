using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "LoadScene", menuName = "ScriptableObjects/Action/LoadScene")]
public class LoadScene : ScriptableObject {

    [Scene]
    public int scene;

    public void Load() {
        SceneManager.LoadScene(scene);
    }
}