using UnityEngine;
using UnityEngine.InputSystem;

public class SCR_PlayerMovement : MonoBehaviour{
    [Header("References")]
    [SerializeField] Rigidbody2D movementBody;
    [SerializeField] SCR_OverLoad overloadComp;

    [Header("Parameters")]
    [SerializeField] float moveSpeed = 5f;

    [Header("InputVariables")]
    InputAction moveAction;
    Vector2 inputMovement;
    bool frozen = false;

    void Start(){
        moveAction = InputSystem.actions.FindAction("Move");
        if (overloadComp != null){
            overloadComp.onOverLoadStart.AddListener(Freeze);
            overloadComp.onOverLoadEnd.AddListener(Unfreeze);
        }
    }

    void FixedUpdate(){
        CaptureInputs();
        MovePlayer();
    }

    void CaptureInputs(){
        inputMovement = moveAction.ReadValue<Vector2>();
    }

    void MovePlayer(){
        if (frozen) return;
        Vector2 targetPosition = PositionAs2D() + (inputMovement.normalized * moveSpeed * Time.deltaTime);
        movementBody.MovePosition(targetPosition);
    }

    void Freeze(){
        frozen = true;
        movementBody.linearVelocity = Vector3.zero;
    }

    void Unfreeze(){
        frozen = false;
    }

    Vector2 PositionAs2D(){
        return new Vector2 (transform.position.x,transform.position.y);
    }
}