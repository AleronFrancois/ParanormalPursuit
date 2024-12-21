using UnityEngine;

public class ToggleOtherGameObjectVisibility : MonoBehaviour
{
    public KeyCode toggleKey = KeyCode.T; // Default toggle key is 'T'
    public GameObject[] objectsToToggle; // References to the GameObjects to toggle visibility

    void Update()
    {
        // Check for keyboard input to toggle object visibility
        if (Input.GetKeyDown(toggleKey) && objectsToToggle != null)
        {
            ToggleVisibility();
        }
    }

    void ToggleVisibility()
    {
        // Check the state of the first object to determine the desired state for toggling
        bool newState = !objectsToToggle[0].activeSelf;

        // Toggle the visibility of each GameObject in the array
        foreach (GameObject obj in objectsToToggle)
        {
            if (obj != null)
            {
                obj.SetActive(newState);
            }
        }
    }
}