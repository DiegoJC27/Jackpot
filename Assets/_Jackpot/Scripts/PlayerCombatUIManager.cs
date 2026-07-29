using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerCombatUIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI curHPText;
    [SerializeField] Slider healthBar;
    [SerializeField] TextMeshProUGUI maxHPText;
    [SerializeField] TextMeshProUGUI curBlockText;
    [SerializeField] TextMeshProUGUI curDamageText;
    [SerializeField] TextMeshProUGUI curTokensText;
    [SerializeField] TextMeshProUGUI maxTokensText;

    private void Start()
    {
        InitializeCombatStats();
    }

    public void InitializeCombatStats()
    {
        UpdateMaxHP();
        UpdateMaxTokens();
    }
    public void UpdateMaxHP()
    {
        maxHPText.text = PlayerManager.instance.GetMaxHP().ToString();
        curHPText.text = PlayerManager.instance.GetCurHP().ToString();
        healthBar.value = (PlayerManager.instance.GetCurHP() / PlayerManager.instance.GetMaxHP());
    }
    public void UpdateCurHP()
    {
        curHPText.text = PlayerManager.instance.GetCurHP().ToString();
        healthBar.value = (PlayerManager.instance.GetCurHP() / PlayerManager.instance.GetMaxHP());
    }
    public void UpdateMaxTokens()
    {
        maxTokensText.text = PlayerManager.instance.GetMaxTokens().ToString();
        curTokensText.text = PlayerManager.instance.GetCurTokens().ToString();
    }                                                     
    public void UpdateCurTokens()
    {                                                     
        curTokensText.text = PlayerManager.instance.GetCurTokens().ToString();
    }
    public void UpdateBlockText(int newBlock)
    {
        curBlockText.text = newBlock.ToString();
    }
    public void UpdateDamageText(int newDamage)
    {
        curDamageText.text = newDamage.ToString();
    }
}
