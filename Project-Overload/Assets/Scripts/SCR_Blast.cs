using UnityEngine;

public class SCR_Blast : MonoBehaviour{
    [SerializeField] SCR_Pusher pusherComp;
    [SerializeField] float blastTime;
    float timer;
    float blastStrength;

    void Update(){
        timer -= Time.deltaTime;
        if (timer <= 0f){
            DeactivateBlast();
        }
    }

    public void SetBlastStrength(float newStrength){
        blastStrength = newStrength; 
        pusherComp.ChangeStrength(newStrength);
    }

    public void ActivateBlast(){
        if (blastStrength == 0f) return;
        gameObject.SetActive(true);
        timer = blastTime;
    }

    void DeactivateBlast(){
        gameObject.SetActive(false);
    }
    
}
