using UnityEngine;

public class SCR_PlayerCamera : MonoBehaviour{
    [Header("References")]
    [SerializeField] GameObject cameraTarget;
    [SerializeField] float lerpStrength;

    bool freeze = false;

    void Start(){
        SCR_GameManager.Instance.onFreezeStateChange.AddListener(Freeze);
    }

    void Update(){
        if (freeze) return;
        Vector3 mouseWorldPos = SCR_CameraController.Instance.GetWorldPositionFromMouse();
        Vector3 targetPos = GetMidPoint(mouseWorldPos, transform.position);
        cameraTarget.transform.position = Vector3.Lerp(cameraTarget.transform.position, targetPos, lerpStrength);
    }

    void Freeze(bool state){
        freeze = state;
    }

    Vector3 GetMidPoint(Vector3 p1, Vector3 p2){
        return new Vector3((p1.x+p2.x)/2 , (p1.y+p2.y)/2 , (p1.z+p2.z)/2);
    }
}
