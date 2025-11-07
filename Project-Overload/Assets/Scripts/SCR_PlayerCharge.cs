using System.Collections.Generic;
using UnityEngine;

public class SCR_PlayerCharge : SCR_Vitals{
    [Header("References")]
    [SerializeField] SCR_CableManager cableManager;

    [Header("Parameters")]

    [Header("Variables")]
    Dictionary<SCR_Charger,float> activeCharges = new Dictionary<SCR_Charger,float>();

    public void TryBeginCharge(SCR_Charger chargeSource, float incomingCharge){
        float USELESS; //I will not use this variable I only use it to match the signature of TryGetValue
        if (activeCharges.TryGetValue(chargeSource, out USELESS)) return; //if there is an active charge from chargeSource, ignore.
        activeCharges.Add(chargeSource,incomingCharge);
        fillSpeed += incomingCharge;
        cableManager.ConnectTo(chargeSource.transform);
    }

    public void TryEndCharge(SCR_Charger chargeSource){
        float USELESS; //I will not use this variable I only use it to match the signature of TryGetValue
        if (!activeCharges.TryGetValue(chargeSource, out USELESS)) return; //if there's no active charge from chargeSource, ignore.
        fillSpeed -= activeCharges[chargeSource];
        activeCharges.Remove(chargeSource);
        cableManager.DisconnectFrom(chargeSource.transform);
    }
}
