using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DimaTi.StateMachine
{
    public abstract class AState : ScriptableObject
    {
        [SerializeField] AAction[] actions = null;
        [SerializeField] Transition[] transitions = null;

//#if UNITY_EDITOR
//        public Color e_gizmosColor = Color.white;
//#endif

        public void OnEnableState(AStateMachine controller)
        {
            if (actions != null)
                for (int i = 0; i < actions.Length; i++)
                    if (actions[i])
                        actions[i].OnEnableAction(controller);
        }
        public void OnDisableState(AStateMachine controller)
        {
            if (actions != null)
                for (int i = 0; i < actions.Length; i++)
                    if (actions[i])
                        actions[i].OnDisableAction(controller);
        }

        public void UpdateState(AStateMachine controller)
        {
            if (actions != null)
                for (int i = 0; i < actions.Length; i++)
                    if (actions[i])
                        actions[i].UpdateAction(controller);
        }

        public AState CheckTransitions(AStateMachine controller)
        {
            AState nextState = null;
            if(transitions != null)
                for (int i = 0; i < transitions.Length; i++)
                {
                    nextState = transitions[i].CheckTransition(controller);
                    if (nextState)
                        break;
                }
            return nextState;
        }

#if UNITY_EDITOR
        public virtual void E_OnDrawGizmos(AStateMachine controller)
        {
            if (actions != null)
                for (int i = 0; i < actions.Length; i++)
                    if (actions[i])
                        actions[i].E_OnDrawGizmos(controller);

            if (transitions != null)
                foreach (var transition in transitions)
                    transition.E_OnDrawGizmos(controller);
        }

        public virtual void E_OnDrawGizmosSelected(AStateMachine controller)
        {
            if (actions != null)
                for (int i = 0; i < actions.Length; i++)
                    if (actions[i])
                        actions[i].E_OnDrawGizmosSelected(controller);

            if (transitions != null)
                foreach (var transition in transitions)
                    transition.E_OnDrawGizmosSelected(controller);
        }
#endif
    }

    [System.Serializable]
    public class Transition
    {
#if UNITY_EDITOR
#pragma warning disable 0414
        [SerializeField] string e_name = "";
#pragma warning restore 0414
#endif
        [SerializeField] bool isMuted = false;
        enum ComparingType { all_true = 0, all_false = 1, any_true = 2, any_false = 3 }
        [SerializeField] ComparingType comparingType = ComparingType.all_true;

        [SerializeField] ADecision[] decisions;
        [SerializeField] AState stateTrue;

        public AState CheckTransition(AStateMachine controller)
        {
            if (isMuted)
                return null;

            if (decisions == null)
                return null;

            switch (comparingType)
            {
                case ComparingType.all_true: //-------------------
                    for (int i = 0; i < decisions.Length; i++)
                    {
                        //Debug.Log($"Decide: {e_name}[{decisions[i].name}]: " + decisions[i].Decide(controller));
                        if (decisions[i] && decisions[i].Decide(controller) == false)
                            return null;
                    }
                    break;
                case ComparingType.all_false: //-------------------
                    for (int i = 0; i < decisions.Length; i++)
                    {
                        if (decisions[i] && decisions[i].Decide(controller) == true)
                            return null;
                    }
                    break;
                case ComparingType.any_true: //-------------------
                    for (int i = 0; i < decisions.Length; i++)
                    {
                        if (decisions[i] && decisions[i].Decide(controller) == true)
                            return stateTrue;
                    }
                    return null;
                case ComparingType.any_false: //-------------------
                    for (int i = 0; i < decisions.Length; i++)
                    {
                        if (decisions[i] && decisions[i].Decide(controller) == false)
                            return stateTrue;
                    }
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

#if UNITY_EDITOR
        [SerializeField] bool e_onDrawGizmos = false;
        public virtual void E_OnDrawGizmos(AStateMachine controller)
        {
            if (decisions != null && e_onDrawGizmos)
                for (int i = 0; i < decisions.Length; i++)
                    if (decisions[i])
                        decisions[i].E_OnDrawGizmos(controller);
        }

        public virtual void E_OnDrawGizmosSelected(AStateMachine controller)
        {
            if (decisions != null && e_onDrawGizmos)
                for (int i = 0; i < decisions.Length; i++)
                    if (decisions[i])
                        decisions[i].E_OnDrawGizmosSelected(controller);
        }
#endif

    }
}