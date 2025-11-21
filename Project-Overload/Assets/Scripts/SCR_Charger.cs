using UnityEngine;

public class SCR_Charger : MonoBehaviour{
    [SerializeField] Transform visualObject;
    [SerializeField] CircleCollider2D colliderComp;
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

    public void ChangeSize(float radius){
        colliderComp.radius = radius;
        visualObject.localScale = new Vector3(radius*2,radius*2,radius*2);
    }
}
