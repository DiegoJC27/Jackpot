using UnityEngine;

public class CombatStateMachine : MonoBehaviour
{
    public CombatState currentState => m_CurrentState;
    private CombatState m_CurrentState;

    private void Update() => m_CurrentState?.Update();
    public void ChangeState(CombatState newState)
    {
        if (newState == null || newState == m_CurrentState) return;
               
        m_CurrentState?.Exit();
        m_CurrentState = newState;
        m_CurrentState.Enter();
    }
}

 //public class TransitionData
    //{
    //    public CombatState fromState => m_from;
    //    public CombatState toState => m_to;
    //    public bool cancel;
    //    private CombatState m_from;
    //    private CombatState m_to;

    //    public TransitionData(CombatState from, CombatState to)
    //    {
    //        m_from = from;
    //        m_to = to;
    //        cancel = false;
    //    }
    //}
    //public event System.Action<TransitionData> OnStateChange;
    
        //TransitionData eventData = new TransitionData(m_CurrentState, newState);
        //OnStateChange?.Invoke(eventData);
        //if (eventData.cancel) return;