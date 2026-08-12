using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;
using System;

public class MaquinaTragamonedas : MonoBehaviour
{
    public List<Rueda> ruedas = new();
    public float spinTime = 2f;
    public float plusSpinTime = 0.5f;
    public bool spinning = false;
    int wheelsSpinning = 0;

    public event Action OnWheelsStopSpinning; 
    public CharacterManager MyCharacter => myCharacter;
    [SerializeField] private CharacterManager myCharacter;
    public void Spin()
    {
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
            OnWheelsStopSpinning?.Invoke();
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
    public void CheckSlotsColor()
    {
        ColoresRanura color = ColoresRanura.notAsigned;
        foreach (Rueda rueda in ruedas)
        {
            if (color == ColoresRanura.notAsigned)
            {
                color = rueda.ranuraSelected.miColor;
                continue;
            }
            if (color != rueda.ranuraSelected.miColor)
                return;
        }

        switch (color)
        {
            case ColoresRanura.azul:
                myCharacter.UpdateBlock(5);
                break;
            case ColoresRanura.rojo:
                myCharacter.UpdateDamage(5);
                break;
            case ColoresRanura.verde:
                myCharacter.UpdateBlock(myCharacter.CurBlock);
                myCharacter.UpdateDamage(myCharacter.CurDamage);
                break;
            case ColoresRanura.notAsigned:
                Debug.Log("Algo se echó a perder, color no asignado");
                break;
        }
    }
}
