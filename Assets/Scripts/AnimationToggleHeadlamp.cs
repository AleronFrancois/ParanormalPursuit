using UnityEngine;

public class AnimationToggleObject : MonoBehaviour
{
    public GameObject objectToToggle;
    public AnimationClip animationClip;
    public float toggleDelayMillis = 1000f; // Delay in milliseconds

    private Animator animator;
    private bool objectActive;
    private float toggleTimer;

    void Start()
    {
        animator = GetComponent<Animator>();
        objectActive = false;
        toggleTimer = 0f;
    }

    void Update()
    {
        // Check if the specified animation clip is playing
        bool clipIsPlaying = false;
        foreach (var clipInfo in animator.GetCurrentAnimatorClipInfo(0))
        {
            if (clipInfo.clip == animationClip)
            {
                clipIsPlaying = true;
                break;
            }
        }

        // If the specified animation clip is playing, start the delay timer
        if (clipIsPlaying)
        {
            toggleTimer += Time.deltaTime * 1000f; // Convert seconds to milliseconds
            if (toggleTimer >= toggleDelayMillis && !objectActive)
            {
                objectToToggle.SetActive(true);
                objectActive = true;
            }
        }
        else
        {
            // Reset the timer if the clip is not playing
            toggleTimer = 0f;

            // If the object was active and the clip is not playing, toggle it off
            if (objectActive)
            {
                objectToToggle.SetActive(false);
                objectActive = false;
            }
        }
    }
}