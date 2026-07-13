using UnityEngine;

public class Bloqueador : MonoBehaviour
{
    public Rueda miRueda;
    public MaquinaTragamonedas mtm;
    public void BlockWheel(bool block)
    {
        if (mtm.spinnning == true)
        {
            Debug.Log("Esta girando");
            return;  
        }
        miRueda.SetBlocked(block);
    }
}
