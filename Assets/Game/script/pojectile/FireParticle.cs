using UnityEngine;

public class FireParticle : MonoBehaviour
{
    [SerializeField]  int damage;
    
    void OnParticleCollision(GameObject other)
    {
        if (other.TryGetComponent(out IFireable _fireble))
            ActivateFire(_fireble);
    }

    void ActivateFire(IFireable _fireble)
    {
        _fireble.FireDamage(damage);
    }
}