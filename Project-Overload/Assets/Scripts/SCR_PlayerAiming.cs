using UnityEngine;

public class SCR_PlayerAiming : MonoBehaviour{
    [Header("References")]
    [SerializeField] Camera mainCamera; //IF WE MAKE A CAMERA HANDLING SINGLETON WE'LL HAVE TO CHANGE THIS DO NOT THE FORGET
    [SerializeField] Transform aimerTransform;

    bool freeze = false;

    void Start(){
        SCR_GameManager.Instance.onFreezeStateChange.AddListener(Freeze);
    }

    void Update(){
        if (freeze) return;
        Vector3 targetPosition = SCR_CameraController.Instance.GetWorldPositionFromMouse();
        PointAimerTo(targetPosition);
    }

    void Freeze(bool state){
        freeze = state;
    }

    void PointAimerTo(Vector3 target){
        aimerTransform.right = target - transform.position;
    }
}
