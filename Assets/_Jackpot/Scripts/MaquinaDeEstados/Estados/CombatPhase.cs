using System;
using UnityEngine;

public class CombatPhase : CombatState
{
    private Phases curPhase;
    enum Phases
    {
        enter,
        playerDealDamage,
        enemyDealDamage,
        exit
    }
    public  CombatPhase(CombatStateMachine csm): base(csm) {}
    protected override void OnEnter()
    {
        Debug.Log("Entrando a CombatPhase");
        elapsedTime = 0f;
        curPhase = Phases.enter;
    }
    protected override void OnUpdate()
    {
        elapsedTime += Time.deltaTime;

        switch (curPhase) { 
            case Phases.enter:
                TimerOver(Phases.playerDealDamage);
                break;
            case Phases.playerDealDamage:
                if (TimerOver(Phases.enemyDealDamage))
                    stateMachine.CombatManager.ResolvePlayerDamage();
                break;
            case Phases.enemyDealDamage:
                if (TimerOver(Phases.exit))
                    stateMachine.CombatManager.ResolveEnemyDamage();
                break;
            case Phases.exit:
                if (TimerOver())
                    stateMachine.EnterEnemyPhase();
                break;

            default:
                Debug.LogError("Valio. LLego en default al Update en CombatPhase");
                break;
        }

    }
    protected override void OnExit()
    {
        
    }
    bool TimerOver(Phases nextPhase)
    {
        if (TimerOver())
        {
            curPhase = nextPhase;
            return true;
        }
        return false;
    }

}
