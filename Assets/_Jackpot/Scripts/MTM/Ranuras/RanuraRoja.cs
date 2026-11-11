using UnityEngine;
public class RanuraRoja : Ranura
{
    protected override void Start()
    {
        base.Start();
        colorRanura = ColoresRanura.rojo;
    }
    protected override void GainBonus()
    {
        base.GainBonus();
        myCharacter.UpdateDamage(1);
    }
}
