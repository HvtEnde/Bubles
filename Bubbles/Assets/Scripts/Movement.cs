using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Vector3 direction;
    float rotationX;

    public WaitForIntro waitForintroScript;

    public float sensitivity = 1f;
    public float speed;

    public void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void Update()
    {
        if (waitForintroScript.canPlay)
        {
            PlayerMovement();
            PlayerCamera();
        }
    }
    public void PlayerMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        direction.x = horizontal * speed * Time.deltaTime;
        direction.z = vertical * speed * Time.deltaTime;

        transform.Translate(direction);
    }
    public void PlayerCamera()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * 2;

        transform.Rotate(Vector3.up * mouseX);

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);
    }
    public void LateUpdate()
    {
        if (waitForintroScript.canPlay)
        {
            Camera.main.transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
        }
    }
}
