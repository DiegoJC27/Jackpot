using UnityEngine;
using UnityEngine.Rendering;

public class Palanca : MonoBehaviour
{
    public MaquinaTragamonedas mtm;
    public void PullLever()
    {
        if (mtm.spinning)
        {
            Debug.Log("Esta girando");
            return;
        }
        mtm.Spin();
    }
}
