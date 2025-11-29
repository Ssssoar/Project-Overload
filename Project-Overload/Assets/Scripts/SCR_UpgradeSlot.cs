using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class SCR_UpgradeSlot : MonoBehaviour{
    [SerializeField] TMP_Text nameText;
    [SerializeField] TMP_Text descriptionText;
    [SerializeField] TMP_Text lvlDisplay;
    [SerializeField] Button upgradeButton;
    [SerializeField] string lvlTextPrefix;
    SO_Upgrade upgradeBeingDisplayed;

    //definitions
    [System.Serializable] public class GameStateEvent : UnityEvent<SCR_GameManager.GameState> {}

    public void Start(){
        upgradeButton.onClick.AddListener(ChooseUpgrade);
    }

    public void ReceiveUpgradeType(SO_Upgrade upgrade){
        upgradeBeingDisplayed = upgrade;
        nameText.text = upgrade.upgradeName;
        descriptionText.text = upgrade.description;
        string lvlText = lvlTextPrefix + " ";
        lvlText += SCR_UpgradeManager.Instance.GetCurrentUpgradeLevel(upgrade.type) + " / ";
        lvlText += upgrade.values.Length - 1;
        lvlDisplay.text = lvlText;
    }

    void ChooseUpgrade(){
        SCR_UpgradeManager.Instance.Upgrade(upgradeBeingDisplayed.type);
    }
}
