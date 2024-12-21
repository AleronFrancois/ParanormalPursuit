using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float rotationSpeed = 100f; // Speed at which the objects rotate
    public GameObject[] objectsToRotate; // References to the objects you want to rotate
    private bool isInput = false; // Flag to track whether there is input

    // Start is called before the first frame update
    void Start()
    {
        // Set the objects' initial rotations to face upwards
        foreach (GameObject obj in objectsToRotate)
        {
            obj.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Get input from the player
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Check if there is input
        if (horizontalInput != 0 || verticalInput != 0)
        {
            isInput = true;

            // Calculate rotation angle based on input
            float rotationAngle = Mathf.Atan2(verticalInput, horizontalInput) * Mathf.Rad2Deg - 90f;

            // Rotate the objects
            foreach (GameObject obj in objectsToRotate)
            {
                obj.transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotationAngle));
            }
        }
        else if (isInput)
        {
            // If there was input before but no longer, face upwards
            foreach (GameObject obj in objectsToRotate)
            {
                obj.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            }
            isInput = false;
        }
    }
}