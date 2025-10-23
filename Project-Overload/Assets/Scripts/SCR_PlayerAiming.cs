using UnityEngine;

public class SCR_PlayerAiming : MonoBehaviour{
    [Header("References")]
    [SerializeField] Camera mainCamera; //IF WE MAKE A CAMERA HANDLING SINGLETON WE'LL HAVE TO CHANGE THIS DO NOT THE FORGET
    [SerializeField] Transform aimerTransform;

    void Update(){
        Vector3 targetPosition = SCR_CameraController.Instance.GetWorldPositionFromMouse();
        PointAimerTo(targetPosition);
    }

    void PointAimerTo(Vector3 target){
        aimerTransform.right = target - transform.position;
    }
}
