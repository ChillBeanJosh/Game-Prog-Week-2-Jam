using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraTarget : MonoBehaviour
{

    public Transform target;
    public Vector3 offset = new Vector3(0, 0, 0);

    void LateUpdate()
    {

        if (target != null)
        {
            //Gets the final position for camera.
            Vector3 targetPosition = target.position + offset;

        } 
    }
}
