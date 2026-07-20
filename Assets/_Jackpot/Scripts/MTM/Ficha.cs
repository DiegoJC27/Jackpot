using UnityEngine;
using UnityEngine.UI;

public abstract class Ficha : MonoBehaviour
{
    //[SerializeField] SO_Ficha ficha;
    public string nombre;
    public string descripcion;
    public Image imagen;
    public Sprite sprite;

    private void Start()
    {
        imagen = GetComponent<Image>();
        imagen.sprite = sprite;
    }

    public abstract void HacerMiAccion();
}
