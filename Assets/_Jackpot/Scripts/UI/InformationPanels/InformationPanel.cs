using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InformationPanel : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI typeText;
    public TextMeshProUGUI descriptionText;
        
    Tween fadeTween;

    RectTransform rectTransform;
    Color drawColor;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        transform.SetAsLastSibling();
        gameObject.SetActive(false);
    }

    public void ObtainObjInfo(InfoDisplayer infoObj)
    {
        nameText.text = infoObj.objName;
        typeText.text = infoObj.type.ToString();
        typeText.color = infoObj.type switch
        {
            ObjectType.Ranura => Color.darkGreen,
            ObjectType.Ficha => Color.red,
            ObjectType.Trago => Color.orange,
            ObjectType.Amuleto => Color.blue,
            _ => Color.white
        };
        descriptionText.text = infoObj.description;
    }
    
    public void TurnOn()
    {
        gameObject.SetActive(true);
        drawColor = gameObject.GetComponent<Image>().color;
        gameObject.GetComponent<Image>().color = new Color(drawColor.r, drawColor.g, drawColor.b, 0);
        fadeTween = gameObject.GetComponent<Image>().DOFade(1f, 0.5f);
    }
    public void TurnOf()
    {
        if(fadeTween != null && fadeTween.IsActive())
        {
            fadeTween.Kill();
        }
        gameObject.SetActive(false);
    }
}