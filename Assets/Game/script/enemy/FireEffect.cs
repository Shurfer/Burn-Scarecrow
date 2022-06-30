using System.Collections;
using UnityEngine;

public class FireEffect : MonoBehaviour, IFireable
{
    [SerializeField] ParticleSystem[] particles;

     Enemy enemy;
     IWaterable _waterable;

    bool burn;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
        _waterable = GetComponent<IWaterable>();
    }

    public void FireDamage(int damage)
    {
        if (_waterable.DecreaseWet(damage) <= 0)
        {
            enemy.DecreaseHealth(damage);
            if (!burn)
                BurnOn();
        }
    }

    void BurnOn()
    {
        burn = true;
        for (int i = 0; i < particles.Length; i++)
        {
            particles[i].Play();
        }

        StartCoroutine(timerToFireOff());
        StartCoroutine(timerToFireDamage());
    }

    public void StopBurn()
    {
        if (burn)
        {
            burn = false;
            StopAllCoroutines();

            for (int i = 0; i < particles.Length; i++)
            {
                particles[i].Stop();
            }
        }
    }

    IEnumerator timerToFireDamage()
    {
        yield return new WaitForSeconds(1);
        if (burn)
        {
            enemy.DecreaseHealth(2);
            StartCoroutine(timerToFireDamage());
        }
    }

    IEnumerator timerToFireOff()
    {
        yield return new WaitForSeconds(10);
        burn = false;
    }
}