using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] int curHP;
    [SerializeField] int maxHP;
    [SerializeField] int maxTokens;
    [SerializeField] int curTokens;

    public int GetCurTokens() { return curTokens; }
    public int GetCurHP() { return curHP; }
    public void UpdateHP(int hpPlus)
    {
        curHP += hpPlus;
    }
}
