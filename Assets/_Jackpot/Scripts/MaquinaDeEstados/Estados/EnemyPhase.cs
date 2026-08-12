using UnityEngine;

public class EnemyPhase : CombatState
{
    private MaquinaTragamonedas mtm;
    public EnemyPhase(CombatStateMachine csm, MaquinaTragamonedas _mtm) : base(csm) {
        mtm = _mtm;
    }
    protected override void OnEnter()
    {
        Debug.Log("Entrando a EnemyPhase");
        stateMachine.Enemy.StartNewTurn();
        mtm.OnWheelsStopSpinning += OnWheelsStopSpinning;
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
        mtm.OnWheelsStopSpinning -= OnWheelsStopSpinning;
        stateMachine.Enemy.ResolveMTM();
        stateMachine.EnterPlayerTurn();
    }
}
