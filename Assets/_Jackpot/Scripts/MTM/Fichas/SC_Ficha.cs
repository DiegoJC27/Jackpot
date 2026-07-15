using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "SC_Ficha", menuName = "Scriptable Objects/SC_Ficha")]
public class SC_Ficha : ScriptableObject
{
    public readonly string nombre;
    public readonly string descripcion;
    public readonly Image imagen;

    protected void HacerMiAccion() { }
}
