using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class SCR_UpgradeSlot : MonoBehaviour{
    [SerializeField] TMP_Text nameText;
    [SerializeField] TMP_Text descriptionText;
    [SerializeField] Button upgradeButton;
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
    }

    void ChooseUpgrade(){
        SCR_UpgradeManager.Instance.Upgrade(upgradeBeingDisplayed.type);
    }
}
