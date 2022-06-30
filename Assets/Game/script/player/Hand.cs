using UnityEngine;

public class Hand : MonoBehaviour
{
    Transform handObject;
    IUseable _useble;

    public void HandCheck(Transform pickUpObject)
    {
        if (handObject)
        {
            handObject.parent = null;
            handObject = null;
        }
        else if (pickUpObject != null)
        {
            handObject = pickUpObject;
            ObjectInHand();
        }
    }

    public void ObjectInHand()
    {
        handObject.SetParent(transform);
        handObject.localPosition = Vector3.zero;
        handObject.localRotation = Quaternion.Euler(0, 0, 0);
    }

    public void UseObject()
    {
        if (handObject)
        {
            _useble = handObject.GetComponent<IUseable>();
            _useble.Use();
        }
    }
}