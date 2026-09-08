using UnityEngine;

public class CombatManager : MonoBehaviour
{
    [SerializeField] PlayerController player;
    [SerializeField] EnemyController enemy;
    [SerializeField] CombatStateMachine csm;

    [SerializeField] GameObject combatLosecreen;
    [SerializeField] GameObject combatRewardsScreen;
    [SerializeField] CombatSelector combatSelector;
    private void Start()
    {
        if (combatSelector == null) combatSelector = GetComponent<CombatSelector>();

        combatLosecreen.SetActive(false);
        combatRewardsScreen.SetActive(false);
        StartCombat();
    }
    public void StartCombat()
    {
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
