using UnityEngine;

public class F_Escudo : Ficha
{
    public override void HacerMiAccion()
    {
        myCharacter.UpdateBlock(1);
    }
}
