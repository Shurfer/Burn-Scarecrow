
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameSettings gameSettings;

    private void Start()
    {
        PlayerPrefs.SetInt("level",5);
        
        int level =  PlayerPrefs.GetInt("level",0);
        
        StaticScript.bulletDamage = gameSettings.bulletDamage;
        StaticScript.bulletWaterDamage = gameSettings.bulletWaterDamage;
        StaticScript.fireParticleDamage = gameSettings.particleFireDamage;
    }
}
