using UnityEngine;

public class SCR_UpgradeManager : MonoBehaviour{

    int[] upgradeLevels = new int[SO_Upgrade.UpgradeType.GetValues().Length]

    SO_Upgrade.UpgradeType GetRandomUpgradeType(){
        int totalAmmount = SO_Upgrade.UpgradeType.GetValues().Length;
        return (SO_Upgrade.UpgradeType) Randoom.Range(0,totalAmmount);
    }
}
