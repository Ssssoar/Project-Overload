using UnityEngine;

public class SCR_MoveToPlayer : MonoBehaviour{
    void Update(){
        transform.position = SCR_GameManager.Instance.GetPlayerPosition();
    }
}
