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
    bool rutineOver = false;
    Coroutine showRutine;
    [SerializeField] Transform panelPivot;

    InformationPanel curPanel;
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("OnPointerEnter");
        curPanel = InfoPanelManager.Instance.ShowPanel(panelPivot, this);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("OnPointerExit");
        if (curPanel != null)
        {
            InfoPanelManager.Instance.HidePanel(curPanel);
            //if (rutineOver)
            //    InfoPanelManager.Instance.HidePanel(curPanel);
            //else
            //{
            //    StopCoroutine(showRutine);
            //    InfoPanelManager.Instance.HidePanel(curPanel);
            //}
        }
    }

    public virtual void OnTurnDown()
    {
        InfoPanelManager.Instance.HidePanel(curPanel);
    }

    IEnumerator ShowPanelRutine()
    {
        rutineOver = false;
        yield return new WaitForSeconds(TIME_TO_SHOW);
        curPanel = InfoPanelManager.Instance.ShowPanel(panelPivot, this);
        rutineOver = true;
    }
}
public enum ObjectType
{
    Ficha,
    Ranura,
    Amuleto,
    Trago
}