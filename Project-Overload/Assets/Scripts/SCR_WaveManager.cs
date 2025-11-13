using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SCR_WaveManager : MonoBehaviour{
    //SINGLETON START
    public static SCR_WaveManager Instance {get; private set;}
    void Awake(){
        if (Instance != null && Instance != this){
            Destroy(this);
        }else{
            Instance = this;
        }
    }
    //SINGLETON END

    [Header("Parameters")]
    [SerializeField] SO_WaveList waveList;

    [Header("Variables")]
    int currentWave = 0;
    SO_Wave currentWaveData;
    List<float> timers = new List<float>();
    List<int> spawnCounters = new List<int>();
    List<int> totalSpawnCounters = new List<int>();

    void Start(){
        StartNextWave();
    }

    void Update(){
        RunTimers();
        TryAdvanceWave();
    }

    void RunTimers(){
        for(int enemyListingIndex = 0; enemyListingIndex < timers.Count; enemyListingIndex++){
            SO_Wave.EnemySpawnListing enemyListing = currentWaveData.enemiesToSpawn[enemyListingIndex];
            timers[enemyListingIndex] -= Time.deltaTime;
            if (timers[enemyListingIndex] <= 0f){
                timers[enemyListingIndex] = 0f;
                if (TrySpawnEnemy(enemyListingIndex))
                    timers[enemyListingIndex] += enemyListing.timeToSpawnAll / enemyListing.totalAmmount;
            }
        }
    }

    void TryAdvanceWave(){
        foreach (int counter in spawnCounters){
            if (counter != 0) return;
        }
        for(int enemyListingIndex = 0; enemyListingIndex < totalSpawnCounters.Count; enemyListingIndex++){
            if (totalSpawnCounters[enemyListingIndex] != currentWaveData.enemiesToSpawn[enemyListingIndex].totalAmmount) return;
        }
        StartNextWave();
    }

    bool TrySpawnEnemy(int listingIndexToSpawnFrom){
        if (
            (spawnCounters[listingIndexToSpawnFrom] >= currentWaveData.enemiesToSpawn[listingIndexToSpawnFrom].maxAtOneTime) ||
            (totalSpawnCounters[listingIndexToSpawnFrom] >= currentWaveData.enemiesToSpawn[listingIndexToSpawnFrom].totalAmmount)
        ){
            return false;
        }
        SCR_EnemySpawner.Instance.SpawnEnemy(currentWaveData.enemiesToSpawn[listingIndexToSpawnFrom].enemyType);
        spawnCounters[listingIndexToSpawnFrom] += 1;
        totalSpawnCounters[listingIndexToSpawnFrom] += 1;
        return true;
    }

    void StartNextWave(){
        currentWave++;
        if (currentWave > waveList.waves.Length){
            currentWave = waveList.waves.Length-1;
        }
        currentWaveData = waveList.waves[currentWave-1];
        SetUpTimers();
        SetUpSpawnCounters();
    }

    void SetUpTimers(){
        timers.Clear();
        foreach (SO_Wave.EnemySpawnListing enemyListing in currentWaveData.enemiesToSpawn){
            timers.Add(enemyListing.timeToSpawnAll / (float)enemyListing.totalAmmount);
        }
    }
    
    void SetUpSpawnCounters(){
        spawnCounters.Clear();
        foreach (SO_Wave.EnemySpawnListing enemyListing in currentWaveData.enemiesToSpawn){
            spawnCounters.Add(0);
        }
        totalSpawnCounters.Clear();
        foreach (SO_Wave.EnemySpawnListing enemyListing in currentWaveData.enemiesToSpawn){
            totalSpawnCounters.Add(0);
        }
    }

    public void FreeEnemySlot(int listingIndexToFree){
        spawnCounters[listingIndexToFree] -= 1;
    }
}
