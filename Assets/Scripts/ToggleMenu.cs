using UnityEngine;

public class ToggleObjectOnKey : MonoBehaviour
{
    // The key to toggle the specified object
    public KeyCode toggleKey = KeyCode.Space;

    // The object to toggle on
    public GameObject objectToToggleOn;

    // The object to toggle off
    public GameObject objectToToggleOff;

    void Update()
    {
        // Check if the specified key is pressed
        if (Input.GetKeyDown(toggleKey))
        {
            // If the object to toggle on is not active, activate it
            if (!objectToToggleOn.activeSelf)
            {
                objectToToggleOn.SetActive(true);
            }
            // If the object to toggle off is active, deactivate it
            if (objectToToggleOff.activeSelf)
            {
                objectToToggleOff.SetActive(false);
            }
        }
    }
}