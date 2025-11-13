using UnityEngine;

public class DEBUG_PrintCollisions : MonoBehaviour{
    void OnCollisionEnter2D(Collision2D collision){
        Debug.Log(collision.gameObject.tag);
    }
}
