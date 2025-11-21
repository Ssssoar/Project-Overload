using UnityEngine;

public class SCR_ZombieMovement : MonoBehaviour{
    [Header("References")]
    [SerializeField] Rigidbody2D rigidbodyComp;

    [Header("Parameters")]
    [SerializeField] float movementStrength;
    [SerializeField] float maxSpeed;

    Transform playerTransform;

    void Start(){
        playerTransform = SCR_GameManager.Instance.GetPlayer()?.transform;
        SCR_Enemy enemyComp = GetComponent<SCR_Enemy>();
        if (enemyComp != null){
            enemyComp.onReset.AddListener(Reset);
        }
    }

    void FixedUpdate(){
        ApplyForceTowardsPlayer();
    }

    void ApplyForceTowardsPlayer(){
        if (rigidbodyComp.linearVelocity.magnitude >= maxSpeed) return;
        Vector3 moveDirection = (playerTransform.position - transform.position).normalized;
        Vector2 moveDirectionAs2D = new Vector2 (moveDirection.x, moveDirection.y);
        //float extraForce = GetExtraForce();
        rigidbodyComp.AddForce(moveDirection * movementStrength);
    }

    void Reset(){
        rigidbodyComp.linearVelocity = new Vector3();
    }
}