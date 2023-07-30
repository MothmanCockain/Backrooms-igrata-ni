using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image image;
    [HideInInspector]
    public Transform parentAfterDrag;

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Inventory.GetComponent<ItemHandler>();

        Transform Inventory = FindChildWithinCurrentRoot("Inventory");
        Debug.Log("Begin drag");
        parentAfterDrag = transform.parent;
        transform.SetParent(Inventory.transform);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Dragging");
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End drag");
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
    }

    private Transform FindChildWithinCurrentRoot(string nameToFind)
    {
        Transform rootParent = transform.root;

        // Loop through all the direct children of the root parent.
        for (int i = 0; i < rootParent.childCount; i++)
        {
            Transform child = rootParent.GetChild(i);

            // Check if the child's name matches the name we are searching for.
            if (child.name == nameToFind)
            {
                // Return the Transform of the matching GameObject.
                return child;
            }
        }

        // Return null if the GameObject is not found within the current root.
        return null;
    }
}

