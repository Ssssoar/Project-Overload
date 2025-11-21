using UnityEngine;

public class SCR_Pusher : MonoBehaviour{
    [SerializeField] float pushStrength;
    public void Push(Rigidbody2D toPush){
        Vector3 direction = (toPush.transform.position - transform.position).normalized;
        toPush.AddForce(direction * pushStrength, ForceMode2D.Impulse);
    }

    public void ChangeStrength(float toSet){
        pushStrength = toSet;
    }
}