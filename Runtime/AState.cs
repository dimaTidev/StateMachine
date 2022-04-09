using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DimaTi.StateMachine
{
    public abstract class AState : ScriptableObject
    {
        [SerializeField] AAction[] actions = null;
        [SerializeField] Transition[] transitions = null;

#if UNITY_EDITOR
        public Color e_gizmosColor = Color.white;
#endif

        public void UpdateState(AStateMachine controller)
        {
            if (actions != null)
            {
                for (int i = 0; i < actions.Length; i++)
                {
                    if (actions[i])
                        actions[i].UpdateAction(controller);
                }
            }
        }
        public AState CheckTransitions(AStateMachine controller)
        {
            AState nextState = null;
            for (int i = 0; i < transitions.Length; i++)
            {
                nextState = transitions[i].CheckTransition(controller);
                if (nextState)
                    break;
            }
            return nextState;
        }
    }

    [System.Serializable]
    public class Transition
    {
#if UNITY_EDITOR
        [SerializeField] string e_name = "";
#endif
        [SerializeField] ADecision[] decisions;
        [SerializeField] AState stateTrue;

        public AState CheckTransition(AStateMachine controller)
        {
            if (decisions == null)
                return null;

            for (int i = 0; i < decisions.Length; i++)
            {
                if (decisions[i] && !decisions[i].Decide(controller))
                    return null;  
            }
            return stateTrue;

            // bool isCompleted = false;
            // for (int i = 0; i < decisions.Length; i++)
            // {
            //     if (decisions[i])
            //         isCompleted |= decisions[i].Decide(controller);
            // }
            //
            // return isCompleted ? stateTrue : null;
        }
    }
}