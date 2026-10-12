using UnityEngine;

public class CombatEndPhase : CombatState
{
    public CombatEndPhase(CombatStateMachine _csm) : base(_csm) { }

    protected override void OnEnter()
    {
        stateMachine.Player.ResetCombatStats();
    }
    protected override void OnUpdate()
    {
    }
    protected override void OnExit()
    {
    }
}
