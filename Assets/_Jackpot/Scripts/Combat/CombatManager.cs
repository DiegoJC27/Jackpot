using UnityEngine;

public class CombatManager : MonoBehaviour
{
    [SerializeField] PlayerController player;
    EnemyController enemy;
    
    [SerializeField] CombatStateMachine csm;
    [SerializeField] CombatSelector combatSelector;

    [SerializeField] GameObject combatLosecreen;
    [SerializeField] GameObject combatRewardsScreen;
    private void Start()
    {
        if (combatSelector == null) combatSelector = GetComponent<CombatSelector>();

        combatLosecreen.SetActive(false);
        
        StartCombat();
    }
    public void StartCombat()
    {
        combatRewardsScreen.SetActive(false);
        
        if (enemy != null) 
            enemy.DestroyMySelf();
        
        enemy = combatSelector.InstantiateRandomEnemy();
        csm.SetEnemy(enemy);
        csm.EnterEnemyPhase();
    }
    public void ResolvePlayerDamage()
    {
        enemy.RecibeDamage(player.CurDamage);
        if (enemy.CurHP <= 0)
        {
            csm.FinishCombat();
            combatRewardsScreen.SetActive(true);
        }
    }
    public void ResolveEnemyDamage()
    {
        player.RecibeDamage(enemy.CurDamage);
        if (player.CurHP <= 0)
        {
            csm.FinishCombat();
            combatLosecreen.SetActive(true);
        }
    }

    public void ResetCombatStats()
    {
        player.ResetCombatStats();
        enemy.ResetCombatStats();
    }
}
