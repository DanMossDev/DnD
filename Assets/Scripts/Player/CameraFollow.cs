using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Tooltip("The speed at which the camera will move when not following the player")]
    [SerializeField] float cameraSpeed = 5;
    [Tooltip("The player character")]
    [SerializeField] GameObject player;
    bool isLocked = true;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
    void FixedUpdate()
    {

        if (Input.mousePosition.x > Screen.width - 10 || Input.mousePosition.x < 10 || Input.mousePosition.y > Screen.height - 10 || Input.mousePosition.y < 10)
        {
            isLocked = false;
            Vector3 mousePos = Utils.CalculateMousePosition();
            if (mousePos.x != Mathf.NegativeInfinity) transform.position = Vector3.MoveTowards(transform.position, mousePos, cameraSpeed * Time.deltaTime);
        }
        if (isLocked) 
        {
            transform.position = player.transform.position;
            return;
        }
    }

    public void OnLockCamera()
    {
        isLocked = true;
    }
}
