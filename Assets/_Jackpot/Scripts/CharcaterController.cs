using UnityEngine;

public abstract class CharacterController : MonoBehaviour
{
    [SerializeField] protected CharacterManager charManager;
    public int CurHP => charManager.CurHP;
    protected int maxHP => charManager.MaxHP;
    public MaquinaTragamonedas mtm => charManager.MTM;
  
    [Header("Combat Stats")]
    public int CurDamage => curDamage;
    [SerializeField] protected int curBlock;
    public int CurBlock => curBlock;
    [SerializeField] protected int curDamage;
    [Space]
    [SerializeField] protected CombatManager combatManager;
    [SerializeField] protected CharacterCombatUI combatUI;
    protected virtual void Start()
    {
        combatUI.UpdateHP(CurHP, maxHP);
    }
    public int GetCurHP() { return CurHP; }
    public void UpdateHP(int hpPlus)
    {
        charManager.SetCurHP(CurHP + hpPlus);
        Mathf.Clamp(CurHP, 0, maxHP);
        combatUI.UpdateHP(CurHP, maxHP);
    }
    public void RecibeDamage(int dmg)
    {
        curBlock -= dmg;
        if (curBlock < 0)
        {
            charManager.SetCurHP(CurHP + curBlock);
            curBlock = 0;
        }
        combatUI.UpdateBlockText(curBlock);
        combatUI.UpdateHP(CurHP, maxHP);
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