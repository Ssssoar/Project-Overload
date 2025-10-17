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

    public void TryBeginCharge(SCR_Charger chargeSource, float incomingCharge){
        float USELESS; //I will not use this variable I only use it to match the signature of TryGetValue
        if (activeCharges.TryGetValue(chargeSource, out USELESS)) return; //if there is an active charge from chargeSource, ignore.
        activeCharges.Add(chargeSource,incomingCharge);
        chargingAmmount += incomingCharge;
    }

    public void TryEndCharge(SCR_Charger chargeSource){
        float USELESS; //I will not use this variable I only use it to match the signature of TryGetValue
        if (!activeCharges.TryGetValue(chargeSource, out USELESS)) return; //if there's no active charge from chargeSource, ignore.
        chargingAmmount -= activeCharges[chargeSource];
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
