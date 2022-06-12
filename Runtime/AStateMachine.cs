using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DimaTi.StateMachine
{
    public abstract class AStateMachine : MonoBehaviour
    {
        [SerializeField] AState defaultState = null;
        private AState m_curState;
        public AState CurState
        {
            get {
                if (!m_curState)
                    m_curState = defaultState;
                return m_curState; 
            }
            set 
            {
                if (value == null)
                    return;
                if(m_curState != value)
                {
                    if (m_curState != null)
                        m_curState.OnDisableState(this);
                    m_curState = value;
                    value.OnEnableState(this);
                }
            }
        }

        void Update() => CurState.UpdateState(this);

        void LateUpdate() => ChangeTransition(CurState.CheckTransitions(this));

        void ChangeTransition(AState state)
        {
            if(state == null)
            {
                CurState = null;
                return;
            }

            if(CurState == null || state.GetInstanceID() != CurState.GetInstanceID()) //came new state
            {
#if UNITY_EDITOR
                for (int i = 1; i < lastStates.Length; i++)
                    lastStates[i - 1] = lastStates[i];
                lastStates[lastStates.Length - 1] = CurState;
#endif
                CurState = state;
            }
        }


#if UNITY_EDITOR
        [Space]
        //[SerializeField] float e_gizmoSize = 0.8f;
        [SerializeField] bool e_isShowCurState_byGizmos;
        [SerializeField] bool e_isShowStates_byGizmos;

        AState[] lastStates = new AState[5];

        void OnDrawGizmosSelected()
        {
            if (CurState)
            {
               // Gizmos.color = CurState.e_gizmosColor;
               // Gizmos.DrawWireSphere(transform.position, gizmoSize);
               if(e_isShowStates_byGizmos)
                    CurState.E_OnDrawGizmos(this);
            }
        }
        private void OnDrawGizmos()
        {
            CurState.E_OnDrawGizmosSelected(this);

            if (e_isShowCurState_byGizmos)
            {
                Vector3 pos = transform.position;
                pos.y += 1.5f;
                var guiStyle = new GUIStyle(GUI.skin.textField);
                guiStyle.richText = true;
                guiStyle.alignment = TextAnchor.MiddleCenter;
                guiStyle.fontSize = 30;
                guiStyle.fontStyle = FontStyle.Bold;
                guiStyle.normal.textColor = Color.yellow;
                UnityEditor.Handles.Label(pos, "State: " + CurState.name, guiStyle);
            }
        }
#endif
    }
}