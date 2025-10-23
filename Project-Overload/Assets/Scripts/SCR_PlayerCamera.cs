using UnityEngine;

public class SCR_PlayerCamera : MonoBehaviour{
    [Header("References")]
    [SerializeField] GameObject cameraTarget;
    void Update(){
        Vector3 mouseWorldPos = SCR_CameraController.Instance.GetWorldPositionFromMouse();
        Vector3 endPos = GetMidPoint(mouseWorldPos, transform.position);
        cameraTarget.transform.position = endPos;
    }

    Vector3 GetMidPoint(Vector3 p1, Vector3 p2){
        return new Vector3((p1.x+p2.x)/2 , (p1.y+p2.y)/2 , (p1.z+p2.z)/2);
    }
}
