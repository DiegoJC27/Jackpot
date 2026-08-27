using UnityEngine;

public class CombatManager : MonoBehaviour
{
    [SerializeField] PlayerController player;
    [SerializeField] EnemyController enemy;
    [SerializeField] CombatStateMachine csm;

    [SerializeField] GameObject combatEndScreen;
    private void Start()
    {
        combatEndScreen.SetActive(false);
        StartCombat();
    }
    public void StartCombat()
    {
        csm.EnterEnemyPhase();
    }
    public void EndCombat()
    {
        Debug.Log("Fin del combate");
        csm.FinishCombat();
        combatEndScreen.SetActive(true);
    }
    public void ResolvePlayerDamage()
    {
        enemy.RecibeDamage(player.CurDamage);
        if (enemy.CurHP <= 0)
        {
            EndCombat();
        }
    }
    public void ResolveEnemyDamage()
    {
        player.RecibeDamage(enemy.CurDamage);
        if (player.CurHP <= 0)
        {
            EndCombat();
        }
    }
}
