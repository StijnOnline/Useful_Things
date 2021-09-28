using StijnUtility;
using System.Collections;
using System.Collections.Generic;
using UltEvents;
using UnityEngine;

namespace StijnUtility.SO_Events {

    public abstract class SOEvent<T> : ScriptableObject {
        public UltEvent<T> @event;
    } 
}
