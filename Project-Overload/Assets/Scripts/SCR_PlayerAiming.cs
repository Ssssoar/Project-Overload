using UnityEngine;

public class SCR_PlayerAiming : MonoBehaviour{
    [Header("References")]
    [SerializeField] Camera mainCamera; //IF WE MAKE A CAMERA HANDLING SINGLETON WE'LL HAVE TO CHANGE THIS DO NOT THE FORGET
    [SerializeField] Transform aimerTransform;

    bool freeze = false;

    void Start(){
        SCR_GameManager.Instance.onPause.AddListener(Freeze);
        SCR_GameManager.Instance.onUnPause.AddListener(UnFreeze);
    }

    void Update(){
        if (freeze) return;
        Vector3 targetPosition = SCR_CameraController.Instance.GetWorldPositionFromMouse();
        PointAimerTo(targetPosition);
    }

    void Freeze(){
        freeze = true;
    }

    void UnFreeze(){
        freeze = false;
    }

    void PointAimerTo(Vector3 target){
        aimerTransform.right = target - transform.position;
    }
}
