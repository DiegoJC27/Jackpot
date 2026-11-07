using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InformationPanel : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI typeText;
    public TextMeshProUGUI descriptionText;
        
    Tween moveTween;
    Tween fadeTween;

    RectTransform rectTransform;
    float lx;
    Color drawColor;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        transform.SetAsLastSibling();
        gameObject.SetActive(false);
        //lx = gameObject.GetComponent<RectTransform>().position.x;
        lx = rectTransform.position.x;
        //gameObject.GetComponent<Image>().color = new Color(drawColor.r, drawColor.g, drawColor.b, 0);
    }

    public void ObtainObjInfo(InfoDisplayer infoObj)
    {
        nameText.text = infoObj.objName;
        //nameText.color = infoObj.titleColor;
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
        //float lx = rectTransform.position.x;
        //rectTransform.position = new Vector3(lx + 200f, 0, 0);
        //moveTween = rectTransform.DOMoveX(lx, 1f).SetEase(Ease.OutQuad);
        
        gameObject.SetActive(true);
        //gameObject.GetComponent<RectTransform>().position = new Vector3(lx + 500, 0, 0);
        //moveTween = gameObject.GetComponent<RectTransform>().DOMoveX(lx + 50, 1f).SetEase(Ease.OutQuad);
        drawColor = gameObject.GetComponent<Image>().color;
        gameObject.GetComponent<Image>().color = new Color(drawColor.r, drawColor.g, drawColor.b, 0);
        fadeTween = gameObject.GetComponent<Image>().DOFade(1f, 0.5f);
    }
    public void TurnOf()
    {
        if(moveTween != null && moveTween.IsActive())
        {
            moveTween.Kill();
        }
        if(fadeTween != null && fadeTween.IsActive())
        {
            //gameObject.GetComponent<Image>().color = drawColor;
            fadeTween.Kill();
        }

        gameObject.SetActive(false);
    }
}