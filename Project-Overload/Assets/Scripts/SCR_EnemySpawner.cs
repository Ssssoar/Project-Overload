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

    [Header("Parameters")]
    [SerializeField] Vector2 spawnBoundaries;

    public void SpawnEnemy(SCR_Enemy enemyToSpawn, int enemyListingIndex){
        Vector2 spawnPosition = GetSpawnPosition();
        SCR_Enemy spawnedEnemy = Instantiate(enemyToSpawn);
        spawnedEnemy.SetListingIndex(enemyListingIndex);
    }

    Vector2 GetSpawnPosition(){
        return new Vector2();
    }

}
