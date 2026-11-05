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

    protected CharacterController myCharacter;
    public void InitializeRanura(Rueda rueda) 
    {  
        if(rueda == null)
        {
            Debug.LogError("La rueda que se intenta asignar es nula");
            return;
        }
        miRueda = rueda;
        if (fichaContenida == null)
        {
            fichaContenida = GetComponentInChildren<Ficha>();
            if (fichaContenida == null)
                Debug.LogError("La ficha contenida en la ranura es nula");
        }
        fichaContenida.SetMyCharacter(miRueda.MTM.MyCharacter);
        myCharacter = miRueda.MTM.MyCharacter;
        fichaContenida.SetMyRanura(this);
    }
    protected virtual void Start()
    {
        if(fichaContenida == null)
        {
            fichaContenida = GetComponentInChildren<Ficha>();
            if(fichaContenida == null)
                Debug.LogError("La ficha contenida en la ranura es nula");
        }
    }
    public virtual void CheckBonusCondition()
    {
        if (miRueda.MTM.AllSlotsSameColor()) { 
            GainBonus();
        }
    }
    protected abstract void GainBonus();

    public override void OnTurnDown()
    {
        base.OnTurnDown();
        if (fichaContenida != null)
        {
            fichaContenida.OnTurnDown();
        }
    }
    
}
