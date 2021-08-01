using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StijnUtility {
    public interface IDraggable {
        void Pick();
        void UpdatePos( Vector2 pos );
        void Drop();
    }
}
