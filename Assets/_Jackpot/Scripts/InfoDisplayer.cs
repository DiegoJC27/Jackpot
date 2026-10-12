using UnityEngine;
using TMPro;
public abstract class InfoDisplayer : MonoBehaviour
{
    public InformationPanel miPanel;

    public string objName;
    public ObjectType type;
    public string description;

    private void OnMouseEnter()
    {
        miPanel.gameObject.SetActive(true);
        Debug.Log("Mouse entered " + objName);
    }
    private void OnMouseExit()
    {
        miPanel.gameObject.SetActive(false);
    }

    protected virtual void Start()
    {
        if(miPanel == null)
        {
            miPanel = GetComponentInChildren<InformationPanel>();
            if(miPanel == null)
                Debug.LogError("No se encontró el panel de informacion.");
        }
    }
}

public enum ObjectType
{
    Ficha,
    Ranura,
    Amuleto,
    Trago
}