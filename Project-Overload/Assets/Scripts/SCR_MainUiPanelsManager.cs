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
    [SerializeField] Button quitButton;
    [SerializeField] Slider SFXVolumeSlider;

    void Start(){
        ActivatePanels();
        if (playButton != null) playButton.onClick.AddListener(SCR_SceneSwitcher.Instance.LoadGame);
        if (quitButton != null) quitButton.onClick.AddListener(SCR_SceneSwitcher.Instance.QuitGame);
        if (SFXVolumeSlider != null) SFXVolumeSlider.onValueChanged.AddListener(SCR_SettingsManager.Instance.SetSFXVolume);
        SCR_AudioPlayer.Instance.BlockChargeSound();
    }

    
    public void OpenMainPanel(){
        OpenPanel(Panel.Main);
    }
    public void OpenConfigPanel(){
        SFXVolumeSlider.SetValueWithoutNotify(SCR_SettingsManager.Instance.GetSFXVolume());
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
