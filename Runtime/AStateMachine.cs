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
                m_curState = value; 
            }
        }

        void Update()
        {
            CurState.UpdateState(this);
        }

        void LateUpdate()
        {
            CurState = CurState.CheckTransitions(this);
        }


#if UNITY_EDITOR
        void OnDrawGizmos()
        {
            if (CurState)
            {
                Gizmos.color = CurState.e_gizmosColor;
                Gizmos.DrawWireSphere(transform.position, 1);
            }

        }
#endif

    }
}