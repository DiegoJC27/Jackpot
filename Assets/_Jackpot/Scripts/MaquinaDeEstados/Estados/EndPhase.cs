using UnityEngine;

public class EndPhase : CombatState
{
    public  EndPhase(CombatStateMachine csm, CombatState nxt) : base(csm, nxt) { }
    protected override void OnEnter()
    {
        Debug.Log("Entrando a EndPhase");
        stateMachine.ChangeState(nextState);

    }
    protected override void OnUpdate()
    {
        
    }
    protected override void OnExit()
    {
        
    }
}
