using UnityEngine;
using UnityEngine.InputSystem;

public class SCR_PlayerMovement : MonoBehaviour{
    [Header("References")]
    [SerializeField] Rigidbody2D movementBody;

    [Header("Parameters")]
    [SerializeField] float moveSpeed = 5f;

    [Header("InputVariables")]
    InputAction moveAction;
    Vector2 inputMovement;

    void Start(){
        moveAction = InputSystem.actions.FindAction("Move");
    }

    void FixedUpdate(){
        CaptureInputs();
        MovePlayer();
    }

    void CaptureInputs(){
        inputMovement = moveAction.ReadValue<Vector2>();
    }

    void MovePlayer(){
        Vector2 targetPosition = PositionAs2D() + (inputMovement.normalized * moveSpeed * Time.deltaTime);
        movementBody.MovePosition(targetPosition);
    }

    Vector2 PositionAs2D(){
        return new Vector2 (transform.position.x,transform.position.y);
    }
}