using UnityEngine;

public class SCR_Health : MonoBehaviour{
    [Header("References")]
    [SerializeField] SCR_BarDisplay chargeBar;

    [Header("Parameters")]
    [SerializeField] float maxHealth; //which is also initial health

    [Header("Variables")]
    [SerializeField] float currentHealth;

    void Start(){
        currentHealth = maxHealth;
        chargeBar.SetBar(currentHealth, maxHealth);
    }

    void Update(){
        chargeBar.SetBar(currentHealth);
    }
}
