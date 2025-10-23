using UnityEngine;

public class SCR_Bullet : MonoBehaviour{
    [SerializeField] float speed;
    [SerializeField] string borderTag;

    void FixedUpdate(){
        transform.position += transform.right * Time.deltaTime * speed;
    }

    void BulletDestroy(){
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.tag == borderTag){
            BulletDestroy();
        }
    }
}
