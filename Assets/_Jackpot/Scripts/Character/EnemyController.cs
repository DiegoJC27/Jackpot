using UnityEngine;

public class EnemyController : CharacterController
{
    public void DestroyMySelf()
    {
        Destroy(gameObject);
    }

    public void SetCombatUI(CharacterCombatUI enemyCombatUI)
    {
               if (combatUI == null)
        {
            combatUI = enemyCombatUI;
        }
    }
}
