using UnityEngine;

public class SCR_Bullet : MonoBehaviour{
    [SerializeField] float speed;
    [SerializeField] string borderTag;
    [SerializeField] float forceStrength;

    void FixedUpdate(){
        transform.position += transform.right * Time.deltaTime * speed;
    }

    public void DamageDealtResponse(Rigidbody2D receiverBody){
        SendForce(receiverBody);
        BulletDestroy();
    }

    void SendForce(Rigidbody2D forceReceiver){
        Vector3 forceDirection = (forceReceiver.transform.position - transform.position).normalized;
        Vector2 forceDirectionAs2D = new Vector2(forceDirection.x, forceDirection.y);
        forceReceiver.AddForce(forceDirectionAs2D * forceStrength, ForceMode2D.Impulse);
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
