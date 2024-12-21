using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioListenerFollow : MonoBehaviour
{
    public Transform playerTransform;

    void Update()
    {
        // Ensure playerTransform is not null and move Audio Listener to player's position
        if (playerTransform != null)
        {
            transform.position = playerTransform.position;
        }
    }
}