using UnityEngine;

public class ScreenCentreRayProvider : MonoBehaviour, IRayProvider
{
    Vector2 screenCenterPoint;

    private void Start()
    {
        screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
    }

    public Ray CreateRay()
    {
        return Camera.main.ScreenPointToRay(screenCenterPoint); 
    }
}