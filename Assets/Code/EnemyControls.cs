using UnityEngine;

public class EnemyControls : MonoBehaviour
{
    public float LaunchForce = 30f;
    public float MinSpinForce = 500f; // Minimum value for the spin force
    public float MaxSpinForce = 1000f; // Maximum value for the spin force
    public GameObject ExplosionEffectPreFab;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody enemyRb = GetComponent<Rigidbody>();
            
            if (enemyRb != null)
            {
                Vector3 launchDirection = transform.position - collision.transform.position;
                launchDirection.y = 0.5f;

                enemyRb.AddForce(launchDirection.normalized * LaunchForce, ForceMode.Impulse);

                // Apply random spin force between MinSpinForce and MaxSpinForce for all axes
                float randomSpinValue = Random.Range(MinSpinForce, MaxSpinForce);
                Vector3 spinForce = new Vector3(randomSpinValue, randomSpinValue, randomSpinValue);
                enemyRb.AddTorque(spinForce, ForceMode.Impulse);
            }
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            Instantiate(ExplosionEffectPreFab, transform.position, Quaternion.identity);
            EnemySpawner.current--;
            Destroy(gameObject);
        }
    }
}
