using UnityEngine;
using UnityEngine.Rendering;

public class Palanca : MTMTButton
{
    public MaquinaTragamonedas mtm;
    [SerializeField] PlayerController player;
    [SerializeField] CombatStateMachine csm;
    public override void OnClick()
    {
        if (player.GetCurTokens() <= 0)
        {
            Debug.Log("Ya no hay tokens");
            return;
        }
        if (mtm.spinning)
        {
            Debug.Log("Sigue girando");
            return;
        }
        if (!csm.IsMainPhase())
        {
            Debug.Log("No es fase principal");
            return;
        }
        player.UpdateTokens(-1);
        mtm.Spin();
    }
}
