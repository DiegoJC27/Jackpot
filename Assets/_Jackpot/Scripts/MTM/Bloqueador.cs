using UnityEngine;

public class Bloqueador : MonoBehaviour
{
    public Rueda miRueda;
    public MaquinaTragamonedas mtm;
    
    public void BlockWheel()
    {
        if (mtm.spinning == true)
        {
            Debug.LogWarning("Esta girando");
            return;  
        }
        miRueda.ToggleBlocked();
    }    
}
