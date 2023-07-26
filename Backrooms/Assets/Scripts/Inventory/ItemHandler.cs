using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHandler : MonoBehaviour
{
    private bool isFollowingMouse = false;
    private Vector3 offset;

    void Update()
    {
        // Check if the mouse is being clicked
        if (Input.GetMouseButtonDown(0))
        {
            // Cast a ray from the camera to the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the ray hits the current game object
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
            {
                // Enable following the mouse
                isFollowingMouse = true;
                // Calculate the offset between the object's position and the mouse position
                offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
            }
        }

        // Check if the mouse button is released
        if (Input.GetMouseButtonUp(0))
        {
            isFollowingMouse = false;
        }

        // If the object is following the mouse, update its position
        if (isFollowingMouse)
        {
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0)) + offset;
            transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
        }
    }
}
