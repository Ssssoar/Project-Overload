using UnityEngine;

[CreateAssetMenu(fileName = "SO_Wave", menuName = "Enemy Waves/Wave")]
public class SO_Wave : ScriptableObject{
    [System.Serializable]
    public struct EnemySpawnListing{
        public SCR_Enemy enemyType;
        public int totalAmmount;
        public float timeToSpawnAll;
        public float maxAtOneTime;
    }

    public EnemySpawnListing[] enemiesToSpawn;
}
