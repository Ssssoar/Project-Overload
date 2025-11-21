using UnityEngine;
using UnityEngine.Events;
using System;
using System.Collections.Generic;

public class SCR_UpgradeManager : MonoBehaviour{
    //SINGLETON START
    public static SCR_UpgradeManager Instance {get; private set;}
    void Awake(){
        if (Instance != null && Instance != this){
            Destroy(this);
        }else{
            Instance = this;
        }
    }
    //SINGLETON END

    public float bulletSpeedFactor {get; private set;}
    public float bulletForceFactor {get; private set;}
    [SerializeField] SO_Upgrade[] upgradeList;
    [SerializeField] int upgradesToRoll;
    Dictionary<SO_Upgrade.UpgradeType,int> upgradeLevels = new Dictionary<SO_Upgrade.UpgradeType,int>();

    //definitions
    [System.Serializable] public class UpgradeDataEvent : UnityEvent<SO_Upgrade[]> {}

    [Header("Events")]
    public UpgradeDataEvent onUpgradesRolled;

    void Start(){
        SCR_GameManager.Instance.onGameStateChange.AddListener(TryStartUpgradeProcess);
        SetUpUpgradeLevels();
        UpdateAll();
    }

    void SetUpUpgradeLevels(){
        foreach(SO_Upgrade upgrade in upgradeList){
            upgradeLevels.Add(upgrade.type, 0);
        }
    }

    void TryStartUpgradeProcess(SCR_GameManager.GameState state){
        if (state == SCR_GameManager.GameState.Upgrade) RollUpgrades();
    }

    void RollUpgrades(){
        SO_Upgrade[] randomUpgrades = new SO_Upgrade[upgradesToRoll];
        for (int i = 0;i < upgradesToRoll; i++){
            randomUpgrades[i] = upgradeList[1/*(int)GetRandomUpgradeType()*/];
        }
        onUpgradesRolled?.Invoke(randomUpgrades);
    }

    SO_Upgrade.UpgradeType GetRandomUpgradeType(){
        return (SO_Upgrade.UpgradeType) UnityEngine.Random.Range(0,upgradeList.Length);
    }

    public void Upgrade(SO_Upgrade.UpgradeType typeToUpgrade){
        upgradeLevels[typeToUpgrade]++;
        switch(typeToUpgrade){
            case SO_Upgrade.UpgradeType.FireRate:
                UpdateFireRate();
            break;
            case SO_Upgrade.UpgradeType.ChargeDecay:
                UpdateChargeDecay();
            break;
            case SO_Upgrade.UpgradeType.HealthRecover:
                UpdateHealthRecover();
            break;
            case SO_Upgrade.UpgradeType.OverloadResist:
                UpdateOverloadResist();
            break;
            case SO_Upgrade.UpgradeType.ChargerRadius:
                UpdateChargerRadius();
            break;
            case SO_Upgrade.UpgradeType.BulletSpeed:
                UpdateBulletSpeed();
            break;
            case SO_Upgrade.UpgradeType.BulletForce:
                UpdateBulletForce();
            break;
        }
        SCR_GameManager.Instance.TryEndUpgradeState();
    }

    void UpdateAll(){
        UpdateFireRate();
        UpdateChargeDecay();
        UpdateHealthRecover();
        UpdateOverloadResist();
        UpdateChargerRadius();
        UpdateBulletSpeed();
        UpdateBulletForce();
    }

    void UpdateFireRate(){
        SCR_PlayerShooter shooterComp = SCR_GameManager.Instance.GetPlayerShooter();
        SO_Upgrade upgradeData = GetUpgradeListingFromType(SO_Upgrade.UpgradeType.FireRate);
        int upgradeLevel = GetUpgradeLevelFromType(SO_Upgrade.UpgradeType.FireRate);
        float fireRateToSet = upgradeData.values[upgradeLevel];
        shooterComp.SetFireRate(fireRateToSet);
    }

    void UpdateChargeDecay(){
        SCR_PlayerCharge chargeComp = SCR_GameManager.Instance.GetPlayerCharge();
        SO_Upgrade upgradeData = GetUpgradeListingFromType(SO_Upgrade.UpgradeType.ChargeDecay);
        int upgradeLevel = GetUpgradeLevelFromType(SO_Upgrade.UpgradeType.ChargeDecay);
        float decayToSet = upgradeData.values[upgradeLevel];
        chargeComp.ChangeDefaultFillSpeed(decayToSet);
    }

    void UpdateHealthRecover(){
        SCR_Health healthComp = SCR_GameManager.Instance.GetPlayerHealth();
        SO_Upgrade upgradeData = GetUpgradeListingFromType(SO_Upgrade.UpgradeType.HealthRecover);
        int upgradeLevel = GetUpgradeLevelFromType(SO_Upgrade.UpgradeType.HealthRecover);
        float recoverToSet = upgradeData.values[upgradeLevel];
        healthComp.ChangeDefaultFillSpeed(recoverToSet);
    }

    void UpdateOverloadResist(){
        SCR_OverLoad overloadComp = SCR_GameManager.Instance.GetPlayerOverLoad();
        SO_Upgrade upgradeData = GetUpgradeListingFromType(SO_Upgrade.UpgradeType.OverloadResist);
        int upgradeLevel = GetUpgradeLevelFromType(SO_Upgrade.UpgradeType.OverloadResist);
        float resistToSet = upgradeData.values[upgradeLevel];
        overloadComp.ChangeIncreaseRate(resistToSet);
    }

    void UpdateChargerRadius(){
        SCR_Charger charger = SCR_GameManager.Instance.GetCharger();
        SO_Upgrade upgradeData = GetUpgradeListingFromType(SO_Upgrade.UpgradeType.ChargerRadius);
        int upgradeLevel = GetUpgradeLevelFromType(SO_Upgrade.UpgradeType.ChargerRadius);
        float sizeToSet = upgradeData.values[upgradeLevel];
        charger.ChangeSize(sizeToSet);
    }

    void UpdateBulletSpeed(){
        SO_Upgrade upgradeData = GetUpgradeListingFromType(SO_Upgrade.UpgradeType.BulletSpeed);
        int upgradeLevel = GetUpgradeLevelFromType(SO_Upgrade.UpgradeType.BulletSpeed);
        bulletSpeedFactor = upgradeData.values[upgradeLevel];
    }

    void UpdateBulletForce(){
        SO_Upgrade upgradeData = GetUpgradeListingFromType(SO_Upgrade.UpgradeType.BulletForce);
        int upgradeLevel = GetUpgradeLevelFromType(SO_Upgrade.UpgradeType.BulletForce);
        bulletForceFactor = upgradeData.values[upgradeLevel];
    }

    SO_Upgrade GetUpgradeListingFromType(SO_Upgrade.UpgradeType type){
        foreach (SO_Upgrade upgradeListing in upgradeList){
            if (upgradeListing.type == type) return upgradeListing;
        }
        return null;
    }

    int GetUpgradeLevelFromType(SO_Upgrade.UpgradeType type){
        SO_Upgrade upgradeData = GetUpgradeListingFromType(type);
        int upgradeLevel = upgradeLevels[type];
        if (upgradeLevel >= upgradeData.values.Length) {
            upgradeLevels[type] = upgradeData.values.Length - 1;
            upgradeLevel = upgradeData.values.Length - 1;
        }
        return upgradeLevel;
    }
}
