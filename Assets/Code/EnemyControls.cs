using UnityEngine;

public class EnemyControls : MonoBehaviour
{
    public float health = 100;
    private Renderer enemyRenderer;

    void Start()
    {
        enemyRenderer = GetComponent<Renderer>();
    }

    public void ApplyDamage(float damageAmount)
    {
        health -= damageAmount;
        Debug.Log("Enemy hit! Health: " + health);

        // Change the Enemy's material to black when it takes damage
        if (health <= 0)
        {
            if (enemyRenderer != null)
            {
                enemyRenderer.material.color = Color.black;
            }
        }
    }
}
