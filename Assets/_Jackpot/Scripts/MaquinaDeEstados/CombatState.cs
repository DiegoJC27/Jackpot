using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class CombatState
{
    public event Action<CombatState> OnStateEnter;
    public event Action<CombatState> OnStateUpdate;
    public event Action<CombatState> OnStateExit;
    protected CombatStateMachine stateMachine;

    protected float delayTime = 1f;
    protected float elapsedTime = 0f;
    public CombatState(CombatStateMachine _stateMachine)
    {
        stateMachine = _stateMachine;
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

    protected bool TimerOver()
    {
        if (elapsedTime > delayTime)
        {
            elapsedTime = 0F;
            return true;
        }
        return false;
    }
}
