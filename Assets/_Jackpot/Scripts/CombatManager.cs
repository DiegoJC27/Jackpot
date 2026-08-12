using UnityEngine;

public class CombatManager : MonoBehaviour
{
    [SerializeField] PlayerManager player;
    [SerializeField] EnemyManager enemy;
    [SerializeField] CombatStateMachine csm;
    private void Start()
    {
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
