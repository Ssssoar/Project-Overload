using UnityEngine;
using UnityEngine.Events;

public class SCR_Enemy : MonoBehaviour{
    [HideInInspector] public int listingIndex;
    public UnityEvent onReset;

    void Update(){
        ResetIfOutsideBounds();
    }

    void ResetIfOutsideBounds(){
        if (SCR_EnemySpawner.Instance.IsPosOutsideBoundaries(transform.position)){
            SCR_EnemySpawner.Instance.ResetEnemy(this);
        }
    }

    public void KillEnemy(){
        SCR_WaveManager.Instance.FreeEnemySlot(listingIndex);
        Destroy(gameObject);
    }

    public void SetListingIndex(int indexToStore){
        listingIndex = indexToStore;
    }

    public void Reset(){
        onReset.Invoke();
    }
}