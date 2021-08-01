using StijnUtility;
using System.Collections;
using System.Collections.Generic;
using UltEvents;
using UnityEngine;

namespace StijnUtility.SO_Events {
    [CreateAssetMenu(fileName = "VoidEvent", menuName = "ScriptableObjects/Events/Void")]
    public class VoidSOEvent : ScriptableObject, ICreatableScriptableObject {
        public UltEvent @event;
    } 
}