using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class CombatState
{
    public event Action<CombatState> OnStateEnter;
    public event Action<CombatState> OnStateUpdate;
    public event Action<CombatState> OnStateExit;
    protected CombatStateMachine StateMachine;

    //public CombatState(Action<CombatState> changeStateMethod) => m_ChangeStateMethod = changeStateMethod;
    //protected List<(Func<bool> condition, CombatState nextState)> m_Transitions = new List<(Func<bool>, CombatState)>();
    public CombatState(CombatStateMachine stateMachine)
    {
        StateMachine = stateMachine;
    }

    public void Enter()
    {
        OnStateEnter?.Invoke(this);
        OnEnter();
    }
    public void Update()
    {
        OnStateUpdate?.Invoke(this);
        OnUpdate();
    }
    public void Exit()
    {
        OnStateExit?.Invoke(this);
        OnExit();
    }

    protected virtual void OnEnter() { }
    protected virtual void OnUpdate() { }
    protected virtual void OnExit() { }
}
