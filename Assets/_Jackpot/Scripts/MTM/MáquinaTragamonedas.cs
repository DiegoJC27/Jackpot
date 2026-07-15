using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class MaquinaTragamonedas : MonoBehaviour
{
    public List<Rueda> ruedas = new();
    public float spinTime = 2f;
    public float plusSpinTime = 0.5f;
    public bool spinnning = false;
    public void Spin()
    {
        Debug.Log("Empieza as girar");
        spinnning = true;
        float plusTime = 0;
        foreach (Rueda rueda in ruedas) { 
            if(rueda.bloqueado) continue;
            
            rueda.SpinFor(spinTime +  plusTime);
            plusTime += plusSpinTime;
        }
    }

    public void RestartWheels()
    {
        foreach(Rueda rueda in ruedas)
        {
            rueda.SetBlocked(false);
        }
        Spin();
    }
}
