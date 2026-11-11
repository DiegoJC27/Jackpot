using UnityEngine;

public class EndPhase : CombatState
{
    public  EndPhase(CombatStateMachine csm) : base(csm) { }
    protected override void OnEnter()
    {
        stateMachine.Player.ResolveMTM();
        stateMachine.EnterCombatPhase();
        elapsedTime = 0f;
    }
    protected override void OnUpdate()
    {
        elapsedTime += Time.deltaTime;

    }
    protected override void OnExit()
    {
        
    }
}
