using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRange = 20f;
    public Vector3 boxMin = new Vector3(-50f, 0f, -50f);
    public Vector3 boxMax = new Vector3(50f, 10f, 50f);
    public static int current = 0;

    public Transform player;
    public BoxCollider spawnBoxCollider;

    void Update()
    {
        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        if (current < 5)
        {
            Vector3 spawnPosition = GetRandomSpawnPosition();
            Debug.Log(spawnPosition);

            if (IsInSpawnBox(spawnPosition))
            {
                Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
                current++;
            }
        }
    }

    Vector3 GetRandomSpawnPosition()
    {
        // Get a random point within the spawn range around the player
        float x = Random.Range(player.position.x - spawnRange, player.position.x + spawnRange);
        float z = Random.Range(player.position.z - spawnRange, player.position.z + spawnRange);

        return new Vector3(x, 1.5f, z);
    }

    bool IsInSpawnBox(Vector3 position)
    {
        return position.x >= boxMin.x && position.x <= boxMax.x &&
               position.z >= boxMin.z && position.z <= boxMax.z &&
               position.y >= boxMin.y && position.y <= boxMax.y;
    }
}
