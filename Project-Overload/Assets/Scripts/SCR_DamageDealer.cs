using UnityEngine;
using UnityEngine.Events;

public class SCR_DamageDealer : MonoBehaviour{
    [System.Serializable]
    public class RigidbodyEvent : UnityEngine.Events.UnityEvent<Rigidbody2D> {} // Leave it empty

    [Header("Parameters")]
    [SerializeField] float damage;
    [SerializeField] bool instant;
    [SerializeField] string tagToDamage;

    [Header("Events")]
    [SerializeField] RigidbodyEvent onInstantDamageDealt;

    void OnCollisionEnter2D(Collision2D collision){
        if (!instant) return;
        if ((tagToDamage == "") || (collision.gameObject.tag == tagToDamage)){
            SCR_Health healthScript = collision.gameObject.GetComponent<SCR_Health>();
            if (healthScript != null){
                healthScript.InstantChange(-damage);
                onInstantDamageDealt.Invoke(collision.rigidbody);
            }
        }
    }

    void OnCollisionStay2D(Collision2D collision){
        if (instant) return;
        if ((tagToDamage == "") || (collision.gameObject.tag == tagToDamage)){
            SCR_Health healthScript = collision.gameObject.GetComponent<SCR_Health>();
            if (healthScript != null){
                healthScript.AddDamageSource(damage);
            }
        }
    }
}