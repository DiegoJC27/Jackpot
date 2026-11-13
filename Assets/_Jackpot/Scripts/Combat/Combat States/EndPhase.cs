using UnityEngine;

public class EndPhase : CombatState
{
    public  EndPhase(CombatStateMachine csm) : base(csm) { }
    protected override void OnEnter()
    {
        elapsedTime = 0f;
        stateMachine.Player.ResolveMTM();
        stateMachine.EnterCombatPhase();
    }
    protected override void OnUpdate()
    {
        elapsedTime += Time.deltaTime;
    }
    protected override void OnExit()
    {
        
    }
}
