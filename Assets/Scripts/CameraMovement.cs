using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    Camera camera;

    [Range(0f, 1000f)] [SerializeField] float movementSpeed=200f;
    [Range(0f, 5f)][SerializeField] float sensitivity = 2f;
    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        float xAxisValue = Input.GetAxis("Horizontal");
        float zAxisValue = Input.GetAxis("Vertical");
        MoveCamera(xAxisValue, zAxisValue);
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        if(Input.GetMouseButton(1))
        {
            RotateCamera(mouseX, mouseY);
        }

    }

    void MoveCamera(float xAxisValue, float zAxisValue)
    {
        if (camera != null)
        {
            camera.transform.Translate(new Vector3(xAxisValue, 0.0f, zAxisValue) * movementSpeed * Time.deltaTime);
        }
    }
    void RotateCamera(float mouseX, float mouseY)
    {        
        Vector3 currentRotation = camera.transform.eulerAngles;        
        currentRotation.y += mouseX * sensitivity;
        currentRotation.x -= mouseY * sensitivity;
        
        currentRotation.x = Mathf.Clamp(currentRotation.x, -45f, 45f);
        
        camera.transform.eulerAngles = currentRotation;
    }
}
