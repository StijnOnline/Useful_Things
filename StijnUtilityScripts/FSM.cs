using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace StijnTest {
    public class FSM : MonoBehaviour{

        [ReadOnly] public List<State> states = new List<State>();

        [SerializeField, ReadOnly] private State _state;
        public State state { get; }


        private bool stateStarted;


        public void Update() {
            if ( _state != null) {
                if ( !stateStarted ) { _state.StartState(); stateStarted = true; }
                _state.UpdateState();
            }
        }

        public void SwitchState( System.Type nextStateType ) {
            State s = states.FirstOrDefault(_s => _s.GetType() == nextStateType);
            if ( s == null ) {
                Debug.LogError($"FSM: {nextStateType} state not found");
                return;
            }
            _state?.ExitState();
            _state = s;
            _state.fsm = this;
            stateStarted = false;
            _state.EnterState();
        }

        private void OnValidate() {
            states = GetComponentsInChildren<State>().ToList();
            foreach ( var state in states ) {
                state.fsm = this;
                Debug.Log(state.GetType());
            }
        }
    }


    public abstract class State : MonoBehaviour {

        [HideInInspector] public FSM fsm;

        /// <summary>
        /// Called after switching to this state
        /// </summary>
        public virtual void EnterState() { }
        /// <summary>
        /// Called before first update of state
        /// </summary>
        public virtual void StartState() { }

        public virtual void UpdateState() { }
        /// <summary>
        /// Called before switching to a new state
        /// </summary>
        public virtual void ExitState() { }
    }
}