using UnityEngine;
using System.Collections.Generic;

public class CombatSelector : MonoBehaviour
{
    [SerializeField] List<GameObject> enemyList;
    [SerializeField] CombatManager combatManager;
    [SerializeField] Transform enemyTrans;

    private void Start()
    {
        if (combatManager == null)
            combatManager = GetComponent<CombatManager>();
    }

    public EnemyController InstantiateRandomEnemy()
    {
        int rand = Random.Range(0, enemyList.Count);
        GameObject enemyObj = Instantiate(enemyList[rand], enemyTrans);
        EnemyController enemyCont = enemyObj.GetComponent<EnemyController>();
        return enemyCont;
    }
}
