using UnityEngine;
using TMPro;

public class SCR_EnemyCounter : MonoBehaviour{
    [SerializeField] TMP_Text textComp;
    [SerializeField] string prefix;

    void Start(){
        UpdateText();
        SCR_WaveManager.Instance.onEnemySlotFreed.AddListener(UpdateText);
        SCR_WaveManager.Instance.onWaveIncrement.AddListener(UpdateText);
    }

    void UpdateText(){
        string finalText = prefix;
        finalText += " ";
        finalText += SCR_WaveManager.Instance.GetEnemiesLeft();
        finalText += " / ";
        finalText += SCR_WaveManager.Instance.GetEnemyTotalInWave();
        textComp.text = finalText;
    }
}
