using UnityEngine;
using UnityEngine.EventSystems;
public abstract class InfoDisplayer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string objName;
    public ObjectType type;
    public string description;

    [SerializeField] Transform panelPivot;

    InformationPanel curPanel;
    public void OnPointerEnter(PointerEventData eventData)
    {
        curPanel = InfoPanelManager.Instance.ShowPanel(panelPivot, this);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        InfoPanelManager.Instance.HidePanel(curPanel);
    }

    public virtual void OnTurnDown()
    {
        InfoPanelManager.Instance.HidePanel(curPanel);
    }
}
public enum ObjectType
{
    Ficha,
    Ranura,
    Amuleto,
    Trago
}