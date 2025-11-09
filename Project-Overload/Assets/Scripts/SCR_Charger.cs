using UnityEngine;

public class SCR_Charger : MonoBehaviour{
    [SerializeField] float chargeToGrant; //in chargePoints per Second

    void OnTriggerEnter2D(Collider2D other){
        SCR_PlayerCharge chargeComp = other.gameObject.GetComponent<SCR_PlayerCharge>();
        if (chargeComp != null){
            chargeComp.TryBeginCharge(this , chargeToGrant);
        }
    }

    void OnTriggerExit2D(Collider2D other){
        SCR_PlayerCharge chargeComp = other.gameObject.GetComponent<SCR_PlayerCharge>();
        if (chargeComp != null){
            chargeComp.TryEndCharge(this);
        }
    }

    public float GetCharge(){
        return chargeToGrant;
    }
}
