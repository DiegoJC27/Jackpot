using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
public abstract class InfoDisplayer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string objName;
    public ObjectType type;
    public string description;
    public Color titleColor = Color.black;

    const float TIME_TO_SHOW = 1f;
    float elapsed = 0f;
    bool panelShown = false;
    bool mouseOver = false;
    
    [SerializeField] Transform panelPivot;
    InformationPanel curPanel;
    public void OnPointerEnter(PointerEventData eventData)
    {
        mouseOver = true;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        mouseOver = false;
        panelShown = false;
        elapsed = 0f;
        if (curPanel != null)
            InfoPanelManager.Instance.HidePanel(curPanel);        
    }
    void Update()
    {
        if (mouseOver && !panelShown) {
            elapsed += Time.deltaTime;
            if (elapsed >= TIME_TO_SHOW) { 
                curPanel = InfoPanelManager.Instance.ShowPanel(panelPivot, this);
                panelShown = true;
            }            
        }
    }
    public virtual void OnTurnDown()
    {
        InfoPanelManager.Instance.HidePanel(curPanel);
        panelShown = false;
    }
}
public enum ObjectType
{
    Ficha,
    Ranura,
    Amuleto,
    Trago
}