using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyRagdoll : MonoBehaviour
{
    public Animator enemyAnimator;
    public CapsuleCollider enemyBoxCollider;
    public Rigidbody enemyRigidbody;


    private Rigidbody[] ragdollRigidbody;
    private Collider[] ragdollCollider;

    private void Start()
    {
        ragdollRigidbody = GetComponentsInChildren<Rigidbody>();
        ragdollCollider = GetComponentsInChildren<Collider>();

        DisabledRagdoll();
    }

    public void KnockbackActive()
    {
        enemyAnimator.enabled = false;
        enemyBoxCollider.enabled = false;
        enemyRigidbody.isKinematic = true;

        ActivatedRagdoll();
    }



    private void ActivatedRagdoll()
    {

        foreach (Rigidbody rb in ragdollRigidbody)
        {
            rb.isKinematic = false;
        }

        foreach (Collider col in ragdollCollider)
        {
            if (col != enemyBoxCollider)
            {
                col.enabled = true;
            }
        }
    }



    private void DisabledRagdoll()
    {
        foreach (Rigidbody rb in ragdollRigidbody)
        {
            rb.isKinematic = true;
        }

        foreach (Collider col in ragdollCollider)
        {
            if (col != enemyBoxCollider)
            {
                col.enabled = false;
            }
        }
    }

   

   
}
