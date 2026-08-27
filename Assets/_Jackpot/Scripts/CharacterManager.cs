using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public int MaxHP => maxHP;
    [SerializeField] protected int maxHP;
    public int CurHP => curHP;
    [SerializeField] protected int curHP;    
    public MaquinaTragamonedas MTM => mtm;
    [SerializeField] protected MaquinaTragamonedas mtm;

    private void Awake()
    {
        if (maxHP == default)
            maxHP = 10;
        if (curHP == default)
            curHP = maxHP;
        if(mtm == null)
            mtm = GetComponent<MaquinaTragamonedas>();
        if(mtm == null)
            Debug.LogError("No se ha asignado la referencia a MaquinaTragamonedas en el CharacterManager.");
    }
    public void SetCurHP(int hp)
    {
        curHP = hp;
    }
    public void SetMaxHP(int hp)
    {
        maxHP = hp;
    }
}
