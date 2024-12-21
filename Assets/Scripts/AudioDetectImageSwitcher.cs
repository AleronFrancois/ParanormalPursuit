using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ToggleImagesOnAudioDetection : MonoBehaviour
{
    public Image topImage; // Reference to the top child Image
    public Image bottomImage; // Reference to the bottom child Image

    private bool isTopImageVisible = true; // Track the visibility state of the top image

    private Coroutine imageSwitchCoroutine; // Coroutine reference for controlling image switching

    private AudioSource audioSource; // Reference to the AudioSource component on this GameObject

    private List<AudioSource> ignoredAudioSources = new List<AudioSource>(); // List of audio sources to ignore during detection

    void Start()
    {
        // Ensure both images are initially enabled/disabled as desired
        SetImageVisibility();

        // Get the AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Check for audible audio sources in the scene
        if (IsAudioDetected())
        {
            // Start coroutine to switch to bottom image for at least 1 second
            if (imageSwitchCoroutine == null)
            {
                imageSwitchCoroutine = StartCoroutine(SwitchToBottomImageForDuration(1f));
            }
        }
    }

    void SetImageVisibility()
    {
        // Set the visibility of the images based on the current state
        if (topImage != null)
        {
            topImage.enabled = isTopImageVisible; // Enable/disable top image based on state
        }

        if (bottomImage != null)
        {
            bottomImage.enabled = !isTopImageVisible; // Enable/disable bottom image based on state
        }
    }

    bool IsAudioDetected()
    {
        // Check if any audio sources are audible to the AudioListener
        AudioSource[] audioSources = FindObjectsOfType<AudioSource>();

        foreach (AudioSource source in audioSources)
        {
            if (!ignoredAudioSources.Contains(source) && source.isPlaying && IsAudible(source))
            {
                return true; // Audible audio source detected
            }
        }

        return false; // No audible audio sources detected
    }

    bool IsAudible(AudioSource audioSource)
    {
        // Check if the given audio source is audible to the AudioListener
        if (audioSource == null)
            return false;

        AudioListener listener = FindObjectOfType<AudioListener>();

        if (listener == null)
            return false;

        float distance = Vector3.Distance(audioSource.transform.position, listener.transform.position);
        return distance <= audioSource.maxDistance;
    }

    IEnumerator SwitchToBottomImageForDuration(float duration)
    {
        // Toggle to bottom image
        isTopImageVisible = false;
        SetImageVisibility();

        // Activate the AudioSource component attached to this GameObject
        if (audioSource != null)
        {
            audioSource.enabled = true;
        }

        // Wait for specified duration
        yield return new WaitForSeconds(duration);

        // Toggle back to top image after delay
        isTopImageVisible = true;
        SetImageVisibility();

        // Deactivate the AudioSource component to prevent detection during image switching
        if (audioSource != null)
        {
            audioSource.enabled = false;
        }

        // Reset coroutine reference
        imageSwitchCoroutine = null;
    }

    public void IgnoreAudioSource(AudioSource source)
    {
        // Add the specified AudioSource to the list of ignored audio sources
        if (!ignoredAudioSources.Contains(source))
        {
            ignoredAudioSources.Add(source);
        }
    }
}