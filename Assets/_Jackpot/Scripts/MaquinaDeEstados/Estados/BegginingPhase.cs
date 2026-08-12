using UnityEngine;

public class BegginingPhase : CombatState
{
    public  BegginingPhase(CombatStateMachine csm) : base(csm) { }
    protected override void OnEnter()
    {
        Debug.Log("Entrando a BegginingPhase");
        stateMachine.Player.StartNewTurn();
        stateMachine.EnterMainPhase();
    }
    protected override void OnUpdate()
    {
        
    }
    protected override void OnExit()
    {
        
    }
}
