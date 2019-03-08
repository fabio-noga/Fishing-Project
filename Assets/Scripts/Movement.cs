using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    private void FixedUpdate()
    {
        offset.y = -0.55f;
        Vector3 desiredPosition = target.position + offset;
        transform.position = desiredPosition;
    }
}
