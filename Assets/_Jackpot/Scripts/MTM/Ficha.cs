using UnityEngine;
using UnityEngine.UI;

public abstract class Ficha : MonoBehaviour
{
    //[SerializeField] SO_Ficha ficha;
    public string nombre;
    public string descripcion;
    public Image imagen;
    public Sprite sprite;
    public CharacterManager myCharacter;
    public void SetMyCharacter(CharacterManager chara) { 
        if(chara == null)
        {
            Debug.LogError("El CharacterManager que se intenta asignar es nulo");
            return;
        }
        myCharacter = chara; 
    }
    
    private void Start()
    {
        imagen = GetComponent<Image>();
        imagen.sprite = sprite;
    }

    public abstract void HacerMiAccion();
}
