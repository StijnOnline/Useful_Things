using StijnUtility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StijnUtility {

    public abstract class GameSystem : ScriptableObject, ICreatableScriptableObject {
        public abstract void Init();
        public abstract void Update();

    }

}