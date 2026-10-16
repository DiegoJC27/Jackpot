using UnityEngine;
using TMPro;
public abstract class InfoDisplayer : MonoBehaviour
{
    public InformationPanel miPanel;

    public string objName;
    public ObjectType type;
    public string description;
    public const float TIMETOSHOW = 0.5f;
    public float elapsedStay = 0f;
    private void OnMouseStay()
    {
        elapsedStay += Time.deltaTime;
        if(elapsedStay >= TIMETOSHOW)
        {
            miPanel.gameObject.SetActive(true);
            Debug.Log("Mouse stayed on " + objName);
        }
    }
    private void OnMouseExit()
    {
        miPanel.gameObject.SetActive(false);
        elapsedStay = 0f;
    }

    protected virtual void Start()
    {
        //if(miPanel == null)
        //{
        //    miPanel = GetComponentInChildren<InformationPanel>();
        //    if(miPanel == null)
        //        Debug.LogError("No se encontró el panel de informacion.");
        //}
    }
}

public enum ObjectType
{
    Ficha,
    Ranura,
    Amuleto,
    Trago
}