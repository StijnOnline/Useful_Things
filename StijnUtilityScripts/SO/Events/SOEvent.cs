using System.Collections;
using System.Collections.Generic;
using UltEvents;
using UnityEngine;

public abstract class SOEvent<T> : ScriptableObject {
    public UltEvent<T> @event;
}
