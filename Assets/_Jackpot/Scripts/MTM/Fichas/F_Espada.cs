using UnityEngine;

public class F_Espada : Ficha
{
    public override void HacerMiAccion()
    {
        base.HacerMiAccion();
        myCharacter.UpdateDamage(1);
    }
}