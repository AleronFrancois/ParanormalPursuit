using UnityEngine;

public class EnemyChaseAndAvoid : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public LayerMask obstacleLayer; // Layer mask for obstacles
    public float moveSpeed = 3f; // Speed at which the enemy moves towards the player
    public float avoidanceRayLength = 2f; // Length of raycasts for obstacle avoidance
    public float avoidanceForce = 5f; // Force to steer away from obstacles

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (player == null)
        {
            // If player reference is null, do nothing
            return;
        }

        // Calculate direction towards the player
        Vector2 direction = (player.position - transform.position).normalized;

        // Raycast to detect obstacles in front of the enemy
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, avoidanceRayLength, obstacleLayer);

        // If obstacle detected, calculate avoidance force
        if (hit.collider != null)
        {
            Vector2 avoidanceDirection = (hit.point - (Vector2)transform.position).normalized;
            direction += avoidanceDirection * avoidanceForce;
        }

        // Move towards the calculated direction
        rb.velocity = direction * moveSpeed;

        // Flip the enemy sprite based on movement direction (optional)
        if (direction.x > 0)
        {
            // Face right
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (direction.x < 0)
        {
            // Face left
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }
}