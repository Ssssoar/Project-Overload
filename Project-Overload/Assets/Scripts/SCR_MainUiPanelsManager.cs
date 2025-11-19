using UnityEngine;
using UnityEngine.UI;

public class SCR_MainUiPanelsManager : MonoBehaviour{
    public enum Panel{Main, Config, Credits, Exit};

    //SINGLETON START
    public static SCR_MainUiPanelsManager Instance {get; private set;}
    void Awake(){
        if (Instance != null && Instance != this){
            Destroy(this);
        }else{
            Instance = this;
        }
    }
    //SINGLETON END

    Panel currentlyOpenPanel = Panel.Main;

    [System.Serializable]
    public struct PanelListing{
        public Panel panelType;
        public GameObject Panel;
    }

    [SerializeField] PanelListing[] panels;
    [SerializeField] Button playButton;

    void Start(){
        ActivatePanels();
        if (playButton != null) playButton.onClick.AddListener(SCR_SceneSwitcher.Instance.LoadGame);
    }

    
    public void OpenMainPanel(){
        OpenPanel(Panel.Main);
    }
    public void OpenConfigPanel(){
        OpenPanel(Panel.Config);
    }
    
    public void OpenCreditsPanel(){
        OpenPanel(Panel.Credits);
    }
    
    public void OpenExitPanel(){
        OpenPanel(Panel.Exit);
    }

    public void OpenPanel(Panel panelToOpen){
        currentlyOpenPanel = panelToOpen;
        ActivatePanels();
    }

    void ActivatePanels(){
        foreach(PanelListing panelListing in panels){
            panelListing.Panel.SetActive(panelListing.panelType == currentlyOpenPanel);
        }
    }
}
