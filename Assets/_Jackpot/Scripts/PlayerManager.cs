using System;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] int curHP;
    [SerializeField] int maxHP;
    [SerializeField] int maxTokens;
    [SerializeField] int curTokens;
    [SerializeField] PlayerCombatUIManager pCombatUIMan;

    public static PlayerManager instance {  get; private set; }
    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this);
    }
    public int GetCurTokens() { return curTokens; }
    public int GetMaxTokens() { return maxTokens; }
    public int GetCurHP() { return curHP; }
    public int GetMaxHP() { return maxHP; }
    public void UpdateHP(int hpPlus)
    {
        curHP += hpPlus;
        pCombatUIMan.UpdateCurHP();
    }
    public void UpdateTokens(int tokensPlus)
    {
        curTokens += tokensPlus;
        pCombatUIMan.UpdateCurTokens();
    }
}
