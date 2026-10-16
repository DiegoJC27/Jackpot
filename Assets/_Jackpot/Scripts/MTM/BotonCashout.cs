using UnityEngine;

public class BotonCashout : MTMTButton
{
    [SerializeField] CombatStateMachine csm;

    public override void OnClick()
    {
        csm.EnterEndPhase();
    }
}
