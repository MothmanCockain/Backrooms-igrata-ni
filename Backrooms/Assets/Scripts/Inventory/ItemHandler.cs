using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

using UnityEngine.UI;

public class ItemHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image image;
    public GameObject Inventory;
    [HideInInspector]
    public Transform parentAfterDrag;

    public void OnBeginDrag(PointerEventData eventData)
    {
        Inventory.GetComponent<ItemHandler>();


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
}

