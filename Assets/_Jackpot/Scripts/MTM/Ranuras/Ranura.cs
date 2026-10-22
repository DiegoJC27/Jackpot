using UnityEngine;
using UnityEngine.UI;
public enum ColoresRanura
{
    verde,
    rojo,
    azul
}
public abstract class Ranura : InfoDisplayer
{
    public Ficha MiFicha => fichaContenida;
    [SerializeField] private Ficha fichaContenida;
    [SerializeField ]protected ColoresRanura colorRanura;
    public ColoresRanura ColorRanura => colorRanura;
    public Rueda miRueda;
    public void SetMiRueda(Rueda rueda) 
    {  
        if(rueda == null)
        {
            Debug.LogError("La rueda que se intenta asignar es nula");
            return;
        }
        miRueda = rueda; 
        fichaContenida.SetMyCharacter(miRueda.MTM.MyCharacter);
        fichaContenida.SetMyRanura(this);
    }
    protected abstract void Start();
    public virtual void CheckBonusCondition()
    {
        if (miRueda.MTM.AllSlotsSameColor()) { 
            GainBonus();
        }
    }
    protected abstract void GainBonus();
}
