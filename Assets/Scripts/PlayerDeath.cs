using UnityEngine;
using UnityEngine.SceneManagement;

public class PrefabCollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collided object is the player
        if (collision.gameObject.CompareTag("Player"))
        {
            TurnOffPlayer(collision.gameObject);
        }
    }

    private void TurnOffPlayer(GameObject player)
    {
        // Disable the player object
        player.SetActive(false);
        Debug.Log("Player turned off!"); // Log a message indicating player has turned off

        // Load the specified scene
        SceneManager.LoadScene("You Died");
    }
}