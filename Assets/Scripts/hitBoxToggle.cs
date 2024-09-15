using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitBoxToggle : MonoBehaviour
{
    public GameObject Target;
    private MeshRenderer meshTarget;

    private bool hitBoxShown;



    private void Start()
    {
        if (Target != null)
        {
            meshTarget = Target.GetComponent<MeshRenderer>();

            //Makes sure the hitbox starts off.
            if (meshTarget != null)
            {
                hitBoxShown = false;
                meshTarget.enabled = hitBoxShown;
            }
        }
    }


    public void hitBox()
    {
        if(meshTarget != null)
        {
            //Toggles between true and false.
            hitBoxShown = !hitBoxShown;
            meshTarget.enabled = hitBoxShown;
        }
    }
}
