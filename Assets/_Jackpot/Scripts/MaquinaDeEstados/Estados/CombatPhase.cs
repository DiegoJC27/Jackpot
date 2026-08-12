using UnityEngine;

public class CombatPhase : CombatState
{
    public  CombatPhase(CombatStateMachine csm): base(csm) {}
    protected override void OnEnter()
    {
        Debug.Log("Entrando a CombatPhase");
        stateMachine.CombatManager.ResolveCombat();
    }
    protected override void OnUpdate()
    {
        Debug.Log("Se resuelve el combate");
    }
    protected override void OnExit()
    {
        
    }
}
