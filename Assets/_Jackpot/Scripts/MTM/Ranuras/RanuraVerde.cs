using UnityEngine;

public class RanuraVerde : Ranura
{
    protected override void Start()
    {
        base.Start();
        colorRanura = ColoresRanura.verde;
    }
    public override void CheckBonusCondition()
    {
        if (!miRueda.Locked)
        {
            GainBonus();
        }
    }
    protected override void GainBonus()
    {
        base.GainBonus();
        MiFicha.HacerMiAccion();
    }
}

