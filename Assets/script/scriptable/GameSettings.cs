using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Scriptable/GameSettings", order = 1)]

public class GameSettings : ScriptableObject
{
    public int startHealthEnemy;
    public float nextShootTime;
    public int bulletDamage; 
    public int bulletWaterDamage; 
    public int maxWaterValue;
    public int particleFireDamage; 
    public int burnDamage;
}
