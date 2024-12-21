using UnityEngine;

public class ObjectMoveOnTrigger : MonoBehaviour
{
    public GameObject objectToMove; // Reference to the GameObject to move
    public Vector2 startPoint; // Starting point for the movement
    public Vector2 endPoint; // Ending point for the movement
    public float moveSpeed = 2.0f; // Speed at which the object moves
    public AudioClip startMovingSound; // Sound to play when the object starts moving

    private bool isMoving = false; // Flag to track if the object is currently moving
    private float startTime; // Time when movement started
    private AudioSource audioSource; // Reference to AudioSource component for playing sound

    void Start()
    {
        // Get or add AudioSource component to objectToMove
        audioSource = objectToMove.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = objectToMove.AddComponent<AudioSource>();
        }

        // Preload the audio clip if available
        if (startMovingSound != null)
        {
            audioSource.clip = startMovingSound;
            audioSource.playOnAwake = false;
            audioSource.volume = 1.0f; // Adjust volume as needed
            audioSource.loop = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isMoving)
        {
            // Play start moving sound if available
            if (startMovingSound != null)
            {
                audioSource.PlayOneShot(startMovingSound);
            }
            else
            {
                Debug.LogWarning("Start moving sound is not assigned.");
            }

            // Start moving the object
            StartMoving();
        }
    }

    void StartMoving()
    {
        if (objectToMove != null && !isMoving)
        {
            isMoving = true;
            startTime = Time.time;
        }
    }

    void Update()
    {
        if (isMoving)
        {
            // Calculate the distance covered by the object based on time and speed
            float distanceCovered = (Time.time - startTime) * moveSpeed;

            // Calculate the fraction of distance covered relative to total distance
            float fractionOfDistance = distanceCovered / Vector2.Distance(startPoint, endPoint);

            // Clamp the fraction between 0 and 1
            fractionOfDistance = Mathf.Clamp01(fractionOfDistance);

            // Interpolate between start and end points to get the current position
            objectToMove.transform.position = Vector2.Lerp(startPoint, endPoint, fractionOfDistance);

            // Check if the object has reached the end point
            if (fractionOfDistance >= 1.0f)
            {
                // Object has reached the end point, destroy it
                Destroy(objectToMove);
                Destroy(gameObject); // Destroy the script's gameObject
                isMoving = false;
            }
        }
    }
}
