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
        SCR_Enemy spawnedEnemy = Instantiate(enemyToSpawn, spawnPosition, Quaternion.identity);
        spawnedEnemy.SetListingIndex(enemyListingIndex);
    }

    Vector2 GetSpawnPosition(){
        Vector2 min, max, playerPos, cameraPos;
        playerPos = SCR_GameManager.Instance.GetPlayerPosition();
        cameraPos = SCR_GameManager.Instance.GetCameraPosition();
        min = new Vector2(
            (playerPos.x > cameraPos.x)? cameraPos.x : playerPos.x ,
            (playerPos.y > cameraPos.y)? cameraPos.y : playerPos.y
        );
        max = new Vector2(
            (playerPos.x < cameraPos.x)? cameraPos.x : playerPos.x ,
            (playerPos.y < cameraPos.y)? cameraPos.y : playerPos.y
        );
        min.x -= spawnBoundaries.x;
        min.y -= spawnBoundaries.y;
        max.x += spawnBoundaries.x;
        max.y += spawnBoundaries.y;
        Vector2 spawnPos = new Vector2(
            Random.Range(min.x, max.x),
            Random.Range(min.y, max.y)
        );
        switch(Random.Range(0,4)){
            case 0:
                spawnPos.x = min.x;
            break;
            case 1:
                spawnPos.y = min.y;
            break;
            case 2:
                spawnPos.x = max.x;
            break;
            case 3:
                spawnPos.y = max.y;
            break;
        }
        return spawnPos;
    }

}
