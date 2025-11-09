using UnityEngine;

public class SCR_Health : SCR_Vitals{
    internal override void FixedUpdate(){
        base.FixedUpdate();
        fillSpeed = 0f;
    }

    void OnCollisionStay2D(Collision2D collision){
        SCR_DamageDealer damageScript = collision.gameObject.GetComponent<SCR_DamageDealer>();
        if (damageScript != null){
            fillSpeed -= damageScript.damage;
        }
    }
}
