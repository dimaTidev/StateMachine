using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DimaTi.StateMachine
{
    public abstract class AAction : ScriptableObject
    {
        public abstract void UpdateAction(AStateMachine controller);
    }
}