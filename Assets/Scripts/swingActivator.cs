using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swingActivator : MonoBehaviour
{
    public Animator animator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("enemy"))
        {
            animator.SetTrigger("isSwinging");
        }
    }
}
