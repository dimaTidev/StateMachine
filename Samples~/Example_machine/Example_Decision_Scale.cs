using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DimaTi.StateMachine
{

    [CreateAssetMenu(fileName = "Decision_scale", menuName = "ScriptableObjects/StateMachine/Example/Decision_scale")]
    public class Example_Decision_Scale : ADecision
    {
        [SerializeField] Vector3 scale = Vector3.one;

        enum CompareType {Less, Greater }
        [SerializeField] CompareType compareType = CompareType.Less;

        public override bool Decide(AStateMachine controller) => DecideScale(controller);

        bool DecideScale(AStateMachine controller)
        {
            if (compareType == CompareType.Less)
                return controller.transform.localScale.x < scale.x;
            else
                return controller.transform.localScale.x > scale.x;  
        }
    }
}