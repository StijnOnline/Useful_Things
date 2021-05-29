using System.Collections;
using System.Collections.Generic;
using UltEvents;
using UnityEngine;

public abstract class SOUltEvent<T> : ScriptableObject {
    public UltEvent<T> @event;
}
