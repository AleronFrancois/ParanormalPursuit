using UnityEngine;
using UnityEngine.UI;

public class ToggleImagesOnKeyPress : MonoBehaviour
{
    public KeyCode toggleKey = KeyCode.B; // Key to trigger the toggle
    public Image topImage; // Reference to the top child Image
    public Image bottomImage; // Reference to the bottom child Image

    private bool isTopImageVisible = true; // Track the visibility state of the top image

    void Start()
    {
        // Ensure both images are initially enabled/disabled as desired
        if (topImage != null)
        {
            topImage.enabled = isTopImageVisible; // Enable the top image initially
        }

        if (bottomImage != null)
        {
            bottomImage.enabled = !isTopImageVisible; // Disable the bottom image initially
        }
    }

    void Update()
    {
        // Check for keyboard input to toggle images
        if (Input.GetKeyDown(toggleKey))
        {
            ToggleImages();
        }
    }

    void ToggleImages()
    {
        // Toggle the visibility of the images
        if (topImage != null && bottomImage != null)
        {
            isTopImageVisible = !isTopImageVisible; // Toggle the visibility state

            topImage.enabled = isTopImageVisible; // Enable/disable the top image
            bottomImage.enabled = !isTopImageVisible; // Enable/disable the bottom image
        }
    }
}