using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class LoadingScreenController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string levelToLoad;
    public KeyCode skipKey = KeyCode.Space; // Change this to any key you want to use for skipping

    void Start()
    {
        string videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, "Paranormal Pursuit Loading Screen 2.mp4");
        videoPlayer.url = videoPath;
        videoPlayer.loopPointReached += OnVideoFinished;
    }

    void Update()
    {
        // Check if the skip key is pressed
        if (Input.GetKeyDown(skipKey))
        {
            LoadScene();
        }
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        // Load the scene when the video finishes playing
        LoadScene();
    }

    void LoadScene()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}