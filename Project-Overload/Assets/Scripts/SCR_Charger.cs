using UnityEngine;

public class SCR_Charger : MonoBehaviour{
    void OnTriggerEnter2D(Collider2D other){
        SCR_PlayerCharge chargeComp = other.gameObject.GetComponent<SCR_PlayerCharge>();
        Debug.Log(chargeComp);
    }
}
