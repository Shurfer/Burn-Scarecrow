using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] internal int health;
    [SerializeField]  GameObject model;
    EnemyUI enemyUI;
    private void Start()
    {
        enemyUI = GetComponent<EnemyUI>();
    }

    public void IncreaseHealth(int heal)
    {
        health += heal;
    }

    public void DecreaseHealth(int damage)
    {
        health -= damage;
        ApplyHealthSlider();
        if (health <= 0)
            Death();
    }
    
    void ApplyHealthSlider()
    {
        enemyUI.ChangeHealthSlider(health);
    }

    void Death()
    {
        model.SetActive(false);
    }
}