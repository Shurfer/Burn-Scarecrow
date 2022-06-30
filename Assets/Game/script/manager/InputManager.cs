using UnityEngine;

public class InputManager : MonoBehaviour
{
    Player player;

    private void Start()
    {
        player = GetComponent<Player>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Cursor.lockState = CursorLockMode.None;

        if (Input.GetKeyDown(KeyCode.Q))
            player.HandCheckToPickUp(0);

        if (Input.GetKeyDown(KeyCode.E))
            player.HandCheckToPickUp(1);

        if (Input.GetMouseButton(0))
            player.UseObjectInHand(0);
        if (Input.GetMouseButton(1))
            player.UseObjectInHand(1);
    }
}