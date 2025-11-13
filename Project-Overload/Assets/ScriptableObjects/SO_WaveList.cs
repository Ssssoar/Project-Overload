using UnityEngine;

[CreateAssetMenu(fileName = "SO_WaveList", menuName = "Enemy Waves/Wave List")]
public class SO_WaveList : ScriptableObject{
    public SO_Wave[] waves;
}
