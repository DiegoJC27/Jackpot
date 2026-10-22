using UnityEngine;

public class RanuraAzul : Ranura
{
    protected override void Start()
    {
        colorRanura = ColoresRanura.azul;
    }
    protected override void GainBonus()
    {
        Debug.Log("Ganaste un bonus azul");
    }
}