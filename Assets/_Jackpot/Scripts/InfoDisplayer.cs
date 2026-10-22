using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
 
public abstract class InfoDisplayer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] public ObjectInfo objInfo;

    [SerializeField] Transform panelPivot;

    public const float TIMETOSHOW = 0.5f;
    public float elapsedStay = 0f;
    InformationPanel panel;
    public void OnPointerEnter(PointerEventData eventData)
    {
        //elapsedStay += Time.deltaTime;
        //if(elapsedStay >= TIMETOSHOW)
        //{
        //    Debug.Log("Mouse stayed on " + objName);
        //}   

        panel = InfoPanelManager.Instance.GetPanel();
        if (panel != null)
        {
            panel.ObtainObjInfo(objInfo);
            panel.ShowPanel(panelPivot.position);
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        InfoPanelManager.Instance.HidePanel(panel);
        elapsedStay = 0f;
    }
}
public struct ObjectInfo
{
    public string objName;
    public ObjectType type;
    public string description;
}
public enum ObjectType
{
    Ficha,
    Ranura,
    Amuleto,
    Trago
}