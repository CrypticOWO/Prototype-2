using UnityEngine;

public class ParticleSystemSelfDestruct : MonoBehaviour
{
    void Start()
    {
        // Destroy the GameObject after 0.5 seconds
        Destroy(gameObject, 0.45f);
    }
}
