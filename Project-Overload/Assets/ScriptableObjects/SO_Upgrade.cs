using UnityEngine;

[CreateAssetMenu(fileName = "SO_Upgrade", menuName = "Ugrade")]
public class SO_Upgrade : ScriptableObject{
    public enum UpgradeType{FireRate, Explosion, HealthRecover, ChargeDecay, OverloadResist, ChargerRadius, BulletSpeed, BulletForce, Teleport}
    public UpgradeType type;
    public string upgradeName;
    public string description;
    public float[] values;
}