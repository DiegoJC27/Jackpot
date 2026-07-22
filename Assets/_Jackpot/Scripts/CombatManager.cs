using UnityEngine;

public class CombatManager : MonoBehaviour
{
    [SerializeField] PlayerCombatUIManager playerCUIMan;

    private void Start()
    {
        BegginCombat();
    }
    public void BegginCombat()
    {
        playerCUIMan.InitializeCombatStats();
    }
}
