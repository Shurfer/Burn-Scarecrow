using UnityEngine;

public class WaterEffect : MonoBehaviour, IWaterable
{
    EnemyUI enemyUI;

    IFireable _fireble;
    int wet;

    private void Start()
    {
        _fireble = GetComponent<IFireable>();
        enemyUI = GetComponent<EnemyUI>();
    }

    public void IncreaseWet(int damage)
    {
        if (wet < 100)
        {
            wet += damage;
            ApplyWetSlider();
            _fireble.StopBurn();
        }
    }

    public int DecreaseWet(int damage)
    {
        if (wet > 0)
        {
            wet -= damage;
            ApplyWetSlider();
        }

        return wet;
    }

    void ApplyWetSlider()
    {
        enemyUI.ChangeWaterSlider(wet);
    }
}