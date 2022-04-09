using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DimaTi.StateMachine
{
    public abstract class ADecision : ScriptableObject
    {
        public abstract bool Decide(AStateMachine controller);
    }
}