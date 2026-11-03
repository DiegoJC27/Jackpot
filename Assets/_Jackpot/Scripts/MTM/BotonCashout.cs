using UnityEngine;

public class BotonCashout : MonoBehaviour, IMTMTButton
{
    [SerializeField] CombatStateMachine csm;

    public void OnClick()
    {
        csm.EnterEndPhase();
    }
}
