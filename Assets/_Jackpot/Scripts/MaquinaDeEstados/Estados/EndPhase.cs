using UnityEngine;

public class EndPhase : CombatState
{
    public  EndPhase(CombatStateMachine csm) : base(csm) { }
    protected override void OnEnter()
    {
        Debug.Log("Entrando a EndPhase");
        stateMachine.Player.ResolveMTM();


        stateMachine.EnterCombatPhase();

    }
    protected override void OnUpdate()
    {
        
    }
    protected override void OnExit()
    {
        
    }
}
