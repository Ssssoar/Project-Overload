using UnityEngine;

[CreateAssetMenu(fileName = "SO_Upgrade", menuName = "Ugrade")]
public class SO_Upgrade : ScriptableObject{
    public enum UpgradeType{FireRate, Explosion, HealthRecover, ChargeDecay, OverloadResist, ChargerSpawn, BulletSpeed, BulletForce, Teleport}
    public UpgradeType type;
    public float[] values;    
}
