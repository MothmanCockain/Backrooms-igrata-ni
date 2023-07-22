using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PositionFollower : NetworkBehaviour
{
    public Transform targetTransform;
    public Vector3 Offset;
    // Update is called once per frame
    void Update()
    {
        transform.position = targetTransform.position + Offset;
    }
}
