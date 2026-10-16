using UnityEngine;

public class Bloqueador : MTMTButton
{
    public Rueda miRueda;
    public MaquinaTragamonedas mtm;
    
    public override void OnClick()
    {
        if (mtm.spinning == true)
        {
            Debug.LogWarning("Esta girando");
            return;  
        }
        miRueda.ToggleBlocked();
    }    
}
