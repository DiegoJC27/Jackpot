using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class MaquinaTragamonedas : MonoBehaviour
{
    public List<Rueda> ruedas = new();
    public float spinTime = 2f;
    public float plusSpinTime = 0.5f;
    public bool spinning = false;
    int wheelsSpinning = 0;

    private void Start()
    {
        RestartWheels();
    }
    public void Spin()
    {
        Debug.Log("Empieza as girar");
        spinning = true;
        float plusTime = 0;
        foreach (Rueda rueda in ruedas) { 
            if(rueda.bloqueado) continue;
            
            StartCoroutine(rueda.SpinFor(spinTime +  plusTime));
            plusTime += plusSpinTime;
            wheelsSpinning++;
        }
    }

    public void OnStopSpinning()
    {
        wheelsSpinning--;
        if (wheelsSpinning == 0)
        {
            spinning = false;
            Debug.Log("Dejo de girar");
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
