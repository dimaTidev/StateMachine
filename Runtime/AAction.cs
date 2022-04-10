using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DimaTi.StateMachine
{
    public abstract class AAction : ScriptableObject
    {
        public virtual void OnEnableAction(AStateMachine controller) { }
        public virtual void OnDisableAction(AStateMachine controller) { }
        public abstract void UpdateAction(AStateMachine controller);
        //public abstract void EndAction(AStateMachine controller);

#if UNITY_EDITOR
        public virtual void E_OnDrawGizmos(AStateMachine controller) { }
        public virtual void E_OnDrawGizmosSelected(AStateMachine controller) { }
#endif
    }
}