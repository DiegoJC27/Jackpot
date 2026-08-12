using UnityEngine;

public class MainPhase : CombatState
{
    public  MainPhase(CombatStateMachine csm) : base(csm) { }
    protected override void OnEnter()
    {
        Debug.Log("Entrando a MainPhase");

    }
    protected override void OnUpdate()
    {
        
    }
    protected override void OnExit()
    {
        
    }
}
