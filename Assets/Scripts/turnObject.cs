using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnObject : MonoBehaviour
{
    public Camera mainCamera;
    public float rotateSpeed;


    private void Update()
    {
        RotateObject();
    }


    void RotateObject()
    {
        //Creates a ray cast from the camera, pointing to the mouse position.
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        //Setting the ground to the attached objects y position, making sure only x and y are being changed.
        Plane groundPlane = new Plane(Vector3.up, new Vector3(0, transform.position.y, 0));


        float rayDistance;

        if (groundPlane.Raycast(ray, out rayDistance))
        {
            //Raycast target hit.
            Vector3 targetPoint = ray.GetPoint(rayDistance);

            //Calculates distance between target hit and attached object.
            Vector3 direction = targetPoint - transform.position;

            //Locks the y-axis so that the object does not tilt.
            direction.y = 0;

            //If the distance between the two above is not (0, 0, 0)
            if (direction != Vector3.zero)
            {
                //Rotates the object.
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotateSpeed);

            }

        }
    }
}
