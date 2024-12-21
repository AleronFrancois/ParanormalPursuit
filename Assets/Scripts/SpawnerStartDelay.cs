using UnityEngine;

public class ComponentActivator : MonoBehaviour
{
    public Behaviour componentToActivate; // Reference to the component to activate
    public float activationDelay = 2f; // Delay before activating the component

    void Start()
    {
        // Call the ActivateComponent method after the specified delay
        Invoke("ActivateComponent", activationDelay);
    }

    void ActivateComponent()
    {
        // Check if the component is not null and is currently disabled
        if (componentToActivate != null && !componentToActivate.enabled)
        {
            // Enable the component
            componentToActivate.enabled = true;
        }
    }
}