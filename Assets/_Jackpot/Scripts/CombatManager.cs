using UnityEngine;

public class CombatManager : MonoBehaviour
{
    [SerializeField] PlayerCombatUIManager playerCUIMan;
    [SerializeField] CombatStateMachine csm;
    CombatPhase combatPhase;
    EnemyPhase enemyPhase;
    BegginingPhase begginingPhase;
    MainPhase mainPhase;
    EndPhase endPhase;
    private void Start()
    {
        combatPhase = new CombatPhase(csm, enemyPhase);
        enemyPhase = new EnemyPhase(csm, begginingPhase);
        begginingPhase = new BegginingPhase(csm, mainPhase);
        mainPhase = new MainPhase(csm, endPhase);
        endPhase = new EndPhase(csm, combatPhase);
        BegginCombat(); 
    }
    public void BegginCombat()
    {
        csm.ChangeState(enemyPhase);
    }
    public void EndCombat()
    {
        Debug.Log("Fin del combate");
    }
}
