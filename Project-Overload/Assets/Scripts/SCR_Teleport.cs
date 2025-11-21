using UnityEngine;

public class SCR_Teleport : MonoBehaviour{
    [SerializeField] Transform toTeleport;
    [SerializeField] float rechargeTime;
    float timer;
    bool able = false;

    void Update(){
        if (timer != -1){
            timer -= Time.deltaTime;
            if (timer <= 0){
                able = true;
            }
        }
    }

    void Teleport(){
        if (!able) return;
    }

    public void SetRechargeTime(float newTime){
        rechargeTime = newTime;
    }
}
