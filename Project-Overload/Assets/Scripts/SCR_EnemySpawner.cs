using UnityEngine;

public class SCR_EnemySpawner : MonoBehaviour{
    //SINGLETON START
    public static SCR_EnemySpawner Instance {get; private set;}
    void Awake(){
        if (Instance != null && Instance != this){
            Destroy(this);
        }else{
            Instance = this;
        }
    }
    //SINGLETON END

    public void SpawnEnemy(SCR_Enemy enemyToSpawn){
        Instantiate(enemyToSpawn);
    }
}
