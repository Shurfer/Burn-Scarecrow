using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameSettings gameSettings;

    [SerializeField] LayerMask aimColliderLayerMask = new LayerMask();

    [SerializeField] Transform[] handsTr;

    ParticleSystem[] effects = new ParticleSystem[2];
    Transform[] spawnPoints = new Transform[2];

    Transform pickupObject;
    Transform pickUps;

    GameObject[] bulletPrefab;

    bool[] nextShoot;

    IEnumerator[] nextShootCoroutine;

    Vector2 screenCenterPoint;
    Ray ray;

    private void Start()
    {
        spawnPoints = new Transform[2];
        effects = new ParticleSystem[2];
        nextShoot = new bool[2];
        nextShoot[0] = true;
        nextShoot[1] = true;
        bulletPrefab = new GameObject[2];
        nextShootCoroutine = new IEnumerator[2];
        nextShootCoroutine[0] = timerNextShootLeft();
        nextShootCoroutine[1] = timerNextShootRight();
    }

    public void Fire(int side)
    {
        if (spawnPoints[side] != null && nextShoot[side])
        {
            nextShoot[side] = false;
            nextShootCoroutine[0] = timerNextShootLeft();
            nextShootCoroutine[1] = timerNextShootRight();
            Instantiate(bulletPrefab[side], spawnPoints[side].position, spawnPoints[side].rotation);
            StartCoroutine(nextShootCoroutine[side]);
        }
        if (effects[side] != null && !effects[side].isPlaying)
            effects[side].Play();
    }

    IEnumerator timerNextShootLeft()
    {
        yield return new WaitForSeconds(gameSettings.nextShootTime); 
        nextShoot[0] = true;
    }

    IEnumerator timerNextShootRight()
    {
        yield return new WaitForSeconds(gameSettings.nextShootTime); 
        nextShoot[1] = true;
    }

    void HandCheck(int side)
    {
        if (handsTr[side].childCount == 0)
        {
            if (pickupObject != null)
            {
                if (pickUps == null)
                    pickUps = pickupObject.parent;
                Transform handObject = pickupObject;
                handObject.SetParent(handsTr[side]);
                handObject.localPosition = Vector3.zero;
                handObject.localRotation = Quaternion.Euler(0, 0, 0);
                effects[side] = null;
                spawnPoints[side] = null;
                effects[side] = handObject.GetComponentInChildren<ParticleSystem>();
                if (effects[side] == null)
                {
                    spawnPoints[side] = handObject.Find("spawnPoint");
                    nextShoot[side] = true;
                    bulletPrefab[side] = handObject.GetComponent<ProjectileGun>().bulletPrefab;
                }
            }
        }
        else
        {
            handsTr[side].GetChild(0).SetParent(pickUps);
        }
    }

    void Update()
    {
        screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask))
        {
            handsTr[0].LookAt(raycastHit.point);
            handsTr[1].LookAt(raycastHit.point);
            if (raycastHit.transform.gameObject.layer == 3)
                pickupObject = raycastHit.transform;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
            Cursor.lockState = CursorLockMode.None;

        if (Input.GetKeyDown(KeyCode.Q))
            HandCheck(0);

        if (Input.GetKeyDown(KeyCode.E))
            HandCheck(1);

        if (Input.GetMouseButton(0))
            Fire(0);
        if (Input.GetMouseButton(1))
            Fire(1);

        if (Input.GetMouseButtonUp(0) && effects[0] != null)
            effects[0].Stop();

        if (Input.GetMouseButtonUp(1) && effects[1] != null)
            effects[1].Stop();
    }
}