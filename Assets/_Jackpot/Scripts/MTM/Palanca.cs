using UnityEngine;
using UnityEngine.Rendering;

public class Palanca : MonoBehaviour
{
    public MaquinaTragamonedas mtm;
    public void PullLever()
    {
        if(PlayerManager.instance.GetCurTokens() <= 0)
        {
            Debug.Log("Ya no hay tokens");
            return;
        }          
        if (mtm.spinning)
        {
            Debug.Log("Sigue girando");
            return;
        }
        PlayerManager.instance.UpdateTokens(-1);
        mtm.Spin();
    }
}
