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
    }

    void FixedUpdate(){
        ApplyForceTowardsPlayer();
    }

    void ApplyForceTowardsPlayer(){
        if (rigidbodyComp.linearVelocity.magnitude >= maxSpeed) return;
        Vector3 moveDirection = (playerTransform.position - transform.position).normalized;
        Vector2 moveDirectionAs2D = new Vector2 (moveDirection.x, moveDirection.y);
        rigidbodyComp.AddForce(moveDirection * movementStrength);
    }
}