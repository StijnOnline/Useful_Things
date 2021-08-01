using StijnUtility.SO_Variables.Lists;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StijnUtility {

    public class AddToList : MonoBehaviour {
        public GameObjectSOList list;
        public enum Mode {
            Enable,
            EnableDisable,
            Awake,
            AwakeDestroy,
        }
        public Mode mode;

        private void OnEnable() {
            if ( mode == Mode.EnableDisable || mode == Mode.Enable )
                list.List.Add(gameObject);
        }

        private void OnDisable() {
            if ( mode == Mode.EnableDisable )
                list.List.Remove(gameObject);
        }

        private void Awake() {
            if ( mode == Mode.AwakeDestroy || mode == Mode.Awake )
                list.List.Add(gameObject);
        }

        private void OnDestroy() {
            if ( mode == Mode.AwakeDestroy )
                list.List.Remove(gameObject);
        }
    }

}