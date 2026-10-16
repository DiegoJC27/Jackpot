using UnityEngine;
using UnityEngine.UI;

public abstract class Ficha : InfoDisplayer
{
    public SpriteRenderer Srenderer;
    public Sprite sprite;
    public CharacterController myCharacter;
    public Ranura myRanura;
    public bool exhausted = false;
    bool alreadyDoubled = false;
    public void SetMyCharacter(CharacterController chara) { 
        if(chara == null)
        {
            Debug.LogError("El CharacterManager que se intenta asignar es nulo");
            return;
        }
        myCharacter = chara; 
    }
    public void SetMyRanura(Ranura ran)
    {
        if(ran == null)
        {
            Debug.Log("la ranura es nula");
            return;
        }
        myRanura = ran;
    }
    
    protected override void Start()
    {
        base.Start();
        Srenderer = GetComponentInChildren<SpriteRenderer>();
        Srenderer.sprite = sprite;
    }

    public virtual void HacerMiAccion()
    {
        if (CheckForGreenBloqued() && !alreadyDoubled) {

            alreadyDoubled = true;
            HacerMiAccion();
        }
        alreadyDoubled = false;
        Debug.Log("Hago mi cosa");
    }

    protected bool CheckForGreenBloqued()
    {
        return myRanura.miColor == ColoresRanura.verde && !myRanura.miRueda.Locked;
    }
}
