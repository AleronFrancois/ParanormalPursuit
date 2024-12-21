using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioClip audioClip;
    public float playAtTime = 5.0f; // Time in seconds to play the audio clip

    private bool hasPlayed = false;

    void Start()
    {
        // Calculate the absolute time at which to play the audio clip
        playAtTime += Time.time;
    }

    void Update()
    {
        // Check if the audio clip should be played and hasn't been played yet
        if (!hasPlayed && Time.time >= playAtTime)
        {
            PlayAudioClip();
            hasPlayed = true;
        }
    }

    void PlayAudioClip()
    {
        if (audioClip != null)
        {
            AudioSource.PlayClipAtPoint(audioClip, transform.position);
        }
        else
        {
            Debug.LogError("Audio clip not assigned to AudioPlayer script!");
        }
    }
}