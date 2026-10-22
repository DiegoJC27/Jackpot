using UnityEngine;

public class RanuraVerde : Ranura
{
    protected override void Start()
    {
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
        Debug.Log("Ganaste un bonus verde");
    }
}

