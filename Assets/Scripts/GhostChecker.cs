using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TagDetector : MonoBehaviour
{
    // Specify the tags to detect and their corresponding buttons
    [System.Serializable]
    public struct TagButtonPair
    {
        public string tag;
        public Button button;
    }

    public TagButtonPair[] tagButtonPairs;
    public string sceneToLoadOnCorrect = "CorrectSceneName";
    public string sceneToLoadOnWrong = "WrongSceneName";

    public float delayBeforeScan = 3f; // Delay before performing the scan

    private bool scanCompleted = false;

    void Start()
    {
        // Start the delayed scan coroutine
        StartCoroutine(DelayedScan(delayBeforeScan));

        // Assign the button click listeners
        foreach (var pair in tagButtonPairs)
        {
            pair.button.onClick.AddListener(() => OnButtonClick(pair.tag));
        }
    }

    IEnumerator DelayedScan(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (!scanCompleted)
        {
            ScanForObject();
        }
    }

    void ScanForObject()
    {
        // Scan for each specified tag
        foreach (var pair in tagButtonPairs)
        {
            // Find all objects in the scene with the specified tag
            GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(pair.tag);

            // Check if any object with the specified tag is active in the scene
            bool tagFound = objectsWithTag.Length > 0;

            if (tagFound)
            {
                Debug.Log("Object with tag '" + pair.tag + "' detected.");
                scanCompleted = true; // Set scan completion flag
                return;
            }
        }
    }

    void OnButtonClick(string tag)
    {
        // Check if the scan has been completed
        if (scanCompleted)
        {
            Debug.Log("Correct button clicked for tag '" + tag + "'.");
            SceneManager.LoadScene(sceneToLoadOnCorrect);
        }
        else
        {
            Debug.Log("Wrong button clicked for tag '" + tag + "'.");
            SceneManager.LoadScene(sceneToLoadOnWrong);
        }
    }
}