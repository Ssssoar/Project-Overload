using UnityEngine;
using TMPro;

public class SCR_WaveCounter : MonoBehaviour{
    [SerializeField] TMP_Text textComp;
    [SerializeField] string prefix;

    void Start(){
        UpdateText();
        SCR_WaveManager.Instance.onWaveIncrement.AddListener(UpdateText);
    }

    void UpdateText(){
        string finalText = prefix;
        finalText += " ";
        finalText += SCR_WaveManager.Instance.GetCurrentWave();
        finalText += " / ";
        finalText += SCR_WaveManager.Instance.GetWaveTotal();
        textComp.text = finalText;
    }
}
