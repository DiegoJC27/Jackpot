using UnityEngine;

public abstract class CharacterManager : MonoBehaviour
{
    public int CurHP => curHP;
    [SerializeField] protected int curHP;
    [SerializeField] protected int maxHP;
    public int CurDamage => curDamage;
    [SerializeField] protected int curBlock;
    public int CurBlock => curBlock;
    [SerializeField] protected int curDamage;

    [SerializeField] public MaquinaTragamonedas mtm;
    [SerializeField] protected CombatManager combatManager;
    [SerializeField] protected CharacterCombatUI combatUI;
    protected virtual void Start()
    {
        combatUI.UpdateHP(curHP, maxHP);
    }
    public int GetCurHP() { return curHP; }
    public void UpdateHP(int hpPlus)
    {
        curHP += hpPlus;
        Mathf.Clamp(curHP, 0, maxHP);
        combatUI.UpdateHP(curHP, maxHP);
    }
    public void RecibeDamage(int dmg)
    {
        curBlock -= dmg;
        if (curBlock < 0)
        {
            curHP += curBlock;
            curBlock = 0;
        }
        combatUI.UpdateBlockText(curBlock);
        combatUI.UpdateHP(curHP, maxHP);
    }
    public int GetMaxHP() { return maxHP; }
    public virtual void UpdateDamage(int dmgPlus)
    {
        curDamage += dmgPlus;
        combatUI.UpdateDamageText(curDamage);
    }
    public virtual void UpdateBlock(int blkPlus)
    {
        curBlock += blkPlus;
        combatUI.UpdateBlockText(curBlock);
    }
    public virtual void StartNewTurn()
    {
        curBlock = 0;
        combatUI.UpdateBlockText(curBlock);
        curDamage = 0;
        combatUI.UpdateDamageText(curDamage);
        mtm.RestartWheels();
    }
    public virtual void ResolveMTM()
    {
        mtm.ResolveFichasActions();
        mtm.CheckSlotsColor();
    }
}