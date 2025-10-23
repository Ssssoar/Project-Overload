using UnityEngine;
using UnityEngine.InputSystem;

public class SCR_CameraController : MonoBehaviour{
    //SINGLETON START
    public static SCR_CameraController Instance {get; private set;}
    void Awake(){
        if (Instance != null && Instance != this){
            Destroy(this);
        }else{
            Instance = this;
        }
    }
    //SINGLETON END

    [Header("References")]
    [SerializeField] Camera mainCamera;
    [SerializeField] Transform posTarget;
    [Header("Ignore Axis")]
    [SerializeField] bool ignoreX;
    [SerializeField] bool ignoreY;
    [SerializeField] bool ignoreZ;
    
    void Update(){
        Vector3 endPos =  new Vector3();
        if (!ignoreX){
            endPos.x = posTarget.position.x;
        }else{
            endPos.x = mainCamera.transform.position.x;
        }
        if (!ignoreY){
            endPos.y = posTarget.position.y;
        }else{
            endPos.y = mainCamera.transform.position.y;
        }
        if (!ignoreZ){
            endPos.z = posTarget.position.z;
        }else{
            endPos.z = mainCamera.transform.position.z;
        }
        mainCamera.transform.position = endPos;
    }

    public Vector3 GetWorldPositionFromMouse(){
        if (Mouse.current != null){
            Vector2 screenPosition = Mouse.current.position.ReadValue();
            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(screenPosition);
            worldPosition.z = 0f;
            return worldPosition;
        }else return Vector3.zero;
    }
}
