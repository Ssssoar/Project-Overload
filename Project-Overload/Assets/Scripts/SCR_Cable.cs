using UnityEngine;

public class SCR_Cable : MonoBehaviour{
    [Header("Parameters")]
    [SerializeField] float connectionProgress;

    [Header("References")]
    [SerializeField] LineRenderer lineRenderer;
    [HideInInspector] public Transform connectFrom, connectTo;

    void Update(){
        Vector3[] newPositions = new Vector3[2];
        newPositions[0] = connectFrom.position;
        newPositions[1] = FindEndPoint();
        lineRenderer.SetPositions(newPositions);
    }

    Vector3 FindEndPoint(){
        Vector3 fullPosition = connectTo.position - connectFrom.position;
        Vector3 actualPosition = fullPosition * connectionProgress;
        return actualPosition + connectFrom.position;
    }
}
