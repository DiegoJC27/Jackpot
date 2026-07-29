using UnityEngine;

public class MainPhase : CombatState
{
    public  MainPhase(CombatStateMachine csm, CombatState nxt) : base(csm, nxt) { }
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
