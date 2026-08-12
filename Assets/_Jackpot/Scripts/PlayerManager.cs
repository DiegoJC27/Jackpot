using System;
using UnityEngine;

public class PlayerManager : CharacterManager
{    
    [SerializeField] int maxTokens;
    [SerializeField] int curTokens;
    [SerializeField] PlayerTokensUI pTokensUI;

    protected override void Start()
    {
        base.Start();
        pTokensUI.UpdateCurTokens(curTokens);
        pTokensUI.UpdateMaxTokens(maxTokens);

    }
    public int GetCurTokens() { return curTokens; }
    public int GetMaxTokens() { return maxTokens; }   
    public void UpdateTokens(int tokensPlus)
    {
        curTokens += tokensPlus;
        pTokensUI.UpdateCurTokens(curTokens);
    }
    public override void StartNewTurn()
    {
        curTokens = maxTokens;
        pTokensUI.UpdateCurTokens(curTokens);
        base.StartNewTurn();
    }
}
