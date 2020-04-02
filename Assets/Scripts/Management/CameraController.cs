using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Handles the camera movement

    public static CameraController cameraController;

    public float cameraSpeed; // How fast the camera moves
    public int cameraZoom = 10; // The zoom of the camera
    
    public Transform targetPosition; // The position where the camera is
    // Start is called before the first frame update

    private void Awake()
    {
        cameraController = this;
    }

    void Start()
    {
        // Camera.main.orthographicSize = 5;
    }

    // Update is called once per frame
    void Update()
    {
        var scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll < 0f)
        {
            Camera.main.orthographicSize = Camera.main.orthographicSize + 15 * Time.deltaTime;
            if (Camera.main.orthographicSize > 6)
            {
                Camera.main.orthographicSize = 6; // Max size
            }
        }
        if (scroll > 0f)
        {
            Camera.main.orthographicSize = Camera.main.orthographicSize - 15 * Time.deltaTime;
            if (Camera.main.orthographicSize < 4)
            {
                Camera.main.orthographicSize = 4; // Min size 
            }
        }

        if (targetPosition != null) // if target is not empty then move the camera otherwise don't move it
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(targetPosition.position.x, targetPosition.position.y, transform.position.z), cameraSpeed * Time.deltaTime);
        }
        
    }

    public void changeCameraToRoom(Transform roomPosition) // Moves camera to the new position
    {
        targetPosition = roomPosition;
    }
}
