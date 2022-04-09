using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DimaTi.StateMachine
{

    [CreateAssetMenu(fileName = "Action_ScaleUp", menuName = "ScriptableObjects/StateMachine/Example/Action/ScaleUp")]
    public class Example_Action_ScaleUp : AAction
    {
        [SerializeField] float speed = 1.1f;

        public override void UpdateAction(AStateMachine controller)
        {
            RandomMove(controller);
        }

        void RandomMove(AStateMachine controller)
        {
            controller.transform.localScale = controller.transform.localScale * speed;
        }
    }
}