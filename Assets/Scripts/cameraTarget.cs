using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraTarget : MonoBehaviour
{

    public Transform target;
    public Vector3 offset = new Vector3(0, 20, -10);

    void LateUpdate()
    {

        if (target != null)
        {
            //Gets the final position for camera.
            Vector3 targetPosition = new Vector3(target.position.x + offset.x, offset.y, target.position.z + offset.z);
            transform.position = targetPosition;

            transform.rotation = Quaternion.Euler(90f, 0f, 0f);

        } 
    }
}
