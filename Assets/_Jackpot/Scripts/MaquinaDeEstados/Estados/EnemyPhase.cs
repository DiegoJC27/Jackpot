using UnityEngine;

public class EnemyPhase : CombatState
{
    public EnemyPhase(CombatStateMachine csm, CombatState nxt) : base(csm, nxt) { }
    protected override void OnEnter()
    {
        Debug.Log("Entrando a EnemyPhase");

    }
    protected override void OnUpdate()
    {
        Debug.Log("El enemigo gira su maquina");
        stateMachine.ChangeState(nextState);
    }
    protected override void OnExit()
    {
        
    }
}
