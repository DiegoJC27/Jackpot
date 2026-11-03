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
        myCharacter.UpdateBlock(1);
    }
}