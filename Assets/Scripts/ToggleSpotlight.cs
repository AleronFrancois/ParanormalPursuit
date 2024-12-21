using UnityEngine;
using UnityEngine.Rendering.Universal;
using System.Collections.Generic;

public class ToggleSpotlight : MonoBehaviour
{
    public List<Light2D> spotlights = new List<Light2D>(); // List of 2D Spotlights
    public AudioClip toggleSound; // Sound effect to play when toggling spotlight
    private AudioSource audioSource; // AudioSource component to play the sound effect

    public KeyCode toggleKey = KeyCode.Space; // Key to toggle the spotlight (default is Space)

    void Start()
    {
        // Ensure at least one spotlight component is assigned in the Inspector
        if (spotlights.Count == 0)
        {
            Debug.LogError("No spotlight components are assigned.");
        }

        // Add AudioSource component to this GameObject if not already present
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        // Check for input to toggle the spotlight using the specified key
        if (Input.GetKeyDown(toggleKey))
        {
            ToggleLights();
        }
    }

    void ToggleLights()
    {
        // Toggle the enabled state of each spotlight in the list
        foreach (var spotlight in spotlights)
        {
            spotlight.enabled = !spotlight.enabled;
        }

        // Play the toggle sound effect if assigned
        if (toggleSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(toggleSound);
        }

        // Print message to console indicating spotlight state
        foreach (var spotlight in spotlights)
        {
            if (spotlight.enabled)
            {
                Debug.Log(spotlight.name + " is ON");
            }
            else
            {
                Debug.Log(spotlight.name + " is OFF");
            }
        }
    }
}