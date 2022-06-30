using UnityEngine;

public class FireStone : MonoBehaviour, IUseable
{
    [SerializeField] ParticleSystem particle;
    [SerializeField]  Renderer[] rendererParticle;
    private void Start()
    {
        for (int i = 0; i < rendererParticle.Length; i++)
        {
            Material fire = rendererParticle[i].material;
            rendererParticle[i].materials = new Material[1];
            rendererParticle[i].material = fire;
        }
    }

    public void Use()
    {
        particle.Play();
    }
}