using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Scripting;
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
    private const int MAX_PANELS = 5;
    private List<InformationPanel> activePanels = new List<InformationPanel>();
    [SerializeField] private InformationPanel panelPrefab;

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
        if (panelsPool.Count > 0)
        {
            InformationPanel panel = panelsPool[0];
            panelsPool.RemoveAt(0);
            activePanels.Add(panel);
            return panel;
        }
        else
        {
            Debug.LogWarning("No more panels available in the pool.");
            return null;
        }
    }

    public void HidePanel(InformationPanel panelToHide)
    {
        if (activePanels.Contains(panelToHide))
        {
            panelToHide.gameObject.SetActive(false);
            activePanels.Remove(panelToHide);
            panelsPool.Add(panelToHide);
        }
        else
        {
            Debug.LogWarning("Panel not found in active panels.");
        }
    }
}
