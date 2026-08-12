using UnityEngine;

public class BotonCashout : MonoBehaviour
{
    [SerializeField] CombatStateMachine csm;

    public void Cashout()
    {
        csm.EnterEndPhase();
    }
}
