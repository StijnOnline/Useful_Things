using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StijnUtility {
    [ExecuteInEditMode]
    public class UIBar : MonoBehaviour {
        public RectTransform bar;
        public float length;
        [Space(5), Range(0, 1f)]
        public float value;

        public bool vertical;
        public bool leftToRight;

        public void SetValue( float percentage ) {
            value = percentage;
        }

        private void Update() {
            float pos = 0;
            if ( leftToRight ) {
                pos = (1 - value) * length * 1f;
            } else {
                pos = (1 - value) * length * -1f;
            }


            if ( vertical ) {
                bar.anchoredPosition = new Vector2(0, pos);
            } else {
                bar.anchoredPosition = new Vector2(pos, 0);
            }
        }
    }

}