using UnityEngine;

public class EnemyController : CharacterController
{
    public void DestroyMySelf()
    {
        Destroy(gameObject);
    }
}
