using UnityEngine;

public class SCR_GameManager : MonoBehaviour{
    //SINGLETON START
    public static SCR_GameManager Instance {get; private set;}
    void Awake(){
        if (Instance != null && Instance != this){
            Destroy(this);
        }else{
            Instance = this;
        }
    }
    //SINGLETON END
    [SerializeField] GameObject player;

    public GameObject GetPlayer(){
        return player;
    }
}
