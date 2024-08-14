using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraMove : MonoBehaviour
{
    public Transform Target;
    public Vector3 offset;
    private void Update()
    {
        transform.position = Target.position + offset; 
    }
}
