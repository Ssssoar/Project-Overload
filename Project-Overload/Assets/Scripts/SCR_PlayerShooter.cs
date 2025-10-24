using UnityEngine;

public class SCR_PlayerShooter : MonoBehaviour{
    //If I had infinite time I'd implement an object pool for these
    [Header("References")]
    [SerializeField] Transform firePoint;
    [SerializeField] SCR_PlayerCharge playerCharge;

    [Header("Prefabs")]
    [SerializeField] SCR_Bullet bulletToFire;

    [Header("Parameters")]
    [SerializeField] float idealFireRate; //in objects instantiated per second when at full charge

    [Header("Variables")]
    float timer = 0f;
    float effectiveFireRate; //fire rate scaled by player charge ratio

    void Start(){
        SetUpTimer();
    }

    void Update(){
        effectiveFireRate = idealFireRate * Mathf.Pow(playerCharge.GetChargeRatio(),3f);
        Debug.Log(effectiveFireRate);
        if (RunTimer(effectiveFireRate)){
            FireBullet();
        }
    }

    bool RunTimer(float fireRate){ //returns whether the timer expired
        timer -= Time.deltaTime;
        if (timer <= 0f){/*if timer expired*/ 
            SetUpTimer();
            return true; 
        }else if(timer > GetTimeBetweenBullets(fireRate)) /*if we're waiting a time longer than the given firerate would imply*/{
            SetUpTimer();
        }
        return false;
    }

    void SetUpTimer(){
        timer = GetTimeBetweenBullets(effectiveFireRate);
    }

    float GetTimeBetweenBullets(float fireRate){
        if (fireRate == 0.0f) return Mathf.Infinity;
        return 1/effectiveFireRate;
    }

    void FireBullet(){
        Instantiate(bulletToFire, firePoint.position, firePoint.rotation);
    }
}
