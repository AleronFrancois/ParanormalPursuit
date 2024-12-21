using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FlickeringLight : MonoBehaviour
{
    public Light2D light2D;
    public float minIntensity = 0.5f;
    public float maxIntensity = 1.0f;
    public float flickerSpeed = 1.0f;

    private float randomOffset;

    void Start()
    {
        // Set a random offset to add some variation in flickering pattern
        randomOffset = Random.Range(0f, 100f);
    }

    void Update()
    {
        // Calculate flicker intensity using Perlin noise
        float flickerIntensity = Mathf.PerlinNoise(Time.time * flickerSpeed + randomOffset, 0f);
        // Map the Perlin noise value to the intensity range
        flickerIntensity = Mathf.Lerp(minIntensity, maxIntensity, flickerIntensity);

        // Apply the flicker intensity to the light
        light2D.intensity = flickerIntensity;
    }
}
