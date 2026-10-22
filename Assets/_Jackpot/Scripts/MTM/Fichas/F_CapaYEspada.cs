using UnityEngine;

public class F_CapaYEspada : Ficha
{
    public override void HacerMiAccion()
    {
        myCharacter.UpdateBlock(1);
        myCharacter.UpdateDamage(1);
    }
}
