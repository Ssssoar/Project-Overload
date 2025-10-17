using UnityEngine;
using UnityEngine.InputSystem;

public class SCR_PlayerAiming : MonoBehaviour{
    [Header("References")]
    [SerializeField] Camera mainCamera; //IF WE MAKE A CAMERA HANDLING SINGLETON WE'LL HAVE TO CHANGE THIS DO NOT THE FORGET
    [SerializeField] Transform aimerTransform;

    void Update(){
        Vector3 targetPosition = GetWorldPositionFromMouse();
        PointAimerTo(targetPosition);
    }

    Vector3 GetWorldPositionFromMouse(){
        if (Mouse.current != null){
            Vector2 screenPosition = Mouse.current.position.ReadValue();
            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(screenPosition);
            worldPosition.z = 0f;
            return worldPosition;
        }else return Vector3.zero;
    }

    void PointAimerTo(Vector3 target){
        aimerTransform.right = target - transform.position;
    }
}
