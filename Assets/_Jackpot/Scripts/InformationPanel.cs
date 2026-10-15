using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InformationPanel : MonoBehaviour
{
    public InfoDisplayer miInfoObj;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI typeText;
    public TextMeshProUGUI descriptionText;

    private void Start()
    {
        if (miInfoObj == null)
        {
            miInfoObj = GetComponentInParent<InfoDisplayer>();
            if (miInfoObj == null)
                Debug.LogError("No se encontró el componente Ficha en el GameObject.");   
        }        
        gameObject.SetActive(false);
        transform.SetAsLastSibling();
    }    

    public void ObtainObjInfo()
    {
        nameText.text = miInfoObj.objName;
        typeText.text = miInfoObj.type.ToString();
        descriptionText.text = miInfoObj.description;
    }
}


