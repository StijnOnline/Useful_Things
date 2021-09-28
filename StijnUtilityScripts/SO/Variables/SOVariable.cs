using StijnUtility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StijnUtility.SO_Variables {
    public abstract class SOVariable<T> : ScriptableObject {
        public T Value;
    }
}
