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


    public void ResetEnemy(SCR_Enemy toReset){
        Vector2 spawnPos = GetSpawnPosition();
        toReset.transform.position = GetSpawnPosition();
        toReset.Reset();
    }

    public void SpawnEnemy(SCR_Enemy enemyToSpawn, int enemyListingIndex){
        Vector2 spawnPosition = GetSpawnPosition();
        SCR_Enemy spawnedEnemy = Instantiate(enemyToSpawn, spawnPosition, Quaternion.identity);
        spawnedEnemy.SetListingIndex(enemyListingIndex);
    }

    Vector2 GetSpawnPosition(){
        Vector2[] bounds = GetBoundaries();
        Vector2 spawnPos = new Vector2(
            Random.Range(bounds[0].x, bounds[1].x),
            Random.Range(bounds[0].y, bounds[1].y)
        );
        switch(Random.Range(0,4)){
            case 0:
                spawnPos.x = bounds[0].x;
            break;
            case 1:
                spawnPos.y = bounds[0].y;
            break;
            case 2:
                spawnPos.x = bounds[1].x;
            break;
            case 3:
                spawnPos.y = bounds[1].y;
            break;
        }
        return spawnPos;
    }

    public bool IsPosOutsideBoundaries(Vector3 position){
        Vector2[] bounds = GetBoundaries();
        return (
            (position.x > bounds[1].x) ||
            (position.y > bounds[1].y) ||
            (position.x < bounds[0].x) ||
            (position.y < bounds[0].y)
        );
    }

    Vector2[] GetBoundaries(){
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
        return new Vector2[] {min,max};
    }
}
