using UnityEngine;
using Cinemachine;

public class ClosetControllerAndZoom : MonoBehaviour
{
    public KeyCode switchKey = KeyCode.C; // Key to switch cameras
    public KeyCode toggleBackKey = KeyCode.X; // Key to toggle back to the main camera
    public KeyCode toggleKey = KeyCode.T; // Key to toggle visibility
    public KeyCode toggleOnKey = KeyCode.Y; // Key to toggle player object on

    public CinemachineVirtualCamera mainCamera; // Reference to the main camera
    public CinemachineVirtualCamera alternateCamera; // Reference to the alternate camera

    public AudioClip toggleSound; // Audio clip to play when toggling visibility
    private AudioSource audioSource; // AudioSource component to play the sound

    private GameObject playerObject; // Reference to the player game object

    private bool isMainCameraActive = true; // Flag to track current camera state
    private bool canSwitch = false; // Flag to track if the Player can switch cameras
    private bool isVisible = true; // Flag to track visibility state
    private bool canToggle = false; // Flag to track whether the toggle key can be pressed

    private void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");

        // Add or get an AudioSource component
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Check if the toggleSound is assigned
        if (toggleSound == null)
        {
            Debug.LogWarning("Toggle sound is not assigned in the Inspector.");
        }
    }

    private void Update()
    {
        // Check if the player pressed the switch key and can switch cameras
        if (Input.GetKeyDown(switchKey) && canSwitch)
        {
            ToggleCamera(); // Toggle between main and alternate cameras
        }

        // Check if the player pressed the toggle back key
        if (Input.GetKeyDown(toggleBackKey))
        {
            ToggleBackToMainCamera(); // Toggle back to the main camera
        }

        // Check if the player pressed the toggle on key
        if (Input.GetKeyDown(toggleOnKey))
        {
            TogglePlayerOn();
        }

        // Check if the ToggleVisibility script is enabled before allowing toggling
        if (canToggle && Input.GetKeyDown(toggleKey))
        {
            ToggleVisibilityState();
        }
    }

    private void ToggleVisibilityState()
    {
        isVisible = !isVisible;
        playerObject.SetActive(isVisible);
        PlayToggleSound();
    }

    private void TogglePlayerOn()
    {
        isVisible = true;
        playerObject.SetActive(true);
        PlayToggleSound();
    }

    private void PlayToggleSound()
    {
        if (audioSource != null && toggleSound != null)
        {
            audioSource.PlayOneShot(toggleSound);
        }
        else
        {
            if (audioSource == null)
            {
                Debug.LogWarning("AudioSource component is missing.");
            }
            if (toggleSound == null)
            {
                Debug.LogWarning("Toggle sound is not assigned.");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ShowToggleMessage();
            canToggle = true; // Allow toggling when colliding
            canSwitch = true; // Allow camera switching
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            HideToggleMessage();
            canToggle = false; // Prevent toggling when not colliding
            canSwitch = false; // Disallow camera switching
        }
    }

    private void ToggleCamera()
    {
        if (isMainCameraActive)
        {
            // Switch to the alternate camera
            if (alternateCamera != null)
            {
                // Activate the alternate camera
                alternateCamera.gameObject.SetActive(true);
                // Deactivate the main camera
                if (mainCamera != null)
                {
                    mainCamera.gameObject.SetActive(false);
                }
                isMainCameraActive = false; // Update camera state
            }
            else
            {
                Debug.LogError("Alternate camera not assigned.");
            }
        }
        else
        {
            // Switch to the main camera
            if (mainCamera != null)
            {
                // Activate the main camera
                mainCamera.gameObject.SetActive(true);
                // Deactivate the alternate camera
                if (alternateCamera != null)
                {
                    alternateCamera.gameObject.SetActive(false);
                }
                isMainCameraActive = true; // Update camera state
            }
            else
            {
                Debug.LogError("Main camera not assigned.");
            }
        }
    }

    private void ToggleBackToMainCamera()
    {
        if (!isMainCameraActive)
        {
            ToggleCamera(); // Toggle back to the main camera
        }
    }

    private void ShowToggleMessage()
    {
        Debug.Log("Press " + toggleKey.ToString() + " to toggle visibility");
    }

    private void HideToggleMessage()
    {
        // You can implement this based on your UI system or game design
    }
}