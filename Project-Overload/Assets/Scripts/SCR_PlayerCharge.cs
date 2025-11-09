using System.Collections.Generic;
using UnityEngine;

public class SCR_PlayerCharge : SCR_Vitals{
    [Header("References")]
    [SerializeField] SCR_CableManager cableManager;
    [SerializeField] Collider2D colliderComponent;

    [Header("Parameters")]

    [Header("Variables")]
    Dictionary<SCR_Charger,float> activeCharges = new Dictionary<SCR_Charger,float>();
    bool blocked = false;

    public void TryBeginCharge(SCR_Charger chargeSource){
        TryBeginCharge(chargeSource, chargeSource.GetCharge());
    }

    public void TryBeginCharge(SCR_Charger chargeSource, float incomingCharge){
        if (blocked) return;
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

    public void BlockCharges(){
        blocked = true;
        foreach(KeyValuePair<SCR_Charger,float> activeCharge in activeCharges){
            cableManager.DisconnectFrom(activeCharge.Key.transform);
            fillSpeed -= activeCharge.Value;
        }
        activeCharges.Clear();
        current = 0f;
    }

    public void UnBlockCharges(){
        blocked = false;
        ReCheckConnections();
    }

    void ReCheckConnections(){
        List<Collider2D> overlappingColliders = new List<Collider2D>();
        //ContactFilter2D filter = ContactFilter2D.NoFilter;
        colliderComponent.Overlap(overlappingColliders);
        foreach(Collider2D overlappingCollider in overlappingColliders){
            SCR_Charger chargerToActivate = overlappingCollider.GetComponent<SCR_Charger>();
            if (chargerToActivate != null){
                TryBeginCharge(chargerToActivate);
            }
        }
    }
}
