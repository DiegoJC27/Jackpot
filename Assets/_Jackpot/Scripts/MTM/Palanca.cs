using UnityEngine;
using UnityEngine.Rendering;

public class Palanca : MonoBehaviour, IMTMTButton
{
    public MaquinaTragamonedas mtm;
    [SerializeField] PlayerController player;
    [SerializeField] CombatStateMachine csm;

    [Header("Sonidos")]
    [SerializeField] AudioClip insertChip;
    public void OnClick()
    {
        if (player.GetCurTokens() <= 0)
        {
            return;
        }
        if (mtm.spinning)
        {
            return;
        }
        if (!csm.IsMainPhase())
        {
            return;
        }
        player.UpdateTokens(-1);
        AudioManager.Instance.PlaySound(insertChip);
        mtm.Spin();
    }
}
