using UnityEngine;
using UnityEngine.Rendering;

public class Palanca : MonoBehaviour
{
    public MaquinaTragamonedas mtm;
    [SerializeField] PlayerController player;
    [SerializeField] CombatStateMachine csm;
    public void PullLever()
    {
        if(player.GetCurTokens() <= 0)
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
