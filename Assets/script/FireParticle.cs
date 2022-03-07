using UnityEngine;

public class FireParticle : MonoBehaviour
{
    int damage;

    void OnParticleCollision(GameObject other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
            enemy.FireOn(StaticScript.fireParticleDamage);
    }
}