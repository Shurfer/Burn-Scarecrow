using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private Rigidbody rigidbody;

    void Start()
    {
        Destroy(gameObject, 4);
        rigidbody.velocity = transform.forward * 40;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IDamageable _hitable))
            DamageToObject(_hitable);
    }

    void DamageToObject(IDamageable _hitable)
    {
        _hitable.GetDamage(damage);
        Destroy(gameObject);
    }
}