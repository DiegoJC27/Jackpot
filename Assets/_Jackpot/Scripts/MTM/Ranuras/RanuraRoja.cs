using UnityEngine;
public class RanuraRoja : Ranura
{
    protected override void Start()
    {
        colorRanura = ColoresRanura.rojo;
    }
    protected override void GainBonus()
    {
        Debug.Log("Ganaste un bonus rojo");
    }
}
