using UnityEngine;

public class SCR_PlayerCharge : MonoBehaviour{
    [Header("Parameters")]
    [SerializeField] float maxCharge = 100f;

    [Header("Variables")]
    float currentCharge;
    [SerializeField] float chargingAmmount = 0f; //in units per second; can be negative

    void Start(){
        currentCharge = maxCharge;
    }

    void FixedUpdate(){
        UpdateCurrentCharge(chargingAmmount);
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
