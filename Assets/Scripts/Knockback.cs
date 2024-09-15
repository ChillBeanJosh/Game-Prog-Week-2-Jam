 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float knockback;
    public float upwardForce;
    public float timeTillDestroy;

    public float ragdollDelay;

    public LayerMask enemyLayer;

    //Active when detection the enemy layer.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("enemy"))
        {
            Rigidbody enemyRb = other.gameObject.GetComponent<Rigidbody>();

            enemyRagdoll ragdoll = other.gameObject.GetComponent<enemyRagdoll>();

            //Knockback effect.
            if (enemyRb != null)
            {
                Vector3 knockbackDirection = other.transform.position - transform.position;
                knockbackDirection.y = 0;

                Vector3 force = knockbackDirection.normalized * knockback + Vector3.up * upwardForce;
                enemyRb.isKinematic = false;
                enemyRb.AddForce(force, ForceMode.Impulse);

                StartCoroutine(RagdollDelay(ragdoll, ragdollDelay));

                //Destroys the enemy after specified time frame.
                Destroy(other.gameObject, timeTillDestroy);
            }
        } 
    }

    private IEnumerator RagdollDelay(enemyRagdoll ragdoll, float delay)
    {
        yield return new WaitForSeconds(delay);
        ragdoll.KnockbackActive();
    }
}
