using UnityEngine;
using TMPro;

public class PlayerTokensUI : MonoBehaviour
{    
    [SerializeField] TextMeshProUGUI curTokensText;
    [SerializeField] TextMeshProUGUI maxTokensText;
  
    public void UpdateMaxTokens(int max)
    {
        maxTokensText.text = max.ToString();
    }                                                     
    public void UpdateCurTokens(int cur)
    {                                                     
        curTokensText.text = cur.ToString();
    }    
}
