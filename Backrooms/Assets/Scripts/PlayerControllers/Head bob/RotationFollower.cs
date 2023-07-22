using System.Collections;
using System.Collections.Generic;

using Unity.Netcode;

using UnityEngine;

public class RotationFollower : NetworkBehaviour
{
    public Transform Target;
    void Update()
    {
        transform.rotation = Target.rotation;
    }
}
