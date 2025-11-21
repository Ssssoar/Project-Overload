using UnityEngine;

public class SCR_Bullet : MonoBehaviour{
    [SerializeField] SCR_Pusher pusherComp;
    [SerializeField] float speed;
    [SerializeField] string borderTag;
    [SerializeField] float forceStrength;
    float realForceStrength;
    float realSpeed;

    void Start(){
        realSpeed = speed * SCR_UpgradeManager.Instance.bulletSpeedFactor;
        realForceStrength = forceStrength * SCR_UpgradeManager.Instance.bulletForceFactor;
        pusherComp.ChangeStrength(realForceStrength);
    }

    void FixedUpdate(){
        transform.position += transform.right * Time.deltaTime * realSpeed;
        if (SCR_EnemySpawner.Instance.IsPosOutsideBoundaries(transform.position)) BulletDestroy();
    }

    public void DamageDealtResponse(Rigidbody2D receiverBody){
        pusherComp.Push(receiverBody);
        BulletDestroy();
    }
    public void BulletDestroy(){
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.tag == borderTag){
            BulletDestroy();
        }
    }
}
