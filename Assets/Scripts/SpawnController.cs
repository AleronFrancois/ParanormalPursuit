using UnityEngine;

public class RandomPrefabSpawner : MonoBehaviour
{
    public GameObject[] prefabsToSpawn;
    public float respawnDelay = 2f;
    public float despawnDelay = 5f;
    public AudioClip spawnAudioClip; // New variable to hold the spawn audio clip

    private GameObject spawnedPrefab;
    private int firstSpawnIndex = -1;
    private AudioSource audioSource; // Reference to AudioSource component

    void Start()
    {
        // Initialize the random seed to make randomness across game restarts
        Random.InitState(System.DateTime.Now.Millisecond);

        // Get the AudioSource component attached to the GameObject or add one if it doesn't exist
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();

        // Start spawning
        Invoke("SpawnPrefab", 0f);
    }

    void SpawnPrefab()
    {
        if (prefabsToSpawn.Length == 0)
        {
            Debug.LogError("No prefabs assigned to the prefabsToSpawn array.");
            return;
        }

        // Choose the prefab for the first spawn
        if (firstSpawnIndex == -1)
        {
            firstSpawnIndex = Random.Range(0, prefabsToSpawn.Length);
            spawnedPrefab = Instantiate(prefabsToSpawn[firstSpawnIndex], transform.position, Quaternion.identity);
        }
        else
        {
            // Spawn the same prefab as the first spawn
            spawnedPrefab = Instantiate(prefabsToSpawn[firstSpawnIndex], transform.position, Quaternion.identity);
        }

        // Play the spawn audio clip
        if (spawnAudioClip != null && audioSource != null)
        {
            audioSource.clip = spawnAudioClip;
            audioSource.Play();
        }

        // Schedule despawn
        Invoke("DespawnPrefab", despawnDelay);
    }

    void DespawnPrefab()
    {
        // Destroy the spawned prefab
        if (spawnedPrefab != null)
            Destroy(spawnedPrefab);

        // Schedule next spawn
        Invoke("SpawnPrefab", respawnDelay);
    }
}