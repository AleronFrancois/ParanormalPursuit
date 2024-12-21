using UnityEngine;
using TMPro;

public class LightSwitchController : MonoBehaviour
{
    public KeyCode switchKey = KeyCode.E; // Change this to the key you want to use for switching the light
    public GameObject lightObject; // Reference to the GameObject representing the light
    public GameObject lightSwitchUp; // Reference to the GameObject representing the light switch in the up position
    public GameObject lightSwitchDown; // Reference to the GameObject representing the light switch in the down position
    public AudioClip toggleSound; // Sound to play when toggling the light
    public TextMeshProUGUI promptText; // Reference to the TextMeshPro UI object for the prompt
    private bool isPlayerInRange = false; // Flag to track if player is in range of the light switch
    private AudioSource audioSource; // Reference to AudioSource component for playing sound

    void Start()
    {
        // Get the AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // If AudioSource component is not attached, add it
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Player entered the trigger collider
            isPlayerInRange = true;
            Debug.Log("Press '" + switchKey + "' to toggle the light.");

            // Show prompt text
            if (promptText != null)
            {
                promptText.gameObject.SetActive(true);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Player exited the trigger collider
            isPlayerInRange = false;

            // Hide prompt text
            if (promptText != null)
            {
                promptText.gameObject.SetActive(false);
            }
        }
    }

    void Update()
    {
        // Check if player is in range and the switch key is pressed
        if (isPlayerInRange && Input.GetKeyDown(switchKey))
        {
            // Toggle the state of the light object
            if (lightObject != null)
            {
                lightObject.SetActive(!lightObject.activeSelf);
                Debug.Log("Light is now " + (lightObject.activeSelf ? "on" : "off"));

                // Play toggle sound if available
                if (toggleSound != null)
                {
                    audioSource.PlayOneShot(toggleSound);
                }

                // Toggle the state of light switch sprites
                if (lightSwitchUp != null && lightSwitchDown != null)
                {
                    lightSwitchUp.SetActive(!lightObject.activeSelf);
                    lightSwitchDown.SetActive(lightObject.activeSelf);
                }
            }
        }
    }
}
