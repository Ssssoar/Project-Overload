using UnityEngine;

public class SCR_Enemy : MonoBehaviour{
    [HideInInspector] public int listingIndex;

    public void KillEnemy(){
        SCR_WaveManager.Instance.FreeEnemySlot(listingIndex);
        Destroy(gameObject);
    }
}