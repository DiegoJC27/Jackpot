using UnityEngine;

public class CombatManager : MonoBehaviour
{
    [SerializeField] PlayerManager player;
    [SerializeField] EnemyManager enemy;
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
    public void ResolveCombat()
    {
        ResolvePlayerDamage();
        if(player.CurHP > 0 && enemy.CurHP > 0)
        {
            ResolveEnemyDamage();
            if(player.CurHP<= 0)
            {
                EndCombat();
            }
        }
        else
        {
            EndCombat();
        }
        csm.EnterEnemyPhase();
    }
    public void EndCombat()
    {
        Debug.Log("Fin del combate");
        combatEndScreen.SetActive(true);
    }

    public void ResolvePlayerDamage()
    {
        enemy.RecibeDamage(player.CurDamage);
    }
    public void ResolveEnemyDamage()
    {
        player.RecibeDamage(enemy.CurDamage);
    }
}
