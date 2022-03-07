using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody;
    int damage;

    void Start()
    {
        damage = StaticScript.bulletDamage;
        Destroy(gameObject, 4);
        rigidbody.velocity = transform.forward * 40;
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemySc = other.gameObject.GetComponentInParent<Enemy>();
        if (enemySc != null)
            enemySc.Hit(damage);
        Destroy(gameObject);
    }
}