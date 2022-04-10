using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DimaTi.StateMachine
{
    public abstract class ADecision : ScriptableObject
    {
        public abstract bool Decide(AStateMachine controller);

#if UNITY_EDITOR
        public virtual void E_OnDrawGizmos(AStateMachine controller) { }
        public virtual void E_OnDrawGizmosSelected(AStateMachine controller) { }
#endif
    }
}