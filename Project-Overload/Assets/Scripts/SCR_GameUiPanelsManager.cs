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
    [SerializeField] Button resumeButton;
    [SerializeField] Button mainMenuButton;
    [SerializeField] SCR_UpgradeSlot[] upgradeSlots;

    void Start(){
        ActivatePanels();
        if (mainMenuButton != null) mainMenuButton.onClick.AddListener(SCR_SceneSwitcher.Instance.LoadMenu);
        SCR_GameManager.Instance.onGameStateChange.AddListener(OpenStatePanels);
        resumeButton.onClick.AddListener(SCR_GameManager.Instance.TryUnpause);
        SCR_UpgradeManager.Instance.onUpgradesRolled.AddListener(UpdateUpgradePanels);
    }

    void OpenStatePanels(SCR_GameManager.GameState newState){
        if (newState == SCR_GameManager.GameState.Playing) ClosePanel();
        else if (newState == SCR_GameManager.GameState.Paused) OpenPausePanel();
        else if (newState == SCR_GameManager.GameState.Upgrade) OpenUpgradePanel();
        else if (newState == SCR_GameManager.GameState.GameOver) OpenGameOverPanel();
    }
    
    void OpenPausePanel(){
        OpenPanel(Panel.Pause);
    }

    void OpenGameOverPanel(){
        OpenPanel(Panel.GameOver);
    }
    
    void OpenUpgradePanel(){
        OpenPanel(Panel.Upgrade);
    }
    
    void OpenConfigPanel(){
        OpenPanel(Panel.Config);
    }

    void OpenPanel(Panel panelToOpen){
        currentlyOpenPanel = panelToOpen;
        ActivatePanels();
    }

    void ClosePanel(){
        currentlyOpenPanel = Panel.None;
        ActivatePanels();
    }

    void ActivatePanels(){
        foreach(PanelListing panelListing in panels){
            panelListing.Panel.SetActive(panelListing.panelType == currentlyOpenPanel);
        }
    }

    void UpdateUpgradePanels (SO_Upgrade[] rolledUpgrades){
        int i = 0;
        foreach (SO_Upgrade rolledUpgrade in rolledUpgrades){
            upgradeSlots[i].ReceiveUpgradeType(rolledUpgrade);
            i++;
        }
    }
}