using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemManager : MonoBehaviour {

    [ReorderableList] public List<GameSystem> systems;

    void Start()
    {

        foreach ( GameSystem system in systems ) {
            system.Init();
        }
    }

    void Update()
    {
        foreach ( GameSystem system in systems ) {
            system.Update();
        }
    }
}
