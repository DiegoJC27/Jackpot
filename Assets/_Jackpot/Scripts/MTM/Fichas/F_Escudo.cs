using UnityEngine;

public class F_Escudo : Ficha
{
    public override void HacerMiAccion()
    {
        base.HacerMiAccion();
        myCharacter.UpdateBlock(1);
    }
}
