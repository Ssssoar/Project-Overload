using UnityEngine;
using UnityEngine.UI;

public class SCR_GameUiPanelsManager : MonoBehaviour{
    public enum Panel{None, Pause, GameOver, Upgrade, Config};

    //SINGLETON START
    public static SCR_GameUiPanelsManager Instance {get; private set;}
    void Awake(){
        if (Instance != null && Instance != this){
            Destroy(this);
        }else{
            Instance = this;
        }
    }
    //SINGLETON END

    Panel currentlyOpenPanel = Panel.None;

    [System.Serializable]
    public struct PanelListing{
        public Panel panelType;
        public GameObject Panel;
    }

    [SerializeField] PanelListing[] panels;
    [SerializeField] Button mainMenuButton;

    void Start(){
        ActivatePanels();
        if (mainMenuButton != null) mainMenuButton.onClick.AddListener(SCR_SceneSwitcher.Instance.LoadMenu);
    }

    
    public void OpenPausePanel(){
        OpenPanel(Panel.Pause);
    }
    public void OpenGameOverPanel(){
        OpenPanel(Panel.GameOver);
    }
    
    public void OpenUpgradePanel(){
        OpenPanel(Panel.Upgrade);
    }
    
    public void OpenConfigPanel(){
        OpenPanel(Panel.Config);
    }

    public void OpenPanel(Panel panelToOpen){
        currentlyOpenPanel = panelToOpen;
        ActivatePanels();
    }

    public void ClosePanel(){
        currentlyOpenPanel = Panel.None;
        ActivatePanels();
    }

    void ActivatePanels(){
        foreach(PanelListing panelListing in panels){
            panelListing.Panel.SetActive(panelListing.panelType == currentlyOpenPanel);
        }
    }
}