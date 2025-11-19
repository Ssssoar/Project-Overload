using UnityEngine;

public class SCR_Health : SCR_Vitals{
    float initMax;
    float initCurrent;
    
    internal override void Start(){
        base.Start();
        initMax = max;
        initCurrent = current;
        SCR_Enemy enemyComp = GetComponent<SCR_Enemy>();
        if (enemyComp != null){
            enemyComp.onReset.AddListener(Reset);
        }
    }

    internal override void FixedUpdate(){
        base.FixedUpdate();
        fillSpeed = 0f;
    }

    public void AddDamageSource(float damagePerSecond){
        fillSpeed -= damagePerSecond;
    }

    void Reset(){
        max = initMax;
        current = initCurrent;
    }

}
