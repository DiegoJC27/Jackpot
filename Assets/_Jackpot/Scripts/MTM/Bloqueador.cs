using UnityEngine;

public class Bloqueador : MonoBehaviour, IMTMTButton
{
    public Rueda miRueda;
    public MaquinaTragamonedas mtm;

    public void OnClick()
    {
        if (mtm.spinning == true)
        {
            Debug.LogWarning("Esta girando");
            return;  
        }
        miRueda.ToggleBlocked();
    }    
}
