using UnityEngine;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour
{
    [SerializeField] int maxWater;
    [SerializeField] Slider healthSlider;
    [SerializeField] Slider wetSlider;
    Enemy enemy;

    void Start()
    {
        enemy = GetComponent<Enemy>();

        healthSlider.maxValue = enemy.health; // = gameSettings.startHealthEnemy;
        healthSlider.value = enemy.health;
        wetSlider.maxValue = maxWater;
    }

    public void ChangeHealthSlider(int health)
    {
        healthSlider.value = health;
    }
    
    public void ChangeWaterSlider(int wet)
    {
        wetSlider.value = wet;
    }
}