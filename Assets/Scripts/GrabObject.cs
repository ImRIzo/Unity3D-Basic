using UnityEngine;

public class GrabObject : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;

    void OnMouseDown()
    {
        // Calculate the offset between the object's position and the mouse position
        offset = gameObject.transform.position - GetMouseWorldPos();

        // Set the dragging flag to true
        isDragging = true;
    }

    void OnMouseUp()
    {
        // Set the dragging flag to false
        isDragging = false;
    }

    void Update()
    {
        // Check if the object is being dragged
        if (isDragging)
        {
            // Move the object to the mouse position with the offset
            transform.position = GetMouseWorldPos() + offset;
        }
    }

    Vector3 GetMouseWorldPos()
    {
        // Get the mouse position in screen space
        Vector3 mousePos = Input.mousePosition;

        // Set the distance to the camera, adjust as needed
        mousePos.z = 50f;

        // Convert the mouse position to world space
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
}
