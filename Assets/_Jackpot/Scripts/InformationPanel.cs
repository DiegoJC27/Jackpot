using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InformationPanel : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI typeText;
    public TextMeshProUGUI descriptionText;

    private void Start()
    {
        gameObject.SetActive(false);
        transform.SetAsLastSibling();
    }    

    public void ObtainObjInfo(ObjectInfo miInfoObj)
    {
        nameText.text = miInfoObj.objName;
        typeText.text = miInfoObj.type.ToString();
        descriptionText.text = miInfoObj.description;
    }

    public void ShowPanel(Vector2 npos)
    {
        gameObject.SetActive(true);
        Vector2 screenPos = Camera.main.WorldToScreenPoint(npos);
        transform.position = screenPos;
    }
}


