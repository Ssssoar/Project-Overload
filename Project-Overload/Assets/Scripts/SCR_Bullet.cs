using UnityEngine;

public class SCR_Bullet : MonoBehaviour{
    [SerializeField] float speed;
    void FixedUpdate(){
        transform.position += transform.right * Time.deltaTime * speed;
    }
}
