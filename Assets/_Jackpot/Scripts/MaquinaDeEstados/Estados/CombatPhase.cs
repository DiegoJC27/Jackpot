using UnityEngine;

public class CombatPhase : CombatState
{
    public  CombatPhase(CombatStateMachine csm, CombatState nxt): base(csm, nxt) {}
    protected override void OnEnter()
    {
        Debug.Log("Entrando a CombatPhase");
    }
    protected override void OnUpdate()
    {
        Debug.Log("Se resuelve el combate");
        stateMachine.ChangeState(nextState);
    }
    protected override void OnExit()
    {
        
    }
}
