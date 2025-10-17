using System.Collections.Generic;
using UnityEngine;

public class SCR_PlayerCharge : MonoBehaviour{
    [Header("References")]
    [SerializeField] SCR_BarDisplay chargeBar;

    [Header("Parameters")]
    [SerializeField] float maxCharge = 100f;

    [Header("Variables")]
    float currentCharge;
    [SerializeField] float chargingAmmount = 0f; //in units per second; can be negative
    Dictionary<SCR_Charger,float> activeCharges = new Dictionary<SCR_Charger,float>();

    void Start(){
        currentCharge = maxCharge;
        chargeBar.SetBar(currentCharge, maxCharge);
    }

    void FixedUpdate(){
        UpdateCurrentCharge(chargingAmmount);
        chargeBar.SetBar(currentCharge);
    }

    void TryBeginCharge(SCR_Charger chargeSource, float incomingCharge){
        if (activeCharges[chargeSource] != null) return;
        activeCharges.Add(chargeSource,incomingCharge);
        chargingAmmount += incomingCharge;
    }

    void TryEndCharge(SCR_Charger chargeSource){
        if (activeCharges[chargeSource] == null) return;
        chargingAmmount -= activeCharges[chargeSources];
        activeCharges.Remove(chargeSource);
    }

    void UpdateCurrentCharge(float chargingAmmount){
        currentCharge += chargingAmmount * Time.deltaTime;
        currentCharge = ClampCharge(currentCharge);
    }

    float ClampCharge(float chargeToClamp){
        if (chargeToClamp <= 0f) return 0f;
        if (chargeToClamp >= maxCharge) return maxCharge;
        return chargeToClamp;
    }
}
