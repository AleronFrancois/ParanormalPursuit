using UnityEngine;

public class PlayLoopingSoundOnTrigger : MonoBehaviour
{
    public string[] triggeringTags; // Array of tags of the specified objects that trigger the sound
    public AudioClip[] loopSounds; // Array of audio clips to play when the object enters the trigger
    public bool loopContinuously = true; // Whether to loop the audio continuously

    private AudioSource[] audioSources; // Array of AudioSources for each loop sound
    private bool[] isPlaying; // Array to track if each audio clip is currently playing

    private void Start()
    {
        // Create AudioSource components for each loop sound
        audioSources = new AudioSource[loopSounds.Length];
        isPlaying = new bool[loopSounds.Length];
        for (int i = 0; i < loopSounds.Length; i++)
        {
            audioSources[i] = gameObject.AddComponent<AudioSource>();
            audioSources[i].clip = loopSounds[i];
            audioSources[i].playOnAwake = false;
            audioSources[i].loop = loopContinuously;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object entering the trigger has any of the specified tags
        foreach (string tag in triggeringTags)
        {
            if (other.CompareTag(tag))
            {
                // Start playing each loop sound if not already playing
                for (int i = 0; i < loopSounds.Length; i++)
                {
                    if (!isPlaying[i])
                    {
                        audioSources[i].Play();
                        isPlaying[i] = true;
                    }
                }
                break; // Exit the loop once a matching tag is found
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Check if the object exiting the trigger has any of the specified tags
        foreach (string tag in triggeringTags)
        {
            if (other.CompareTag(tag))
            {
                // Stop playing each loop sound if playing
                for (int i = 0; i < loopSounds.Length; i++)
                {
                    if (isPlaying[i])
                    {
                        audioSources[i].Stop();
                        isPlaying[i] = false;
                    }
                }
                break; // Exit the loop once a matching tag is found
            }
        }
    }
}
