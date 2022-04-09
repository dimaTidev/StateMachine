using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DimaTi.StateMachine
{

    [CreateAssetMenu(fileName = "Decision_Collider", menuName = "ScriptableObjects/StateMachine/Example/Decision_Collider")]
    public class Example_Decision_CheckCollider : ADecision
    {
        [SerializeField] bool isEnabled = false;
        public override bool Decide(AStateMachine controller) => controller.GetComponent<Collider>() && controller.GetComponent<Collider>().enabled == isEnabled;
    }
}
