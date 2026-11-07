using UnityEngine;
using System.Collections.Generic;
using System;

public class MaquinaTragamonedas : MonoBehaviour
{
    public List<Rueda> ruedas = new();
    public float spinTime = 2f;
    public float plusSpinTime = 0.5f;
    public bool spinning = false;
    int wheelsSpinning = 0;

    public event Action OnWheelsStopSpinning; 
    public CharacterController MyCharacter => myCharacter;
    [SerializeField] private CharacterController myCharacter;
    public void Spin()
    {
        spinning = true;
        float plusTime = 0;
        foreach (Rueda rueda in ruedas) {
            if (rueda.bloqueado)
            {
                rueda.Lock();
                continue;
            }
            
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
            OnWheelsStopSpinning?.Invoke();
        }
    }
    public void RestartWheels()
    {
        foreach(Rueda rueda in ruedas)
        {
            rueda.Unlock();
            rueda.SetBlocked(false);
        }
        Spin();
    }
    public void ResolveFichasActions()
    {
        foreach (Rueda rueda in ruedas)
        {
            if (rueda.ranuraSelected.MiFicha != null)
            {
                rueda.ranuraSelected.MiFicha.HacerMiAccion();
            }
        }
    }

    public void CheckRanuraBonuses()
    {
        foreach (Rueda rueda in ruedas)
        {
            rueda.ranuraSelected.CheckBonusCondition();
        }
    }
    public bool AllSlotsSameColor()
    {
        foreach (Rueda rueda in ruedas)
        {
            if (rueda.ranuraSelected.ColorRanura != ruedas[0].ranuraSelected.ColorRanura)
            {
                return false;
            }
        }
        return true;
    }
}
