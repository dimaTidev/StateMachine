using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DimaTi.StateMachine.AI
{
    [CreateAssetMenu(fileName = "Decision_boolTest", menuName = "ScriptableObjects/StateMashine/Decisions/Bool")]
    public class Decision_bool : ADecision
    {
        [SerializeField] bool returnValue = false;
        public override bool Decide(AStateMachine controller) => returnValue;
    }
}