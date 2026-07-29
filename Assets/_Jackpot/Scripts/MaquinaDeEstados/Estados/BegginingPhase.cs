using UnityEngine;

public class BegginingPhase : CombatState
{
    public  BegginingPhase(CombatStateMachine csm, CombatState nxt) : base(csm, nxt) { }
    protected override void OnEnter()
    {
        Debug.Log("Entrando a BegginingPhase");
        stateMachine.ChangeState(nextState);

    }
    protected override void OnUpdate()
    {
        
    }
    protected override void OnExit()
    {
        
    }
}
