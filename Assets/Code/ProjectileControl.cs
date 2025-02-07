using UnityEngine;

public class ProjectileControl : MonoBehaviour
{
    public ParticleSystem fireEffect;

    void Start()
    {
        var collisionModule = fireEffect.collision;
        collisionModule.enabled = true;
        collisionModule.type = ParticleSystemCollisionType.World;
    }

    void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Fire particle hit Enemy!");

            // Apply damage to the building
            EnemyControls Enemy = other.GetComponent<EnemyControls>();
            if (Enemy != null)
            {
                Enemy.ApplyDamage(2f);
            }
        }
    }
}
