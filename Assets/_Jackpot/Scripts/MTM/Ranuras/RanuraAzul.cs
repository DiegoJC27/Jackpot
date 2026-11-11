using UnityEngine;

public class RanuraAzul : Ranura
{
    protected override void Start()
    {
        base.Start();
        colorRanura = ColoresRanura.azul;
    }
    protected override void GainBonus()
    { 
        base.GainBonus();
        myCharacter.UpdateBlock(1);
        if(myCharacter.CurDamage < 2) myCharacter.UpdateDamage(1);
    }
}