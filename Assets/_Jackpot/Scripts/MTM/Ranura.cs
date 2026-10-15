using UnityEngine;
using UnityEngine.UI;

public class Ranura : MonoBehaviour
{
    public Ficha MiFicha => fichaContenida;
    [SerializeField] private Ficha fichaContenida;
    public ColoresRanura miColor;
    public SpriteRenderer borde;
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
    private void Start()
    {
        SetRanuraColor();
    }
    public void CambiarFichaConetnida(Ficha nuevaFicha)
    {
        if (nuevaFicha == null)
        {
            Debug.LogError("La ficha que se intenta asignar es nula");
            return;
        }
        fichaContenida = nuevaFicha;
        fichaContenida.SetMyCharacter(miRueda.MTM.MyCharacter);
    }

    private void SetRanuraColor()
    {
        switch (miColor)
        {
            case ColoresRanura.verde:
                borde.color = Color.green;
                break;
            case ColoresRanura.rojo:
                borde.color = Color.red;
                break;
            case ColoresRanura.azul:
                borde.color = Color.blue;
                break;
            case ColoresRanura.notAsigned:
                borde.color = Color.white;
                break;
        }
    }
}

public enum ColoresRanura
{
    verde,
    rojo,
    azul,
    notAsigned
}
