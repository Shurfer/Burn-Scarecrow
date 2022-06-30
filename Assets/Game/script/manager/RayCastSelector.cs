using UnityEngine;

public class RayCastSelector : MonoBehaviour, ISelector
{
    [SerializeField] LayerMask aimColliderLayerMask = new LayerMask();

    [HideInInspector] public Transform _selection;
    [SerializeField] Player player;
    
    public void Check(Ray ray)
    {
        _selection = null;
        player.GetObjectTransform(null);
        if (Physics.Raycast(ray, out var raycastHit, 999f, this.aimColliderLayerMask))
        {
            _selection = raycastHit.transform;
            player.GetObjectTransform(_selection);
        }
    }

    public Transform GetSelection()
    {
        return _selection;
    }
}