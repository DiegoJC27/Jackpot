using UnityEngine;

public class EnemyPhase : CombatState
{
    public EnemyPhase(CombatStateMachine csm) : base(csm) { }
    
    protected override void OnEnter()
    {
        Debug.Log("Entrando a EnemyPhase");
        stateMachine.Enemy.StartNewTurn();
        stateMachine.Enemy.mtm.OnWheelsStopSpinning += OnWheelsStopSpinning;
    }
    protected override void OnUpdate()
    {
        Debug.Log("El enemigo gira su maquina");
    }
    protected override void OnExit()
    {
        
    }

    private void OnWheelsStopSpinning()
    {
        stateMachine.Enemy.mtm.OnWheelsStopSpinning -= OnWheelsStopSpinning;
        stateMachine.Enemy.ResolveMTM();
        stateMachine.EnterPlayerTurn();
    }
}
