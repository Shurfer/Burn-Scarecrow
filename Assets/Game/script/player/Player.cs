using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Hand[] hands;

    Transform pickUpObject;

    public void HandCheckToPickUp(int side)
    {
        hands[side].HandCheck(pickUpObject);
    }

    public void UseObjectInHand(int side)
    {
        hands[side].UseObject();
    }

    public void GetObjectTransform(Transform pickUpObject)
    {
        this.pickUpObject = pickUpObject;
    }
}