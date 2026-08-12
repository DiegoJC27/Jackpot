using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCombatUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI curHPText;
    [SerializeField] Slider healthBar;
    [SerializeField] TextMeshProUGUI maxHPText;
    [SerializeField] TextMeshProUGUI curBlockText;
    [SerializeField] TextMeshProUGUI curDamageText;
    public void UpdateHP(int cur, int max)
    {
        maxHPText.text = max.ToString();
        curHPText.text = cur.ToString();
        healthBar.value = ((float)cur / max);
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
