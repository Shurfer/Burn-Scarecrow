using UnityEngine;

public class WaterBall : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] ParticleSystem particle;
     int damage;

    void Start()
    {
        damage = StaticScript.bulletWaterDamage;
        Destroy(gameObject, 10);
        rigidbody.velocity = transform.forward * 10 + transform.up * 3;
    }

    public GameObject sphere;

    private void OnTriggerEnter(Collider other)
    {
        rigidbody.isKinematic = true;
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
            enemy.WaterDamage(damage);

        sphere.SetActive(false);
        particle.Play();
        Destroy(gameObject, 2);
    }
}