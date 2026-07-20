using UnityEngine;
using UnityEngine.UI;

public class Ranura : MonoBehaviour
{
    [SerializeField] private Ficha fichaContenida;
    public ColoresRanura miColor;
    public Image borde;

    private void Start()
    {
        SetRanuraColor();
    }
    public void CambiarFichaConetnida(Ficha nuevaFicha)
    {
        fichaContenida = nuevaFicha;
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
        }
    }
}

public enum ColoresRanura
{
    verde,
    rojo,
    azul
}
