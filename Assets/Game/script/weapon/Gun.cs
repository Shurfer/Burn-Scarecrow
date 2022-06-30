
using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour, IUseable
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float nextShootTime;
    bool nextShoot=true;

    public void Use()
    {
        Shooting();
    }

    public void Shooting()
    {
        if (nextShoot)
        {
            nextShoot = false;
            Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
            StartCoroutine(timerNextShoot());
        }
    }

    IEnumerator timerNextShoot()
    {
        yield return new WaitForSeconds(nextShootTime);
        nextShoot = true;
    }
}