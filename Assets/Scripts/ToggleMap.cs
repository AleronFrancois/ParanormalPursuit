using UnityEngine;

public class ToggleMapOnKey : MonoBehaviour
{
    // The key to toggle the object
    public KeyCode toggleMapKey = KeyCode.Space;

    // The object to toggle
    public GameObject objectToToggle;

    void Update()
    {
        // Check if the specified key is pressed
        if (Input.GetKeyDown(toggleMapKey))
        {
            // Toggle the active state of the object
            objectToToggle.SetActive(!objectToToggle.activeSelf);
        }
    }
}