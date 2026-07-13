using UnityEngine;

public class Ranura : MonoBehaviour
{
    public ColoresRanura miColor { private set; get; }
    public Ficha fichaContenida { private set; get; }

    public void CambiarFichaConetnida(Ficha fichaNueva)
    {
        Debug.Log($"Cambio a {fichaNueva.nombre}");
    }
}

public enum ColoresRanura
{
    verde,
    rojo,
    azul
}
