using System;
using UnityEngine;

public class PlayerController : CharacterController
{    
    [SerializeField] int maxTokens;
    [SerializeField] int curTokens;
    [SerializeField] PlayerTokensUI pTokensUI;

    [SerializeField] protected MaquinaTragamonedas maquinaTragamonedas;


    protected override void Start()
    {       
        if(PlayerManager.instance.MTM == null)
            PlayerManager.instance.SetMTM(maquinaTragamonedas);

        if (charManager == null)
            charManager = PlayerManager.instance;   
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
