using UnityEngine;

public class SCR_Health : SCR_Vitals{
    internal override void FixedUpdate(){
        base.FixedUpdate();
        fillSpeed = 0f;
    }

    public void AddDamageSource(float damagePerSecond){
        fillSpeed -= damagePerSecond;
    }
}
