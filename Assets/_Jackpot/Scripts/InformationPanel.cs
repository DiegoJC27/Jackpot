using TMPro;
using Unity.VisualScripting;
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

    public void ObtainObjInfo(InfoDisplayer infoObj)
    {
        nameText.text = infoObj.objName;
        typeText.text = infoObj.type.ToString();
        descriptionText.text = infoObj.description;
    }   
}


