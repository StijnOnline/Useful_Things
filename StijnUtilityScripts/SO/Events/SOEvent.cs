using StijnUtility;
using System.Collections;
using System.Collections.Generic;
using UltEvents;
using UnityEngine;

namespace StijnUtility.SO_Events {

    public abstract class SOEvent<T> : ScriptableObject, ICreatableScriptableObject {
        public UltEvent<T> @event;
    } 
}
