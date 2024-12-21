using System.Collections;
using UnityEngine;

public class ObjectActivator : MonoBehaviour
{
    public GameObject objectToToggle;
    public float startTime = 2f; // Time to start toggling the object (in seconds)
    public float duration = 5f; // Duration for which the object will be active (in seconds)

    void Start()
    {
        // Start the coroutine to toggle the object
        StartCoroutine(ToggleObject());
    }

    IEnumerator ToggleObject()
    {
        yield return new WaitForSeconds(startTime);

        // Toggle the object on
        objectToToggle.SetActive(true);

        // Wait for the specified duration
        yield return new WaitForSeconds(duration);

        // Toggle the object off
        objectToToggle.SetActive(false);
    }
}