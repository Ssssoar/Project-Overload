using UnityEngine;

public class SCR_PlayerShooter : MonoBehaviour{
    //If I had infinite time I'd implement an object pool for these
    [Header("References")]
    [SerializeField] Transform firePoint;

    [Header("Prefabs")]
    [SerializeField] SCR_Bullet bulletToFire;

    [Header("Parameters")]
    [SerializeField] float fireRate; //in objects instantiated per second

    [Header("Variables")]
    float timer = 0f;

    void Start(){
        SetUpTimer();
    }

    void Update(){
        if (RunTimer()){
            SetUpTimer();
            FireBullet();
        }
    }

    bool RunTimer(){ //returns whether the timer expired
        timer -= Time.deltaTime;
        if (timer <= 0f) return true; //if timer expired
        else if ((timer == float.PositiveInfinity) && (fireRate != 0f)) return true; //if timer is infinite but we began firing at some point
        else return false;

    }

    void SetUpTimer(){
        if (fireRate == 0f){
            timer = float.PositiveInfinity;
        }else{
            timer += 1/fireRate;
        }
    }

    void FireBullet(){
        Instantiate(bulletToFire, firePoint.position, firePoint.rotation);
    }
}
