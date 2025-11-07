using UnityEngine;

public class SCR_Health : MonoBehaviour{
    [Header("References")]
    [SerializeField] SCR_BarDisplay chargeBar;

    [Header("Parameters")]
    [SerializeField] float maxHealth; //which is also initial health

    [Header("Variables")]
    float currentHealth;
    [SerializeField] float healthLoss; //in points per second

    void Start(){
        currentHealth = maxHealth;
        chargeBar.SetBar(currentHealth, maxHealth);
    }

    void Update(){
        UpdateCurrentHealth(healthLoss);
        chargeBar.SetBar(currentHealth);
    }

    void UpdateCurrentHealth(float healthLoss){
        //currentHealth += chargingAmmount * Time.deltaTime;
        //currentHealth = ClampHealth(currentHealth);
    }
}
