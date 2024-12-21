using UnityEngine;

public class ClosetPromptController : MonoBehaviour
{
    public GameObject objectToToggle; // Reference to the object to toggle

    private void Start()
    {
        // Check if the object is assigned at the start
        if (objectToToggle == null)
        {
            Debug.LogError("Object to toggle is not assigned in the Inspector!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Check if the specified object exists
            if (objectToToggle != null)
            {
                // Turn on the specified object
                objectToToggle.SetActive(true);
            }
            else
            {
                Debug.LogError("Object to toggle is not assigned!");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Check if the specified object exists
            if (objectToToggle != null)
            {
                // Turn off the specified object
                objectToToggle.SetActive(false);
            }
            else
            {
                Debug.LogError("Object to toggle is not assigned!");
            }
        }
    }
}