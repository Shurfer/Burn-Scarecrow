using UnityEngine;

public class WaterBall : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] Rigidbody rigidbody;
    [SerializeField] ParticleSystem particle;
    [SerializeField] GameObject sphere;


    void Start()
    {
        Destroy(gameObject, 10);
        rigidbody.velocity = transform.forward * 10 + transform.up * 3;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IWaterable _waterable))
            _waterable.IncreaseWet(damage);

        BurstWaterBall();
    }

    void BurstWaterBall()
    {
        rigidbody.isKinematic = true;
        sphere.SetActive(false);
        particle.Play();
        Destroy(gameObject, 2);
    }
}