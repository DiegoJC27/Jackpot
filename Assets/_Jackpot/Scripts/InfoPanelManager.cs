using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
public class InfoPanelManager : MonoBehaviour
{
    public static InfoPanelManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    
    private List<InformationPanel> panelsPool = new List<InformationPanel>();
    private const int MAX_PANELS = 6;
    [SerializeField] private InformationPanel panelPrefab;

    const float CANVAS_WIDTH = 800;
    const float OFFSET_FRACTION = 30;
    float offset;
    float panelWidth = 270;

    void Start()
    {
        for (int i = 0; i < MAX_PANELS; i++)
        {
            InformationPanel panel = Instantiate(panelPrefab, this.transform);
            panel.gameObject.SetActive(false);
            panelsPool.Add(panel);
        }   
    }

    public InformationPanel GetPanel()
    {
        foreach (InformationPanel panel in panelsPool)
        {
            if (!panel.gameObject.activeSelf)
            {
                return panel;
            }
        }
        Debug.LogWarning("No more panels available in the pool.");
        return null;    
    }

    public void HidePanel(InformationPanel panelToHide)
    {
        if(panelToHide != null)
            panelToHide.TurnOf();
    }

    public void HideAllPannels()
    {
        foreach (InformationPanel panel in panelsPool)
        {
            HidePanel(panel);
        }
    }
    public InformationPanel ShowPanel(Transform ntrans, InfoDisplayer info)
    {
        InformationPanel curPanel = GetPanel();
        curPanel.TurnOn();
        curPanel.ObtainObjInfo(info);

        offset = Screen.width / OFFSET_FRACTION;
        Vector2 screenPos = Camera.main.WorldToScreenPoint(ntrans.position);
        Vector2 canvasPos = (screenPos / Screen.width) * CANVAS_WIDTH;
        if (canvasPos.x + offset + panelWidth > CANVAS_WIDTH)
        {
            screenPos.x -= offset;
            transform.GetComponent<RectTransform>().position = screenPos;
            GetComponent<GridLayoutGroup>().startCorner = GridLayoutGroup.Corner.UpperRight;
            GetComponent<GridLayoutGroup>().childAlignment = TextAnchor.MiddleRight;
            return curPanel;
        }
        screenPos.x += offset;
        transform.GetComponent<RectTransform>().position = screenPos;
        GetComponent<GridLayoutGroup>().startCorner = GridLayoutGroup.Corner.UpperLeft;
        GetComponent<GridLayoutGroup>().childAlignment = TextAnchor.MiddleLeft;
        
        return curPanel;
    }
}